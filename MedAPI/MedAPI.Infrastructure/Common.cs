using System.ComponentModel;

namespace MedAPI.Infrastructure
{
    public class Common
    {
        public enum Specialty
        {
            [Description("Medicina general")]
            GENERAL = 1,
            [Description("Cardiología")]
            CARDIOLOGY = 2,
            [Description("Ciriguía general")]
            SURGERY_GENERAL = 3,
            [Description("Cardiovascular Surgery")]
            SURGERY_CARDIOVASCULAR = 4,
            [Description("Dermatology")]
            DERMATOLOGY = 5,
            [Description("Endocrinology")]
            ENDOCRINOLOGY = 6,
            [Description("Gastroenterology")]
            GASTROENTEROLOGY = 7,
            [Description("Gynecology")]
            GYNECOLOGY = 8,
            [Description("Internal Medicine")]
            INTERNAL_MEDICINE = 9,
            [Description("Pneumology")]
            PNEUMOLOGY = 10,
            [Description("Neurology")]
            NEUROLOGY = 11,
            [Description("Dentistry")]
            DENTISTRY = 12,
            [Description("Ophthalmology")]
            OPHTHALMOLOGY = 13,
            [Description("Orthopedics")]
            ORTHOPEDICS = 14,
            [Description("Pediatrics")]
            PEDIATRICS = 15,
            [Description("Psychology")]
            PSYCHOLOGY = 16,
            [Description("Psychiatry")]
            PSYCHIATRY = 17,
            [Description("Rheumatology")]
            RHEUMATOLOGY = 18,
            [Description("Physical Therapy and Rehabilitation")]
            PHYSICAL_THERAPY = 19,
            [Description("Traumatology")]
            TRAUMATOLOGY = 20,
            [Description("Urology")]
            UROLOGY = 21
        }

        public enum BloodType
        {
            [Description("AB+")]
            ABP = 1,
            [Description("AB-")]
            ABM = 2,
            [Description("A+")]
            AP = 3,
            [Description("A-")]
            AM = 4,
            [Description("B+")]
            BP = 5,
            [Description("B-")]
            BM = 6,
            [Description("O+")]
            OP = 7,
            [Description("O-")]
            OM = 8
        }

        public enum DocumentType
        {
            [Description("DNI")]
            DNI = 8,
            [Description("Pasaporte")]
            PASAPORTE = 9,
            [Description("Carné de extranjería")]
            CARNET_EXTRANJERIA = 12
        }

        public enum EducationalAttainment
        {
            [Description("Superior")]
            SUPERIOR = 1,
            [Description("Secundaria")]
            SECUNDARIA = 2,
            [Description("Primaria")]
            PRIMARIA = 3,
            [Description("Ninguno")]
            NINGUNO = 4
        }

        public enum HomeMaterial
        {
            [Description("Noble")]
            NOBLE = 1,
            [Description("Seminoble")]
            SEMINOBLE = 2,
            [Description("Precario")]
            PRECARIO = 3
        }

        public enum HomeOwnership
        {
            [Description("Alquilada")]
            ALQUILADA = 1,
            [Description("Propia")]
            PROPIA = 2,
            [Description("Otra")]
            INVASION = 3
        }

        public enum HomeType
        {
            [Description("Urbana")]
            URBANO = 1,
            [Description("Periférica")]
            PERIFERICO = 2,
            [Description("Rural")]
            RURAL = 3
        }

        public enum MaritalStatus
        {
            [Description("Soltero")]
            SOLTERO = 1,
            [Description("Casado")]
            CASADO = 2,
            [Description("Divorciado")]
            DIVORCIADO = 3,
            [Description("Viudo")]
            VIUDO = 4,
            [Description("Conviviente")]
            CONVIVIENTE = 5
        }

        public enum Permission
        {
            [Description("Permiso para generar reportes")]
            GENERATE_REPORT = 1,
            [Description("Permisos de administrador")]
            ADMIN = 2,
            [Description("Permiso para afiliar pacientes")]
            AFFILIATE = 3,
            [Description("Permiso para realizar triaje")]
            TRIAGE = 4,
            [Description("Permiso para llenar hojas médicas")]
            ASSESS = 5,
            [Description("Permiso para ver resultados de laboratorio")]
            READ_LAB_RESULTS = 6,
            [Description("Permiso para ingresar resultados de laboratorio")]
            WRITE_LAB_RESULTS = 7
        }

