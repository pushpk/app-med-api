using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedAPI.Repository
{
    public class MedicRepository : IMedicRepository
    {
        public List<Medic> GetAllMedic()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from me in context.medics
                        select new Medic()
                        {
                            id = me.id,
                            cmp = me.cmp,
                            rne = me.rne
                        }).ToList();
            }
        }

        public int GetActiveMedicCount()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.medics.Where(x => (x.IsApproved || x.IsFreezed) && x.user.emailConfirmed == true).Count();
            }
        }

        public Medic GetMedicById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.medics.Where(x => x.id == id)
                   .Select(x => new Medic()
                   {
                       id = x.id,
                       cmp = x.cmp,
                       rne = x.rne, 
                       IsApproved = x.IsApproved,
                       IsFreezed = x.IsFreezed,
                       user = new User
                       {

                           id = x.user.id,
                           address = x.user.address,
                           birthday = x.user.birthday,
                           cellphone = x.user.cellphone,
                           countryId = x.user.country_id,
                           deleted = x.user.deleted,
                           createdBy = x.user.createdBy,
                           createdDate = x.user.createdDate,
                           districtId = x.user.district_id,
                           departmentId = x.user.department_id,
                           provinceId = x.user.province_id,
                           documentNumber = x.user.documentNumber,
                           documentType = x.user.documentType,
                           email = x.user.email,
                           firstName = x.user.firstName,
                           lastNameFather = x.user.lastNameFather,
                           lastNameMother = x.user.lastNameMother,
                           maritalStatus = x.user.maritalStatus,
                           modifiedBy = x.user.modifiedBy,
                           modifiedDate = x.user.modifiedDate,
                           organDonor = x.user.organDonor,
                           phone = x.user.phone,
                           roleId = x.user.role_id,
                           since = x.user.since,
                           passwordHash = x.user.password_hash,
                           role = new Role
                           {
                               id = x.user.role.id,
                               name = x.user.role.name,
                               description = x.user.role.description
                           },
                           sex = x.user.sex

                       }
                   }).FirstOrDefault();
            }
        }
        public bool DeleteMedicById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efMedics = context.medics.Where(m => m.id == id).FirstOrDefault();
                if (efMedics != null)
                {
                    context.medics.Remove(efMedics);
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public long SaveMedic(Medic mMedic)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efMedic = context.medics.Where(m => m.id == mMedic.id).FirstOrDefault();
                if (efMedic == null)
                {
                    efMedic = new DataAccess.medic();
                    context.medics.Add(efMedic);
                }
                efMedic.id = mMedic.id;
                efMedic.rne = mMedic.rne;
                efMedic.cmp = mMedic.cmp;


                context.SaveChanges();
                var efMedicSp = context.medic_specialties.Where(m => m.Medic_id == mMedic.id).FirstOrDefault();
                if (efMedicSp == null)
                {

                    efMedicSp = new DataAccess.medic_specialties();
                    context.medic_specialties.Add(efMedicSp);
                }

                efMedicSp.Medic_id = mMedic.id;
                efMedicSp.specialties = mMedic.Speciality;

                context.SaveChanges();

                return efMedic.id;
            }
        }

        public void UpdateMedic(Medic mMedic)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efMedic = context.medics.Where(m => m.id == mMedic.id).FirstOrDefault();
                efMedic.IsFreezed = mMedic.IsFreezed;
                efMedic.IsApproved = mMedic.IsApproved;
                efMedic.IsDenied = mMedic.IsDenied;

                context.SaveChanges();
            }
        }
    }
}
