 
using Camunda_Client;
using CamundaClient;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json", optional:true , reloadOnChange:true)
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)//To specify environment

    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();


builder.Services.AddOptionsBinders(configuration);

builder.Services.AddCamunda();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");




app.Run();