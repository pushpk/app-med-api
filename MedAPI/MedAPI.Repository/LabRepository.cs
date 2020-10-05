using AutoMapper;
using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MedAPI.Repository
{
    public class LabRepository : ILabRepository
    {
        public List<LabUploadResult> GetAllUploadsByLab(int LabId)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                
                int.TryParse(context.labs.FirstOrDefault(s => s.user_id == LabId).id.ToString(), out LabId);
                var result = Mapper.Map<List<LabUploadResult>>(context.lab_Upload_Results.Where(x => x.lab_id == LabId).ToList());
                return result;
                
            }
        }

        public List<LabUploadResult> GetAllUploadsByPatient(int patientId)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var result = Mapper.Map<List<LabUploadResult>>(context.lab_Upload_Results.Where(x => x.user_id == patientId).ToList());
                return result;

            }
        }

        public LabUploadResult GetTestResultById(int id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return Mapper.Map<LabUploadResult>(context.lab_Upload_Results.FirstOrDefault(s => s.id == id));
            }
        }

        public long SaveLab(Lab lab)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efLab = context.labs.Where(m => m.id == lab.id).FirstOrDefault();
                if (efLab == null)
                {
                    efLab = new DataAccess.lab();
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
        }

        public long SaveUploadedFile(LabUploadResult labResult)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efUploadResult = context.lab_Upload_Results.Where(m => m.id == labResult.id).FirstOrDefault();
                if (efUploadResult == null)
                {
                    efUploadResult = new DataAccess.lab_upload_result();
                    context.lab_Upload_Results.Add(efUploadResult);
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
        }
    }
}
