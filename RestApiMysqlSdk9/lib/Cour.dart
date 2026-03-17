class Cour {
  final int id = 0;

  final int annee = 0;

  final int trimestre = 0;

  final String libelle = "";

  final String resume = "";

  final String resumeImg = "";

  final String moktasabatImg = "";

  const Cour({required annee, required trimestre, required libelle});

  // Factory constructor : convertit une Map JSON → objet
  factory Cour.fromJson(Map<String, dynamic> json) {
    return Cour(
      annee: json['annee'],
      trimestre: json['trimestre'],
      libelle: json['libelle'],
    );
  }

  // Optionnel : objet → JSON
  Map<String, dynamic> toJson() {
    return {
      'annee': annee,
      'trimestre': trimestre,
      'libelle': libelle,
    };
  }
}
