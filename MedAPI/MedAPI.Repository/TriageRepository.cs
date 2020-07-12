using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Linq;
namespace MedAPI.Repository
{
    public class TriageRepository: ITriageRepository
    {
        public Triage GetLatest(long id)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from tr in context.triages
                        where tr.deleted != false && tr.patient.id==id
                        select new Triage
                        {
                            AbdominalPerimeter=tr.abdominalPerimeter,
                            Bmi=tr.bmi,
                            BreathingRate=tr.breathingRate,
                            CreatedBy=tr.createdBy,
                            CreatedDate=tr.createdDate,
                            Deleted=tr.deleted,
                            Deposition=tr.deposition,
                            DiastolicBloodPressure=tr.diastolicBloodPressure,
                            Glycemia=tr.glycemia,
                            HdlCholesterol=tr.hdlCholesterol,
                            HeartRate=tr.heartRate,
                            HeartRisk=tr.heartRisk,
                            Hunger=tr.hunger,
                            HypertensionRisk=tr.hypertensionRisk,
                            Id=tr.id,
                            LdlCholesterol=tr.ldlCholesterol,
                            ModifiedBy=tr.modifiedBy,
                            ModifiedDate=tr.modifiedDate,
                           PatientId=tr.patient.id,
                           Size=tr.size,
                           Sleep=tr.sleep,
                           SystolicBloodPressure=tr.systolicBloodPressure,
                           Temperature=tr.temperature,
                           Thirst=tr.thirst,
                           TicketId=tr.ticket_id,
                           TotalCholesterol=tr.totalCholesterol,
                           Urine=tr.urine,
                           Weight=tr.weight,
                          WeightEvolution=tr.weightEvolution
                        }).FirstOrDefault();
            }
        }

        public Triage SaveTriage(Triage triage)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efTriages = context.triages.Where(m => m.id == triage.Id).FirstOrDefault();
                if (efTriages == null)
                {
                    efTriages = new DataAccess.triage();
                    efTriages.createdDate = DateTime.UtcNow;
                    efTriages.deleted = false;// BitConverter.GetBytes(false);
                    context.triages.Add(efTriages);
                }
                efTriages.abdominalPerimeter = triage.AbdominalPerimeter;
                efTriages.bmi = triage.Bmi;
                efTriages.breathingRate = triage.BreathingRate;
                efTriages.createdBy = triage.CreatedBy;
                efTriages.deposition = triage.Deposition;
                efTriages.diastolicBloodPressure = triage.DiastolicBloodPressure;

                efTriages.glycemia = triage.Glycemia;

                efTriages.hdlCholesterol = triage.HdlCholesterol;
                efTriages.heartRate = triage.HeartRate;
                efTriages.heartRisk = triage.HeartRisk;
                efTriages.hunger = triage.Hunger;
                efTriages.hypertensionRisk = triage.HypertensionRisk;
                efTriages.ldlCholesterol = triage.LdlCholesterol;
                efTriages.modifiedBy = triage.ModifiedBy;
                efTriages.modifiedDate = triage.ModifiedDate;
                efTriages.patient_id = triage.PatientId;
                efTriages.size = triage.PatientId;
                efTriages.sleep = triage.Sleep;
                efTriages.systolicBloodPressure = triage.SystolicBloodPressure ;
                efTriages.temperature = triage.Temperature;
                efTriages.thirst = triage.Thirst;
                efTriages.ticket_id = triage.TicketId;
                efTriages.totalCholesterol = triage.TotalCholesterol ;
                efTriages.urine = triage.Urine;
                efTriages.weight = triage.Weight;
                efTriages.weightEvolution = triage.WeightEvolution;
                context.SaveChanges();
                triage.Id = efTriages.id;
            }
            return triage;
        }
    }
}


