using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RestApiMysqlSdk9.ModelsBase4;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agence> Agences { get; set; }

    public virtual DbSet<EntClient> EntClients { get; set; }

    public virtual DbSet<EntCondition> EntConditions { get; set; }

    public virtual DbSet<EntContrat> EntContrats { get; set; }

    public virtual DbSet<EntFacture> EntFactures { get; set; }

    public virtual DbSet<EntLigneProforma> EntLigneProformas { get; set; }

    public virtual DbSet<EntLigneTravail> EntLigneTravails { get; set; }

    public virtual DbSet<EntLocation> EntLocations { get; set; }

    public virtual DbSet<EntMarque> EntMarques { get; set; }

    public virtual DbSet<EntModele> EntModeles { get; set; }

    public virtual DbSet<EntProforma> EntProformas { get; set; }

    public virtual DbSet<EntReservation> EntReservations { get; set; }

    public virtual DbSet<EntTravail> EntTravails { get; set; }

    public virtual DbSet<EntUser> EntUsers { get; set; }

    public virtual DbSet<EntUser2> EntUser2s { get; set; }

    public virtual DbSet<EntVehicule> EntVehicules { get; set; }

    public virtual DbSet<EntVehicule2> EntVehicule2s { get; set; }

    public virtual DbSet<EntVehiculeImage> EntVehiculeImages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=db_atelier;uid=root;pwd=0000", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.19-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Agence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("agence")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(200)
                .HasColumnName("adresse")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Aimposition)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Banque)
                .HasMaxLength(255)
                .HasColumnName("banque")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Fimposition)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Horaire)
                .HasMaxLength(100)
                .HasColumnName("horaire")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .HasColumnName("logo")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Presentation)
                .HasColumnType("text")
                .HasColumnName("presentation")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Proprietaire)
                .HasMaxLength(255)
                .HasColumnName("proprietaire")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Rcommerce)
                .HasMaxLength(100)
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Rib)
                .HasMaxLength(255)
                .HasColumnName("rib")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Telephone)
                .HasMaxLength(100)
                .HasColumnName("telephone")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<EntClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_client")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(100)
                .HasColumnName("adresse");
            entity.Property(e => e.DateNaiss)
                .HasMaxLength(10)
                .HasColumnName("date_naiss");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Narticle)
                .HasMaxLength(50)
                .HasColumnName("narticle");
            entity.Property(e => e.Nature)
                .HasMaxLength(50)
                .HasColumnName("nature");
            entity.Property(e => e.Nif)
                .HasMaxLength(50)
                .HasColumnName("nif");
            entity.Property(e => e.Nis)
                .HasMaxLength(50)
                .HasColumnName("nis");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Passe)
                .HasMaxLength(100)
                .HasColumnName("passe");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
            entity.Property(e => e.Raison)
                .HasMaxLength(50)
                .HasColumnName("raison");
            entity.Property(e => e.Rcommerce)
                .HasMaxLength(50)
                .HasColumnName("rcommerce");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<EntCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_condition")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cond)
                .HasColumnType("text")
                .HasColumnName("cond")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
        });

        modelBuilder.Entity<EntContrat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ent_contrat");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Clientid)
                .HasColumnType("int(11)")
                .HasColumnName("clientid");
            entity.Property(e => e.Datedebut)
                .HasMaxLength(10)
                .HasColumnName("datedebut");
            entity.Property(e => e.Datefin)
                .HasMaxLength(10)
                .HasColumnName("datefin");
            entity.Property(e => e.Montant)
                .HasMaxLength(10)
                .HasColumnName("montant");
            entity.Property(e => e.Numerocontrat)
                .HasMaxLength(50)
                .HasColumnName("numerocontrat");
            entity.Property(e => e.Typecontrat)
                .HasMaxLength(50)
                .HasColumnName("typecontrat");
        });

        modelBuilder.Entity<EntFacture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_facture")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Etat)
                .HasMaxLength(20)
                .HasColumnName("etat");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .HasColumnName("num");
            entity.Property(e => e.Reste)
                .HasMaxLength(20)
                .HasColumnName("reste");
            entity.Property(e => e.Total)
                .HasMaxLength(20)
                .HasColumnName("total");
            entity.Property(e => e.Versement)
                .HasMaxLength(20)
                .HasColumnName("versement");
        });

        modelBuilder.Entity<EntLigneProforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_ligne_proforma")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .HasColumnName("designation");
            entity.Property(e => e.IdProforma)
                .HasColumnType("int(11)")
                .HasColumnName("id_proforma");
            entity.Property(e => e.Pu)
                .HasMaxLength(10)
                .HasColumnName("pu");
            entity.Property(e => e.Qtt)
                .HasMaxLength(20)
                .HasColumnName("qtt");
            entity.Property(e => e.Total)
                .HasMaxLength(10)
                .HasColumnName("total");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Unite)
                .HasMaxLength(10)
                .HasColumnName("unite");
        });

        modelBuilder.Entity<EntLigneTravail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_ligne_travail")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .HasColumnName("designation");
            entity.Property(e => e.IdTravail)
                .HasColumnType("int(11)")
                .HasColumnName("id_travail");
            entity.Property(e => e.Pu)
                .HasMaxLength(10)
                .HasColumnName("pu");
            entity.Property(e => e.Qtt)
                .HasMaxLength(20)
                .HasColumnName("qtt");
            entity.Property(e => e.Total)
                .HasMaxLength(20)
                .HasColumnName("total");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Unite)
                .HasMaxLength(10)
                .HasColumnName("unite");
        });

        modelBuilder.Entity<EntLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_location")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cautionnement)
                .HasMaxLength(20)
                .HasColumnName("cautionnement");
            entity.Property(e => e.Client)
                .HasColumnType("int(11)")
                .HasColumnName("client");
            entity.Property(e => e.Conducteur)
                .HasColumnType("int(11)")
                .HasColumnName("conducteur");
            entity.Property(e => e.DateDeb)
                .HasMaxLength(10)
                .HasColumnName("date_deb");
            entity.Property(e => e.DateFin)
                .HasMaxLength(10)
                .HasColumnName("date_fin");
            entity.Property(e => e.Etat)
                .HasMaxLength(20)
                .HasColumnName("etat");
            entity.Property(e => e.KmDepart)
                .HasMaxLength(20)
                .HasColumnName("km_depart");
            entity.Property(e => e.KmJour)
                .HasMaxLength(20)
                .HasColumnName("km_jour");
            entity.Property(e => e.KmRetour)
                .HasMaxLength(20)
                .HasColumnName("km_retour");
            entity.Property(e => e.ModePaiement)
                .HasMaxLength(20)
                .HasColumnName("mode_paiement");
            entity.Property(e => e.Montant)
                .HasMaxLength(20)
                .HasColumnName("montant");
            entity.Property(e => e.MontantReste)
                .HasMaxLength(20)
                .HasColumnName("montant_reste");
            entity.Property(e => e.MontantVerse)
                .HasMaxLength(20)
                .HasColumnName("montant_verse");
            entity.Property(e => e.Num)
                .HasMaxLength(20)
                .HasColumnName("num");
            entity.Property(e => e.Prixu)
                .HasMaxLength(20)
                .HasColumnName("prixu");
            entity.Property(e => e.Vehicule)
                .HasColumnType("int(11)")
                .HasColumnName("vehicule");
        });

        modelBuilder.Entity<EntMarque>(entity =>
        {
            entity.HasKey(e => e.IdMarque).HasName("PRIMARY");

            entity
                .ToTable("ent_marque")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdMarque)
                .HasColumnType("int(9)")
                .HasColumnName("id_marque");
            entity.Property(e => e.Marque)
                .HasMaxLength(50)
                .HasColumnName("marque");
        });

        modelBuilder.Entity<EntModele>(entity =>
        {
            entity.HasKey(e => e.IdModele).HasName("PRIMARY");

            entity
                .ToTable("ent_modele")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdModele)
                .HasColumnType("int(11)")
                .HasColumnName("id_modele");
            entity.Property(e => e.IdMarque)
                .HasColumnType("int(11)")
                .HasColumnName("id_marque");
            entity.Property(e => e.Modele)
                .HasMaxLength(50)
                .HasColumnName("modele");
        });

        modelBuilder.Entity<EntProforma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_proforma")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Etat)
                .HasMaxLength(20)
                .HasColumnName("etat");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.IdTravail)
                .HasColumnType("int(11)")
                .HasColumnName("id_travail");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .HasColumnName("num");
            entity.Property(e => e.Reste)
                .HasMaxLength(20)
                .HasColumnName("reste");
            entity.Property(e => e.Total)
                .HasMaxLength(20)
                .HasColumnName("total");
            entity.Property(e => e.Validite)
                .HasMaxLength(100)
                .HasColumnName("validite");
            entity.Property(e => e.Versement)
                .HasMaxLength(20)
                .HasColumnName("versement");
        });

        modelBuilder.Entity<EntReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_reservation")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateDepart)
                .HasMaxLength(10)
                .HasColumnName("date_depart");
            entity.Property(e => e.DateRetour)
                .HasMaxLength(10)
                .HasColumnName("date_retour");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.IdVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("id_vehicule");
            entity.Property(e => e.NbJour)
                .HasMaxLength(10)
                .HasColumnName("nb_jour");
            entity.Property(e => e.NomClient)
                .HasMaxLength(100)
                .HasColumnName("nom_client");
            entity.Property(e => e.NomVehicule)
                .HasMaxLength(100)
                .HasColumnName("nom_vehicule");
            entity.Property(e => e.Somme)
                .HasMaxLength(20)
                .HasColumnName("somme");
            entity.Property(e => e.TypePaiement)
                .HasMaxLength(50)
                .HasColumnName("type_paiement");
            entity.Property(e => e.Valider)
                .HasMaxLength(10)
                .HasColumnName("valider");
        });

        modelBuilder.Entity<EntTravail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_travail")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("date");
            entity.Property(e => e.Etat)
                .HasMaxLength(20)
                .HasColumnName("etat");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.IdFacture)
                .HasColumnType("int(11)")
                .HasColumnName("id_facture");
            entity.Property(e => e.IdProforma)
                .HasColumnType("int(11)")
                .HasColumnName("id_proforma");
            entity.Property(e => e.Num)
                .HasMaxLength(10)
                .HasColumnName("num");
            entity.Property(e => e.Reste)
                .HasMaxLength(20)
                .HasColumnName("reste");
            entity.Property(e => e.Total)
                .HasMaxLength(20)
                .HasColumnName("total");
            entity.Property(e => e.Versement)
                .HasMaxLength(20)
                .HasColumnName("versement");
        });

        modelBuilder.Entity<EntUser>(entity =>
        {
            entity.HasKey(e => e.User).HasName("PRIMARY");

            entity
                .ToTable("ent_user")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.User, "user").IsUnique();

            entity.Property(e => e.User)
                .HasMaxLength(200)
                .HasColumnName("user");
            entity.Property(e => e.Etat)
                .HasMaxLength(100)
                .HasColumnName("etat");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Profile)
                .HasMaxLength(100)
                .HasColumnName("profile");
        });

        modelBuilder.Entity<EntUser2>(entity =>
        {
            entity.HasKey(e => e.User).HasName("PRIMARY");

            entity
                .ToTable("ent_user2")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.User).HasMaxLength(50);
            entity.Property(e => e.Nom).HasMaxLength(50);
            entity.Property(e => e.Passe).HasMaxLength(50);
            entity.Property(e => e.Prenom).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<EntVehicule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_vehicule")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abs).HasColumnName("ABS");
            entity.Property(e => e.AgenceAssurance)
                .HasMaxLength(100)
                .HasColumnName("AGENCE_ASSURANCE");
            entity.Property(e => e.AgenceControl)
                .HasMaxLength(100)
                .HasColumnName("AGENCE_CONTROL");
            entity.Property(e => e.Apercu)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Chassis).HasMaxLength(100);
            entity.Property(e => e.Couleur).HasMaxLength(100);
            entity.Property(e => e.DateVidange)
                .HasMaxLength(10)
                .HasColumnName("DATE_VIDANGE");
            entity.Property(e => e.DebAssurance)
                .HasMaxLength(10)
                .HasColumnName("DEB_ASSURANCE");
            entity.Property(e => e.DebControl)
                .HasMaxLength(10)
                .HasColumnName("DEB_CONTROL");
            entity.Property(e => e.Energie)
                .HasMaxLength(100)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Etat).HasMaxLength(255);
            entity.Property(e => e.FinAssurance)
                .HasMaxLength(10)
                .HasColumnName("FIN_ASSURANCE");
            entity.Property(e => e.FinControl)
                .HasMaxLength(10)
                .HasColumnName("FIN_CONTROL");
            entity.Property(e => e.Kilometrage).HasColumnType("int(11)");
            entity.Property(e => e.KmRetourVidange)
                .HasColumnType("int(11)")
                .HasColumnName("KM_RETOUR_VIDANGE");
            entity.Property(e => e.KmVidange)
                .HasColumnType("int(11)")
                .HasColumnName("KM_VIDANGE");
            entity.Property(e => e.Marque).HasColumnType("int(11)");
            entity.Property(e => e.Matricule).HasMaxLength(100);
            entity.Property(e => e.ModelAnnee).HasMaxLength(10);
            entity.Property(e => e.Modele).HasColumnType("int(11)");
            entity.Property(e => e.NombrePlace).HasMaxLength(10);
            entity.Property(e => e.PrixParJour).HasColumnType("int(11)");
            entity.Property(e => e.Transmission).HasMaxLength(100);
            entity.Property(e => e.Vimage1)
                .HasMaxLength(120)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Vimage2)
                .HasMaxLength(120)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Vimage3)
                .HasMaxLength(120)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Vimage4)
                .HasMaxLength(120)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.Vimage5)
                .HasMaxLength(120)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
        });

        modelBuilder.Entity<EntVehicule2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_vehicule2")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
        });

        modelBuilder.Entity<EntVehiculeImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("ent_vehicule_image")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdVehicule)
                .HasColumnType("int(11)")
                .HasColumnName("id_vehicule");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("products")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
