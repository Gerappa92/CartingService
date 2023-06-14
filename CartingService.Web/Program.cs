using System.Reflection;
using CartingService.BusinessLogic;
using CartingService.DataAccess;
using CartingService.Web.BackgroundServices;
using CartingService.Web.Endpoints.Cart;
using CartingService.Web.Options;
using CartingService.Web.Platform;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(GetXmlCommentsPath());
});

builder.Services.AddBusinessLogic();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection(RabbitMqOptions.Position));
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<RabbitMqFactory>();
builder.Services.AddHostedService<ItemUpdateBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Configuration.GetValue<bool>("Documentation:Swagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.RegisterCartEndpoints();

app.Run();

string GetXmlCommentsPath()
{
    var currentDomainBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    return Path.Combine(currentDomainBaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
}