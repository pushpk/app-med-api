using MedAPI.Domain;
using MedAPI.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MedAPI.Repository
{
    public class CardiovascularNoteRepository : ICardiovascularNoteRepository
    {
        public bool DeleteCardiovascularNoteById(long id)
        {
            bool isSuccess = false;
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efCardiovascularnotes = context.cardiovascularnotes.Where(m => m.id == id).FirstOrDefault();
                if (efCardiovascularnotes != null)
                {
                    context.Entry(efCardiovascularnotes).State = EntityState.Deleted;
                    context.SaveChanges();
                    isSuccess = true;
                }
                return isSuccess;
            }
        }

        public List<CardiovascularNote> GetAllCardiovascularNote()
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return (from ca in context.cardiovascularnotes
                        select new CardiovascularNote()
                        {
                            AuscultationSite = ca.auscultationSite,
                            CapillaryRefillLLM = ca.capillaryRefillLLM,
                            CapillaryRefillLRM = ca.capillaryRefillLRM,
                            CardiacPressureIntensity = ca.cardiacPressureIntensity,
                            CardiacPressureRhythm = ca.cardiacPressureRhythm,
                            DiastolicPhase = ca.diastolicPhase,
                            EdemaAnkle = ca.edemaAnkle,
                            EdemaGeneralized = ca.edemaGeneralized,
                            EdemaLowerMembers = ca.edemaLowerMembers,
                            FourthNoise = ca.fourthNoise,
                            GastrointestinalSemiology = ca.gastrointestinalSemiology,
                            Murmurs = ca.murmurs,
                            NeckRadiation = ca.neckRadiation,
                            OtherSymptoms = ca.otherSymptoms,
                            PedalPulsesL = ca.pedalPulsesL,
                            PedalPulsesR = ca.pedalPulsesR,
                            PulsesLLM = ca.pulsesLLM,
                            PulsesLRM = ca.pulsesLRM,
                            RadialPulsesL = ca.radialPulsesL,
                            RadialPulsesR = ca.radialPulsesR,
                            SystolicPhase = ca.systolicPhase,
                            ThirdNoise = ca.thirdNoise,
                            TrophicChanges = ca.trophicChanges,
                            VesicularWhisperL = ca.vesicularWhisperL,
                            VesicularWhisperR = ca.vesicularWhisperR,
                            Id = ca.id
                        }).ToList();
            }
        }

        public CardiovascularNote GetCardiovascularNoteById(long id)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                return context.cardiovascularnotes.Where(x => x.id == id)
                   .Select(x => new CardiovascularNote()
                   {
                       AuscultationSite = x.auscultationSite,
                       CapillaryRefillLLM = x.capillaryRefillLLM,
                       CapillaryRefillLRM = x.capillaryRefillLRM,
                       CardiacPressureIntensity = x.cardiacPressureIntensity,
                       CardiacPressureRhythm = x.cardiacPressureRhythm,
                       DiastolicPhase = x.diastolicPhase,
                       EdemaAnkle = x.edemaAnkle,
                       EdemaGeneralized = x.edemaGeneralized,
                       EdemaLowerMembers = x.edemaLowerMembers,
                       FourthNoise = x.fourthNoise,
                       GastrointestinalSemiology = x.gastrointestinalSemiology,
                       Murmurs = x.murmurs,
                       NeckRadiation = x.neckRadiation,
                       OtherSymptoms = x.otherSymptoms,
                       PedalPulsesL = x.pedalPulsesL,
                       PedalPulsesR = x.pedalPulsesR,
                       PulsesLLM = x.pulsesLLM,
                       PulsesLRM = x.pulsesLRM,
                       RadialPulsesL = x.radialPulsesL,
                       RadialPulsesR = x.radialPulsesR,
                       SystolicPhase = x.systolicPhase,
                       ThirdNoise = x.thirdNoise,
                       TrophicChanges = x.trophicChanges,
                       VesicularWhisperL = x.vesicularWhisperL,
                       VesicularWhisperR = x.vesicularWhisperR,
                       Id = x.id,
                   }).FirstOrDefault();
            }
        }

        public int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efCardiovascularNote = context.cardiovascularnotes.Where(x => x.id == mCardiovascularNote.Id).FirstOrDefault();
                if (efCardiovascularNote == null)
                {
                    efCardiovascularNote = new DataAccess.cardiovascularnote();
                    context.cardiovascularnotes.Add(efCardiovascularNote);
                }
                efCardiovascularNote.auscultationSite = mCardiovascularNote.AuscultationSite;
                efCardiovascularNote.capillaryRefillLLM = mCardiovascularNote.CapillaryRefillLLM;
                efCardiovascularNote.capillaryRefillLRM = mCardiovascularNote.CapillaryRefillLRM;
                efCardiovascularNote.cardiacPressureIntensity = mCardiovascularNote.CardiacPressureIntensity;
                efCardiovascularNote.cardiacPressureRhythm = mCardiovascularNote.CardiacPressureRhythm;
                efCardiovascularNote.diastolicPhase = mCardiovascularNote.DiastolicPhase;
                efCardiovascularNote.edemaAnkle = mCardiovascularNote.EdemaAnkle;
                efCardiovascularNote.edemaGeneralized = mCardiovascularNote.EdemaGeneralized;
                efCardiovascularNote.edemaLowerMembers = mCardiovascularNote.EdemaLowerMembers;
                efCardiovascularNote.fourthNoise = mCardiovascularNote.FourthNoise;
                efCardiovascularNote.gastrointestinalSemiology = mCardiovascularNote.GastrointestinalSemiology;
                efCardiovascularNote.murmurs = mCardiovascularNote.Murmurs;
                efCardiovascularNote.neckRadiation = mCardiovascularNote.NeckRadiation;
                efCardiovascularNote.otherSymptoms = mCardiovascularNote.OtherSymptoms;
                efCardiovascularNote.pedalPulsesL = mCardiovascularNote.PedalPulsesL;
                efCardiovascularNote.pedalPulsesR = mCardiovascularNote.PedalPulsesR;
                efCardiovascularNote.pulsesLLM = mCardiovascularNote.PulsesLLM;
                efCardiovascularNote.pulsesLRM = mCardiovascularNote.PulsesLRM;
                efCardiovascularNote.radialPulsesL = mCardiovascularNote.RadialPulsesL;
                efCardiovascularNote.radialPulsesR = mCardiovascularNote.RadialPulsesR;
                efCardiovascularNote.systolicPhase = mCardiovascularNote.SystolicPhase;
                efCardiovascularNote.thirdNoise = mCardiovascularNote.ThirdNoise;
                efCardiovascularNote.trophicChanges = mCardiovascularNote.TrophicChanges;
                efCardiovascularNote.vesicularWhisperL = mCardiovascularNote.VesicularWhisperL;
                efCardiovascularNote.vesicularWhisperR = mCardiovascularNote.VesicularWhisperR;
                context.SaveChanges();
                return Convert.ToInt32(efCardiovascularNote.id);
            }
        }
    }
}
