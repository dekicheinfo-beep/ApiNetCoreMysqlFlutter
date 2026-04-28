using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RestApiMysqlSdk.ModelsBase2;

public partial class DbAssuranceContext : DbContext
{
    public DbAssuranceContext()
    {
    }

    public DbAssuranceContext(DbContextOptions<DbAssuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assure> Assures { get; set; }

    public virtual DbSet<Contrat> Contrats { get; set; }

    public virtual DbSet<Garantie> Garanties { get; set; }

    public virtual DbSet<Police> Polices { get; set; }

    public virtual DbSet<Risque> Risques { get; set; }

    public virtual DbSet<Sinistre> Sinistres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=db_assurance;uid=root;pwd=0000;charset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.19-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Assure>(entity =>
        {
            entity.HasKey(e => e.Codeassu).HasName("PRIMARY");

            entity.ToTable("assure");

            entity.Property(e => e.Codeassu)
                .ValueGeneratedNever()
                .HasColumnType("bigint(12)")
                .HasColumnName("CODEASSU");
            entity.Property(e => e.Adreassu)
                .HasMaxLength(100)
                .HasColumnName("ADREASSU");
            entity.Property(e => e.Fiscal)
                .HasMaxLength(100)
                .HasColumnName("FISCAL");
            entity.Property(e => e.Mailassu)
                .HasMaxLength(50)
                .HasColumnName("MAILASSU");
            entity.Property(e => e.Nomprenom)
                .HasMaxLength(100)
                .HasColumnName("NOMPRENOM");
            entity.Property(e => e.Passassu)
                .HasMaxLength(50)
                .HasColumnName("PASSASSU");
            entity.Property(e => e.Prof)
                .HasMaxLength(100)
                .HasColumnName("PROF");
            entity.Property(e => e.Raissoci)
                .HasMaxLength(100)
                .HasColumnName("RAISSOCI");
            entity.Property(e => e.ResetToken).HasMaxLength(100);
            entity.Property(e => e.ResetTokenExpiry).HasColumnType("datetime");
            entity.Property(e => e.Teleassu)
                .HasMaxLength(30)
                .HasColumnName("TELEASSU");
            entity.Property(e => e.Userassu)
                .HasMaxLength(50)
                .HasColumnName("USERASSU");
            entity.Property(e => e.Ville)
                .HasMaxLength(100)
                .HasColumnName("VILLE");
        });

        modelBuilder.Entity<Contrat>(entity =>
        {
            entity.HasKey(e => new { e.Codagence, e.Numepoli, e.Coderisq, e.Codeassu })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("contrat");

            entity.HasIndex(e => e.Codagence, "CODAGENCE").IsUnique();

            entity.HasIndex(e => e.Codeassu, "CODEASSU").IsUnique();

            entity.HasIndex(e => e.Coderisq, "CODERISQ").IsUnique();

            entity.HasIndex(e => e.Numepoli, "NUMEPOLI").IsUnique();

            entity.Property(e => e.Codagence)
                .HasMaxLength(100)
                .HasColumnName("CODAGENCE");
            entity.Property(e => e.Numepoli)
                .HasMaxLength(100)
                .HasColumnName("NUMEPOLI");
            entity.Property(e => e.Coderisq)
                .HasMaxLength(100)
                .HasColumnName("CODERISQ");
            entity.Property(e => e.Codeassu)
                .HasMaxLength(50)
                .HasColumnName("CODEASSU");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .HasColumnName("ADRESS");
            entity.Property(e => e.Agence)
                .HasMaxLength(100)
                .HasColumnName("AGENCE");
            entity.Property(e => e.Avenant)
                .HasMaxLength(100)
                .HasColumnName("AVENANT");
            entity.Property(e => e.Chassis)
                .HasMaxLength(50)
                .HasColumnName("CHASSIS");
            entity.Property(e => e.Dateeche)
                .HasMaxLength(10)
                .HasColumnName("DATEECHE");
            entity.Property(e => e.Dateeffe)
                .HasMaxLength(10)
                .HasColumnName("DATEEFFE");
            entity.Property(e => e.Energie)
                .HasMaxLength(20)
                .HasColumnName("ENERGIE");
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .HasColumnName("GENRE");
            entity.Property(e => e.Immat)
                .HasMaxLength(50)
                .HasColumnName("IMMAT");
            entity.Property(e => e.Liberisq)
                .HasMaxLength(100)
                .HasColumnName("LIBERISQ");
            entity.Property(e => e.Marque)
                .HasMaxLength(100)
                .HasColumnName("MARQUE");
            entity.Property(e => e.Prime)
                .HasMaxLength(10)
                .HasColumnName("PRIME");
            entity.Property(e => e.Puissance)
                .HasMaxLength(20)
                .HasColumnName("PUISSANCE");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("TYPE");
            entity.Property(e => e.Typemote)
                .HasMaxLength(100)
                .HasColumnName("TYPEMOTE");
            entity.Property(e => e.Usagee)
                .HasMaxLength(100)
                .HasColumnName("USAGEE");
            entity.Property(e => e.Zone)
                .HasMaxLength(10)
                .HasColumnName("ZONE");
        });

        modelBuilder.Entity<Garantie>(entity =>
        {
            entity.HasKey(e => new { e.Codagence, e.Numepoli, e.Coderisq, e.Codecate, e.Codegara })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0 });

            entity.ToTable("garantie");

            entity.Property(e => e.Codagence)
                .HasMaxLength(5)
                .HasColumnName("CODAGENCE");
            entity.Property(e => e.Numepoli)
                .HasColumnType("bigint(10)")
                .HasColumnName("NUMEPOLI");
            entity.Property(e => e.Coderisq)
                .HasColumnType("bigint(10)")
                .HasColumnName("CODERISQ");
            entity.Property(e => e.Codecate)
                .HasColumnType("int(5)")
                .HasColumnName("CODECATE");
            entity.Property(e => e.Codegara)
                .HasMaxLength(5)
                .HasColumnName("CODEGARA");
            entity.Property(e => e.Avenant)
                .HasMaxLength(50)
                .HasColumnName("AVENANT");
            entity.Property(e => e.Capiassu)
                .HasMaxLength(10)
                .HasColumnName("CAPIASSU");
            entity.Property(e => e.Francaise)
                .HasMaxLength(10)
                .HasColumnName("FRANCAISE");
            entity.Property(e => e.Libgara)
                .HasMaxLength(100)
                .HasColumnName("LIBGARA");
            entity.Property(e => e.PrimeNette)
                .HasMaxLength(10)
                .HasColumnName("PRIME NETTE");
        });

        modelBuilder.Entity<Police>(entity =>
        {
            entity.HasKey(e => new { e.Agence, e.Numepoli })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("police");

            entity.Property(e => e.Agence)
                .HasMaxLength(100)
                .HasColumnName("AGENCE");
            entity.Property(e => e.Numepoli)
                .HasMaxLength(100)
                .HasColumnName("NUMEPOLI");
            entity.Property(e => e.Adress)
                .HasMaxLength(100)
                .HasColumnName("ADRESS");
            entity.Property(e => e.Avenant)
                .HasMaxLength(100)
                .HasColumnName("AVENANT");
            entity.Property(e => e.Codagence)
                .HasMaxLength(100)
                .HasColumnName("CODAGENCE");
            entity.Property(e => e.Codeassu)
                .HasMaxLength(100)
                .HasColumnName("CODEASSU");
            entity.Property(e => e.Codecate)
                .HasMaxLength(100)
                .HasColumnName("CODECATE");
            entity.Property(e => e.Codedure)
                .HasMaxLength(4)
                .HasColumnName("CODEDURE");
            entity.Property(e => e.Dateeche)
                .HasMaxLength(10)
                .HasColumnName("DATEECHE");
            entity.Property(e => e.Dateeffe)
                .HasMaxLength(10)
                .HasColumnName("DATEEFFE");
            entity.Property(e => e.Direction)
                .HasMaxLength(100)
                .HasColumnName("DIRECTION");
            entity.Property(e => e.LibCate)
                .HasMaxLength(100)
                .HasColumnName("LIBِCATE");
            entity.Property(e => e.Typecont)
                .HasMaxLength(1)
                .HasColumnName("TYPECONT");
        });

        modelBuilder.Entity<Risque>(entity =>
        {
            entity.HasKey(e => new { e.Codagence, e.Numepoli, e.Coderisq })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("risque");

            entity.Property(e => e.Codagence)
                .HasMaxLength(100)
                .HasColumnName("CODAGENCE");
            entity.Property(e => e.Numepoli)
                .HasMaxLength(100)
                .HasColumnName("NUMEPOLI");
            entity.Property(e => e.Coderisq)
                .HasMaxLength(100)
                .HasColumnName("CODERISQ");
            entity.Property(e => e.Avenant)
                .HasMaxLength(100)
                .HasColumnName("AVENANT");
            entity.Property(e => e.Chassis)
                .HasMaxLength(50)
                .HasColumnName("CHASSIS");
            entity.Property(e => e.Datemec)
                .HasMaxLength(11)
                .HasColumnName("DATEMEC");
            entity.Property(e => e.Energie)
                .HasMaxLength(20)
                .HasColumnName("ENERGIE");
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .HasColumnName("GENRE");
            entity.Property(e => e.Immat)
                .HasMaxLength(50)
                .HasColumnName("IMMAT");
            entity.Property(e => e.Liberisq)
                .HasMaxLength(100)
                .HasColumnName("LIBERISQ");
            entity.Property(e => e.Marque)
                .HasMaxLength(100)
                .HasColumnName("MARQUE");
            entity.Property(e => e.Place)
                .HasMaxLength(11)
                .HasColumnName("PLACE");
            entity.Property(e => e.PtcCu)
                .HasMaxLength(11)
                .HasColumnName("PTC/CU");
            entity.Property(e => e.Puissance)
                .HasMaxLength(20)
                .HasColumnName("PUISSANCE");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("TYPE");
            entity.Property(e => e.Typemote)
                .HasMaxLength(100)
                .HasColumnName("TYPEMOTE");
            entity.Property(e => e.Usagee)
                .HasMaxLength(100)
                .HasColumnName("USAGEE");
            entity.Property(e => e.ValeurNeuf)
                .HasMaxLength(11)
                .HasColumnName("VALEUR NEUF");
            entity.Property(e => e.ValeurVenale)
                .HasMaxLength(10)
                .HasColumnName("VALEUR VENALE");
            entity.Property(e => e.Zone)
                .HasMaxLength(10)
                .HasColumnName("ZONE");
        });

        modelBuilder.Entity<Sinistre>(entity =>
        {
            entity.HasKey(e => new { e.Codesini, e.Numepoli, e.Codeassu, e.Coderisq })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("sinistre");

            entity.Property(e => e.Codesini)
                .HasMaxLength(50)
                .HasColumnName("CODESINI");
            entity.Property(e => e.Numepoli)
                .HasMaxLength(50)
                .HasColumnName("NUMEPOLI");
            entity.Property(e => e.Codeassu)
                .HasMaxLength(50)
                .HasColumnName("CODEASSU");
            entity.Property(e => e.Coderisq)
                .HasMaxLength(50)
                .HasColumnName("CODERISQ");
            entity.Property(e => e.Datesini)
                .HasMaxLength(10)
                .HasColumnName("DATESINI");
            entity.Property(e => e.Descrip)
                .HasMaxLength(100)
                .HasColumnName("DESCRIP");
            entity.Property(e => e.Latitude)
                .HasMaxLength(50)
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasMaxLength(50)
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.Statut)
                .HasMaxLength(50)
                .HasColumnName("STATUT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
