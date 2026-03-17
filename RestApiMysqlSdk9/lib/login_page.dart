import 'package:flutter/material.dart';
import 'api_service_user.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();

  bool loading = false;
  String errorMessage = "";

  void login() async {
    setState(() {
      loading = true;
      errorMessage = "";
    });

    final result = await ApiServiceLogin.login(
      emailController.text,
      passwordController.text,
    );

    setState(() => loading = false);

    if (result["success"] == true) {
      // Navigate to home page
      Navigator.pushReplacementNamed(context, "/main");
    } else {
      setState(() => errorMessage = result["message"]);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Login")),
      body: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            TextField(
              controller: emailController,
              decoration: InputDecoration(labelText: "Email"),
            ),
            TextField(
              controller: passwordController,
              obscureText: true,
              decoration: InputDecoration(labelText: "Password"),
            ),
            SizedBox(height: 20),
            if (loading) CircularProgressIndicator(),
            if (errorMessage.isNotEmpty)
              Text(errorMessage, style: TextStyle(color: Colors.red)),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: loading ? null : login,
              child: Text("Login"),
            ),
          ],
        ),
      ),
    );
  }
}
