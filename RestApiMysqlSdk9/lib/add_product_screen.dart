import 'package:flutter/material.dart';
import 'product.dart';
import 'api_service_product.dart';

class AddProductScreen extends StatefulWidget {
  @override
  _AddProductScreenState createState() => _AddProductScreenState();
}

class _AddProductScreenState extends State<AddProductScreen> {
  final _formKey = GlobalKey<FormState>();
  final _nameController = TextEditingController();
  final _priceController = TextEditingController();
  final ApiService api = ApiService();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Add Product')),
      body: Padding(
        padding: EdgeInsets.all(16),
        child: Form(
          key: _formKey,
          child: Column(children: [
            TextFormField(
              controller: _nameController,
              decoration: InputDecoration(labelText: 'Name'),
              validator: (val) => val!.isEmpty ? 'Enter product name' : null,
            ),
            TextFormField(
              controller: _priceController,
              decoration: InputDecoration(labelText: 'Price'),
              keyboardType: TextInputType.number,
              validator: (val) => val!.isEmpty ? 'Enter price' : null,
            ),
            SizedBox(height: 20),
            ElevatedButton(
              child: Text('Add'),
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  await api.createProduct(Product(
                    id: 0,
                    name: _nameController.text,
                    price: double.parse(_priceController.text),
                  ));
                  Navigator.pop(context);
                }
              },
            )
          ]),
        ),
      ),
    );
  }
}
