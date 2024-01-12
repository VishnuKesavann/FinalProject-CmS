using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Models
{
    public partial class MainCMS_dbContext : DbContext
    {
        public MainCMS_dbContext()
        {
        }

        public MainCMS_dbContext(DbContextOptions<MainCMS_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<ConsultBill> ConsultBill { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Diagnosis> Diagnosis { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<LabBillGeneration> LabBillGeneration { get; set; }
        public virtual DbSet<LabPresc> LabPresc { get; set; }
        public virtual DbSet<LabReportGeneration> LabReportGeneration { get; set; }
        public virtual DbSet<Laboratory> Laboratory { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicinePresc> MedicinePresc { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientHistory> PatientHistory { get; set; }
        public virtual DbSet<PrescriptionBill> PrescriptionBill { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = VISHNU\\SQLEXPRESS; Initial Catalog = MainCMS_db; Integrated security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("appointment_Id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("appointment_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CheckUpStatus)
                    .IsRequired()
                    .HasColumnName("CheckUp_Status")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CONFIRMED')");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_ID");

                entity.Property(e => e.PatientId).HasColumnName("patient_Id");

                entity.Property(e => e.TokenNo).HasColumnName("token_No");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Doctor1");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient1");
            });

            modelBuilder.Entity<ConsultBill>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__Consult___D733892B8D94A490");

                entity.ToTable("Consult_Bill");

                entity.Property(e => e.BillId).HasColumnName("bill_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_Id");

                entity.Property(e => e.RegisterFees)
                    .HasColumnName("register_Fees")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalAmt)
                    .HasColumnName("total_Amt")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.ConsultBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("department_Id");

                entity.Property(e => e.Department1)
                    .HasColumnName("department")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_Id");

                entity.Property(e => e.DiagnosisDesc)
                    .HasColumnName("diagnosis_Desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocNotes)
                    .HasColumnName("doc_Notes")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Symptoms)
                    .HasColumnName("symptoms")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Diagnosis)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Diagnosis__appoi__45F365D3");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("doctor_ID");

                entity.Property(e => e.ConsultationFee).HasColumnName("consultation_Fee");

                entity.Property(e => e.SpecializationId).HasColumnName("specialization_Id");

                entity.Property(e => e.StaffId).HasColumnName("staff_Id");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Doctor__speciali__38996AB5");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Doctor__staff_Id__37A5467C");
            });

            modelBuilder.Entity<LabBillGeneration>(entity =>
            {
                entity.HasKey(e => e.LabbillId)
                    .HasName("PK__LabBillG__E68C5DAD535898CF");

                entity.Property(e => e.LabbillId).HasColumnName("labbill_Id");

                entity.Property(e => e.LabbillDate)
                    .HasColumnName("labbill_Date")
                    .HasColumnType("date");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.TestId).HasColumnName("test_Id");

                entity.Property(e => e.TotalAmount).HasColumnName("total_Amount");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LabBillGeneration)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__LabBillGe__Patie__628FA481");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.LabBillGeneration)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__LabBillGe__test___6383C8BA");
            });

            modelBuilder.Entity<LabPresc>(entity =>
            {
                entity.ToTable("Lab_Presc");

                entity.Property(e => e.LabPrescId).HasColumnName("labPresc_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");

                entity.Property(e => e.LabNote)
                    .HasColumnName("lab_Note")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LabtestName)
                    .HasColumnName("labtest_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LabtestStatus)
                    .IsRequired()
                    .HasColumnName("labtest_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('PENDING')");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabPresc)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Lab_Presc__appoi__5441852A");
            });

            modelBuilder.Entity<LabReportGeneration>(entity =>
            {
                entity.HasKey(e => e.LabreportId)
                    .HasName("PK__LabRepor__775EB86110F7AEEE");

                entity.Property(e => e.LabreportId).HasColumnName("labreport_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_Id");

                entity.Property(e => e.LabResult)
                    .IsRequired()
                    .HasColumnName("lab_Result")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate)
                    .HasColumnName("report_Date")
                    .HasColumnType("date");

                entity.Property(e => e.StaffId).HasColumnName("staff_Id");

                entity.Property(e => e.TestId).HasColumnName("test_Id");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabReport__appoi__5DCAEF64");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__LabReport__staff__5FB337D6");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.LabReportGeneration)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__LabReport__test___5EBF139D");
            });

            modelBuilder.Entity<Laboratory>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Laborato__F3FE002AF8A00B79");

                entity.Property(e => e.TestId).HasColumnName("test_Id");

                entity.Property(e => e.HighRange)
                    .HasColumnName("high_Range")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LowRange)
                    .HasColumnName("low_Range")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .HasColumnName("test_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestPrice)
                    .HasColumnName("test_Price")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("medicine_Id");

                entity.Property(e => e.CompanyName)
                    .HasColumnName("company_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenericName)
                    .HasColumnName("generic_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineCode).HasColumnName("medicine_Code");

                entity.Property(e => e.MedicineName)
                    .HasColumnName("medicine_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineStock).HasColumnName("medicine_Stock");

                entity.Property(e => e.MedicineUnitPrice)
                    .HasColumnName("medicine_unitPrice")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<MedicinePresc>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__Medicine__3EE1708071397887");

                entity.ToTable("Medicine_Presc");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("appointment_Id");

                entity.Property(e => e.Dosage)
                    .HasColumnName("dosage")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DosageDays).HasColumnName("dosage_Days");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_id");

                entity.Property(e => e.MedpresName)
                    .HasColumnName("medpres_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicinePresc)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Medicine___appoi__48CFD27E");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicinePresc)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Medicine___medic__19DFD96B");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("patient_Id");

                entity.Property(e => e.BloodGroup)
                    .IsRequired()
                    .HasColumnName("bloodGroup")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PatientAddr)
                    .IsRequired()
                    .HasColumnName("patient_Addr")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("patient_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.PatientEmail)
                    .HasColumnName("patient_Email")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("patient_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientStatus)
                    .IsRequired()
                    .HasColumnName("patient_status")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVE')");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.RegisterNo)
                    .HasColumnName("register_No")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientHistory>(entity =>
            {
                entity.HasKey(e => e.PatienthisId)
                    .HasName("PK__Patient___70066D53F9FF4D19");

                entity.ToTable("Patient_History");

                entity.Property(e => e.PatienthisId).HasColumnName("patienthis_Id");

                entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_Id");

                entity.Property(e => e.LabPrescId).HasColumnName("labPresc_Id");

                entity.Property(e => e.LabreportId).HasColumnName("labreport_Id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_Id");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK__Patient_H__diagn__571DF1D5");

                entity.HasOne(d => d.LabPresc)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.LabPrescId)
                    .HasConstraintName("FK__Patient_H__labPr__59063A47");

                entity.HasOne(d => d.Labreport)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.LabreportId)
                    .HasConstraintName("FK__Patient_H__labre__6477ECF3");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__Patient_H__presc__5812160E");
            });

            modelBuilder.Entity<PrescriptionBill>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__Prescrip__D733892B6F3CAACD");

                entity.ToTable("Prescription_Bill");

                entity.Property(e => e.BillId).HasColumnName("bill_Id");

                entity.Property(e => e.BillDate)
                    .HasColumnName("bill_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MedicineId).HasColumnName("medicine_Id");

                entity.Property(e => e.PatientId).HasColumnName("patient_Id");

                entity.Property(e => e.PrescriptionId).HasColumnName("prescription_Id");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_Amount")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionBill)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Prescript__medic__6E01572D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PrescriptionBill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Prescript__patie__6EF57B66");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.PrescriptionBill)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__Prescript__presc__6D0D32F4");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.Property(e => e.QualificationId).HasColumnName("qualification_Id");

                entity.Property(e => e.Qualification1)
                    .HasColumnName("qualification")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_Id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationId).HasColumnName("specialization_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_Id");

                entity.Property(e => e.SpecializationName)
                    .HasColumnName("specialization_Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Specialization)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Specializ__depar__30F848ED");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasColumnName("staff_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_Id");

                entity.Property(e => e.EMail)
                    .HasColumnName("E_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId).HasColumnName("login_Id");

                entity.Property(e => e.QualificationId).HasColumnName("qualification_Id");

                entity.Property(e => e.RoleId).HasColumnName("role_Id");

                entity.Property(e => e.SpecializationId).HasColumnName("specialization_Id");

                entity.Property(e => e.StaffAddress)
                    .HasColumnName("staff_Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffBloodgroup)
                    .HasColumnName("staff_Bloodgroup")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob)
                    .HasColumnName("staff_Dob")
                    .HasColumnType("date");

                entity.Property(e => e.StaffGender)
                    .HasColumnName("staff_Gender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffJoindate)
                    .HasColumnName("staff_Joindate")
                    .HasColumnType("date");

                entity.Property(e => e.StaffMobieno).HasColumnName("staff_Mobieno");

                entity.Property(e => e.StaffName)
                    .HasColumnName("staff_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffSalary).HasColumnName("staff_Salary");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Staff__departmen__1CBC4616");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__Staff__login_Id__34C8D9D1");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK__Staff__qualifica__33D4B598");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Staff__role_Id__282DF8C2");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Staff__specializ__2739D489");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__UserLogi__C2CA7DB3D84BFF01");

                entity.Property(e => e.LoginId).HasColumnName("login_ID");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_Id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserLogin__role___2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
