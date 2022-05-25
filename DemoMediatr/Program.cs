using DemoMediatr.Decorators;
using DemoMediatr.MediatRefactor.Decorators;
using DemoMediatr.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<IUserService, UserService>();

//builder.Services.AddMediatR(typeof(Program));


//builder.Services.Decorate<IMediator>((mediatRService) => new MediatrDecorator2(new MediatrDecorator1(mediatRService)));


//var decorator = new AuthorizeUserServiceDecorator(new LoggingUserServiceDecorator(new ValidateUserServiceDecorator(new UserService())));
//builder.Services.AddSingleton<IUserService>(decorator);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
