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
            Normal = 1,
            Disminuido = 2,
            Aumentado = 3
        }
    }
}

