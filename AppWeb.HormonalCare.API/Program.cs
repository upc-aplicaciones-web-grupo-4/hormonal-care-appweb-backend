using AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.CommandServices;
using AppWeb.HormonalCare.API.MedicalRecord.Application.Internal.QueryServices;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Repositories;
using AppWeb.HormonalCare.API.MedicalRecord.Domain.Services;
using AppWeb.HormonalCare.API.MedicalRecord.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Profiles.Application.Internal.CommandServices;
using AppWeb.HormonalCare.API.Profiles.Application.Internal.QueryServices;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Repositories;
using AppWeb.HormonalCare.API.Profiles.Domain.Model.Services;
using AppWeb.HormonalCare.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Publishing.Application.Internal.CommandServices;
using AppWeb.HormonalCare.API.Publishing.Application.Internal.QueryServices;
using AppWeb.HormonalCare.API.Publishing.Domain.Repositories;
using AppWeb.HormonalCare.API.Publishing.Domain.Services;
using AppWeb.HormonalCare.API.Publishing.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Shared.Domain.Repositories;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using AppWeb.HormonalCare.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ACME.LearningCenterPlatform.API",
                Version = "v1",
                Description = "ACME Learning Center Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialCommandService, TutorialCommandService>();
builder.Services.AddScoped<ITutorialQueryService, TutorialQueryService>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();


// TypeExam Bounded Context Injection Configuration
builder.Services.AddScoped<ITypeExamRepository, TypeExamRepository>();
builder.Services.AddScoped<ITypeExamCommandService, TypeExamCommandService>();
builder.Services.AddScoped<ITypeExamQueryService, TypeExamQueryService>();

// MedicalExam Bounded Context Injection Configuration
builder.Services.AddScoped<IMedicalExamRepository, MedicalExamRepository>();
builder.Services.AddScoped<IMedicalExamCommandService, MedicalExamCommandService>();
builder.Services.AddScoped<IMedicalExamQueryService, MedicalExamQueryService>();

// Patient Bounded Context Injection Configuration
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientCommandService, PatientCommandService>();
builder.Services.AddScoped<IPatientQueryService, PatientQueryService>();



// ReasonOfConsultation Bounded Context Injection Configuration
builder.Services.AddScoped<IReasonOfConsultationRepository, ReasonOfConsultationRepository>();
builder.Services.AddScoped<IReasonOfConsultationCommandService, ReasonOfConsultationCommandService>();
builder.Services.AddScoped<IReasonOfConsultationQueryService, ReasonOfConsultationQueryService>();

// Treatment Bounded Context Injection Configuration
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<ITreatmentCommandService, TreatmentCommandService>();
builder.Services.AddScoped<ITreatmentQueryService, TreatmentQueryService>();


// Doctor Bounded Context Injection Configuration
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorCommandService, DoctorCommandService>();
builder.Services.AddScoped<IDoctorQueryService, DoctorQueryService>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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