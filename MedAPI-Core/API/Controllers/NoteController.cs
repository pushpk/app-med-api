using Repository.DTOs;
using Services.IServices;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using API.Controllers;   
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/record")]
    [Authorize]
    public class NoteController : BaseController
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
        public ActionResult List()
        {
           
            try
            {
               return Ok(noteService.GetAllNote());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("note/{id:int}")]
        public ActionResult Show(long id)
        {
           
            try
            {
                Repository.DTOs.Note mNote = noteService.GetNoteById(id);
                if (mNote == null)
                {
                    return NotFound("Requested entity was not found in database.");
                }
                else
                {
                   return Ok(mNote);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpDelete]
        [Route("note/{id:int}")]
        public ActionResult Delete(long id)
        {
           
            try
            {
                bool isSuccess = false;
                isSuccess = noteService.DeleteNoteById(id);
                if (isSuccess)
                {
                   return Ok("Entity removed successfully.");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }


        [HttpPost]
        [Authorize(Roles = "medic")]
        [Route("note")]
        public ActionResult Create(API.Models.Note mNote)
        {
           
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

                   return Ok(responseNote);
                }
                else
                {
                    var triage = setTriageDetails(mNote);
                    var responseTriage = noteService.TriageSave(triage);
                   return Ok(responseTriage);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpPost]
        [Route("saveSignatureForNote")]
        public ActionResult SaveSignatureForNote()
        {
           

            var httpRequest = HttpContext.Request;
            byte[] signImageData = null;
            string signText = null;

            var noteId = int.Parse(httpRequest.Form["noteId"].ToString());
            var isSignDraw= httpRequest.Form["IsSignDraw"].ToString() == "true" ? true : false;
            
            if(isSignDraw)
            {
                if (httpRequest.Form.Files.Count < 1)
                {
                    return BadRequest();
                }
                
                using (var binaryReader = new BinaryReader(httpRequest.Form.Files[0].OpenReadStream()))
                {
                    signImageData = binaryReader.ReadBytes(httpRequest.Form.Files[0].ContentDisposition.Length);
                }
            }
            else
            {
                signText = httpRequest.Form["signText"].ToString();

            }

           var result =  noteService.saveSignature(noteId, isSignDraw, signText, signImageData);

            if (result)
            {
               return Ok(result);
                
            }
            else
            {
                return StatusCode(500);
            }
          

        }

        [HttpGet]
        [Route("noteSignature/{noteId}")]
        public string Get(int noteId)
        {
            var image = noteService.GetNoteSignatureIfDraw(noteId);
            return System.Convert.ToBase64String(image);
        }

        [HttpPost]
        [Route("note/{id:int}")]
        public ActionResult Update(Repository.DTOs.Note mNote, long id)
        {
           
            try
            {
                mNote.id = id;
                mNote = noteService.SaveNote(mNote);
               return Ok(mNote);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        [HttpGet]
        [Route("resources/note")]
        public ActionResult Resources()
        {
           
            NoteResources mNoteResources = new NoteResources();
            try
            {
                mNoteResources = noteService.GetResources();
               return Ok(mNoteResources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }

        //Evaluation Related Services

        [HttpGet]
        [Route("note/close-attention/{id:int}")]
        public ActionResult CloseAttention(long id)
        {
            try
            {
                bool isSuccess = false;
                isSuccess = noteService.CloseAttention(id);
                if (isSuccess)
                {
                   return Ok("Entity removed successfully.");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

        }



        //[HttpGet]
        //[Route("resources/cardiology")]
        //public ActionResult ResourcesCardiology()
        //{
        //   
        //    NoteResources mNoteResources = new NoteResources();
        //    try
        //    {
        //        mNoteResources = noteService.GetResources();
        //       return Ok(mNoteResources);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //  
        //}
        private bool IsTRIAGEPermission()
        {
            bool result = false;
            var email = Request.Headers["email"].ToString();
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
        private bool IsAdminPermission()
        {
            bool result = false;
            var email = Request.Headers["email"].ToString();
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

        private Repository.DTOs.Note setNoteDetails(API.Models.Note mNote)
        {
            var userData = getUserInfo();


            var note = new Repository.DTOs.Note();

            note.id = mNote.id;
            note.age = null;
            note.completed = false;
            note.control = false;

            note.status = mNote.status;
            note.category = mNote.category;
            note.attached_attention = mNote.attached_attention;

            note.prognosis = mNote.prognosis;
            note.notes = mNote.notes;

            if (userData != null)
            {
                note.createdBy = Convert.ToString(userData.id);
                note.createdDate = DateTime.Now;
                note.medicId = userData.id;
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
            note.story = mNote.symptoms.background;
            note.symptom = mNote.symptoms.description;
            note.treatment = mNote.treatments.other;
            note.patientId = mNote.patientId;
            note.triage.id = mNote.triageId;
            note.ticketId = mNote.ticketId;
            note.ticket.id = mNote.ticketId;
            note.isSignatureDraw = mNote.isSignatureDraw;
            note.signatuteText = mNote.signatuteText;
            note.signatuteDraw = mNote.signatuteDraw;
            note.userId = mNote.userId;
            return note;
        }

        private Repository.DTOs.User getUserInfo()
        {
            var email = Request.Headers["email"].ToString();
            return userService.GetByEmail(email); ;
        }

        private List<NoteDiagnosi> setDignosisList(API.Models.Note note)
        {
            List<NoteDiagnosi> lstDignosis = new List<NoteDiagnosi>();
            NoteDiagnosi dignosi;
            foreach (var item in note.diagnosis.list)
            {
                dignosi = new NoteDiagnosi();
                dignosi.noteId = note.id;
                dignosi.diagnosisType = item.type;
                dignosi.diagnosisId = item.id;
                lstDignosis.Add(dignosi);
            }
            return lstDignosis;
        }
        private List<NoteExam> setExamsList(API.Models.Note note)
        {
            List<NoteExam> lstExams = new List<NoteExam>();
            NoteExam exam;
            foreach (var item in note.exams.list)
            {
                exam = new NoteExam();
                exam.noteId = note.id;
                exam.observation = note.exams.observations;
                exam.specification = null;
                exam.status = null;
                exam.examId = item.id;
                lstExams.Add(exam);
            }
            return lstExams;
        }
        private List<NoteMedicine> setMedicinesList(API.Models.Note note)
        {
            List<NoteMedicine> lstMedications = new List<NoteMedicine>();
            NoteMedicine medication;
            foreach (var item in note.treatments.list)
            {
                medication = new NoteMedicine();
                medication.noteId = note.id;
                medication.medicineId = item.id;
                medication.indication = item.indications;
                lstMedications.Add(medication);
            }
            return lstMedications;
        }
        private List<NoteReferral> setReferralsList(API.Models.Note note)
        {
            List<NoteReferral> lstReferrals = new List<NoteReferral>();
            NoteReferral referral;
            if (note.referrals.list.Length > 0)
            {
                foreach (var item in note.referrals.list)
                {
                    referral = new NoteReferral();
                    referral.noteId = note.id;
                    referral.reason = note.interconsultation.reason;
                    referral.specialty = item.name;
                    lstReferrals.Add(referral);
                }
            }
            return lstReferrals;
        }

        private Repository.DTOs.Triage setTriageDetails(API.Models.Note note)
        {
            Repository.DTOs.Triage triage = new Repository.DTOs.Triage();
            triage.id = note.triageId;
            triage.abdominalPerimeter = note.triage.vitalFunctions.waistCircumference;
            triage.bmi = note.triage.vitalFunctions.bmi;
            triage.breathingRate = note.triage.vitalFunctions.respiratoryRate;
            triage.diastolicBloodPressure = note.triage.vitalFunctions.diastolic;
            triage.heartRate = note.triage.vitalFunctions.heartRate;
            triage.heartRisk = note.triage.vitalFunctions.cardiovascularAge;
            triage.hypertensionRisk = note.triage.vitalFunctions.hypertensionRisk;
            triage.systolicBloodPressure = note.triage.vitalFunctions.systolic;
            triage.saturation = note.triage.vitalFunctions.saturation;
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

            triage.specialities = note.triage.others.specialities;

            triage.patientId = note.patientId;
            return triage;
        }

        private Repository.DTOs.CardiovascularNote setCardiovascularNote(API.Models.Note note)
        {
            var cardiovascularNote = new Repository.DTOs.CardiovascularNote();
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

        private List<Repository.DTOs.CardiovascularSymptoms> setCardiovascularSymptomList(API.Models.Note note, long cardiovascularNoteId)
        {
            List<Repository.DTOs.CardiovascularSymptoms> cardiovascularSymptoms = new List<Repository.DTOs.CardiovascularSymptoms>();
            Repository.DTOs.CardiovascularSymptoms cardiovascularSymptom;
            foreach (var item in note.cardiovascularSymptoms)
            {
                cardiovascularSymptom = new Repository.DTOs.CardiovascularSymptoms();
                cardiovascularSymptom.cardiovascularNoteId = cardiovascularNoteId;
                cardiovascularSymptom.id = item.id;
                cardiovascularSymptom.cardiovascularSymptoms = item.cardiovascularSymptoms;
                cardiovascularSymptoms.Add(cardiovascularSymptom);
            }
            return cardiovascularSymptoms;
        }

    }

    public class signClass
    {
        public int NoteId { get; set; }

        public object signDraw { get; set; }
    }
}
