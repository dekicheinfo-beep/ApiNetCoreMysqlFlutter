import 'package:flutter/material.dart';
import 'product.dart';
import 'api_service_product.dart';

class EditProductScreen extends StatefulWidget {
  final Product product;
  EditProductScreen({required this.product});

  @override
  _EditProductScreenState createState() => _EditProductScreenState();
}

class _EditProductScreenState extends State<EditProductScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nameController;
  late TextEditingController _priceController;
  final ApiService api = ApiService();

  @override
  void initState() {
    super.initState();
    _nameController = TextEditingController(text: widget.product.name);
    _priceController =
        TextEditingController(text: widget.product.price.toString());
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Edit Product')),
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
              child: Text('Update'),
              onPressed: () async {
                if (_formKey.currentState!.validate()) {
                  widget.product.name = _nameController.text;
                  widget.product.price = double.parse(_priceController.text);
                  await api.updateProduct(widget.product);
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
