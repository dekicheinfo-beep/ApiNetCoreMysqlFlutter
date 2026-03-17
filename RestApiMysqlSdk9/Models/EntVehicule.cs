using System;
using System.Collections.Generic;

namespace RestApiMysqlSdk9.Models;

public partial class EntVehicule
{
    public int Id { get; set; }

    public int Modele { get; set; }

    public int? Marque { get; set; }

    public string? Apercu { get; set; }

    public int? PrixParJour { get; set; }

    public string? Energie { get; set; }

    public string? ModelAnnee { get; set; }

    public string? NombrePlace { get; set; }

    public string Matricule { get; set; } = null!;

    public string Chassis { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public int Kilometrage { get; set; }

    public string Etat { get; set; } = null!;

    public string Transmission { get; set; } = null!;

    public string? DebAssurance { get; set; }

    public string? FinAssurance { get; set; }

    public string AgenceAssurance { get; set; } = null!;

    public string? DebControl { get; set; }

    public string? FinControl { get; set; }

    public string AgenceControl { get; set; } = null!;

    public string? DateVidange { get; set; }

    public int KmVidange { get; set; }

    public int KmRetourVidange { get; set; }

    public string? Vimage1 { get; set; }

    public string? Vimage2 { get; set; }

    public string? Vimage3 { get; set; }

    public string? Vimage4 { get; set; }

    public string? Vimage5 { get; set; }

    public bool? Climatiseur { get; set; }

    public bool? TriangeSignalisation { get; set; }

    public bool? Abs { get; set; }

    public bool? SiegeAuto { get; set; }

    public bool? DirectionAssiste { get; set; }

    public bool? AirbagConducteur { get; set; }

    public bool? AirbagPassager { get; set; }

    public bool? VitresElectriques { get; set; }

    public bool? LecteurCd { get; set; }

    public bool? VerouillageCentralise { get; set; }

    public bool? CapteurCollision { get; set; }

    public bool? SiegesEnCuir { get; set; }

    public bool RoueSecours { get; set; }

    public bool CableRemorquage { get; set; }

    public bool AntiVol { get; set; }

    public bool Alarme { get; set; }

    public bool CricManivelle { get; set; }

    public bool CameraRecul { get; set; }

    public bool BoitePharmacie { get; set; }

    public bool BoiteSendrie { get; set; }

    public bool FeuAntiBrouillard { get; set; }

    public bool EcranTactile { get; set; }

    public bool JantesAlliages { get; set; }
}
