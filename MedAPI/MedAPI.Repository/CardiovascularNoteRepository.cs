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
                            auscultationSite = ca.auscultationSite,
                            capillaryRefillLLM = ca.capillaryRefillLLM,
                            capillaryRefillLRM = ca.capillaryRefillLRM,
                            cardiacPressureIntensity = ca.cardiacPressureIntensity,
                            cardiacPressureRhythm = ca.cardiacPressureRhythm,
                            diastolicPhase = ca.diastolicPhase,
                            edemaAnkle = ca.edemaAnkle,
                            edemaGeneralized = ca.edemaGeneralized,
                            edemaLowerMembers = ca.edemaLowerMembers,
                            fourthNoise = ca.fourthNoise,
                            gastrointestinalSemiology = ca.gastrointestinalSemiology,
                            murmurs = ca.murmurs,
                            neckRadiation = ca.neckRadiation,
                            otherSymptoms = ca.otherSymptoms,
                            pedalPulsesL = ca.pedalPulsesL,
                            pedalPulsesR = ca.pedalPulsesR,
                            pulsesLLM = ca.pulsesLLM,
                            pulsesLRM = ca.pulsesLRM,
                            radialPulsesL = ca.radialPulsesL,
                            radialPulsesR = ca.radialPulsesR,
                            systolicPhase = ca.systolicPhase,
                            thirdNoise = ca.thirdNoise,
                            trophicChanges = ca.trophicChanges,
                            vesicularWhisperL = ca.vesicularWhisperL,
                            vesicularWhisperR = ca.vesicularWhisperR,
                            id = ca.id
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
                       auscultationSite = x.auscultationSite,
                       capillaryRefillLLM = x.capillaryRefillLLM,
                       capillaryRefillLRM = x.capillaryRefillLRM,
                       cardiacPressureIntensity = x.cardiacPressureIntensity,
                       cardiacPressureRhythm = x.cardiacPressureRhythm,
                       diastolicPhase = x.diastolicPhase,
                       edemaAnkle = x.edemaAnkle,
                       edemaGeneralized = x.edemaGeneralized,
                       edemaLowerMembers = x.edemaLowerMembers,
                       fourthNoise = x.fourthNoise,
                       gastrointestinalSemiology = x.gastrointestinalSemiology,
                       murmurs = x.murmurs,
                       neckRadiation = x.neckRadiation,
                       otherSymptoms = x.otherSymptoms,
                       pedalPulsesL = x.pedalPulsesL,
                       pedalPulsesR = x.pedalPulsesR,
                       pulsesLLM = x.pulsesLLM,
                       pulsesLRM = x.pulsesLRM,
                       radialPulsesL = x.radialPulsesL,
                       radialPulsesR = x.radialPulsesR,
                       systolicPhase = x.systolicPhase,
                       thirdNoise = x.thirdNoise,
                       trophicChanges = x.trophicChanges,
                       vesicularWhisperL = x.vesicularWhisperL,
                       vesicularWhisperR = x.vesicularWhisperR,
                       id = x.id,
                   }).FirstOrDefault();
            }
        }

        public int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote)
        {
            using (var context = new DataAccess.registroclinicoEntities())
            {
                var efCardiovascularNote = context.cardiovascularnotes.Where(x => x.id == mCardiovascularNote.id).FirstOrDefault();
                if (efCardiovascularNote == null)
                {
                    efCardiovascularNote = new DataAccess.cardiovascularnote();
                    context.cardiovascularnotes.Add(efCardiovascularNote);
                }
                efCardiovascularNote.auscultationSite = mCardiovascularNote.auscultationSite;
                efCardiovascularNote.capillaryRefillLLM = mCardiovascularNote.capillaryRefillLLM;
                efCardiovascularNote.capillaryRefillLRM = mCardiovascularNote.capillaryRefillLRM;
                efCardiovascularNote.cardiacPressureIntensity = mCardiovascularNote.cardiacPressureIntensity;
                efCardiovascularNote.cardiacPressureRhythm = mCardiovascularNote.cardiacPressureRhythm;
                efCardiovascularNote.diastolicPhase = mCardiovascularNote.diastolicPhase;
                efCardiovascularNote.edemaAnkle = mCardiovascularNote.edemaAnkle;
                efCardiovascularNote.edemaGeneralized = mCardiovascularNote.edemaGeneralized;
                efCardiovascularNote.edemaLowerMembers = mCardiovascularNote.edemaLowerMembers;
                efCardiovascularNote.fourthNoise = mCardiovascularNote.fourthNoise;
                efCardiovascularNote.gastrointestinalSemiology = mCardiovascularNote.gastrointestinalSemiology;
                efCardiovascularNote.murmurs = mCardiovascularNote.murmurs;
                efCardiovascularNote.neckRadiation = mCardiovascularNote.neckRadiation;
                efCardiovascularNote.otherSymptoms = mCardiovascularNote.otherSymptoms;
                efCardiovascularNote.pedalPulsesL = mCardiovascularNote.pedalPulsesL;
                efCardiovascularNote.pedalPulsesR = mCardiovascularNote.pedalPulsesR;
                efCardiovascularNote.pulsesLLM = mCardiovascularNote.pulsesLLM;
                efCardiovascularNote.pulsesLRM = mCardiovascularNote.pulsesLRM;
                efCardiovascularNote.radialPulsesL = mCardiovascularNote.radialPulsesL;
                efCardiovascularNote.radialPulsesR = mCardiovascularNote.radialPulsesR;
                efCardiovascularNote.systolicPhase = mCardiovascularNote.systolicPhase;
                efCardiovascularNote.thirdNoise = mCardiovascularNote.thirdNoise;
                efCardiovascularNote.trophicChanges = mCardiovascularNote.trophicChanges;
                efCardiovascularNote.vesicularWhisperL = mCardiovascularNote.vesicularWhisperL;
                efCardiovascularNote.vesicularWhisperR = mCardiovascularNote.vesicularWhisperR;
                context.SaveChanges();
                return Convert.ToInt32(efCardiovascularNote.id);
            }
        }
    }
}
