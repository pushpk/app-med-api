using AutoMapper;
using Data.DataModels; using Repository.DTOs;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
    public class LabRepository : ILabRepository
    {
        private readonly IMapper mapper;
        private readonly registroclinicocoreContext context;

        public LabRepository(IMapper mapper, registroclinicocoreContext context)
        {
            this.mapper = mapper;
            this.context = context;

        }
        public List<LabUploadResult> GetAllUploadsByLabAndPatient(int LabId, int patientId)
        {
           
                
                int.TryParse(context.labs.FirstOrDefault(s => s.user_id == LabId).id.ToString(), out LabId);
                var result = mapper.Map<List<LabUploadResult>>(context.lab_upload_results.Where(x => x.lab_id == LabId && x.user_id == patientId).Select(s => new LabUploadResult
                {
                    id = s.id,
                    user_id = s.user_id,
                    patient_docNumber = s.user.documentNumber,
                    uploadedBy = s.medic_user.user.lastNameFather.Length > 0 ? "Dr./Dra. " + s.medic_user.user.lastNameFather : s.lab.labName,
                    fileName = s.fileName,
                    dateUploaded = s.dateUploaded,
                    comments = s.comments
                }).ToList());
                return result;
                
            
        }

        public List<LabUploadResult> GetAllUploadsByPatient(int patientId)
        {
            
                var result = mapper.Map<List<LabUploadResult>>(context.lab_upload_results.Where(x => x.user_id == patientId).Select(s => new LabUploadResult { 
                    id = s.id,
                    user_id = s.user_id,
                    patient_docNumber = s.user.documentNumber,
                    uploadedBy = s.medic_user.user.lastNameFather.Length > 0 ? "Dr./Dra. " + s.medic_user.user.lastNameFather : s.lab.labName,
                    fileName = s.fileName,
                    dateUploaded = s.dateUploaded,
                    comments = s.comments
                }).ToList());
                return result;

            
        }


        public LabUploadResult GetTestResultById(int id)
        {
           
                 return mapper.Map<LabUploadResult>(context.lab_upload_results.First(s => s.id == id));
                
            
        }

        public long SaveLab(Lab lab)
        {
            
                var efLab = context.labs.Where(m => m.id == lab.id).FirstOrDefault();
                if (efLab == null)
                {
                    efLab = new lab();
                    context.labs.Add(efLab);
                }
                efLab.id = lab.id;
                efLab.ruc = lab.ruc;
                efLab.user_id = lab.userId;
                efLab.parentCompany = lab.parentCompany;
                efLab.labName = lab.labName;

                context.SaveChanges();

               return efLab.id;
            
        }

        public long SaveUploadedFile(LabUploadResult labResult)
        {
            
                var efUploadResult = context.lab_upload_results.Where(m => m.id == labResult.id).FirstOrDefault();
                if (efUploadResult == null)
                {
                    efUploadResult = new lab_upload_result();
                    context.lab_upload_results.Add(efUploadResult);
                }
                efUploadResult.id = labResult.id;
                efUploadResult.user_id = labResult.user_id;
                if(labResult.labId == null)
                {
                    efUploadResult.lab_id = null;
                }
                else
                {
                    efUploadResult.lab_id = context.labs.FirstOrDefault(s => s.user_id == labResult.labId).id;
                }

                

                efUploadResult.medic_user_id  = labResult.medicId;
                efUploadResult.comments = labResult.comments;
                efUploadResult.fileName = labResult.fileName;
                efUploadResult.fileContent = labResult.fileContent;
                efUploadResult.dateUploaded = DateTime.Now;

                context.SaveChanges();

                return labResult.id;

            
        }

        public Lab GetLab(long id)
        {
            
                return context.labs.Where(x => x.user_id == id)
                   .Select(x => new Lab()
                   {
                       id = x.id,
                       ruc = x.ruc,
                       parentCompany = x.parentCompany,
                       labName = x.labName,
                       IsApproved = x.IsApproved,
                       IsFreezed = x.IsFreezed,
                       IsDenied = x.IsDenied,
                       user = new User
                       {

                           Id = x.user.Id,
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
                           Email = x.user.Email,
                           firstName = x.user.firstName,
                           lastNameFather = x.user.lastNameFather,
                           lastNameMother = x.user.lastNameMother,
                           maritalStatus = x.user.maritalStatus,
                           modifiedBy = x.user.modifiedBy,
                           modifiedDate = x.user.modifiedDate,
                           organDonor = x.user.organDonor,
                           phone = x.user.phone,
                           roleId = x.user.Id,
                           since = x.user.since,
                           PasswordHash = x.user.password_hash,
                           role = new Role
                           {
                               id = x.user.role.Id,
                               name = x.user.role.Name,
                               description = x.user.role.Name
                           },
                           sex = x.user.sex

                       }
                   }).FirstOrDefault();
            
        }

        public int GetActiveLabCount()
        {
           
                return context.labs.Where(x => (x.IsApproved || x.IsFreezed) && x.user.EmailConfirmed == true).Count();
            
        }

        public Lab UpdateLab(Lab mLab)
        {
           
                var efLab = context.labs.Where(m => m.id == mLab.id).FirstOrDefault();
                efLab.IsFreezed = mLab.IsFreezed;
                efLab.IsApproved = mLab.IsApproved;
                efLab.IsDenied = mLab.IsDenied;

                context.SaveChanges();

                return mLab;
            
        }
    }
}
