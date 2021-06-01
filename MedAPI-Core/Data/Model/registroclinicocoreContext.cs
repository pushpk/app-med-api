using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Model
{
    public partial class registroclinicocoreContext : DbContext
    {
    

        public registroclinicocoreContext(DbContextOptions<registroclinicocoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cardiovascularnote> Cardiovascularnotes { get; set; }
        public virtual DbSet<CardiovascularnoteCardiovascularsymptom> CardiovascularnoteCardiovascularsymptoms { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Establishment> Establishments { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<LabUploadResult> LabUploadResults { get; set; }
        public virtual DbSet<Medic> Medics { get; set; }
        public virtual DbSet<MedicSpecialty> MedicSpecialties { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Notediagnosis> Notediagnoses { get; set; }
        public virtual DbSet<Noteexam> Noteexams { get; set; }
        public virtual DbSet<NoteexamUpload> NoteexamUploads { get; set; }
        public virtual DbSet<Notemedicine> Notemedicines { get; set; }
        public virtual DbSet<Notereferral> Notereferrals { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<NurseSpecialty> NurseSpecialties { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientAllergy> PatientAllergies { get; set; }
        public virtual DbSet<PatientFatherbackground> PatientFatherbackgrounds { get; set; }
        public virtual DbSet<PatientMedicPermission> PatientMedicPermissions { get; set; }
        public virtual DbSet<PatientMedicine> PatientMedicines { get; set; }
        public virtual DbSet<PatientMotherbackground> PatientMotherbackgrounds { get; set; }
        public virtual DbSet<PatientPersonalbackground> PatientPersonalbackgrounds { get; set; }
        public virtual DbSet<PatientSymptom> PatientSymptoms { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Triage> Triages { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cardiovascularnote>(entity =>
            {
                entity.ToTable("cardiovascularnote", "registroclinico");

               
            });

            modelBuilder.Entity<CardiovascularnoteCardiovascularsymptom>(entity =>
            {
                entity.ToTable("cardiovascularnote_cardiovascularsymptoms", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardiovascularNoteId).HasColumnName("cardiovascularNote_id");

                entity.Property(e => e.CardiovascularSymptoms)
                    .HasMaxLength(255)
                    .HasColumnName("cardiovascularSymptoms");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.HasOne(d => d.CardiovascularNote)
                    .WithMany(p => p.CardiovascularnoteCardiovascularsymptoms)
                    .HasForeignKey(d => d.CardiovascularNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cardiovascularnote_cardiovascularsymptoms_cardiovascularnote");
            });

            modelBuilder.Entity<Chapter>(entity =>
            {
                entity.ToTable("chapter", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country", "registroclinico");

                entity.HasIndex(e => e.Name, "country$UK_t81fgsgaq5hcgbixtau1ptk3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department", "registroclinico");

                entity.HasIndex(e => e.Name, "department$UK_biw7tevwc07g3iutlbmkes0cm")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department$FK43w9v6odn5ebkcotastqgn1dw");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("diagnosis", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChapterId).HasColumnName("chapter_id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("code");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.HasOne(d => d.Chapter)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.ChapterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("diagnosis$FKdkejwjwwrvhod7ilsu9u62d4r");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.Ubigeo).HasColumnName("ubigeo");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("district$FKft8pluvn8a75sbmt3bn3o11ph");
            });

            modelBuilder.Entity<Establishment>(entity =>
            {
                entity.ToTable("establishment", "registroclinico");

                entity.HasIndex(e => e.Name, "establishment$UK_odanp3w4u1swk7mhgmv7rvxq0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Deleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("deleted")
                    .IsFixedLength(true);

                entity.Property(e => e.EstablishmentType)
                    .HasMaxLength(255)
                    .HasColumnName("establishmentType");

                entity.Property(e => e.Initials)
                    .HasMaxLength(255)
                    .HasColumnName("initials");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("exam", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.ToTable("lab", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LabName)
                    .HasMaxLength(255)
                    .HasColumnName("labName");

                entity.Property(e => e.ParentCompany)
                    .HasMaxLength(255)
                    .HasColumnName("parentCompany");

                entity.Property(e => e.Ruc).HasColumnName("ruc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Labs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->labs");
            });

            modelBuilder.Entity<LabUploadResult>(entity =>
            {
                entity.ToTable("lab_upload_result", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.DateUploaded)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUploaded");

                entity.Property(e => e.FileContent).HasColumnName("fileContent");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .HasColumnName("fileName");

                entity.Property(e => e.LabId).HasColumnName("lab_id");

                entity.Property(e => e.MedicUserId).HasColumnName("medic_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Lab)
                    .WithMany(p => p.LabUploadResults)
                    .HasForeignKey(d => d.LabId)
                    .HasConstraintName("lab->lab_upload_result");

                entity.HasOne(d => d.MedicUser)
                    .WithMany(p => p.LabUploadResults)
                    .HasForeignKey(d => d.MedicUserId)
                    .HasConstraintName("medic->lab_upload_result");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LabUploadResults)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->lab_upload_result");
            });

            modelBuilder.Entity<Medic>(entity =>
            {
                entity.ToTable("medic", "registroclinico");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cmp)
                    .HasMaxLength(255)
                    .HasColumnName("cmp");

                entity.Property(e => e.Rne)
                    .HasMaxLength(255)
                    .HasColumnName("rne");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Medic)
                    .HasForeignKey<Medic>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic$FKa63sueb7mgdy1vvoejcxsafil");
            });

            modelBuilder.Entity<MedicSpecialty>(entity =>
            {
                entity.HasKey(e => e.MedicId);

                entity.ToTable("medic_specialties", "registroclinico");

                entity.Property(e => e.MedicId)
                    .ValueGeneratedNever()
                    .HasColumnName("Medic_id");

                entity.Property(e => e.Specialties)
                    .HasMaxLength(255)
                    .HasColumnName("specialties");

                entity.HasOne(d => d.Medic)
                    .WithOne(p => p.MedicSpecialty)
                    .HasForeignKey<MedicSpecialty>(d => d.MedicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic_specialties$FKgyco417bacd28ti07gdpxwvsr");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("medicine", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Concentration)
                    .HasMaxLength(255)
                    .HasColumnName("concentration");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Form)
                    .HasMaxLength(255)
                    .HasColumnName("form");

                entity.Property(e => e.Fractions).HasColumnName("fractions");

                entity.Property(e => e.HealthRegistration)
                    .HasMaxLength(255)
                    .HasColumnName("healthRegistration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Owner)
                    .HasMaxLength(255)
                    .HasColumnName("owner");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(255)
                    .HasColumnName("presentation");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("note", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age)
                    .HasMaxLength(255)
                    .HasColumnName("age");

                entity.Property(e => e.AttachedAttention).HasColumnName("attached_attention");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.Control).HasColumnName("control");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");

                entity.Property(e => e.EstablishmentId).HasColumnName("establishment_id");

                entity.Property(e => e.Exam).HasColumnName("exam");

                entity.Property(e => e.IsSignatureDraw)
                    .HasColumnName("isSignatureDraw")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MedicId).HasColumnName("medic_id");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasColumnName("modifiedDate");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PhysicalExam).HasColumnName("physicalExam");

                entity.Property(e => e.Prognosis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("prognosis");

                entity.Property(e => e.SecondOpinion).HasColumnName("secondOpinion");

                entity.Property(e => e.SicknessTime).HasColumnName("sicknessTime");

                entity.Property(e => e.SicknessUnit)
                    .HasMaxLength(255)
                    .HasColumnName("sicknessUnit");

                entity.Property(e => e.SignatuteDraw).HasColumnName("signatuteDraw");

                entity.Property(e => e.SignatuteText)
                    .HasMaxLength(200)
                    .HasColumnName("signatuteText");

                entity.Property(e => e.Specialty)
                    .HasMaxLength(255)
                    .HasColumnName("specialty");

                entity.Property(e => e.Stage).HasColumnName("stage");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status")
                    .HasDefaultValueSql("(N'open')");

                entity.Property(e => e.Story).HasColumnName("story");

                entity.Property(e => e.Symptom)
                    .HasMaxLength(255)
                    .HasColumnName("symptom");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.Treatment).HasColumnName("treatment");

                entity.Property(e => e.TriageId).HasColumnName("triage_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Establishment)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.EstablishmentId)
                    .HasConstraintName("FK_note_establishment");

                entity.HasOne(d => d.Medic)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.MedicId)
                    .HasConstraintName("FK_note_medic");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_note_patient");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_note_ticket");

                entity.HasOne(d => d.Triage)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.TriageId)
                    .HasConstraintName("FK_note_triage");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_note_users");
            });

            modelBuilder.Entity<Notediagnosis>(entity =>
            {
                entity.ToTable("notediagnosis", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");

                entity.Property(e => e.DiagnosisType)
                    .HasMaxLength(255)
                    .HasColumnName("diagnosisType");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.Notediagnoses)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK_notediagnosis_diagnosis");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Notediagnoses)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_notediagnosis_note");
            });

            modelBuilder.Entity<Noteexam>(entity =>
            {
                entity.ToTable("noteexam", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.Observation)
                    .HasMaxLength(255)
                    .HasColumnName("observation");

                entity.Property(e => e.Specification)
                    .HasMaxLength(255)
                    .HasColumnName("specification");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Noteexams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_noteexam_exam");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Noteexams)
                    .HasForeignKey(d => d.NoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_noteexam_note");
            });

            modelBuilder.Entity<NoteexamUpload>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("noteexam_upload", "registroclinico");

                entity.HasIndex(e => e.UploadsId, "noteexam_upload$UK_ff7t6g8kbapqe17vt5yjio5da")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NoteExamId).HasColumnName("noteExam_id");

                entity.Property(e => e.UploadsId).HasColumnName("uploads_id");

                entity.HasOne(d => d.NoteExam)
                    .WithMany(p => p.NoteexamUploads)
                    .HasForeignKey(d => d.NoteExamId)
                    .HasConstraintName("FK_noteexam_upload_noteexam");

                entity.HasOne(d => d.Uploads)
                    .WithOne(p => p.NoteexamUpload)
                    .HasForeignKey<NoteexamUpload>(d => d.UploadsId)
                    .HasConstraintName("FK_noteexam_upload_upload");
            });

            modelBuilder.Entity<Notemedicine>(entity =>
            {
                entity.ToTable("notemedicine", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DurationTime).HasColumnName("durationTime");

                entity.Property(e => e.DurationUnit)
                    .HasMaxLength(255)
                    .HasColumnName("durationUnit");

                entity.Property(e => e.FrequencyTime).HasColumnName("frequencyTime");

                entity.Property(e => e.FrequencyUnit)
                    .HasMaxLength(255)
                    .HasColumnName("frequencyUnit");

                entity.Property(e => e.Indication)
                    .HasMaxLength(255)
                    .HasColumnName("indication");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Notemedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_notemedicine_medicine");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Notemedicines)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_notemedicine_note");
            });

            modelBuilder.Entity<Notereferral>(entity =>
            {
                entity.ToTable("notereferral", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.NoteId).HasColumnName("note_id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(255)
                    .HasColumnName("reason");

                entity.Property(e => e.Specialty)
                    .HasMaxLength(255)
                    .HasColumnName("specialty");

                entity.HasOne(d => d.Note)
                    .WithMany(p => p.Notereferrals)
                    .HasForeignKey(d => d.NoteId)
                    .HasConstraintName("FK_notereferral_note");
            });

            modelBuilder.Entity<Nurse>(entity =>
            {
                entity.ToTable("nurse", "registroclinico");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MedicRegistration)
                    .HasMaxLength(255)
                    .HasColumnName("medicRegistration");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Nurse)
                    .HasForeignKey<Nurse>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurse$FKinc1dd4o81eetpkv731etxb34");
            });

            modelBuilder.Entity<NurseSpecialty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("nurse_specialties", "registroclinico");

                entity.Property(e => e.NurseId).HasColumnName("Nurse_id");

                entity.Property(e => e.Specialties)
                    .HasMaxLength(255)
                    .HasColumnName("specialties");

                entity.HasOne(d => d.Nurse)
                    .WithMany()
                    .HasForeignKey(d => d.NurseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurse_specialties$FK6nc16jusxlaag0qyhvwjs89fk");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alcohol)
                    .HasMaxLength(255)
                    .HasColumnName("alcohol");

                entity.Property(e => e.BloodType)
                    .HasMaxLength(255)
                    .HasColumnName("bloodType");

                entity.Property(e => e.CigaretteNumber).HasColumnName("cigaretteNumber");

                entity.Property(e => e.CreatedTicket)
                    .HasMaxLength(255)
                    .HasColumnName("createdTicket");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DormNumber).HasColumnName("dormNumber");

                entity.Property(e => e.EducationalAttainment)
                    .HasMaxLength(255)
                    .HasColumnName("educationalAttainment");

                entity.Property(e => e.Electricity).HasColumnName("electricity");

                entity.Property(e => e.FractureNumber).HasColumnName("fractureNumber");

                entity.Property(e => e.FruitsVegetables)
                    .HasMaxLength(255)
                    .HasColumnName("fruitsVegetables");

                entity.Property(e => e.HighGlucose)
                    .HasMaxLength(255)
                    .HasColumnName("highGlucose");

                entity.Property(e => e.HomeMaterial)
                    .HasMaxLength(255)
                    .HasColumnName("homeMaterial");

                entity.Property(e => e.HomeOwnership)
                    .HasMaxLength(255)
                    .HasColumnName("homeOwnership");

                entity.Property(e => e.HomeType)
                    .HasMaxLength(255)
                    .HasColumnName("homeType");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .HasColumnName("occupation");

                entity.Property(e => e.OtherAllergies)
                    .HasMaxLength(255)
                    .HasColumnName("otherAllergies");

                entity.Property(e => e.OtherFatherBackground)
                    .HasMaxLength(255)
                    .HasColumnName("otherFatherBackground");

                entity.Property(e => e.OtherMedicines)
                    .HasMaxLength(255)
                    .HasColumnName("otherMedicines");

                entity.Property(e => e.OtherMotherBackground)
                    .HasMaxLength(255)
                    .HasColumnName("otherMotherBackground");

                entity.Property(e => e.OtherPersonalBackground)
                    .HasMaxLength(255)
                    .HasColumnName("otherPersonalBackground");

                entity.Property(e => e.PhysicalActivity)
                    .HasMaxLength(255)
                    .HasColumnName("physicalActivity");

                entity.Property(e => e.Race)
                    .HasMaxLength(50)
                    .HasColumnName("race");

                entity.Property(e => e.ResidentNumber).HasColumnName("residentNumber");

                entity.Property(e => e.Sewage).HasColumnName("sewage");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Water).HasColumnName("water");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_department");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->patients");
            });

            modelBuilder.Entity<PatientAllergy>(entity =>
            {
                entity.ToTable("patient_allergies", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allergies)
                    .HasMaxLength(255)
                    .HasColumnName("allergies");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAllergies)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_allergies_patient");
            });

            modelBuilder.Entity<PatientFatherbackground>(entity =>
            {
                entity.ToTable("patient_fatherbackgrounds", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FatherBackgrounds)
                    .HasMaxLength(255)
                    .HasColumnName("fatherBackgrounds");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientFatherbackgrounds)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_fatherbackgrounds_patient");
            });

            modelBuilder.Entity<PatientMedicPermission>(entity =>
            {
                entity.HasKey(e => new { e.PatientId, e.MedicId })
                    .HasName("pk_patient_medic");

                entity.ToTable("patient_medic_permission", "registroclinico");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.MedicId).HasColumnName("medic_id");

                entity.Property(e => e.IsFutureRequestBlocked).HasColumnName("is_future_request_blocked");

                entity.Property(e => e.IsMedicAuthorized).HasColumnName("is_medic_authorized");

                entity.Property(e => e.IsRequestSent).HasColumnName("is_request_sent");

                entity.HasOne(d => d.Medic)
                    .WithMany(p => p.PatientMedicPermissions)
                    .HasForeignKey(d => d.MedicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic_$FKgyco417bacd28ti07gdpxwvsr");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedicPermissions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_$FKgyco417bacd28ti07gdpxwvsr");
            });

            modelBuilder.Entity<PatientMedicine>(entity =>
            {
                entity.ToTable("patient_medicines", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Medicines)
                    .HasMaxLength(255)
                    .HasColumnName("medicines");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMedicines)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_medicines_patient");
            });

            modelBuilder.Entity<PatientMotherbackground>(entity =>
            {
                entity.ToTable("patient_motherbackgrounds", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MotherBackgrounds)
                    .HasMaxLength(255)
                    .HasColumnName("motherBackgrounds");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientMotherbackgrounds)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_motherbackgrounds_patient");
            });

            modelBuilder.Entity<PatientPersonalbackground>(entity =>
            {
                entity.ToTable("patient_personalbackgrounds", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.PersonalBackgrounds)
                    .HasMaxLength(255)
                    .HasColumnName("personalBackgrounds");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientPersonalbackgrounds)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_personalbackgrounds_patient");
            });

            modelBuilder.Entity<PatientSymptom>(entity =>
            {
                entity.ToTable("patient_symptoms", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomSymptom)
                    .HasMaxLength(255)
                    .HasColumnName("custom_symptom");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.SymptomsId).HasColumnName("symptoms_id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientSymptoms)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_symptoms_patient");

                entity.HasOne(d => d.Symptoms)
                    .WithMany(p => p.PatientSymptoms)
                    .HasForeignKey(d => d.SymptomsId)
                    .HasConstraintName("FK_patient_symptoms_symptoms");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province", "registroclinico");

                entity.HasIndex(e => e.Name, "province$UK_moejme3ohebd07k2d4b70l8vh")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("province$FK3joxh8ppnjhvvt1485efkpxm8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deletable).HasColumnName("deletable");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("role_permissions", "registroclinico");

                entity.Property(e => e.Permissions)
                    .HasMaxLength(255)
                    .HasColumnName("permissions");

                entity.Property(e => e.RoleId).HasColumnName("Role_id");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_permissions$FKr5u91l7q7yikdobgi0lhntse6");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.ToTable("specialities", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("symptoms", "registroclinico");

                entity.HasIndex(e => e.Name, "symptom$UK_t81fgsgaq5hcgbixtau1ptk3")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Closed).HasColumnName("closed");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.NroTicket)
                    .HasMaxLength(255)
                    .HasColumnName("nroTicket");

                entity.Property(e => e.Serie)
                    .HasMaxLength(255)
                    .HasColumnName("serie");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Triage>(entity =>
            {
                entity.ToTable("triage", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AbdominalPerimeter).HasColumnName("abdominalPerimeter");

                entity.Property(e => e.Bmi).HasColumnName("bmi");

                entity.Property(e => e.BreathingRate).HasColumnName("breathingRate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Deposition)
                    .HasMaxLength(255)
                    .HasColumnName("deposition");

                entity.Property(e => e.DiastolicBloodPressure).HasColumnName("diastolicBloodPressure");

                entity.Property(e => e.Glycemia).HasColumnName("glycemia");

                entity.Property(e => e.HdlCholesterol).HasColumnName("hdlCholesterol");

                entity.Property(e => e.HeartRate).HasColumnName("heartRate");

                entity.Property(e => e.HeartRisk).HasColumnName("heartRisk");

                entity.Property(e => e.Hunger)
                    .HasMaxLength(255)
                    .HasColumnName("hunger");

                entity.Property(e => e.HypertensionRisk).HasColumnName("hypertensionRisk");

                entity.Property(e => e.LdlCholesterol).HasColumnName("ldlCholesterol");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("date")
                    .HasColumnName("modifiedDate");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.Saturation).HasColumnName("saturation");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Sleep)
                    .HasMaxLength(255)
                    .HasColumnName("sleep");

                entity.Property(e => e.Speciality)
                    .HasMaxLength(255)
                    .HasColumnName("speciality");

                entity.Property(e => e.SystolicBloodPressure).HasColumnName("systolicBloodPressure");

                entity.Property(e => e.Temperature).HasColumnName("temperature");

                entity.Property(e => e.Thirst)
                    .HasMaxLength(255)
                    .HasColumnName("thirst");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.TotalCholesterol).HasColumnName("totalCholesterol");

                entity.Property(e => e.Urine)
                    .HasMaxLength(255)
                    .HasColumnName("urine");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.WeightEvolution)
                    .HasMaxLength(255)
                    .HasColumnName("weightEvolution");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Triages)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("ticket -> triage");
            });

            modelBuilder.Entity<Upload>(entity =>
            {
                entity.ToTable("upload", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("createdDate");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Path)
                    .HasMaxLength(255)
                    .HasColumnName("path");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "registroclinico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(255)
                    .HasColumnName("cellphone");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .HasColumnName("createdBy");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(0)
                    .HasColumnName("createdDate");

                entity.Property(e => e.Deletable).HasColumnName("deletable");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("documentNumber");

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("documentType");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastNameFather)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("lastNameFather");

                entity.Property(e => e.LastNameMother)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("lastNameMother");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(255)
                    .HasColumnName("maritalStatus");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .HasColumnName("modifiedBy");

                entity.Property(e => e.ModifiedDate)
                    .HasPrecision(0)
                    .HasColumnName("modifiedDate");

                entity.Property(e => e.OrganDonor).HasColumnName("organDonor");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password_hash");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");

                entity.Property(e => e.ResetToken)
                    .HasColumnName("reset_token")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sex");

                entity.Property(e => e.Since)
                    .HasColumnType("date")
                    .HasColumnName("since");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users$FK1eit3dhanvh8r59sd30a3vyaw");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_users_department");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("users$FKdoiykqja8oxn78j7gf3l536ta");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("users$FKiod6nq5d7gqshxljomqccs7tp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
