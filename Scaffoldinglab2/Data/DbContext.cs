using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Scaffoldinglab2.Models;

namespace Scaffoldinglab2.Data;

public partial class dblab2DbContext : DbContext
{
    

    public dblab2DbContext(DbContextOptions<dblab2DbContext> options)
     : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC074026A7DE");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC071AEF4B3A");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("subjects_teachers_teacherid_fk");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07AAAAF2CB");

            entity.Property(e => e.Details).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal object Find(int id)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
