using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.DataModels
{
    public partial class registroclinicocoreContext : IdentityDbContext<user, role, long>
    {
        public registroclinicocoreContext()
        {
        }

        public registroclinicocoreContext(DbContextOptions<registroclinicocoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<cardiovascularnote> cardiovascularnotes { get; set; }
        public virtual DbSet<cardiovascularnote_cardiovascularsymptom> cardiovascularnote_cardiovascularsymptoms { get; set; }
        public virtual DbSet<chapter> chapters { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<diagnosis> diagnoses { get; set; }
        public virtual DbSet<district> districts { get; set; }
        public virtual DbSet<establishment> establishments { get; set; }
        public virtual DbSet<exam> exams { get; set; }
        public virtual DbSet<lab> labs { get; set; }
        public virtual DbSet<lab_upload_result> lab_upload_results { get; set; }
        public virtual DbSet<medic> medics { get; set; }
        public virtual DbSet<medic_specialty> medic_specialties { get; set; }
        public virtual DbSet<medicine> medicines { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<notediagnosis> notediagnoses { get; set; }
        public virtual DbSet<noteexam> noteexams { get; set; }
        public virtual DbSet<noteexam_upload> noteexam_uploads { get; set; }
        public virtual DbSet<notemedicine> notemedicines { get; set; }
        public virtual DbSet<notereferral> notereferrals { get; set; }
        public virtual DbSet<nurse> nurses { get; set; }
        public virtual DbSet<nurse_specialty> nurse_specialties { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<patient_allergy> patient_allergies { get; set; }
        public virtual DbSet<patient_fatherbackground> patient_fatherbackgrounds { get; set; }
        public virtual DbSet<patient_medic_permission> patient_medic_permissions { get; set; }
        public virtual DbSet<patient_medicine> patient_medicines { get; set; }
        public virtual DbSet<patient_motherbackground> patient_motherbackgrounds { get; set; }
        public virtual DbSet<patient_personalbackground> patient_personalbackgrounds { get; set; }
        public virtual DbSet<patient_symptom> patient_symptoms { get; set; }
        public virtual DbSet<province> provinces { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<role_permission> role_permissions { get; set; }
        public virtual DbSet<speciality> specialities { get; set; }
        public virtual DbSet<symptom> symptoms { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<triage> triages { get; set; }
        public virtual DbSet<upload> uploads { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           ;
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8JJ6GUN\\SQLEXPRESS;Database=registroclinico-core;Persist Security Info=True;User ID=registroclinico;Password=Password10*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<cardiovascularnote>(entity =>
            {
                entity.ToTable("cardiovascularnote", "registroclinico");

                entity.Property(e => e.auscultationSite).HasMaxLength(255);

                entity.Property(e => e.capillaryRefillLLM).HasMaxLength(255);

                entity.Property(e => e.capillaryRefillLRM).HasMaxLength(255);

                entity.Property(e => e.cardiacPressureIntensity).HasMaxLength(255);

                entity.Property(e => e.cardiacPressureRhythm).HasMaxLength(255);

                entity.Property(e => e.gastrointestinalSemiology).HasMaxLength(255);

                entity.Property(e => e.otherSymptoms).HasMaxLength(255);

                entity.Property(e => e.pedalPulsesL).HasMaxLength(255);

                entity.Property(e => e.pedalPulsesR).HasMaxLength(255);

                entity.Property(e => e.pulsesLLM).HasMaxLength(255);

                entity.Property(e => e.pulsesLRM).HasMaxLength(255);

                entity.Property(e => e.radialPulsesL).HasMaxLength(255);

                entity.Property(e => e.radialPulsesR).HasMaxLength(255);

                entity.Property(e => e.vesicularWhisperL).HasMaxLength(255);

                entity.Property(e => e.vesicularWhisperR).HasMaxLength(255);

                entity.HasOne(d => d.note)
                    .WithMany(p => p.cardiovascularnotes)
                    .HasForeignKey(d => d.note_id)
                    .HasConstraintName("FK_cardiovascularnote_note");
            });

            modelBuilder.Entity<cardiovascularnote_cardiovascularsymptom>(entity =>
            {
                entity.ToTable("cardiovascularnote_cardiovascularsymptoms", "registroclinico");

                entity.Property(e => e.cardiovascularSymptoms).HasMaxLength(255);

                entity.HasOne(d => d.cardiovascularNote)
                    .WithMany(p => p.cardiovascularnote_cardiovascularsymptoms)
                    .HasForeignKey(d => d.cardiovascularNote_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cardiovascularnote_cardiovascularsymptoms_cardiovascularnote");
            });

            modelBuilder.Entity<chapter>(entity =>
            {
                entity.ToTable("chapter", "registroclinico");

                entity.Property(e => e.code)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<country>(entity =>
            {
                entity.ToTable("country", "registroclinico");

                entity.HasIndex(e => e.name, "country$UK_t81fgsgaq5hcgbixtau1ptk3")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<department>(entity =>
            {
                entity.ToTable("department", "registroclinico");

                entity.HasIndex(e => e.name, "department$UK_biw7tevwc07g3iutlbmkes0cm")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.country)
                    .WithMany(p => p.departments)
                    .HasForeignKey(d => d.country_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department$FK43w9v6odn5ebkcotastqgn1dw");
            });

            modelBuilder.Entity<diagnosis>(entity =>
            {
                entity.ToTable("diagnosis", "registroclinico");

                entity.Property(e => e.code)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.chapter)
                    .WithMany(p => p.diagnoses)
                    .HasForeignKey(d => d.chapter_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("diagnosis$FKdkejwjwwrvhod7ilsu9u62d4r");
            });

            modelBuilder.Entity<district>(entity =>
            {
                entity.ToTable("district", "registroclinico");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.province)
                    .WithMany(p => p.districts)
                    .HasForeignKey(d => d.province_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("district$FKft8pluvn8a75sbmt3bn3o11ph");
            });

            modelBuilder.Entity<establishment>(entity =>
            {
                entity.ToTable("establishment", "registroclinico");

                entity.HasIndex(e => e.name, "establishment$UK_odanp3w4u1swk7mhgmv7rvxq0")
                    .IsUnique();

                entity.Property(e => e.address).HasMaxLength(255);

                entity.Property(e => e.deleted)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.establishmentType).HasMaxLength(255);

                entity.Property(e => e.initials).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.phone).HasMaxLength(255);
            });

            modelBuilder.Entity<exam>(entity =>
            {
                entity.ToTable("exam", "registroclinico");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.type).HasMaxLength(255);
            });

            modelBuilder.Entity<lab>(entity =>
            {
                entity.ToTable("lab", "registroclinico");

                entity.Property(e => e.labName).HasMaxLength(255);

                entity.Property(e => e.parentCompany).HasMaxLength(255);

                entity.HasOne(d => d.user)
                    .WithMany(p => p.labs)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->labs");
            });

            modelBuilder.Entity<lab_upload_result>(entity =>
            {
                entity.ToTable("lab_upload_result", "registroclinico");

                entity.Property(e => e.dateUploaded).HasColumnType("datetime");

                entity.Property(e => e.fileName).HasMaxLength(255);

                entity.HasOne(d => d.lab)
                    .WithMany(p => p.lab_upload_results)
                    .HasForeignKey(d => d.lab_id)
                    .HasConstraintName("lab->lab_upload_result");

                entity.HasOne(d => d.medic_user)
                    .WithMany(p => p.lab_upload_results)
                    .HasForeignKey(d => d.medic_user_id)
                    .HasConstraintName("medic->lab_upload_result");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.lab_upload_results)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->lab_upload_result");
            });

            modelBuilder.Entity<medic>(entity =>
            {
                entity.ToTable("medic", "registroclinico");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.cmp).HasMaxLength(255);

                entity.Property(e => e.rne).HasMaxLength(255);

                entity.HasOne(d => d.user)
                    .WithOne(p => p.medic)
                    .HasForeignKey<medic>(d => d.id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic$FKa63sueb7mgdy1vvoejcxsafil");
            });

            modelBuilder.Entity<medic_specialty>(entity =>
            {
                entity.HasKey(e => e.Medic_id);

                entity.ToTable("medic_specialties", "registroclinico");

                entity.Property(e => e.Medic_id).ValueGeneratedNever();

                entity.Property(e => e.specialties).HasMaxLength(255);

                entity.HasOne(d => d.Medic)
                    .WithOne(p => p.medic_specialty)
                    .HasForeignKey<medic_specialty>(d => d.Medic_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic_specialties$FKgyco417bacd28ti07gdpxwvsr");
            });

            modelBuilder.Entity<medicine>(entity =>
            {
                entity.ToTable("medicine", "registroclinico");

                entity.Property(e => e.concentration).HasMaxLength(255);

                entity.Property(e => e.form).HasMaxLength(255);

                entity.Property(e => e.healthRegistration).HasMaxLength(255);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.owner).HasMaxLength(255);

                entity.Property(e => e.presentation).HasMaxLength(255);
            });

            modelBuilder.Entity<note>(entity =>
            {
                entity.ToTable("note", "registroclinico");

                entity.Property(e => e.age).HasMaxLength(255);

                entity.Property(e => e.category).HasMaxLength(50);

                entity.Property(e => e.createdBy).HasMaxLength(255);

                entity.Property(e => e.createdDate).HasColumnType("date");

                entity.Property(e => e.isSignatureDraw).HasDefaultValueSql("((0))");

                entity.Property(e => e.modifiedBy).HasMaxLength(255);

                entity.Property(e => e.modifiedDate).HasColumnType("date");

                entity.Property(e => e.notes).IsUnicode(false);

                entity.Property(e => e.prognosis)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.sicknessUnit).HasMaxLength(255);

                entity.Property(e => e.signatuteText).HasMaxLength(200);

                entity.Property(e => e.specialty).HasMaxLength(255);

                entity.Property(e => e.status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'open')");

                entity.Property(e => e.symptom).HasMaxLength(255);

                entity.HasOne(d => d.establishment)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.establishment_id)
                    .HasConstraintName("FK_note_establishment");

                entity.HasOne(d => d.medic)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.medic_id)
                    .HasConstraintName("FK_note_medic");

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_note_patient");

                entity.HasOne(d => d.ticket)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.ticket_id)
                    .HasConstraintName("FK_note_ticket");

                entity.HasOne(d => d.triage)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.triage_id)
                    .HasConstraintName("FK_note_triage");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_note_users");
            });

            modelBuilder.Entity<notediagnosis>(entity =>
            {
                entity.ToTable("notediagnosis", "registroclinico");

                entity.Property(e => e.diagnosisType).HasMaxLength(255);

                entity.HasOne(d => d.diagnosis)
                    .WithMany(p => p.notediagnoses)
                    .HasForeignKey(d => d.diagnosis_id)
                    .HasConstraintName("FK_notediagnosis_diagnosis");

                entity.HasOne(d => d.note)
                    .WithMany(p => p.notediagnoses)
                    .HasForeignKey(d => d.note_id)
                    .HasConstraintName("FK_notediagnosis_note");
            });

            modelBuilder.Entity<noteexam>(entity =>
            {
                entity.ToTable("noteexam", "registroclinico");

                entity.Property(e => e.observation).HasMaxLength(255);

                entity.Property(e => e.specification).HasMaxLength(255);

                entity.Property(e => e.status).HasMaxLength(255);

                entity.HasOne(d => d.exam)
                    .WithMany(p => p.noteexams)
                    .HasForeignKey(d => d.exam_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_noteexam_exam");

                entity.HasOne(d => d.note)
                    .WithMany(p => p.noteexams)
                    .HasForeignKey(d => d.note_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_noteexam_note");
            });

            modelBuilder.Entity<noteexam_upload>(entity =>
            {
                entity.HasKey(e => e.id)
                    .IsClustered(false);

                entity.ToTable("noteexam_upload", "registroclinico");

                entity.HasIndex(e => e.uploads_id, "noteexam_upload$UK_ff7t6g8kbapqe17vt5yjio5da")
                    .IsUnique()
                    .IsClustered();

                entity.HasOne(d => d.noteExam)
                    .WithMany(p => p.noteexam_uploads)
                    .HasForeignKey(d => d.noteExam_id)
                    .HasConstraintName("FK_noteexam_upload_noteexam");

                entity.HasOne(d => d.uploads)
                    .WithOne(p => p.noteexam_upload)
                    .HasForeignKey<noteexam_upload>(d => d.uploads_id)
                    .HasConstraintName("FK_noteexam_upload_upload");
            });

            modelBuilder.Entity<notemedicine>(entity =>
            {
                entity.ToTable("notemedicine", "registroclinico");

                entity.Property(e => e.durationUnit).HasMaxLength(255);

                entity.Property(e => e.frequencyUnit).HasMaxLength(255);

                entity.Property(e => e.indication).HasMaxLength(255);

                entity.HasOne(d => d.medicine)
                    .WithMany(p => p.notemedicines)
                    .HasForeignKey(d => d.medicine_id)
                    .HasConstraintName("FK_notemedicine_medicine");

                entity.HasOne(d => d.note)
                    .WithMany(p => p.notemedicines)
                    .HasForeignKey(d => d.note_id)
                    .HasConstraintName("FK_notemedicine_note");
            });

            modelBuilder.Entity<notereferral>(entity =>
            {
                entity.ToTable("notereferral", "registroclinico");

                entity.Property(e => e.reason).HasMaxLength(255);

                entity.Property(e => e.specialty).HasMaxLength(255);

                entity.HasOne(d => d.note)
                    .WithMany(p => p.notereferrals)
                    .HasForeignKey(d => d.note_id)
                    .HasConstraintName("FK_notereferral_note");
            });

            modelBuilder.Entity<nurse>(entity =>
            {
                entity.ToTable("nurse", "registroclinico");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.medicRegistration).HasMaxLength(255);

                entity.HasOne(d => d.idNavigation)
                    .WithOne(p => p.nurse)
                    .HasForeignKey<nurse>(d => d.id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurse$FKinc1dd4o81eetpkv731etxb34");
            });

            modelBuilder.Entity<nurse_specialty>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("nurse_specialties", "registroclinico");

                entity.Property(e => e.specialties).HasMaxLength(255);

                entity.HasOne(d => d.Nurse)
                    .WithMany()
                    .HasForeignKey(d => d.Nurse_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nurse_specialties$FK6nc16jusxlaag0qyhvwjs89fk");
            });

            modelBuilder.Entity<patient>(entity =>
            {
                entity.ToTable("patient", "registroclinico");

                entity.Property(e => e.alcohol).HasMaxLength(255);

                entity.Property(e => e.bloodType).HasMaxLength(255);

                entity.Property(e => e.createdTicket).HasMaxLength(255);

                entity.Property(e => e.educationalAttainment).HasMaxLength(255);

                entity.Property(e => e.fruitsVegetables).HasMaxLength(255);

                entity.Property(e => e.highGlucose).HasMaxLength(255);

                entity.Property(e => e.homeMaterial).HasMaxLength(255);

                entity.Property(e => e.homeOwnership).HasMaxLength(255);

                entity.Property(e => e.homeType).HasMaxLength(255);

                entity.Property(e => e.occupation).HasMaxLength(255);

                entity.Property(e => e.otherAllergies).HasMaxLength(255);

                entity.Property(e => e.otherFatherBackground).HasMaxLength(255);

                entity.Property(e => e.otherMedicines).HasMaxLength(255);

                entity.Property(e => e.otherMotherBackground).HasMaxLength(255);

                entity.Property(e => e.otherPersonalBackground).HasMaxLength(255);

                entity.Property(e => e.physicalActivity).HasMaxLength(255);

                entity.Property(e => e.race).HasMaxLength(50);

                entity.HasOne(d => d.department)
                    .WithMany(p => p.patients)
                    .HasForeignKey(d => d.departmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_department");

                entity.HasOne(d => d.user)
                    .WithMany(p => p.patients)
                    .HasForeignKey(d => d.user_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user->patients");
            });

            modelBuilder.Entity<patient_allergy>(entity =>
            {
                entity.ToTable("patient_allergies", "registroclinico");

                entity.Property(e => e.allergies).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_allergies)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_allergies_patient");
            });

            modelBuilder.Entity<patient_fatherbackground>(entity =>
            {
                entity.ToTable("patient_fatherbackgrounds", "registroclinico");

                entity.Property(e => e.fatherBackgrounds).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_fatherbackgrounds)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_fatherbackgrounds_patient");
            });

            modelBuilder.Entity<patient_medic_permission>(entity =>
            {
                entity.HasKey(e => new { e.patient_id, e.medic_id })
                    .HasName("pk_patient_medic");

                entity.ToTable("patient_medic_permission", "registroclinico");

                entity.HasOne(d => d.medic)
                    .WithMany(p => p.patient_medic_permissions)
                    .HasForeignKey(d => d.medic_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("medic_$FKgyco417bacd28ti07gdpxwvsr");

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_medic_permissions)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_$FKgyco417bacd28ti07gdpxwvsr");
            });

            modelBuilder.Entity<patient_medicine>(entity =>
            {
                entity.ToTable("patient_medicines", "registroclinico");

                entity.Property(e => e.medicines).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_medicines)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_medicines_patient");
            });

            modelBuilder.Entity<patient_motherbackground>(entity =>
            {
                entity.ToTable("patient_motherbackgrounds", "registroclinico");

                entity.Property(e => e.motherBackgrounds).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_motherbackgrounds)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_motherbackgrounds_patient");
            });

            modelBuilder.Entity<patient_personalbackground>(entity =>
            {
                entity.ToTable("patient_personalbackgrounds", "registroclinico");

                entity.Property(e => e.personalBackgrounds).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_personalbackgrounds)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_personalbackgrounds_patient");
            });

            modelBuilder.Entity<patient_symptom>(entity =>
            {
                entity.ToTable("patient_symptoms", "registroclinico");

                entity.Property(e => e.custom_symptom).HasMaxLength(255);

                entity.HasOne(d => d.patient)
                    .WithMany(p => p.patient_symptoms)
                    .HasForeignKey(d => d.patient_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_patient_symptoms_patient");

                entity.HasOne(d => d.symptoms)
                    .WithMany(p => p.patient_symptoms)
                    .HasForeignKey(d => d.symptoms_id)
                    .HasConstraintName("FK_patient_symptoms_symptoms");
            });

            modelBuilder.Entity<province>(entity =>
            {
                entity.ToTable("province", "registroclinico");

                entity.HasIndex(e => e.name, "province$UK_moejme3ohebd07k2d4b70l8vh")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.department)
                    .WithMany(p => p.provinces)
                    .HasForeignKey(d => d.department_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("province$FK3joxh8ppnjhvvt1485efkpxm8");
            });

            modelBuilder.Entity<role>(entity =>
            {
                entity.ToTable("role", "registroclinico");

              

               
            });

            modelBuilder.Entity<role_permission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("role_permissions", "registroclinico");

                entity.Property(e => e.permissions).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.Role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_permissions$FKr5u91l7q7yikdobgi0lhntse6");
            });

            modelBuilder.Entity<speciality>(entity =>
            {
                entity.ToTable("specialities", "registroclinico");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<symptom>(entity =>
            {
                entity.ToTable("symptoms", "registroclinico");

                entity.HasIndex(e => e.name, "symptom$UK_t81fgsgaq5hcgbixtau1ptk3")
                    .IsUnique();

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ticket>(entity =>
            {
                entity.ToTable("ticket", "registroclinico");

                entity.Property(e => e.nroTicket).HasMaxLength(255);

                entity.Property(e => e.serie).HasMaxLength(255);

                entity.Property(e => e.status).HasMaxLength(255);
            });

            modelBuilder.Entity<triage>(entity =>
            {
                entity.ToTable("triage", "registroclinico");

                entity.Property(e => e.createdBy).HasMaxLength(255);

                entity.Property(e => e.createdDate).HasColumnType("date");

                entity.Property(e => e.deposition).HasMaxLength(255);

                entity.Property(e => e.hunger).HasMaxLength(255);

                entity.Property(e => e.modifiedBy).HasMaxLength(255);

                entity.Property(e => e.modifiedDate).HasColumnType("date");

                entity.Property(e => e.sleep).HasMaxLength(255);

                entity.Property(e => e.speciality).HasMaxLength(255);

                entity.Property(e => e.thirst).HasMaxLength(255);

                entity.Property(e => e.urine).HasMaxLength(255);

                entity.Property(e => e.weightEvolution).HasMaxLength(255);

                entity.HasOne(d => d.ticket)
                    .WithMany(p => p.triages)
                    .HasForeignKey(d => d.ticket_id)
                    .HasConstraintName("ticket -> triage");
            });

            modelBuilder.Entity<upload>(entity =>
            {
                entity.ToTable("upload", "registroclinico");

                entity.Property(e => e.createdBy).HasMaxLength(255);

                entity.Property(e => e.createdDate).HasColumnType("date");

                entity.Property(e => e.path).HasMaxLength(255);
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.ToTable("users", "registroclinico");

                entity.Property(e => e.address)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.birthday).HasColumnType("date");

                entity.Property(e => e.cellphone).HasMaxLength(255);

                entity.Property(e => e.createdBy).HasMaxLength(255);

                entity.Property(e => e.createdDate).HasPrecision(0);

                entity.Property(e => e.documentNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.documentType)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.firstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.lastNameFather)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.lastNameMother)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.maritalStatus).HasMaxLength(255);

                entity.Property(e => e.modifiedBy).HasMaxLength(255);

                entity.Property(e => e.modifiedDate).HasPrecision(0);

              

                entity.Property(e => e.phone).HasMaxLength(255);

                entity.Property(e => e.reset_token).HasDefaultValueSql("(newid())");

                entity.Property(e => e.sex)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.since).HasColumnType("date");

                entity.Property(e => e.token).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.country)
                    .WithMany(p => p.users)
                    .HasForeignKey(d => d.country_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users$FK1eit3dhanvh8r59sd30a3vyaw");

                entity.HasOne(d => d.department)
                    .WithMany(p => p.users)
                    .HasForeignKey(d => d.department_id)
                    .HasConstraintName("FK_users_department");

                entity.HasOne(d => d.district)
                    .WithMany(p => p.users)
                    .HasForeignKey(d => d.district_id)
                    .HasConstraintName("users$FKdoiykqja8oxn78j7gf3l536ta");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.users)
                    .HasForeignKey(d => d.role_id)
                    .HasConstraintName("users$FKiod6nq5d7gqshxljomqccs7tp");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
