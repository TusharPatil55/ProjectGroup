using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CollegeInsight1.EntityModel;

public partial class CollegeInsightContext : DbContext
{
    public CollegeInsightContext()
    {
    }

    public CollegeInsightContext(DbContextOptions<CollegeInsightContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCollegeInfo> TblCollegeInfos { get; set; }

    public virtual DbSet<TblFeedbackCategoryMaster> TblFeedbackCategoryMasters { get; set; }

    public virtual DbSet<TblFeedbackMaster> TblFeedbackMasters { get; set; }

    public virtual DbSet<TblUserMaster> TblUserMasters { get; set; }

    public virtual DbSet<TblUserType> TblUserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CollegeInsight;Persist Security Info=True;User ID=sa;Password=456;Encrypt=False;\nTrust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCollegeInfo>(entity =>
        {
            entity.ToTable("tbl_CollegeInfo");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<TblFeedbackCategoryMaster>(entity =>
        {
            entity.ToTable("tbl_FeedbackCategoryMaster");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblFeedbackMaster>(entity =>
        {
            entity.ToTable("tbl_FeedbackMaster");

            entity.Property(e => e.CatagoryId).HasColumnName("Catagory_ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FeedbackSubject)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackText).IsUnicode(false);
            entity.Property(e => e.Photo).IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Catagory).WithMany(p => p.TblFeedbackMasters)
                .HasForeignKey(d => d.CatagoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_FeedbackMaster_tbl_FeedbackCategoryMaster");

            entity.HasOne(d => d.User).WithMany(p => p.TblFeedbackMasters)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_FeedbackMaster_tbl_UserMaster");
        });

        modelBuilder.Entity<TblUserMaster>(entity =>
        {
            entity.ToTable("tbl_UserMaster");

            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserTypeId).HasColumnName("UserType_ID");

            entity.HasOne(d => d.UserType).WithMany(p => p.TblUserMasters)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_UserMaster_tbl_UserType");
        });

        modelBuilder.Entity<TblUserType>(entity =>
        {
            entity.ToTable("tbl_UserType");

            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
