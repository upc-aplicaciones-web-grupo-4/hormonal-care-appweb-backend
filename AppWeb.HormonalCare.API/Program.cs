using AppWeb.HormonalCare.API.IAM.Application.Internal.CommandServices;
using AppWeb.HormonalCare.API.IAM.Application.Internal.OutboundServices;
using AppWeb.HormonalCare.API.IAM.Application.Internal.QueryServices;
using AppWeb.HormonalCare.API.IAM.Domain.Repositories;
using AppWeb.HormonalCare.API.IAM.Domain.Services;
using AppWeb.HormonalCare.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using AppWeb.HormonalCare.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using AppWeb.HormonalCare.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using AppWeb.HormonalCare.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using AppWeb.HormonalCare.API.IAM.Infrastructure.Tokens.JWT.Services;
using AppWeb.HormonalCare.API.IAM.Interfaces.ACL;
using AppWeb.HormonalCare.API.IAM.Interfaces.ACL.Services;
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
using AppWeb.HormonalCare.API.StoryClinic.Domain.Repositories;
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
                Title = "HormonalCare.API",
                Version = "v1",
                Description = "Hormonal Care Platform API",
                TermsOfService = new Uri("https://hormonal-care.com/tos"),
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
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        });
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

// MedicalRecord Bounded Context Injection Configuration
builder.Services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
builder.Services.AddScoped<IMedicalRecordCommandService, MedicalRecordCommandService>();
builder.Services.AddScoped<IMedicalRecordQueryService, MedicalRecordQueryService>();
builder.Services.AddScoped<IDiagnosticRepository, DiagnosticRepository>(); 
builder.Services.AddScoped<iDiagnosticCommandService, DiagnosticCommandService>();
builder.Services.AddScoped<IDiagnosticQueryService, DiagnosticQueryService>();
builder.Services.AddScoped<iExternalReportCommandService, ExternalReportCommandService>();
builder.Services.AddScoped<iExternalReportQueryService, ExternalReportQueryService>();
builder.Services.AddScoped<IExternalReportRepository, ExternalReportRepository>();


// Medication Bounded Context Injection Configuration
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IMedicationCommandService, MedicationCommandService>();
builder.Services.AddScoped<IMedicationQueryService, MedicationQueryService>();

// Prescription Bounded Context Injection Configuration
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionCommandService, PrescriptionCommandService>();
builder.Services.AddScoped<IPrescriptionQueryService, PrescriptionQueryService>();

// MedicationType Bounded Context Injection Configuration
builder.Services.AddScoped<IMedicationTypeRepository, MedicationTypeRepository>();
builder.Services.AddScoped<IMedicationTypeCommandService, MedicationTypeCommandService>();
builder.Services.AddScoped<IMedicationTypeQueryService, MedicationTypeQueryService>();

// Treatment Bounded Context Injection Configuration
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<ITreatmentCommandService, TreatmentCommandService>();
builder.Services.AddScoped<ITreatmentQueryService, TreatmentQueryService>();

// Doctor Bounded Context Injection Configuration
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorCommandService, DoctorCommandService>();
builder.Services.AddScoped<IDoctorQueryService, DoctorQueryService>();

// MedicalAppointment Bounded Context Injection Configuration
builder.Services.AddScoped<IMedicalAppointmentRepository, MedicalAppointmentRepository>();
builder.Services.AddScoped<IMedicalAppointmentCommandService, MedicalAppointmentCommandService>();
builder.Services.AddScoped<IMedicalAppointmentQueryService, MedicalAppointmentQueryService>();


// IAM Bounded Context Injection Configuration

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();




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
// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();