        public enum PhysicalActivity
        {
            [Description("Ninguna")]
            NINGUNA = 1,
            [Description("Moderada")]
            MODERADA = 2,
            [Description("Intensa")]
            INTENSA = 3
        }
        public enum Hunger
        {
            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }

        public enum AuscultationSite
        {
            AORTICO = 1,
            TRICUSPIDEO = 2,
            MITRAL = 3,
            PULMONAR = 4
        }
        public enum CapillaryRefillLLM
        {
            NORMAL = 1,
            PROLONGADO = 2
        }
        public enum CapillaryRefillLRM
        {
            NORMAL = 1,
            PROLONGADO = 2
        }

        public enum CardiacPressureIntensity
        {
            NORMAL = 1,
            PROLONGADO = 2,
        }
        public enum CardiacPressureRhythm
        {
            NORMAL = 1,
            PROLONGADO = 2,
        }
        public enum CardiovascularSymptom
        {
            DISNEA = 1,
            DISNEA_PAROXISTICA_NOCTURNA = 2,
            EDEMA = 3,
            OPTOPNEA = 4,
            DOLORTORAXICO = 5,
            DOLORPRECORDIAL = 6,
            ANGINA = 7,
            PALPITACIONES = 8,
            CLAUDICACION_INTERMITENTE = 9,
            CIANOSIS = 10,
            SINCOPE = 11,
            CEFALEA = 12,
            MAREOS = 13
        }
        public enum GastrointestinalSemiology
        {
            NORMAL = 1,
            HEPATO_ESPLENOMEGALIA = 2
        }
        public enum PedalPulsesL
        {
            NORMAL = 1,
            AUSENTE = 2,
            DISMINUIDO = 3
        }
        public enum PedalPulsesR
        {
            NORMAL = 1,
            PROLONGADO = 2
        }

        public enum PulsesLLM
        {
            NORMAL = 1,
            AUSENTE = 2,
            DISMINUIDO = 3

        }
        public enum PulsesLRM
        {
            NORMAL = 1,
            AUSENTE = 2,
            DISMINUIDO = 3
        }
        public enum RadialPulsesL
        {
            NORMAL = 1,
            AUSENTE = 2,
            DISMINUIDO = 3
        }
        public enum RadialPulsesR
        {
            NORMAL = 1,
            AUSENTE = 2,
            DISMINUIDO = 3
        }

        public enum VesicularWhisperL
        {
            NORMAL = 1,
            RONCANTE = 2,
            SUBCREPITANTE = 3,
            CREPITANTE = 4
        }
        public enum VesicularWhisperR
        {
            NORMAL = 1,
            RONCANTE = 2,
            SUBCREPITANTE = 3,
            CREPITANTE = 4
        }
        public enum Deposition
        {
            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }
        public enum Sleep
        {
            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }
        public enum Thirst
        {

            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }
        public enum Urine
        {
            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }

        public enum WeightEvolution
        {
            NORMAL = 1,
            DISMINUIDO = 2,
            AUMENTADO = 3
        }
        public enum Medicine
        {
            ANTIHIPERTENSIVOS = 1,
            ANTICOAGULANTES = 2,
            HIPOLIPEMIANTES = 3,
            ANTIAGREGANTESPLAQUETARIOS = 4,
            AINESMED = 5
        }
        public enum Background
        {
            HIPERTENSION_ARTERIAL = 1,
            GLUCOSA_ELEVADA = 2,
            DIABETES_MELITUS_I = 3,
            DIABETES_MELITUS_II = 4,
            DISLIPIDEMIA = 5,
            TUBERCULOSIS = 6,
            CANCER = 7,
            ENFERMEDAD_RENAL = 8,
            ENFERMEDAD_CARDIOVASCULAR = 9
        }
        public enum Sex
        {
            M = 1,
            F = 2
        }

    }
}

