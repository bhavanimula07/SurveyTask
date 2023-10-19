using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SurveyTask.Models;

public partial class Day1Context : DbContext
{
    public Day1Context()
    {
    }

    public Day1Context(DbContextOptions<Day1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusLog> StatusLogs { get; set; }

    public virtual DbSet<SurveyProgress> SurveyProgresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TMOOLA-L-5539\\SQLEXPRESS;Initial Catalog=Day1;User ID=sa;Password=Welcome2evoke@1234;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Status");

            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<StatusLog>(entity =>
        {
            entity.ToTable("StatusLog");

            entity.Property(e => e.Time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SurveyProgress>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SurveyProgress", tb => tb.HasTrigger("triggerstat"));

            entity.Property(e => e.SurveyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
