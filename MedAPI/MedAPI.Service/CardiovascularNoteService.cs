using MedAPI.Domain;
using MedAPI.Infrastructure;
using MedAPI.Infrastructure.IRepository;
using MedAPI.Infrastructure.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using static MedAPI.Infrastructure.Common;

namespace MedAPI.Service
{
    public class CardiovascularNoteService : ICardiovascularNoteService
    {
        private readonly ICardiovascularNoteRepository cardiovascularNoteRepository;

        public CardiovascularNoteService(ICardiovascularNoteRepository cardiovascularNoteRepository)
        {
            this.cardiovascularNoteRepository = cardiovascularNoteRepository;
        }

        public bool DeleteCardiovascularNoteById(long id)
        {
            return cardiovascularNoteRepository.DeleteCardiovascularNoteById(id);
        }

        public List<CardiovascularNote> GetAllCardiovascularNote()
        {
            return cardiovascularNoteRepository.GetAllCardiovascularNote();
        }

        public CardiovascularNote GetCardiovascularNoteById(long id)
        {
            return cardiovascularNoteRepository.GetCardiovascularNoteById(id);
        }

        public int SaveCardiovascularNote(CardiovascularNote mCardiovascularNote)
        {
            return cardiovascularNoteRepository.SaveCardiovascularNote(mCardiovascularNote);
        }
        public bool SaveCardiovascularSymptoms(List<CardiovascularSymptoms> mCardiovascularSymptom)
        {
            return cardiovascularNoteRepository.SaveCardiovascularSymptoms(mCardiovascularSymptom);
        }
        
        public CardiovascularResource GetResources()
        {
            CardiovascularResource mCardiovascularResourceList = new CardiovascularResource();


            mCardiovascularResourceList.hungers = Enum.GetValues(typeof(Hunger))
                            .Cast<Hunger>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mCardiovascularResourceList.thirsts = Enum.GetValues(typeof(Thirst))
                            .Cast<Thirst>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mCardiovascularResourceList.sleeps = Enum.GetValues(typeof(Sleep))
                          .Cast<Sleep>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mCardiovascularResourceList.urines = Enum.GetValues(typeof(Urine))
                          .Cast<Urine>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mCardiovascularResourceList.weightEvolutions = Enum.GetValues(typeof(WeightEvolution))
                         .Cast<WeightEvolution>()
                         .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                         .ToList();

            mCardiovascularResourceList.depositions = Enum.GetValues(typeof(Deposition))
                        .Cast<Deposition>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mCardiovascularResourceList.cardiovascularSymptom = Enum.GetValues(typeof(CardiovascularSymptom))
                        .Cast<CardiovascularSymptom>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();


            mCardiovascularResourceList.medicines = Enum.GetValues(typeof(Infrastructure.Common.Medicine))
                        .Cast<Infrastructure.Common.Medicine>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mCardiovascularResourceList.backgrounds = Enum.GetValues(typeof(Infrastructure.Common.Background))
                      .Cast<Infrastructure.Common.Background>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();

            mCardiovascularResourceList.physicalActivities = Enum.GetValues(typeof(Infrastructure.Common.PhysicalActivity))
                      .Cast<Infrastructure.Common.PhysicalActivity>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();
            mCardiovascularResourceList.sexes = Enum.GetValues(typeof(Infrastructure.Common.Sex))
            .Cast<Infrastructure.Common.Sex>()
            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
            .ToList();


            mCardiovascularResourceList.pulsesLLMs = Enum.GetValues(typeof(PulsesLLM))
                            .Cast<PulsesLLM>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mCardiovascularResourceList.pulsesLRMs = Enum.GetValues(typeof(PulsesLRM))
                            .Cast<PulsesLRM>()
                            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                            .ToList();

            mCardiovascularResourceList.auscultationSites = Enum.GetValues(typeof(AuscultationSite))
                          .Cast<AuscultationSite>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mCardiovascularResourceList.capillaryRefillLRMs = Enum.GetValues(typeof(CapillaryRefillLRM))
                          .Cast<CapillaryRefillLRM>()
                          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                          .ToList();

            mCardiovascularResourceList.capillaryRefillLLMs = Enum.GetValues(typeof(CapillaryRefillLLM))
                         .Cast<CapillaryRefillLLM>()
                         .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                         .ToList();

            mCardiovascularResourceList.cardiacPressureRhythms = Enum.GetValues(typeof(CardiacPressureRhythm))
                        .Cast<CardiacPressureRhythm>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mCardiovascularResourceList.cardiacPressureIntensities = Enum.GetValues(typeof(CardiacPressureIntensity))
                        .Cast<CardiacPressureIntensity>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();


            mCardiovascularResourceList.gastrointestinalSemiologies = Enum.GetValues(typeof(Infrastructure.Common.GastrointestinalSemiology))
                        .Cast<Infrastructure.Common.GastrointestinalSemiology>()
                        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                        .ToList();

            mCardiovascularResourceList.pedalPulsesLs = Enum.GetValues(typeof(Infrastructure.Common.PedalPulsesL))
                      .Cast<Infrastructure.Common.PedalPulsesL>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();

            mCardiovascularResourceList.pedalPulsesRs = Enum.GetValues(typeof(Infrastructure.Common.PedalPulsesR))
                      .Cast<Infrastructure.Common.PedalPulsesR>()
                      .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
                      .ToList();

            mCardiovascularResourceList.radialPulsesRs = Enum.GetValues(typeof(Infrastructure.Common.RadialPulsesR))
            .Cast<Infrastructure.Common.RadialPulsesR>()
            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
            .ToList();

            mCardiovascularResourceList.radialPulsesLs = Enum.GetValues(typeof(Infrastructure.Common.RadialPulsesL))
            .Cast<Infrastructure.Common.RadialPulsesL>()
            .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
            .ToList();

            mCardiovascularResourceList.vesicularWhisperLs = Enum.GetValues(typeof(Infrastructure.Common.VesicularWhisperL))
          .Cast<Infrastructure.Common.VesicularWhisperL>()
          .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
          .ToList();

            mCardiovascularResourceList.vesicularWhisperRs = Enum.GetValues(typeof(Infrastructure.Common.VesicularWhisperR))
        .Cast<Infrastructure.Common.VesicularWhisperR>()
        .Select(d => new ObjectNode() { id = d.ToString().ToUpper(), name = StringExtensions.FirstCharToUpper(d.ToString()) })
        .ToList();

            return mCardiovascularResourceList;
        }
    }
}
