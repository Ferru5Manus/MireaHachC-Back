using MireaHackBack.Repository;
using Microsoft.EntityFrameworkCore;
using MireaHackBack.Database;
using MireaHackBack.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using MireaHackBack.Services.RunCodeService.CSharp;
using MireaHackBack.Services.RunCodeService;
;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
// configureLogging();
builder.Host.UseSerilog();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = "redis";
    options.InstanceName = "CodeRunner";
});
// Database context
builder.Services.AddDbContext<ApplicationContext>(x => {
    var Hostname=Environment.GetEnvironmentVariable("DB_HOSTNAME") ?? "postgres";
    var Port=Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
    var Name=Environment.GetEnvironmentVariable("DB_NAME") ?? "postgres";
    var Username=Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres";
    var Password=Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "postgres";
    x.UseNpgsql($"Server={Hostname}:{Port};Database={Name};Uid={Username};Pwd={Password};");
});

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IRegistrationCodeRepository, RegistrationCodeRepository>();
builder.Services.AddScoped<IResetCodeRepository, ResetCodeRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();

//builder.Services.AddScoped<IRunProjectService, RunProjectService>();

// Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {

        string issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "MireaHackBack";
        string audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "MireaHackBack";
        string secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "TopSecretKeyForTheProtectionOfChocolateCookiesAndOtherSweetThings";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Компилятор кода",
        Description = "Сервис компиляции кода от команды «Эспада» для студенческого хакатона «Системное программирование», организованный Институтом перспективных технологий и индустриального программирования и «Группой Астра»",
    });

    // Add JWT Bearer authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        BearerFormat = "JWT",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    var xmlFile = Path.Combine(AppContext.BaseDirectory, "TestAPI.xml");
    if (File.Exists(xmlFile))
    {
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }
 });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

// void configureLogging(){
//     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
//     var configuration = new ConfigurationBuilder()
//     .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
//     .AddJsonFile($"appsettings.{environment}.json", optional:true).Build();
//     Log.Logger = new LoggerConfiguration()
//             .Enrich.FromLogContext()
//             .Enrich.WithExceptionDetails()
//             .WriteTo.Debug()
//             .WriteTo.Console()
//             .WriteTo.Elasticsearch(ConfigureElasticSink(configuration,environment))
//             .Enrich.WithProperty("Environment",environment)
//             .ReadFrom.Configuration(configuration)
//             .CreateLogger();
// }
// ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration,string environment){
//     return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
//     {
//         AutoRegisterTemplate = true,
//         IndexFormat =  $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".","-")}-{environment.ToLower()}-{DateTime.UtcNow:yyyy-MM-DD}",
//         NumberOfReplicas =1,
//         NumberOfShards = 1
//     };
// }


