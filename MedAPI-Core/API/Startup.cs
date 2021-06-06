
using Data.DataModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.IRepository;
using Services;
using Services.IServices; using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<registroclinicocoreContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });




            services.AddAutoMapper(typeof(Startup));
                        
            //Repository
            services.AddTransient<IDiagnosisRepository, DiagnosisRepository>();
            services.AddTransient<IExamRepository, ExamRepository>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();
             services.AddTransient<ICardiovascularNoteRepository, CardiovascularNoteRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<ITriageRepository, TriageRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDistrictRepository, DistrictRepository>();
            services.AddTransient<IEstablishmentRepository, EstablishmentRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IMedicRepository, MedicRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<INurseRepository, NurseRepository>();
            services.AddTransient<ISpecialtyRepository, SpecialtyRepository>();
            services.AddTransient<ILabRepository, LabRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();


            services.AddTransient<IDiagnosisService, DiagnosisService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IMedicineService, MedicineService>();
            services.AddTransient<ICardiovascularNoteService, CardiovascularNoteService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ISpecialtyService, SpecialtyService>();
            services.AddTransient<IBloodTypeService, BloodTypeService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IEducationService, EducationService>();
            services.AddTransient<IHomeMaterialService, HomeMaterialService>();
            services.AddTransient<IHomeOwnershipService, HomeOwnershipService>();
            services.AddTransient<IHomeTypeService, HomeTypeService>();
            services.AddTransient<IMedicineService, MedicineService>();
            services.AddTransient<IMaritalStatusService, MaritalStatusService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ITriageService, TriageService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<INurseService, NurseService>();
            services.AddTransient<IEstablishmentService, EstablishmentService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IMedicService, MedicService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ISpecialtyService, SpecialtyService>();
            services.AddTransient<ILabService, LabService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();

            services.AddControllers();



            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            

            app.UseHttpsRedirection();

            app.UseRouting();

           // app.UseAuthentication();
          //  app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
