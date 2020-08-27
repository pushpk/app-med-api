using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        public User Authenticate(string email)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.users.Where(x => x.email == email && x.deleted == false)
                      .Select(x => new Domain.User
                      {
                          id = x.id,
                          address = x.address,
                          birthday = x.birthday,
                          cellphone = x.cellphone,
                          countryId = x.country_id,
                          createdBy = x.createdBy,
                          createdDate = x.createdDate,
                          districtId = x.district_id,
                          documentNumber = x.documentNumber,
                          documentType = x.documentType,
                          email = x.email,
                          firstName = x.firstName,
                          lastNameFather = x.lastNameFather,
                          lastNameMother = x.lastNameFather,
                          maritalStatus = x.maritalStatus,
                          modifiedBy = x.modifiedBy,
                          modifiedDate = x.modifiedDate,
                          organDonor = x.organDonor,
                          phone = x.phone,
                          roleId = x.role_id,
                          since = x.since,
                          passwordHash = x.password_hash,
                          role = new Role
                          {
                              id = x.role.id,
                              name = x.role.name,
                              description = x.role.description
                          },
                          sex = x.sex
                      }).FirstOrDefault();
            }
        }

        public bool DeleteUserById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efuser = context.users.Where(m => m.id == id).FirstOrDefault();
                if (efuser != null)
                {
                    efuser.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<User> GetAllUser()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from us in context.users
                        select new User()
                        {
                            id = us.id,
                            address = us.address,
                            birthday = us.birthday,
                            cellphone = us.cellphone,
                            createdBy = us.createdBy,
                            createdDate = us.createdDate,
                            deletable = us.deletable,
                            deleted = us.deleted,
                            documentNumber = us.documentNumber,
                            documentType = us.documentType,
                            email = us.email,
                            firstName = us.firstName,
                            lastNameFather = us.lastNameFather,
                            lastNameMother = us.lastNameMother,
                            maritalStatus = us.maritalStatus,
                            modifiedBy = us.modifiedBy,
                            modifiedDate = us.modifiedDate,
                            organDonor = us.organDonor,
                            passwordHash = us.password_hash,
                            phone = us.phone,
                            sex = us.sex,
                            since = us.since,
                            countryId = us.country_id,
                            districtId = us.district_id,
                            roleId = us.role_id
                        }).ToList();
            }
        }

        public User GetUserById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.users.Where(x => x.id == id)
                   .Select(x => new User()
                   {
                       id = x.id,
                       address = x.address,
                       birthday = x.birthday,
                       cellphone = x.cellphone,
                       createdBy = x.createdBy,
                       createdDate = x.createdDate,
                       deletable = x.deletable,
                       deleted = x.deleted,
                       documentNumber = x.documentNumber,
                       documentType = x.documentType,
                       email = x.email,
                       firstName = x.firstName,
                       lastNameFather = x.lastNameFather,
                       lastNameMother = x.lastNameMother,
                       maritalStatus = x.maritalStatus,
                       modifiedBy = x.modifiedBy,
                       modifiedDate = x.modifiedDate,
                       organDonor = x.organDonor,
                       passwordHash = x.password_hash,
                       phone = x.phone,
                       sex = x.sex,
                       since = x.since,
                       countryId = x.country_id,
                       districtId = x.district_id,
                       roleId = x.role_id,
                   }).FirstOrDefault();
            }
        }

        public User GetByEmail(string email)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.users.Where(x => x.email == email && x.deleted == false)
                   .Select(x => new User()
                   {
                       id = x.id,
                       address = x.address,
                       birthday = x.birthday,
                       cellphone = x.cellphone,
                       createdBy = x.createdBy,
                       createdDate = x.createdDate,
                       deletable = x.deletable,
                       deleted = x.deleted,
                       documentNumber = x.documentNumber,
                       documentType = x.documentType,
                       email = x.email,
                       firstName = x.firstName,
                       lastNameFather = x.lastNameFather,
                       lastNameMother = x.lastNameMother,
                       maritalStatus = x.maritalStatus,
                       modifiedBy = x.modifiedBy,
                       modifiedDate = x.modifiedDate,
                       organDonor = x.organDonor,
                       passwordHash = x.password_hash,
                       phone = x.phone,
                       sex = x.sex,
                       since = x.since,
                       countryId = x.country_id,
                       districtId = x.district_id,
                       roleId = x.role_id,
                       role = new Domain.Role
                       {
                           id = x.role.id,
                           name = x.role.name
                       }
                   }).FirstOrDefault();
            }
        }

        public User SaveUser(User mUser)
        {

    //        firstName = '';
    //        lastName = ''
    //        email = '';
    //        password = '';
    //        confirmPassword = '';
    //        documentNumber = '';
    //        phone = '';
    //    country: String = null;
    //    department: String = null;
    //    province: String = null;
    //    district: String = null;
    //    speciality: string  = '';
    //    CMP: string = '';
    //    RNE: string = '';

            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efUser = context.users.Where(m => m.id == mUser.id).FirstOrDefault();
                if (efUser == null)
                {
                    efUser = new DataAccess.user();
                    efUser.deleted = false;// BitConverter.GetBytes(false);
                    efUser.deletable = false;// BitConverter.GetBytes(false);
                    efUser.organDonor = false;// BitConverter.GetBytes(false);
                    efUser.createdBy = mUser.createdBy;
                    efUser.createdDate = DateTime.UtcNow;
                    efUser.since = DateTime.UtcNow.Date;
                    efUser.password_hash = mUser.passwordHash;
                    context.users.Add(efUser);
                }
                else
                {
                    efUser.modifiedDate = DateTime.UtcNow;
                    efUser.modifiedBy = mUser.createdBy;
                }

                //Following properties does not apply to medic, hence setting as empty to avoid validation error
                if(mUser.roleId == 2)
                {
                    mUser.lastNameFather = string.Empty;
                    mUser.address = string.Empty;
                    mUser.lastNameMother = string.Empty;
                    mUser.sex = string.Empty;
                    mUser.documentType = string.Empty;
                }
                efUser.firstName = mUser.firstName;
                efUser.lastNameFather = mUser.lastNameFather;
                efUser.lastNameMother = mUser.lastNameMother;
                efUser.phone = mUser.phone;
                efUser.address = mUser.address;
                efUser.country_id = mUser.countryId;
                efUser.documentType = mUser.documentType;
                efUser.documentNumber = mUser.documentNumber;
                efUser.birthday = mUser.birthday;
                efUser.role_id = mUser.roleId;
                efUser.email = mUser.email;
                efUser.maritalStatus = mUser.maritalStatus;
                efUser.cellphone = mUser.cellphone;
                efUser.sex = mUser.sex;
                efUser.district_id = mUser.districtId;
                efUser.department_id = mUser.departmentId;
                efUser.province_id = mUser.provinceId;
                context.SaveChanges();
                mUser.id = efUser.id;
            }
            return mUser;
        }
    }
}
