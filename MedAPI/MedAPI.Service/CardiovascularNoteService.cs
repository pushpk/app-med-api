using MedAPI.Domain;
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
        public CardiovascularResource GetResources()
        {
            CardiovascularResource mCardiovascularResourceList = new CardiovascularResource();

            mCardiovascularResourceList.pulsesLLMs = Enum.GetValues(typeof(PulsesLLM))
                            .Cast<PulsesLLM>()
                            .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                            .ToList();

            mCardiovascularResourceList.pulsesLRMs = Enum.GetValues(typeof(PulsesLRM))
                            .Cast<PulsesLRM>()
                            .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                            .ToList();

            mCardiovascularResourceList.auscultationSites = Enum.GetValues(typeof(AuscultationSite))
                          .Cast<AuscultationSite>()
                          .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                          .ToList();

            mCardiovascularResourceList.capillaryRefillLRMs = Enum.GetValues(typeof(CapillaryRefillLRM))
                          .Cast<CapillaryRefillLRM>()
                          .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                          .ToList();

            mCardiovascularResourceList.capillaryRefillLLMs = Enum.GetValues(typeof(CapillaryRefillLLM))
                         .Cast<CapillaryRefillLLM>()
                         .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                         .ToList();

            mCardiovascularResourceList.cardiacPressureRhythms = Enum.GetValues(typeof(CardiacPressureRhythm))
                        .Cast<CardiacPressureRhythm>()
                        .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                        .ToList();

            mCardiovascularResourceList.cardiacPressureIntensities = Enum.GetValues(typeof(CardiacPressureIntensity))
                        .Cast<CardiacPressureIntensity>()
                        .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                        .ToList();


            mCardiovascularResourceList.gastrointestinalSemiologies = Enum.GetValues(typeof(Infrastructure.Common.GastrointestinalSemiology))
                        .Cast<Infrastructure.Common.GastrointestinalSemiology>()
                        .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                        .ToList();

            mCardiovascularResourceList.pedalPulsesLs = Enum.GetValues(typeof(Infrastructure.Common.PedalPulsesL))
                      .Cast<Infrastructure.Common.PedalPulsesL>()
                      .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                      .ToList();

            mCardiovascularResourceList.pedalPulsesRs = Enum.GetValues(typeof(Infrastructure.Common.PedalPulsesR))
                      .Cast<Infrastructure.Common.PedalPulsesR>()
                      .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
                      .ToList();

            mCardiovascularResourceList.radialPulsesRs = Enum.GetValues(typeof(Infrastructure.Common.RadialPulsesR))
            .Cast<Infrastructure.Common.RadialPulsesR>()
            .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
            .ToList();

            mCardiovascularResourceList.radialPulsesLs = Enum.GetValues(typeof(Infrastructure.Common.RadialPulsesL))
            .Cast<Infrastructure.Common.RadialPulsesL>()
            .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
            .ToList();

            mCardiovascularResourceList.vesicularWhisperLs = Enum.GetValues(typeof(Infrastructure.Common.VesicularWhisperL))
          .Cast<Infrastructure.Common.VesicularWhisperL>()
          .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
          .ToList();

            mCardiovascularResourceList.vesicularWhisperRs = Enum.GetValues(typeof(Infrastructure.Common.VesicularWhisperR))
        .Cast<Infrastructure.Common.VesicularWhisperR>()
        .Select(d => new ObjectNode() { Id = (int)d, name = d.ToString() })
        .ToList();

            return mCardiovascularResourceList;
        }
    }
}
