using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RestApiMysqlSdk9.ModelsBase;

public partial class DbEducation35313137b935Context : DbContext
{
    public DbEducation35313137b935Context()
    {
    }

    public DbEducation35313137b935Context(DbContextOptions<DbEducation35313137b935Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cour> Cours { get; set; }

    public virtual DbSet<Exercice> Exercices { get; set; }

    public virtual DbSet<ReponseChoix> ReponseChoixes { get; set; }

    public virtual DbSet<ReponseExo> ReponseExos { get; set; }

    public virtual DbSet<Resumer> Resumers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning 
//        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=db_education-35313137b935;uid=root;pwd=0000;charset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.19-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cours");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Annee)
                .HasColumnType("int(11)")
                .HasColumnName("annee");
            entity.Property(e => e.Libelle)
                .HasMaxLength(255)
                .HasColumnName("libelle");
            entity.Property(e => e.MoktasabatImg)
                .HasMaxLength(100)
                .HasColumnName("moktasabat_img");
            entity.Property(e => e.Resume)
                .HasColumnType("mediumtext")
                .HasColumnName("resume");
            entity.Property(e => e.ResumeImg)
                .HasMaxLength(100)
                .HasColumnName("resume_img");
            entity.Property(e => e.Trimestre)
                .HasColumnType("int(11)")
                .HasColumnName("trimestre");
        });

        modelBuilder.Entity<Exercice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("exercice");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Annee)
                .HasColumnType("int(11)")
                .HasColumnName("annee");
            entity.Property(e => e.Cours)
                .HasColumnType("int(11)")
                .HasColumnName("cours");
            entity.Property(e => e.Ennonce)
                .HasColumnType("text")
                .HasColumnName("ennonce");
            entity.Property(e => e.EnnonceImg)
                .HasMaxLength(100)
                .HasColumnName("ennonce_img");
            entity.Property(e => e.Explication)
                .HasColumnType("text")
                .HasColumnName("explication");
            entity.Property(e => e.ExplicationImg)
                .HasMaxLength(100)
                .HasColumnName("explication_img");
            entity.Property(e => e.Formule)
                .HasMaxLength(50)
                .HasColumnName("formule");
            entity.Property(e => e.FormuleImg)
                .HasMaxLength(50)
                .HasColumnName("formule_img");
            entity.Property(e => e.Numero)
                .HasMaxLength(100)
                .HasColumnName("numero");
            entity.Property(e => e.Solution)
                .HasColumnType("text")
                .HasColumnName("solution");
            entity.Property(e => e.SolutionImg)
                .HasMaxLength(100)
                .HasColumnName("solution_img");
            entity.Property(e => e.Trimestre)
                .HasColumnType("int(11)")
                .HasColumnName("trimestre");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ReponseChoix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reponse_choix");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Exercice)
                .HasColumnType("int(11)")
                .HasColumnName("exercice");
            entity.Property(e => e.Question)
                .HasColumnType("int(11)")
                .HasColumnName("question");
            entity.Property(e => e.Reponse)
                .HasMaxLength(100)
                .HasColumnName("reponse");
            entity.Property(e => e.ReponseImg)
                .HasMaxLength(100)
                .HasColumnName("reponse_img");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ReponseExo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reponse_exo")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Correct)
                .HasMaxLength(10)
                .HasColumnName("correct");
            entity.Property(e => e.Formule)
                .HasMaxLength(100)
                .HasColumnName("formule");
            entity.Property(e => e.FormuleImg)
                .HasMaxLength(100)
                .HasColumnName("formule_img");
        });

        modelBuilder.Entity<Resumer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("resumer")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdCours)
                .HasColumnType("int(11)")
                .HasColumnName("id_cours");
            entity.Property(e => e.Libelle)
                .HasMaxLength(100)
                .HasColumnName("libelle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
