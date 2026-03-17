import 'dart:convert';
import 'package:http/http.dart' as http;

class ApiServiceLogin {
  static const String baseUrl =
      "https://localhost:44379/api/Ent_user"; // change

  static Future<Map<String, dynamic>> login(
      String username, String passe) async {
    final url = Uri.parse("$baseUrl/login");

    try {
      final response = await http.post(
        url,
        headers: {"Content-Type": "application/json"},
        body: json.encode({
          "username": email,
          "passe": password,
        }),
      );

      if (response.statusCode == 200) {
        return {"success": true, "message": "Login OK"};
      } else {
        return {
          "success": false,
          "message":
              json.decode(response.body)["message"] ?? "Invalid credentials"
        };
      }
    } catch (e) {
      return {"success": false, "message": "Connection error: $e"};
    }
  }
}
