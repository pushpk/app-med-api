using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using MedAPI.Repository;
using MedAPI.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MedAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //Service
            container.RegisterType<IDiagnosisService, DiagnosisService>();
            container.RegisterType<IExamService, ExamService>();
            container.RegisterType<IMedicineService, MedicineService>();
            container.RegisterType<ICardiovascularNoteService, CardiovascularNoteService>();
            container.RegisterType<INoteService, NoteService>();
            container.RegisterType<ISpecialtyService, SpecialtyService>();

            container.RegisterType<IBloodTypeService, BloodTypeService>();
            container.RegisterType<IDocumentTypeService, DocumentTypeService>();
            container.RegisterType<IEducationService, EducationService>();
            container.RegisterType<IHomeMaterialService, HomeMaterialService>();
            container.RegisterType<IHomeOwnershipService, HomeOwnershipService>();
            container.RegisterType<IHomeTypeService, HomeTypeService>();
            container.RegisterType<IMedicineService, MedicineService>();
            container.RegisterType<IMaritalStatusService, MaritalStatusService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ITicketService, TicketService>();
            container.RegisterType<ITriageService, TriageService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<INurseService, NurseService>();
            container.RegisterType<IEstablishmentService, EstablishmentService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IMedicService, MedicService>();
            container.RegisterType<IPatientService, PatientService>();

            container.RegisterType<IApplicationService, ApplicationService>();
            container.RegisterType<IEmailService, EmailService>();
            //Repository
            container.RegisterType<IDiagnosisRepository, DiagnosisRepository>();
            container.RegisterType<IExamRepository, ExamRepository>();
            container.RegisterType<IMedicineRepository, MedicineRepository>();
            container.RegisterType<ICardiovascularNoteRepository, CardiovascularNoteRepository>();
            container.RegisterType<INoteRepository, NoteRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITicketRepository, TicketRepository>();
            container.RegisterType<ITriageRepository, TriageRepository>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<IEstablishmentRepository, EstablishmentRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IMedicRepository, MedicRepository>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IApplicationRepository, ApplicationRepository>();
            container.RegisterType<INurseRepository, NurseRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}