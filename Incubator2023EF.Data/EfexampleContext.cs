using Incubator2023EF.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Incubator2023EF.Data;

public partial class EfexampleContext : DbContext
{
    public EfexampleContext()
    {
    }

    public EfexampleContext(DbContextOptions<EfexampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassGrade> ClassGrades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EFExample;TrustServerCertificate=true;Integrated Security=SSPI");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC0701993E91");

            entity.Property(e => e.ClassName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClassGrade>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ClassId }).HasName("PK__ClassGra__2E74B9E544FA37AD");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassGrades)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassGrad__Class__3C69FB99");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassGrades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassGrad__Stude__3B75D760");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07AF9F1DB0");

            entity.Property(e => e.StudentName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
