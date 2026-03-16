
using Microsoft.Extensions;

using MongoDB.Driver;
using Monoexample.Middleware;
using Monoexample.Repository;
using Serilog;
using Serilog.Events;


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .WriteTo.Console() // To console the logger info
    //.WriteTo.File("Files/LoggFile.txt", rollingInterval:RollingInterval.Day) //To write the logger info into the local file

    .MinimumLevel.Information()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Host.UseSerilog((Serilog.ILogger?)logger);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options=>
{
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    // Optional: Ensure Swagger 2.0 compatibility
   



IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json").Build();

var client = new MongoClient(config.GetConnectionString("DefaultStrings"));
builder.Services.AddSingleton<IMongoClient>(client);
builder.Services.AddScoped<IUserRepo, UserRepo>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");


app.Run();
