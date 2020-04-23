using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool DeleteUserById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efuser = context.users.Where(m => m.id == id).FirstOrDefault();
                if (efuser != null)
                {
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<User> GetAllUser()
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from us in context.users
                        select new User()
                        {
                            Id = us.id,
                            Address = us.address,
                            Birthday = us.birthday,
                            Cellphone = us.cellphone,
                            CreatedBy = us.createdBy,
                            CreatedDate = us.createdDate,
                            Deletable = us.deletable,
                            Deleted = us.deleted,
                            DocumentNumber = us.documentNumber,
                            DocumentType = us.documentType,
                            Email = us.email,
                            FirstName = us.firstName,
                            LastNameFather = us.lastNameFather,
                            LastNameMother = us.lastNameMother,
                            MaritalStatus = us.maritalStatus,
                            ModifiedBy = us.modifiedBy,
                            ModifiedDate = us.modifiedDate,
                            OrganDonor = us.organDonor,
                            PasswordHash = us.password_hash,
                            Phone = us.phone,
                            Sex = us.sex,
                            Since = us.since,
                            CountryId = us.country_id,
                            DistrictId = us.district_id,
                            RoleId = us.role_id
                        }).ToList();
            }
        }

        public User GetUserById(long id)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.users.Where(x => x.id == id)
                   .Select(x => new User()
                   {
                       Id = x.id,
                       Address = x.address,
                       Birthday = x.birthday,
                       Cellphone = x.cellphone,
                       CreatedBy = x.createdBy,
                       CreatedDate = x.createdDate,
                       Deletable = x.deletable,
                       Deleted = x.deleted,
                       DocumentNumber = x.documentNumber,
                       DocumentType = x.documentType,
                       Email = x.email,
                       FirstName = x.firstName,
                       LastNameFather = x.lastNameFather,
                       LastNameMother = x.lastNameMother,
                       MaritalStatus = x.maritalStatus,
                       ModifiedBy = x.modifiedBy,
                       ModifiedDate = x.modifiedDate,
                       OrganDonor = x.organDonor,
                       PasswordHash = x.password_hash,
                       Phone = x.phone,
                       Sex = x.sex,
                       Since = x.since,
                       CountryId = x.country_id,
                       DistrictId = x.district_id,
                       RoleId = x.role_id,
                   }).FirstOrDefault();
            }
        }

        public User GetByEmail(string email)
        {
            var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return context.users.Where(x => x.email == email && x.deleted== bytes)
                   .Select(x => new User()
                   {
                       Id = x.id,
                       Address = x.address,
                       Birthday = x.birthday,
                       Cellphone = x.cellphone,
                       CreatedBy = x.createdBy,
                       CreatedDate = x.createdDate,
                       Deletable = x.deletable,
                       Deleted = x.deleted,
                       DocumentNumber = x.documentNumber,
                       DocumentType = x.documentType,
                       Email = x.email,
                       FirstName = x.firstName,
                       LastNameFather = x.lastNameFather,
                       LastNameMother = x.lastNameMother,
                       MaritalStatus = x.maritalStatus,
                       ModifiedBy = x.modifiedBy,
                       ModifiedDate = x.modifiedDate,
                       OrganDonor = x.organDonor,
                       PasswordHash = x.password_hash,
                       Phone = x.phone,
                       Sex = x.sex,
                       Since = x.since,
                       CountryId = x.country_id,
                       DistrictId = x.district_id,
                       RoleId = x.role_id,
                       role=x.role
                   }).FirstOrDefault();
            }
        }

        public User SaveUser(User mUser)
        {
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                var efUser = context.users.Where(m => m.id == mUser.Id).FirstOrDefault();
                if (efUser == null)
                {
                    efUser = new DataAccess.user();
                    efUser.deleted = BitConverter.GetBytes(false);
                    efUser.deletable = BitConverter.GetBytes(false);
                    efUser.createdBy = mUser.CreatedBy;
                    efUser.createdDate = DateTime.UtcNow;
                    efUser.since = DateTime.UtcNow.Date;
                    context.users.Add(efUser);
                }
                efUser.firstName = mUser.FirstName;
                efUser.lastNameFather = mUser.LastNameFather;
                efUser.lastNameMother = mUser.LastNameMother;
                efUser.phone = mUser.Phone;
                efUser.address = mUser.Address;
                efUser.country_id = mUser.CountryId;
                efUser.documentType = mUser.DocumentType;
                efUser.documentNumber = mUser.DocumentNumber;
                efUser.birthday = mUser.Birthday;
                efUser.role_id = mUser.RoleId;
                efUser.email = mUser.Email;
                efUser.maritalStatus = mUser.MaritalStatus;
                efUser.cellphone = mUser.Cellphone;
                efUser.sex = mUser.Sex;
                efUser.district_id = mUser.DistrictId;
                context.SaveChanges();
                mUser.Id = efUser.id;
            }
            return mUser;
        }
    }
}
