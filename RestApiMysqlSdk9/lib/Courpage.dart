import 'package:flutter/material.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'Cour.dart'; // importer le modèle

class CourPage extends StatefulWidget {
  @override
  _CourPageState createState() => _CourPageState();
}

class _CourPageState extends State<CourPage> {
  late Future<List<Cour>> _futureCour;

  @override
  void initState() {
    super.initState();
    _futureCour = fetchCour();
  }

  Future<List<Cour>> fetchCour() async {
    final response =
        await http.get(Uri.parse('http://localhost:2030/Api/Cours'));

    if (response.statusCode == 200) {
      List jsonResponse = json.decode(response.body);
      return jsonResponse.map((c) => Cour.fromJson(c)).toList();
    } else {
      throw Exception('Failed to load Cour');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Cour List')),
      body: FutureBuilder<List<Cour>>(
        future: _futureCour,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(child: CircularProgressIndicator());
          } else if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else if (!snapshot.hasData || snapshot.data!.isEmpty) {
            return Center(child: Text('No Cour found.'));
          } else {
            return ListView.builder(
              itemCount: snapshot.data!.length,
              itemBuilder: (context, index) {
                final c = snapshot.data![index];
                return ListTile(
                  leading: CircleAvatar(child: Text(c.id.toString())),
                  title: Text(c.libelle),
                );
              },
            );
          }
        },
      ),
    );
  }
}
