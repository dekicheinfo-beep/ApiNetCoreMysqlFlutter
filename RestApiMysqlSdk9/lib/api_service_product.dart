import 'dart:convert';
import 'package:http/http.dart' as http;
import 'product.dart';

class ApiServiceProduct {
  final String baseUrl = "https://localhost:44379/api/products";
  //final String baseUrl = "http://dekicheinfo-001-site1.ktempurl.com/api/Products";

  final String username = "11277066";
  final String password = "60-dayfreetrial";

  Map<String, String> _headers() {
    String basicAuth =
        'Basic ${base64Encode(utf8.encode('$username:$password'))}';
    return {
      "Content-Type": "application/json",
      "Authorization": basicAuth,
    };
  }

  Future<List<Product>> getProducts() async {
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: _headers(),
    );
    if (response.statusCode == 200) {
      List jsonResponse = json.decode(response.body);
      return jsonResponse.map((p) => Product.fromJson(p)).toList();
    } else {
      throw Exception('Failed to load products');
    }
  }

  Future<Product> createProduct(Product product) async {
    final response = await http.post(Uri.parse(baseUrl),
        headers: {"Content-Type": "application/json"},
        body: json.encode(product.toJson()));
    if (response.statusCode == 201) {
      return Product.fromJson(json.decode(response.body));
    } else {
      throw Exception('Failed to create product');
    }
  }

  Future<void> updateProduct(Product product) async {
    final response = await http.put(Uri.parse('$baseUrl/${product.id}'),
        headers: {"Content-Type": "application/json"},
        body: json.encode(product.toJson()));
    if (response.statusCode != 204) {
      throw Exception('Failed to update product');
    }
  }

  Future<void> deleteProduct(int id) async {
    final response = await http.delete(Uri.parse('$baseUrl/$id'));
    if (response.statusCode != 204) {
      throw Exception('Failed to delete product');
    }
  }
}
