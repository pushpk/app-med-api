using AutoMapper;
using Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Helpers;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
       
        private readonly registroclinicocoreContext context;
        private readonly UserManager<user> _userManager;
        public UserRepository(registroclinicocoreContext context, UserManager<user> userManager)
        { 
            this.context = context;
            _userManager = userManager;

        }

        public User ConfirmEmail(string userId, string token)
        {
            int userIdInt = int.Parse(userId);
            //var bytes = BitConverter.GetBytes(false);
           

                var user = context.users.Where(x => x.Id == userIdInt && x.deleted == false)
                      .Select(x => new User
                      {
                          id = x.Id,
                          address = x.address,
                          birthday = x.birthday,
                          cellphone = x.cellphone,
                          countryId = x.country_id,
                          createdBy = x.createdBy,
                          createdDate = x.createdDate,
                          districtId = x.district_id,
                          documentNumber = x.documentNumber,
                          documentType = x.documentType,
                          email = x.Email,
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
                              id = x.role.Id,
                              name = x.role.Name,
                              description = x.role.Name
                          },
                          sex = x.sex,
                          token = x.token

                      }).FirstOrDefault();

                var tokenDecord = HttpUtility.UrlDecode(token);
                if (user != null && HashPasswordHelperRepo.ValidatePassword(user.token.ToString(), tokenDecord))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.Id == userIdInt && x.deleted == false);
                    userUpdate.EmailConfirmed = true;
                    context.SaveChanges();
                    return user;

                }
                else
                {
                    return null;
               }
            
        }

        public User Authenticate(string email)
        {
           
                return context.users.Where(x => x.Email == email && x.deleted == false)
                      .Select(x => new User
                      {
                          id = x.Id,
                          address = x.address,
                          birthday = x.birthday,
                          cellphone = x.cellphone,
                          countryId = x.country_id,
                          createdBy = x.createdBy,
                          createdDate = x.createdDate,
                          districtId = x.district_id,
                          documentNumber = x.documentNumber,
                          documentType = x.documentType,
                          email = x.Email,
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
                              id = x.role.Id,
                              name = x.role.Name,
                              description = x.role.Name
                          },
                          sex = x.sex,
                          emailConfirmed = x.EmailConfirmed
                      }).FirstOrDefault();
            
        }

        public bool DeleteUserById(long id)
        {
            bool isSuccess = false;
         
                var efuser = context.users.Where(m => m.Id == id).FirstOrDefault();
                if (efuser != null)
                {
                    efuser.deleted = true;// BitConverter.GetBytes(true);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            
        }

        public List<User> GetAllUser()
        {
           
                return (from us in context.users
                        select new User()
                        {
                            id = us.Id,
                            address = us.address,
                            birthday = us.birthday,
                            cellphone = us.cellphone,
                            createdBy = us.createdBy,
                            createdDate = us.createdDate,
                            deletable = us.deletable,
                            deleted = us.deleted,
                            documentNumber = us.documentNumber,
                            documentType = us.documentType,
                            email = us.Email,
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

        public User GetUserById(long id)
        {
          
                return context.users.Where(x => x.Id == id)
                   .Select(x => new User()
                   {
                       id = x.Id,
                       address = x.address,
                       birthday = x.birthday,
                       cellphone = x.cellphone,
                       createdBy = x.createdBy,
                       createdDate = x.createdDate,
                       deletable = x.deletable,
                       deleted = x.deleted,
                       documentNumber = x.documentNumber,
                       documentType = x.documentType,
                       email = x.Email,
                       emailConfirmed = x.EmailConfirmed,
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
                       token = x.token,
                       reset_token = x.reset_token
                   }).FirstOrDefault();
            
        }

        public User GetByEmail(string email)
        {
           
                try
                {
                    return context.users.Where(x => x.Email == email && x.deleted == false)
                  .Select(x => new User()
                  {
                      id = x.Id,
                      address = x.address,
                      birthday = x.birthday,
                      cellphone = x.cellphone,
                      createdBy = x.createdBy,
                      createdDate = x.createdDate,
                      deletable = x.deletable,
                      deleted = x.deleted,
                      documentNumber = x.documentNumber,
                      documentType = x.documentType,
                      email = x.Email,
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
                      reset_token = x.reset_token,
                      token = x.token,
                      role = new Role
                      {
                          id = x.role.Id,
                          name = x.role.Name
                      }
                  }).FirstOrDefault();
                }
                catch (Exception e)
                {

                    throw ;
                }
               

                
            
        }

        public bool IsUserAlreadyExist(User mUser, string cmp = null)
        {
          
                bool emailAlreadyExist =  context.users.Any(m => m.Email == mUser.email);
                if (!emailAlreadyExist)
                {
                    if (mUser.roleId == 4)
                    {
                        return context.users.Any(m => m.documentNumber == mUser.documentNumber);
                    }
                    else if (mUser.roleId == 2)
                    {
                        return context.users.Any(m => m.documentNumber == mUser.documentNumber) || context.medics.Any(m => m.cmp== cmp);
                    }
                }
                return emailAlreadyExist;
                
            
        }
        public User SaveUser(User mUser)
        {

            var efUser = context.users.Where(m => m.Id == mUser.id).FirstOrDefault();
            if (efUser == null)
            {
                efUser = new user();
                efUser.deleted = false;// BitConverter.GetBytes(false);
                efUser.deletable = false;// BitConverter.GetBytes(false);
                efUser.organDonor = false;// BitConverter.GetBytes(false);
                efUser.createdBy = mUser.createdBy;
                efUser.createdDate = DateTime.UtcNow;
                efUser.since = DateTime.UtcNow.Date;
                efUser.password_hash = string.Empty;
                //efUser.token = Guid.NewGuid();
                //efUser.reset_token = Guid.NewGuid();

              
                


            }
            else
            {
                efUser.modifiedDate = DateTime.UtcNow;
                efUser.modifiedBy = mUser.createdBy;
            }

            //Following properties does not apply to medic OR Lab, hence setting as empty to avoid validation error
            if (mUser.roleId == 2 || mUser.roleId == 5)
            {

                if (mUser.roleId == 2) mUser.address = string.Empty;

                mUser.sex = string.Empty;
                mUser.documentType = string.Empty;


            }

            efUser.UserName = mUser.email;
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
            efUser.Email = mUser.email;
            efUser.maritalStatus = mUser.maritalStatus;
            efUser.cellphone = mUser.cellphone;
            efUser.sex = mUser.sex;
            efUser.district_id = mUser.districtId;
            efUser.department_id = mUser.departmentId;
            efUser.province_id = mUser.provinceId;
            try
            {
                var result = _userManager.CreateAsync(efUser, mUser.passwordHash).Result;
                if (result.Succeeded)
                {
                    mUser.id = _userManager.FindByEmailAsync(mUser.email).Result.Id;
                    mUser.token = efUser.token;

                    return mUser;
                }
                else
                {
                    throw new Exception(result.Errors.FirstOrDefault().Description);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            
        }
        

        public List<Medic> GetAllNonApprovedMedics()
        {
            
                // var abc = context.medics.Include("user").Where(s => s.user.role_id == 2 && (!s.IsApproved || s.IsFreezed)).ToList();

                var abc = (from us in context.medics.Include("user").Where(s => s.user.role_id == 2).OrderBy(s => s.IsApproved)
                           select new Medic()
                           {
                               cmp = us.cmp,
                               rne = us.rne,
                               IsApproved = us.IsApproved,
                               IsFreezed = us.IsFreezed,
                               IsDenied = us.IsDenied,
                               user = new User
                               {

                                   id = us.user.Id,
                                   address = us.user.address,
                                   birthday = us.user.birthday,
                                   cellphone = us.user.cellphone,
                                   createdBy = us.user.createdBy,
                                   createdDate = us.user.createdDate,
                                   deletable = us.user.deletable,
                                   deleted = us.user.deleted,
                                   documentNumber = us.user.documentNumber,
                                   documentType = us.user.documentType,
                                   email = us.user.Email,
                                   firstName = us.user.firstName,
                                   lastNameFather = us.user.lastNameFather,
                                   lastNameMother = us.user.lastNameMother,
                                   maritalStatus = us.user.maritalStatus,
                                   modifiedBy = us.user.modifiedBy,
                                   modifiedDate = us.user.modifiedDate,
                                   organDonor = us.user.organDonor,
                                   passwordHash = us.user.password_hash,
                                   phone = us.user.phone,
                                   sex = us.user.sex,
                                   since = us.user.since,
                                   countryId = us.user.country_id,
                                   districtId = us.user.district_id,
                                   roleId = us.user.role_id,

                               }

                           }).ToList();

                return abc;
            
        }

        public List<Lab> GetAllNonApprovedLabs()
        {
          
                // var abc = context.medics.Include("user").Where(s => s.user.role_id == 2 && (!s.IsApproved || s.IsFreezed)).ToList();

                var abc = (from us in context.labs.Include("user").Where(s => s.user.role_id == 5).OrderBy(s => s.IsApproved)
                           select new Lab()
                           {
                              parentCompany = us.parentCompany,
                               labName = us.labName,
                               ruc = us.ruc,
                               IsApproved = us.IsApproved,
                               IsFreezed = us.IsFreezed,
                               IsDenied = us.IsDenied,
                               user = new User
                               {

                                   id = us.user.Id,
                                   address = us.user.address,
                                   birthday = us.user.birthday,
                                   cellphone = us.user.cellphone,
                                   createdBy = us.user.createdBy,
                                   createdDate = us.user.createdDate,
                                   deletable = us.user.deletable,
                                   deleted = us.user.deleted,
                                   documentNumber = us.user.documentNumber,
                                   documentType = us.user.documentType,
                                   email = us.user.Email,
                                   firstName = us.user.firstName,
                                   lastNameFather = us.user.lastNameFather,
                                   lastNameMother = us.user.lastNameMother,
                                   maritalStatus = us.user.maritalStatus,
                                   modifiedBy = us.user.modifiedBy,
                                   modifiedDate = us.user.modifiedDate,
                                   organDonor = us.user.organDonor,
                                   passwordHash = us.user.password_hash,
                                   phone = us.user.phone,
                                   sex = us.user.sex,
                                   since = us.user.since,
                                   countryId = us.user.country_id,
                                   districtId = us.user.district_id,
                                   roleId = us.user.role_id,

                               }

                           }).ToList();

                return abc;
            
        }

        public bool ResetPassword(string userId, string oldPassword, string passwordHash)
        {
            int userIdInt = int.Parse(userId);

            
                var user = context.users.FirstOrDefault(x => x.Id == userIdInt && x.deleted == false);

                
                if (user != null && HashPasswordHelperRepo.ValidatePassword(oldPassword, user.password_hash))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.Id == userIdInt && x.deleted == false);

                    userUpdate.password_hash = passwordHash;
                    
                    context.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            

        }

        public bool UpdatePassword(string userId, string token, string passwordHash)
        {
            int userIdInt = int.Parse(userId);

              var user = context.users.FirstOrDefault(x => x.Id == userIdInt && x.deleted == false);

                var tokenDecoded = HttpUtility.UrlDecode(token);

                if (user != null && HashPasswordHelperRepo.ValidatePassword(user.reset_token.ToString(), tokenDecoded))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.Id == userIdInt && x.deleted == false);

                        userUpdate.password_hash = passwordHash;
                        userUpdate.reset_token = Guid.NewGuid();

                        context.SaveChanges();
                         return true;

                }
                else
                {
                    return false;
                }
            
            
        }
    }
}

