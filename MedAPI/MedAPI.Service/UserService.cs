using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using static MedAPI.Infrastructure.Common;
using Medicine = MedAPI.Infrastructure.Common.Medicine;

namespace MedAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IDistrictRepository districtRepository;
        private readonly IProvinceRepository provinceRepository;
        private readonly IBloodTypeService bloodTypeService;

        public UserService(IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            ICountryRepository countryRepository,
             IDistrictRepository districtRepository,
             IProvinceRepository provinceRepository,
             IBloodTypeService bloodTypeService
            )
        {
            this.userRepository = userRepository;
            this.departmentRepository = departmentRepository;
            this.countryRepository = countryRepository;
            this.districtRepository = districtRepository;
            this.provinceRepository = provinceRepository;
            this.bloodTypeService = bloodTypeService;
        }


        public User Authenticate(string email, string password)
        {
            var a = HashPasswordHelper.HashPassword(password);

            User mUser = new User();
            mUser = userRepository.Authenticate(email);
            if (mUser != null && HashPasswordHelper.ValidatePassword(password, mUser.passwordHash))
            {
                return mUser;
            }
            else
            {
                return null;
            }
        }
        public User Credentials(string email)
        {
            return userRepository.Authenticate(email);

        }

        public bool DeleteUserById(long id)
        {
            return userRepository.DeleteUserById(id);
        }

        public List<User> GetAllUser()
        {
            return userRepository.GetAllUser();
        }

        public User GetUserById(long id)
        {
            return userRepository.GetUserById(id);
        }

        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }
        public User SaveUser(User mUser)
        {
            if (mUser.id == 0)
            {
                mUser.passwordHash = Infrastructure.HashPasswordHelper.HashPassword(mUser.passwordHash);
            }
            return userRepository.SaveUser(mUser);
        }

        public UserResources GetResources()
        {
            UserResources mUserResourcesList = new UserResources();

            mUserResourcesList.maritalStatuses = Enum.GetValues(typeof(MaritalStatus))
                            .Cast<MaritalStatus>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mUserResourcesList.bloodTypes = bloodTypeService.GetAllBloodType()
                            .Cast<string>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mUserResourcesList.documentTypes = Enum.GetValues(typeof(DocumentType))
                       .Cast<DocumentType>()
                       .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                       .ToList();


            mUserResourcesList.educationalAttainments = Enum.GetValues(typeof(EducationalAttainment))
                       .Cast<EducationalAttainment>()
                       .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                       .ToList();

            mUserResourcesList.homeMaterials = Enum.GetValues(typeof(HomeMaterial))
                       .Cast<HomeMaterial>()
                       .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                       .ToList();

            mUserResourcesList.homeOwnerships = Enum.GetValues(typeof(HomeOwnership))
                       .Cast<HomeOwnership>()
                       .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                       .ToList();

            mUserResourcesList.homeTypes = Enum.GetValues(typeof(HomeType))
                       .Cast<HomeType>()
                       .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                       .ToList();

            mUserResourcesList.physicalActivities = Enum.GetValues(typeof(PhysicalActivity))
                     .Cast<PhysicalActivity>()
                     .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                     .ToList();

            mUserResourcesList.sexes = Enum.GetValues(typeof(Sex))
                     .Cast<Sex>()
                     .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                     .ToList();

            mUserResourcesList.departments = departmentRepository.GetAllDepartment().Select(x => new Domain.ObjectNode()
            {
                id = x.id.ToString().ToUpper(),
                name = x.name
            }).ToList();

            mUserResourcesList.countries = countryRepository.GetAllCountry().Select(x => new Domain.ObjectNode()
            {
                id = x.id.ToString().ToUpper(),
                name = x.name
            }).ToList();

            mUserResourcesList.medicines = Enum.GetValues(typeof(Medicine))
                     .Cast<Medicine>()
                     .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString().Replace('_', ' ')) })
                     .ToList();

            mUserResourcesList.backgrounds = Enum.GetValues(typeof(Background))
                     .Cast<Background>()
                     .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString().Replace('_',' ')) })
                     .ToList();

            mUserResourcesList.allergies = Enum.GetValues(typeof(Allergy))
                     .Cast<Allergy>()
                     .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                     .ToList();

            mUserResourcesList.alcoholConsumptions = Enum.GetValues(typeof(Alcohol))
                    .Cast<Alcohol>()
                    .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                    .ToList();

            mUserResourcesList.fvConsumptions = Enum.GetValues(typeof(FruitsVegetables))
                  .Cast<FruitsVegetables>()
                  .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                  .ToList();

            mUserResourcesList.races = Enum.GetValues(typeof(Race))
                .Cast<FruitsVegetables>()
                .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                .ToList();

            mUserResourcesList.provinces = provinceRepository.GetAllProvince().Select(x => new Domain.ObjectNode()
            {
                id = x.id.ToString().ToUpper(),
                name = x.name
            }).ToList();

            mUserResourcesList.districts = districtRepository.GetAllDistrict().Select(x => new Domain.ObjectNode()
            {
                id = x.id.ToString().ToUpper(),
                name = x.name
            }).ToList();
            return mUserResourcesList;
        }

    }
}
