using Data.Model;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository
{
    public class TriageRepository : ITriageRepository
    {
        public Triage GetLatest(long id)
        {
            //var bytes = BitConverter.GetBytes(false);
            using (var context = new registroclinicocoreContext())
            {
                return (from tr in context.triages
                        where tr.deleted != false && tr.patient_id == id
                        select new Triage
                        {
                            abdominalPerimeter = tr.abdominalPerimeter,
                            bmi = tr.bmi,
                            breathingRate = tr.breathingRate,
                            createdBy = tr.createdBy,
                            createdDate = tr.createdDate,
                            deleted = tr.deleted,
                            deposition = tr.deposition,
                            diastolicBloodPressure = tr.diastolicBloodPressure,
                            specialities = tr.speciality,
                            glycemia = tr.glycemia,
                            hdlCholesterol = tr.hdlCholesterol,
                            heartRate = tr.heartRate,
                            heartRisk = tr.heartRisk,
                            hunger = tr.hunger,
                            hypertensionRisk = tr.hypertensionRisk,
                            id = tr.id,
                            ldlCholesterol = tr.ldlCholesterol,
                            modifiedBy = tr.modifiedBy,
                            modifiedDate = tr.modifiedDate,
                            patientId = tr.patient_id,
                            saturation = tr.saturation,
                            size = tr.size,
                            sleep = tr.sleep,
                            systolicBloodPressure = tr.systolicBloodPressure,
                            temperature = tr.temperature,
                            thirst = tr.thirst,
                            ticketId = tr.ticket_id,
                            totalCholesterol = tr.totalCholesterol,
                            urine = tr.urine,
                            weight = tr.weight,
                            weightEvolution = tr.weightEvolution
                        }).FirstOrDefault();
            }
        }

        public List<Speciality> getSpecialities()
        {
            using (var context = new registroclinicocoreContext())
            {
                return context.specialities.Select(s => new Speciality
                {
                    id = s.id,
                    name = s.name
                }).ToList();

            }
        }

        public Triage SaveTriage(Triage triage)
        {
            using (var context = new registroclinicocoreContext())
            {
                var efTriages = context.triages.Where(m => m.id == triage.id).FirstOrDefault();
                if (efTriages == null)
                {
                    efTriages = new DataAccess.triage();
                    efTriages.createdDate = DateTime.UtcNow;
                    efTriages.deleted = false;// BitConverter.GetBytes(false);
                    context.triages.Add(efTriages);
                }
                efTriages.abdominalPerimeter = triage.abdominalPerimeter;
                efTriages.bmi = triage.bmi;
                efTriages.breathingRate = triage.breathingRate;
                efTriages.createdBy = triage.createdBy;
                efTriages.deposition = triage.deposition;
                efTriages.diastolicBloodPressure = triage.diastolicBloodPressure;
                efTriages.speciality = triage.specialities;

                efTriages.glycemia = triage.glycemia;

                efTriages.hdlCholesterol = triage.hdlCholesterol;
                efTriages.heartRate = triage.heartRate;
                efTriages.heartRisk = triage.heartRisk;
                efTriages.hunger = triage.hunger;
                efTriages.hypertensionRisk = triage.hypertensionRisk;
                efTriages.ldlCholesterol = triage.ldlCholesterol;
                efTriages.modifiedBy = triage.modifiedBy;
                efTriages.modifiedDate = triage.modifiedDate;
                efTriages.patient_id = triage.patientId;
                efTriages.size = triage.size;
                efTriages.sleep = triage.sleep;
                efTriages.systolicBloodPressure = triage.systolicBloodPressure;
                efTriages.temperature = triage.temperature;
                efTriages.saturation = triage.saturation;
                efTriages.thirst = triage.thirst;
                efTriages.ticket_id = triage.ticketId;
                efTriages.totalCholesterol = triage.totalCholesterol;
                efTriages.urine = triage.urine;
                efTriages.weight = triage.weight;
                efTriages.weightEvolution = triage.weightEvolution;
                context.SaveChanges();
                triage.id = efTriages.id;
            }
            return triage;
        }
    }
}


