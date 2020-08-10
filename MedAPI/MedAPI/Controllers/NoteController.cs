using MedAPI.Domain;
using MedAPI.Infrastructure.IService;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MedAPI.models;
using System.Collections.Generic;
using static MedAPI.Infrastructure.Common;

namespace MedAPI.Controllers
{
    [System.Web.Http.RoutePrefix("record")]
    public class NoteController : ApiController
    {
        private readonly INoteService noteService;
        private readonly IUserService userService;
        private readonly ITriageService triageService;
        private readonly ICardiovascularNoteService cardiovascularNoteService;
        public NoteController(INoteService noteService, IUserService userService,
            ITriageService triageService, ICardiovascularNoteService cardiovascularNoteService)
        {
            this.noteService = noteService;
            this.userService = userService;
            this.triageService = triageService;
            this.cardiovascularNoteService = cardiovascularNoteService;
        }

        [HttpGet]
        [Route("note")]
        public HttpResponseMessage List()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, noteService.GetAllNote());
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("note/{id:int}")]
        public HttpResponseMessage Show(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                Domain.Note mNote = noteService.GetNoteById(id);
                if (mNote == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound, "Requested entity was not found in database.");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, mNote);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpDelete]
        [Route("note/{id:int}")]
        public HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage response = null;
            try
            {
                bool isSuccess = false;
                isSuccess = noteService.DeleteNoteById(id);
                if (isSuccess)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "Entity removed successfully.");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;

        }


        [HttpPost]
        [Route("note")]
        public HttpResponseMessage Create(models.Note mNote)
        {
            HttpResponseMessage response = null;
            try
            {
                if (IsTRIAGEPermission() || IsAdminPermission())
                {
                    var note = setNoteDetails(mNote);
                    note.triage = setTriageDetails(mNote);
                    var responseNote = noteService.SaveNote(note);
                    mNote.id = responseNote.id;
                    var dignosis = setDignosisList(mNote);
                    noteService.SaveDiagnosisList(dignosis);

                    var exams = setExamsList(mNote);
                    noteService.SaveExamsList(exams);

                    var medications = setMedicinesList(mNote);
                    noteService.SaveMedicationsList(medications);

                    var referrals = setReferralsList(mNote);
                    noteService.SaveReferralsList(referrals);

                    if (mNote.specialty == "cardiology")
                    {
                        long cardiovascularNoteId = 0;
                        if (mNote.cardiovascularNote != null)
                        {
                            var mCardiovascularNote = setCardiovascularNote(mNote);
                            cardiovascularNoteId = cardiovascularNoteService.SaveCardiovascularNote(mCardiovascularNote);
                        }
                        if (mNote.cardiovascularSymptoms != null)
                        {
                            var mCardiovascularSymptoms = setCardiovascularSymptomList(mNote, cardiovascularNoteId);
                            cardiovascularNoteService.SaveCardiovascularSymptoms(mCardiovascularSymptoms);
                        }
                    }

                    response = Request.CreateResponse(HttpStatusCode.OK, responseNote);
                }
                else
                {
                    var triage = setTriageDetails(mNote);
                    var responseTriage = noteService.TriageSave(triage);
                    response = Request.CreateResponse(HttpStatusCode.OK, responseTriage);
                }

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("note/{id:int}")]
        public HttpResponseMessage Update(Domain.Note mNote, long id)
        {
            HttpResponseMessage response = null;
            try
            {
                mNote.id = id;
                mNote = noteService.SaveNote(mNote);
                response = Request.CreateResponse(HttpStatusCode.OK, mNote);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("resources/note")]
        public HttpResponseMessage Resources()
        {
            HttpResponseMessage response = null;
            Domain.NoteResources mNoteResources = new NoteResources();
            try
            {
                mNoteResources = noteService.GetResources();
                response = Request.CreateResponse(HttpStatusCode.OK, mNoteResources);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        //[HttpGet]
        //[Route("resources/cardiology")]
        //public HttpResponseMessage ResourcesCardiology()
        //{
        //    HttpResponseMessage response = null;
        //    Domain.NoteResources mNoteResources = new NoteResources();
        //    try
        //    {
        //        mNoteResources = noteService.GetResources();
        //        response = Request.CreateResponse(HttpStatusCode.OK, mNoteResources);
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //    return response;
        //}
        public bool IsTRIAGEPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.TRIAGE)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool IsAdminPermission()
        {
            bool result = false;
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            var user = userService.GetByEmail(email);
            if (user != null)
            {
                if (user.roleId == (int)Infrastructure.Common.Permission.ADMIN)
                {
                    result = true;
                }
            }
            return result;
        }

        public Domain.Note setNoteDetails(models.Note mNote)
        {
            var userData = getUserInfo();


            Domain.Note note = new Domain.Note();

            note.id = mNote.id;
            note.age = null;
            note.completed = false;
            note.control = false;
            if (userData != null)
            {
                note.createdBy = Convert.ToString(userData.id);
                note.createdDate = DateTime.Now;
            }
            note.deleted = false;
            note.diagnosis = mNote.diagnosis.observations;
            note.exam = mNote.exams.observations;
            if (note.id > 0)
            {
                note.modifiedBy = Convert.ToString(userData.id);
                note.modifiedDate = DateTime.Now;
            }
            note.physicalExam = mNote.physicalExam.text;
            note.secondOpinion = mNote.otherSymptoms;
            note.sicknessTime = mNote.symptoms.duration;
            note.sicknessUnit = mNote.symptoms.durationUnit;
            note.specialty = mNote.specialty;
            note.stage = 0;
            note.story = null;
            note.symptom = mNote.symptoms.description;
            note.treatment = mNote.treatments.other;
            note.patientId = mNote.patientId;
            note.triage.id = mNote.triageId;
            note.ticketId = mNote.ticketId;
            note.ticket.id = mNote.ticketId;
            note.userId = mNote.userId;
            return note;
        }

        public Domain.User getUserInfo()
        {
            var headerValues = HttpContext.Current.Request.Headers.GetValues("email");
            string email = Convert.ToString(headerValues.FirstOrDefault());
            return userService.GetByEmail(email); ;
        }

        public List<Domain.NoteDiagnosi> setDignosisList(models.Note note)
        {
            List<Domain.NoteDiagnosi> lstDignosis = new List<Domain.NoteDiagnosi>();
            Domain.NoteDiagnosi dignosi;
            foreach (var item in note.diagnosis.list)
            {
                dignosi = new Domain.NoteDiagnosi();
                dignosi.noteId = note.id;
                dignosi.diagnosisType = item.type;
                dignosi.diagnosisId = item.id;
                lstDignosis.Add(dignosi);
            }
            return lstDignosis;
        }
        public List<Domain.NoteExam> setExamsList(models.Note note)
        {
            List<Domain.NoteExam> lstExams = new List<Domain.NoteExam>();
            Domain.NoteExam exam;
            foreach (var item in note.exams.list)
            {
                exam = new Domain.NoteExam();
                exam.noteId = note.id;
                exam.observation = note.exams.observations;
                exam.specification = null;
                exam.status = null;
                exam.examId = item.id;
                lstExams.Add(exam);
            }
            return lstExams;
        }
        public List<Domain.NoteMedicine> setMedicinesList(models.Note note)
        {
            List<Domain.NoteMedicine> lstMedications = new List<Domain.NoteMedicine>();
            Domain.NoteMedicine medication;
            foreach (var item in note.treatments.list)
            {
                medication = new Domain.NoteMedicine();
                medication.noteId = note.id;
                medication.medicineId = item.id;
                medication.indication = item.indications;
                lstMedications.Add(medication);
            }
            return lstMedications;
        }
        public List<Domain.NoteReferral> setReferralsList(models.Note note)
        {
            List<Domain.NoteReferral> lstReferrals = new List<Domain.NoteReferral>();
            Domain.NoteReferral referral;
            if (note.referrals.list.Length > 0)
            {
                foreach (var item in note.referrals.list)
                {
                    referral = new Domain.NoteReferral();
                    referral.noteId = note.id;
                    referral.reason = note.interconsultation.reason;
                    referral.specialty = item.name;
                    lstReferrals.Add(referral);
                }
            }
            return lstReferrals;
        }

        public Domain.Triage setTriageDetails(models.Note note)
        {
            Domain.Triage triage = new Domain.Triage();
            triage.id = note.triageId;
            triage.abdominalPerimeter = note.triage.vitalFunctions.waistCircumference;
            triage.bmi = note.triage.vitalFunctions.bmi;
            triage.breathingRate = note.triage.vitalFunctions.respiratoryRate;
            triage.diastolicBloodPressure = note.triage.vitalFunctions.diastolic;
            triage.heartRate = note.triage.vitalFunctions.heartRate;
            triage.heartRisk = note.triage.vitalFunctions.cardiovascularAge;
            triage.hypertensionRisk = note.triage.vitalFunctions.hypertensionRisk;
            triage.systolicBloodPressure = note.triage.vitalFunctions.systolic;
            triage.temperature = note.triage.vitalFunctions.temperature;
            triage.weight = note.triage.vitalFunctions.weight;
            triage.size = note.triage.vitalFunctions.height;

            triage.sleep = note.triage.biologicalFunctions.sleep;
            triage.hunger = note.triage.biologicalFunctions.hunger;
            triage.deposition = note.triage.biologicalFunctions.deposition;
            triage.thirst = note.triage.biologicalFunctions.thirst;
            triage.urine = note.triage.biologicalFunctions.urine;
            triage.weightEvolution = note.triage.biologicalFunctions.weightEvolution;

            triage.glycemia = note.triage.others.glycemia;
            triage.hdlCholesterol = note.triage.others.hdlCholesterol;
            triage.ldlCholesterol = note.triage.others.ldlCholesterol;
            triage.totalCholesterol = note.triage.others.totalCholesterol;
            triage.patientId = note.patientId;
            return triage;
        }

        public Domain.CardiovascularNote setCardiovascularNote(models.Note note)
        {
            Domain.CardiovascularNote cardiovascularNote = new Domain.CardiovascularNote();
            cardiovascularNote.noteId = note.id;
            cardiovascularNote.auscultationSite = null;
            cardiovascularNote.capillaryRefillLLM = note.cardiovascularNote.skin.capillaryRefillLLM;
            cardiovascularNote.capillaryRefillLRM = note.cardiovascularNote.skin.capillaryRefillLRM;
            cardiovascularNote.cardiacPressureIntensity = note.cardiovascularNote.cardiovascularSystem.cardiacPressureIntensity;
            cardiovascularNote.cardiacPressureRhythm = note.cardiovascularNote.cardiovascularSystem.cardiacPressureRhythm;
            cardiovascularNote.diastolicPhase = false;
            cardiovascularNote.edemaAnkle = note.cardiovascularNote.skin.edemaAnkle;
            cardiovascularNote.edemaGeneralized = note.cardiovascularNote.skin.edemaGeneralized;
            cardiovascularNote.edemaLowerMembers = note.cardiovascularNote.skin.edemaLowerMember;
            cardiovascularNote.fourthNoise = false;
            cardiovascularNote.gastrointestinalSemiology = note.cardiovascularNote.gastrointestinalSemiology.gastrointestinalSemiology;
            cardiovascularNote.murmurs = note.cardiovascularNote.murmurs.murmurs;
            cardiovascularNote.neckRadiation = false;
            cardiovascularNote.otherSymptoms = note.otherSymptoms;
            cardiovascularNote.pedalPulsesL = note.cardiovascularNote.cardiovascularSystem.pedalPulsesL;
            cardiovascularNote.pedalPulsesR = note.cardiovascularNote.cardiovascularSystem.pedalPulsesR;
            cardiovascularNote.pulsesLLM = note.cardiovascularNote.pulses.pulsesLLM;
            cardiovascularNote.pulsesLRM = note.cardiovascularNote.pulses.pulsesLRM;
            cardiovascularNote.radialPulsesL = note.cardiovascularNote.cardiovascularSystem.radialPulsesL;
            cardiovascularNote.radialPulsesR = note.cardiovascularNote.cardiovascularSystem.radialPulsesR;
            cardiovascularNote.systolicPhase = false;
            cardiovascularNote.thirdNoise = false;
            cardiovascularNote.trophicChanges = note.cardiovascularNote.skin.trophicChanges;
            cardiovascularNote.vesicularWhisperL = note.cardiovascularNote.respiratorySystem.vesicularWhisperL;
            cardiovascularNote.vesicularWhisperR = note.cardiovascularNote.respiratorySystem.vesicularWhisperR;
            return cardiovascularNote;
        }

        public List<Domain.CardiovascularSymptoms> setCardiovascularSymptomList(models.Note note, long cardiovascularNoteId)
        {
            List<Domain.CardiovascularSymptoms> cardiovascularSymptoms = new List<Domain.CardiovascularSymptoms>();
            Domain.CardiovascularSymptoms cardiovascularSymptom;
            foreach (var item in note.cardiovascularSymptoms)
            {
                cardiovascularSymptom = new Domain.CardiovascularSymptoms();
                cardiovascularSymptom.cardiovascularNoteId = cardiovascularNoteId;
                cardiovascularSymptom.id = item.id;
                cardiovascularSymptom.cardiovascularSymptoms = item.cardiovascularSymptoms;
                cardiovascularSymptoms.Add(cardiovascularSymptom);
            }
            return cardiovascularSymptoms;
        }

    }
}
