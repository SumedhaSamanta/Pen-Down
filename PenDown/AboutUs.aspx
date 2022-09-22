<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="PenDown.AboutUs" %>

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
    <div class="d-flex justify-content-center h-auto">
       <div class="card w-50" style="">
  <img class="card-img-top text-center" src="Images\Diary.jpg" alt="Diary image" style="height:200px;width:auto">
  <div class="card-body text-center">

     <p>Welcome to PenDown.com!</p>
            <p>We here at PenDown.com, want you to pour out your thoughts anytime and anywhere something strikes your
                head!
            </p>
            <p>We value your ideas and don't want to miss out on your profoundness just because you don't have paper or
                pen infront of you!</p>
            <p>We want you to put your "pen down" and write here so that you can read and write without having to carry
                your personal diary with you!</p>
  </div>
</div>
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