using BLL.Models;
using BLL.Repositories;
using BLL.Services;
using DAL.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SportAPI.Models;
using SportAPI.Tools;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new AuthorizeFilter());
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de l'authentification avec JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


// Configuration de Swagger

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "SportAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

//DAL
builder.Services.AddScoped<ICountryRepositoryDAL, CountryServiceDAL>();
builder.Services.AddScoped<IPersonRepositoryDAL, PersonServiceDAL>();
builder.Services.AddScoped<ITypePersonRepositoryDAL, TypePersonServiceDAL>();
builder.Services.AddScoped<ITypeProgramRepositoryDAL, TypeProgramServiceDAL>();
builder.Services.AddScoped<IProgramRepositoryDAL, ProgramServiceDAL>();
builder.Services.AddScoped<ISortExerciceRepositoryDAL, SortExerciceServiceDAL>();
builder.Services.AddScoped<ITypeExerciceRepositoryDAL, TypeExerciceServiceDAL>();
builder.Services.AddScoped<IExerciceRepositoryDAL, ExerciceServiceDAL>();
builder.Services.AddScoped<IProfilRepositoryDAL, ProfilServiceDAL>();
builder.Services.AddScoped<ITrainingRepositoryDAL, TrainingServiceDAL>();
builder.Services.AddScoped<ITrainingLogRepositoryDAL, TrainingLogServiceDAL>();
builder.Services.AddScoped<IExerciceLogRepositoryDAL, ExerciceLogServiceDAL>();
builder.Services.AddScoped<IPerformanceRepositoryDAL, PerformanceServiceDAL>();
builder.Services.AddScoped<IPersonProgramRepositoryDAL, PersonProgramServiceDAL>();  //Table d'association entre person et program
builder.Services.AddScoped<IProgramTrainingRepositoryDAL, ProgramTrainingServiceDAL>(); //Table d'association entre program et training
builder.Services.AddScoped<ITrainingExerciceRepositoryDAL, TrainingExerciceServiceDAL>(); //Table d'association entre training et exercice


//BLL
builder.Services.AddScoped<IPersonRepositoryBLL<PersonBLL>, PersonServiceBLL>();
builder.Services.AddScoped<IProgramRepositoryBLL<ProgramBLL>, ProgramServiceBLL>();
builder.Services.AddScoped<ITrainingRepositoryBLL<TrainingBLL>, TrainingServiceBLL>();
builder.Services.AddScoped<IProfilRepositoryBLL<ProfilBLL>, ProfilServiceBLL>();
builder.Services.AddScoped<ITrainingLogRepositoryBLL<TrainingLogBLL>, TrainingLogServiceBLL>();
builder.Services.AddScoped<IExerciceLogRepositoryBLL<ExerciceLogBLL>, ExerciceLogServiceBLL>();
builder.Services.AddScoped<IPerformanceRepositoryBLL<PerformanceBLL>, PerformanceServiceBLL>();
builder.Services.AddScoped<IPersonProgramRepositoryBLL, PersonProgramServiceBLL>();
builder.Services.AddScoped<IProgramTrainingRepositoryBLL, ProgramTrainingServiceBLL>();
builder.Services.AddScoped<ITrainingExerciceRepositoryBLL, TrainingExerciceServiceBLL>();
builder.Services.AddScoped<IAuthRepositoryBLL, AuthServiceBLL>(); // JWT

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
