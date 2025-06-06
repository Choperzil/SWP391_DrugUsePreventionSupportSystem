﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class Drug_use_prevention_systemContext : DbContext
{
    public Drug_use_prevention_systemContext()
    {
    }

    public Drug_use_prevention_systemContext(DbContextOptions<Drug_use_prevention_systemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeGroup> AgeGroups { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentOption> AssessmentOptions { get; set; }

    public virtual DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }

    public virtual DbSet<AssessmentType> AssessmentTypes { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Consultant> Consultants { get; set; }

    public virtual DbSet<ConsultantsAvailability> ConsultantsAvailabilities { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCategory> CourseCategories { get; set; }

    public virtual DbSet<CourseQuestion> CourseQuestions { get; set; }

    public virtual DbSet<CourseQuestionOption> CourseQuestionOptions { get; set; }

    public virtual DbSet<CourseRegister> CourseRegisters { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<RiskLevel> RiskLevels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAnswer> UserAnswers { get; set; }

    public virtual DbSet<UserAssessment> UserAssessments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SQROIFG\\CHOPERZIL;Initial Catalog=Drug_use_prevention_system;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Age_grou__31981269FB889A8F");

            entity.ToTable("Age_group");

            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.MaxAge).HasColumnName("Max_age");
            entity.Property(e => e.MinAge).HasColumnName("Min_age");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__FD01B50331A2BF9D");

            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("Appointment_date");
            entity.Property(e => e.ConsultantId).HasColumnName("Consultant_ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_date");
            entity.Property(e => e.MeetingLink)
                .HasMaxLength(200)
                .HasColumnName("Meeting_link");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_date");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Consultant).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ConsultantId)
                .HasConstraintName("FK__Appointme__Consu__66603565");

            entity.HasOne(d => d.MaterialNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.Material)
                .HasConstraintName("FK__Appointme__Mater__6754599E");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Appointme__User___656C112C");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__Assessme__6B3C1D92752EB051");

            entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");
            entity.Property(e => e.AgeGroup).HasColumnName("Age_group");
            entity.Property(e => e.AssessmentType).HasColumnName("Assessment_type");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.IsActive).HasColumnName("Is_active");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.AgeGroupNavigation).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.AgeGroup)
                .HasConstraintName("FK__Assessmen__Age_g__0D7A0286");

            entity.HasOne(d => d.AssessmentTypeNavigation).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.AssessmentType)
                .HasConstraintName("FK__Assessmen__Asses__0C85DE4D");
        });

        modelBuilder.Entity<AssessmentOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Assessme__3260905E1750FFF7");

            entity.ToTable("Assessment_options");

            entity.Property(e => e.OptionId).HasColumnName("Option_ID");
            entity.Property(e => e.DisplayOrder).HasColumnName("Display_order");
            entity.Property(e => e.OptionText)
                .HasMaxLength(200)
                .HasColumnName("Option_text");
            entity.Property(e => e.OptionValue)
                .HasMaxLength(100)
                .HasColumnName("Option_value");
            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentOptions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Assessmen__Quest__19DFD96B");
        });

        modelBuilder.Entity<AssessmentQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Assessme__B0B2E4C63D208A6E");

            entity.ToTable("Assessment_questions");

            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");
            entity.Property(e => e.DisplayOrder).HasColumnName("Display_order");
            entity.Property(e => e.IsRequired).HasColumnName("Is_required");
            entity.Property(e => e.QuestionText).HasColumnName("Question_text");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .HasColumnName("Question_type");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentQuestions)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("FK__Assessmen__Asses__17036CC0");
        });

        modelBuilder.Entity<AssessmentType>(entity =>
        {
            entity.HasKey(e => e.AssessmentTypeId).HasName("PK__Assessme__9B54AECBE3BD7A3A");

            entity.ToTable("Assessment_Type");

            entity.Property(e => e.AssessmentTypeId).HasColumnName("Assessment_type_ID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__C164D0180C4869B7");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("Blog_ID");
            entity.Property(e => e.AuthorId).HasColumnName("Author_ID");
            entity.Property(e => e.PublishedDate).HasColumnName("Published_date");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Blog__Author_ID__6A30C649");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CourseId }).HasName("PK__Certific__831391CF5617F0F3");

            entity.ToTable("Certification");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.AchievedDate).HasColumnName("Achieved_date");
            entity.Property(e => e.CertificationCode)
                .HasMaxLength(100)
                .HasColumnName("Certification_code");
            entity.Property(e => e.CertificationUrl)
                .HasMaxLength(300)
                .HasColumnName("Certification_URL");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Course).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__Cours__7A672E12");

            entity.HasOne(d => d.User).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Certifica__User___797309D9");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__99FC143B1A978737");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("Comment_ID");
            entity.Property(e => e.BlogId).HasColumnName("Blog_ID");
            entity.Property(e => e.PostDate)
                .HasColumnType("datetime")
                .HasColumnName("Post_date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Blog).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BlogId)
                .HasConstraintName("FK__Comment__Blog_ID__6E01572D");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__User_ID__6D0D32F4");
        });

        modelBuilder.Entity<Consultant>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Consulta__78A1A19C20DD7A54");

            entity.Property(e => e.ConsultantId).HasColumnName("Consultant_ID");
            entity.Property(e => e.ExperienceYears).HasColumnName("Experience_years");
            entity.Property(e => e.IsActive).HasColumnName("Is_active");
            entity.Property(e => e.Qualifications).HasMaxLength(200);
            entity.Property(e => e.Specification).HasMaxLength(100);
        });

        modelBuilder.Entity<ConsultantsAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__Consulta__9F3391BB432B1956");

            entity.ToTable("Consultants_availability");

            entity.Property(e => e.AvailabilityId).HasColumnName("Availability_ID");
            entity.Property(e => e.ConsultantId).HasColumnName("Consultant_ID");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(20)
                .HasColumnName("Day_of_week");
            entity.Property(e => e.EndDate).HasColumnName("End_date");
            entity.Property(e => e.StartDate).HasColumnName("Start_date");

            entity.HasOne(d => d.Consultant).WithMany(p => p.ConsultantsAvailabilities)
                .HasForeignKey(d => d.ConsultantId)
                .HasConstraintName("FK__Consultan__Consu__60A75C0F");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__37E005FBE1BFFDA0");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DocumentContent).HasColumnName("Document_content");
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(300)
                .HasColumnName("VideoURL");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK__Course__Category__72C60C4A");
        });

        modelBuilder.Entity<CourseCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Course_c__6DB38D4E9BCE8BDB");

            entity.ToTable("Course_category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CourseQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Course_q__B0B2E4C6160A63F7");

            entity.ToTable("Course_question");

            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.DisplayOrder).HasColumnName("Display_order");
            entity.Property(e => e.IsRequired).HasColumnName("Is_required");
            entity.Property(e => e.QuestionText).HasColumnName("Question_text");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .HasColumnName("Question_type");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseQuestions)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Course_qu__Cours__7D439ABD");
        });

        modelBuilder.Entity<CourseQuestionOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Course_q__3260905EAA614A7B");

            entity.ToTable("Course_question_options");

            entity.Property(e => e.OptionId).HasColumnName("Option_ID");
            entity.Property(e => e.DisplayOrder).HasColumnName("Display_order");
            entity.Property(e => e.OptionText)
                .HasMaxLength(200)
                .HasColumnName("Option_text");
            entity.Property(e => e.OptionValue)
                .HasMaxLength(100)
                .HasColumnName("Option_value");
            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");

            entity.HasOne(d => d.Question).WithMany(p => p.CourseQuestionOptions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Course_qu__Quest__00200768");
        });

        modelBuilder.Entity<CourseRegister>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CourseId }).HasName("PK__Course_r__831391CFF2DFB515");

            entity.ToTable("Course_register");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.RegisterDate)
                .HasColumnType("datetime")
                .HasColumnName("Register_date");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseRegisters)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course_re__Cours__76969D2E");

            entity.HasOne(d => d.User).WithMany(p => p.CourseRegisters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course_re__User___75A278F5");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Document__3A09B0FD251D6A74");

            entity.ToTable("Document");

            entity.Property(e => e.MaterialId).HasColumnName("Material_ID");
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<RiskLevel>(entity =>
        {
            entity.HasKey(e => e.RiskId).HasName("PK__Risk_lev__53E19F0A8211B695");

            entity.ToTable("Risk_level");

            entity.Property(e => e.RiskId).HasColumnName("Risk_ID");
            entity.Property(e => e.RiskDescription).HasColumnName("Risk_description");
            entity.Property(e => e.RiskLevel1)
                .HasMaxLength(100)
                .HasColumnName("Risk_level");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D9190C0F072B0");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_of_birth");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("Full_name");
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<UserAnswer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__User_Ans__36918F585BA6DE48");

            entity.ToTable("User_Answer");

            entity.Property(e => e.AnswerId).HasColumnName("Answer_ID");
            entity.Property(e => e.AnswerAt)
                .HasColumnType("datetime")
                .HasColumnName("Answer_at");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.OptionId).HasColumnName("Option_ID");
            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__User_Answ__Cours__02FC7413");

            entity.HasOne(d => d.Option).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK__User_Answ__Optio__05D8E0BE");

            entity.HasOne(d => d.Question).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__User_Answ__Quest__04E4BC85");

            entity.HasOne(d => d.User).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Answ__User___03F0984C");
        });

        modelBuilder.Entity<UserAssessment>(entity =>
        {
            entity.HasKey(e => e.UserAssessmentId).HasName("PK__User_ass__E66ED1FA737364A3");

            entity.ToTable("User_assessments");

            entity.Property(e => e.UserAssessmentId).HasColumnName("User_assessment_ID");
            entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");
            entity.Property(e => e.CompletedTime)
                .HasColumnType("datetime")
                .HasColumnName("Completed_time");
            entity.Property(e => e.RiskLevel).HasColumnName("Risk_level");
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_time");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Assessment).WithMany(p => p.UserAssessments)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("FK__User_asse__Asses__123EB7A3");

            entity.HasOne(d => d.RiskLevelNavigation).WithMany(p => p.UserAssessments)
                .HasForeignKey(d => d.RiskLevel)
                .HasConstraintName("FK__User_asse__Risk___14270015");

            entity.HasOne(d => d.User).WithMany(p => p.UserAssessments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_asse__User___1332DBDC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}