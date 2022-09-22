<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="PenDown.ContactUs" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Pen Down</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet"
            integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
        <link href="Stylesheets/style.css" rel="stylesheet">   
    </head>

    <body class="vh-100" runat="server">
        <!--Navigation Bar-->
        <nav class="navbar sticky-top">
            <div class="container-fluid">
                <p class="navbar-brand">
                    <img src="Images\Ink Pen.png" alt="Page Icon" width="30" height="30"
                        class="d-inline-block align-text-top">
                    Pen Down
                </p>
                <ul class="nav justify-content-end">
                    <li class="nav-item">
                        <a class="nav-link" aria-current="page" href="AboutUs.aspx">About Us</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ContactUs.aspx">Contact Us</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Index.aspx">Login</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Register.aspx">Register</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container text-center">
            <img src="Images\Writing Quote.png" class="rounded img-fluid py-5">
            <h3>Write to us at penDown@email.com</h3>
            <h6 class=" py-3">Celebrating You and Your Thoughts</h6>
        </div>

         <!--Footer-->
        <footer class="my-4 sticky-bottom">
            <p class="text-center text-muted">© 2022 PenDown Company, Inc</p>
        </footer>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa"
            crossorigin="anonymous"></script>
    </body>

    </html>