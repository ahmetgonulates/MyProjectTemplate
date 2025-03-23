using MyProjectTemplate.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApplication();
//test
app.Run();
