using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using NewProject.Context;
using NewProject.ExceptionHandler;
using NewProject.Profiles;
using NewProject.Service.UserService;
using Serilog;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration) // optional, read from appsettings.json
    .CreateLogger();
var logger = new LoggerConfiguration()
    .WriteTo.Console() // To console the logger info
                       //.WriteTo.File("Files/LoggFile.txt", rollingInterval:RollingInterval.Day) //To write the logger info into the local file

    .MinimumLevel.Information()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Host.UseSerilog((Serilog.ILogger?)logger);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token here"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
  
                  Type = ReferenceType.SecurityScheme,
                    Id ="Bearer"
                }
            },
            Array.Empty<string>()
        }

    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Key"])),
            RoleClaimType = ClaimTypes.Role
        };
    });
builder.Services.AddAuthorization(options=>{
    options.AddPolicy("StudentOnly",
        p => p.RequireRole("Student"));

    options.AddPolicy("InstructorOnly",
        p => p.RequireRole("Instructor"));
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MyConnections"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MyConnections"))
        //,mySqlOptions =>
        //{
        //    mySqlOptions.GuidFormat(MySqlGuidFormat.Char36);
        //}
    ));    
builder.Services.AddScoped<IStuAuth, StuAuth>();
builder.Services.AddScoped<IInstructAuth, InstructAuth>();
builder.Services.AddScoped<IStudentService, StudentService>();      
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IUserService, UserListService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<EceptionHandlermiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
