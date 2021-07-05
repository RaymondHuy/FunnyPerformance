using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyPerformance.StmLargeStringDeserialization
{
    public class StmDbContext : DbContext
    {
        public StmDbContext(DbContextOptions<StmDbContext> options) : base(options)
        { 
        }

        public virtual DbSet<OPS_DITOPackageData> OPS_DITOPackageData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }

    public partial class OPS_DITOPackageData
    {
        public long ID { get; set; }
        public long PackageID { get; set; }
        public string JsonData { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class DIMasterVNPostDataBD8
    {
        public string PostBagCode { get; set; }
        public string PostBagNumber { get; set; }
        public double Weight { get; set; }
        public string MailTripType { get; set; }
        public int Status { get; set; }
        public double PostBagWeightConvert { get; set; }
        public string PostBagTypeCode { get; set; }
        public double CaseWeight { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string OpeningUser { get; set; }
        public string Note { get; set; }
        public string ServiceCode { get; set; }
        public bool F { get; set; }
        public string Year { get; set; }
        public DateTime createdAt { get; set; }
        public bool IsPrinted { get; set; }
        public int Quantity { get; set; }
        public string PackagingUser { get; set; }
        public string PackagingMachine { get; set; }
        public DateTime PackagingTime { get; set; }
        public string MailTripNumber { get; set; }
        public string OpeningMachine { get; set; }
        public string ToPOSCode { get; set; }
        public DateTime updatedAt { get; set; }
        public bool IsDeliveryRoute { get; set; }
        public string FromPOSCode { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public int PostBagIndex { get; set; }
        public double? KhoiLuongThuc { get; set; }
        public double? KhoiLuongQD { get; set; }
        public double? KhoiLuongTinhCuoc { get; set; }
        public decimal? DoanhThuCongBo { get; set; }
        public decimal? DoanhThuTinhCuoc { get; set; }
    }
}
