﻿using AutoMapper;
using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        public User ConfirmEmail(string userId, string token)
        {
            int userIdInt = int.Parse(userId);
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {

                var user = context.users.Where(x => x.id == userIdInt && x.deleted == false)
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
                          sex = x.sex,
                          token = x.token

                      }).FirstOrDefault();

                var tokenDecord = HttpUtility.UrlDecode(token);
                if (user != null && HashPasswordHelper.ValidatePassword(user.token.ToString(), tokenDecord))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.id == userIdInt && x.deleted == false);
                    userUpdate.emailConfirmed = true;
                    context.SaveChanges();
                    return user;

                }
                else
                {
                    return null;
                }
            }
        }

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
                          sex = x.sex,
                          emailConfirmed = x.emailConfirmed
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
                       emailConfirmed = x.emailConfirmed,
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
                       reset_token = x.reset_token,
                       token = x.token,
                       role = new Domain.Role
                       {
                           id = x.role.id,
                           name = x.role.name
                       }
                   }).FirstOrDefault();
            }
        }

        public bool IsUserAlreadyExist(User mUser, string cmp = null)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                bool emailAlreadyExist =  context.users.Any(m => m.email == mUser.email);
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
        }
        public User SaveUser(User mUser)
        {
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
                    efUser.token = Guid.NewGuid();
                    efUser.reset_token = Guid.NewGuid();
                    context.users.Add(efUser);

                   
                }
                else
                {
                    efUser.modifiedDate = DateTime.UtcNow;
                    efUser.modifiedBy = mUser.createdBy;
                }

                //Following properties does not apply to medic OR Lab, hence setting as empty to avoid validation error
                if (mUser.roleId == 2 || mUser.roleId == 5)
                {

                   if(mUser.roleId ==2) mUser.address = string.Empty;

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
                mUser.token = efUser.token;
            }
            return mUser;
        }

        public List<Medic> GetAllNonApprovedMedics()
        {
            using (var context = new DataAccess.registroclinicoEntities())
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

                                   id = us.user.id,
                                   address = us.user.address,
                                   birthday = us.user.birthday,
                                   cellphone = us.user.cellphone,
                                   createdBy = us.user.createdBy,
                                   createdDate = us.user.createdDate,
                                   deletable = us.user.deletable,
                                   deleted = us.user.deleted,
                                   documentNumber = us.user.documentNumber,
                                   documentType = us.user.documentType,
                                   email = us.user.email,
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
        }

        public List<Lab> GetAllNonApprovedLabs()
        {
            using (var context = new DataAccess.registroclinicoEntities())
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

                                   id = us.user.id,
                                   address = us.user.address,
                                   birthday = us.user.birthday,
                                   cellphone = us.user.cellphone,
                                   createdBy = us.user.createdBy,
                                   createdDate = us.user.createdDate,
                                   deletable = us.user.deletable,
                                   deleted = us.user.deleted,
                                   documentNumber = us.user.documentNumber,
                                   documentType = us.user.documentType,
                                   email = us.user.email,
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
        }

        public bool ResetPassword(string userId, string oldPassword, string passwordHash)
        {
            int userIdInt = int.Parse(userId);

            using (var context = new DataAccess.registroclinicoEntities())
            {
                var user = context.users.FirstOrDefault(x => x.id == userIdInt && x.deleted == false);

                
                if (user != null && HashPasswordHelper.ValidatePassword(oldPassword, user.password_hash))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.id == userIdInt && x.deleted == false);

                    userUpdate.password_hash = passwordHash;
                    
                    context.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }

        }

        public bool UpdatePassword(string userId, string token, string passwordHash)
        {
            int userIdInt = int.Parse(userId);

            using (var context = new DataAccess.registroclinicoEntities())
            {
                var user = context.users.FirstOrDefault(x => x.id == userIdInt && x.deleted == false);

                var tokenDecoded = HttpUtility.UrlDecode(token);

                if (user != null && HashPasswordHelper.ValidatePassword(user.reset_token.ToString(), tokenDecoded))
                {
                    var userUpdate = context.users.FirstOrDefault(x => x.id == userIdInt && x.deleted == false);

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
}

