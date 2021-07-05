using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyPerformance.StmLargeStringDeserialization
{
    [MemoryDiagnoser]
    public class LargeStringPerformanceTest
    {
        public StmDbContext DbContext;
        public List<long> Ids;
        public List<Package> packages;

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddDbContext<StmDbContext>(option =>
            {
                option.UseNpgsql("input tmscustest vnpost connection string");
            });

            var provider = services.BuildServiceProvider();

            DbContext = provider.GetRequiredService<StmDbContext>();

            using (var stream = new StreamReader("ids.txt"))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // read the json from a stream
                    // json size doesn't matter because only a small piece is read at a time from the HTTP request
                    Ids = serializer.Deserialize<List<long>>(reader);
                }
            }

        }

        [Benchmark]
        public void CurrentStmStrategy()
        {
            var data = new List<DIMasterVNPostDataBD8>();

            var packages1 = DbContext.OPS_DITOPackageData.Where(c => Ids.Contains(c.PackageID)).Select(c => new Package
            {
                PackageID = c.PackageID,
                JsonData = c.JsonData
            }).ToList();
            foreach (var item in packages1)
            {
                data.AddRange(JsonConvert.DeserializeObject<List<DIMasterVNPostDataBD8>>(item.JsonData));
            }

            data.Clear();
        }


        [Benchmark]
        public async Task NewStrategy()
        {
            var data = new List<DIMasterVNPostDataBD8>();
            var connection = DbContext.Database.GetDbConnection();

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            using (DbDataReader dbDataReader = await connection.ExecuteReaderAsync($@"SELECT ""PackageID"", ""JsonData"" FROM dbo.""OPS_DITOPackageData"" WHERE ""PackageID"" = ANY(@Ids)", new { Ids }))
            {
                while (dbDataReader.Read())
                {
                    long id = dbDataReader.GetFieldValue<long>(0);
                    using (var stream = dbDataReader.GetStream(1))
                    {
                        using (var streamReader = new StreamReader(stream))
                        {
                            using (JsonReader reader = new JsonTextReader(streamReader))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                data.AddRange(serializer.Deserialize<List<DIMasterVNPostDataBD8>>(reader));
                            }
                        }
                    }
                }
            };
            data.Clear();
        }
    }

    public class Package
    {
        public long PackageID { get; set; }

        public string JsonData { get; set; }
    }
}
