class User {
  String username;
  String passe;
  String profile;
  String etat;

  User({this.username, required this.passe, this.profile, this.etat});

  factory Product.fromJson(Map<String, dynamic> json) => Product(
        username: json['username'],
        passe: json['passe'],
        profile: json['profile'],
        etat: json['etat'],
      );

  Map<String, dynamic> toJson() => {
        'username': username,
        'passe': passe,
        'profile': profile,
        'etat': etat,
      };
}