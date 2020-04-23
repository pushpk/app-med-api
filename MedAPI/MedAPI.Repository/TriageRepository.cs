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
            var bytes = BitConverter.GetBytes(false);
            using (var context = new DataAccess.RegistroclinicoEntities())
            {
                return (from tr in context.triages
                        where tr.deleted != bytes  && tr.patient.id==id
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
    }
}


