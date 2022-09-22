<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PenDown.Register" %>

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
                    <img src="Images\Ink Pen.png" alt="" width="30" height="30" class="d-inline-block align-text-top">
                    Pen Down
                </p>
                <ul class="nav justify-content-end">
                    <li class="nav-item">
                        <a class="nav-link" aria-current="page" href="AboutUs.aspx">About Us</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ContactUs.aspx">Contact Us</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="container">
            <div class="row align-items-center">
                <div class="col-sm-6 col-md-7 vh-100">
                    <img src="Images\Writing.jpg" class="rounded img-fluid">
                </div>
                <div class="col-sm-6 col-md-5 vh-100">
                    <div class="card">
                        <div class="card-body pb-0">
                            <h5 class="card-title text-center">Register Here</h5>
                        </div>
                        <!--Registration Form-->
                        <form id="registration" runat="server">
                            <div class="form-group px-3 pb-1">
                                <label for="Name" class="pb-1">Full Name</label>
                                <asp:TextBox ID="Name" class="form-control" placeholder="Enter full name" runat="server"/>
                            </div>
                            <div class="form-group px-3 py-1">
                                <label for="Email" class="pb-1">Email address</label>
                                <asp:TextBox ID="Email" TextMode="Email" class="form-control" placeholder="Enter email" runat="server"/>
                            </div>
                            <div class="form-group px-3 py-1">
                                <label for="Password" class="pb-1">Password</label>
                                <asp:TextBox ID="Password" TextMode="Password" class="form-control"  placeholder="Password" runat="server"/>
                            </div>
                            <div class="form-group px-3 py-1">
                                <label for="ConfirmPassword" class="pb-1">Confirm Password</label>
                                <asp:TextBox ID="ConfirmPassword" TextMode="Password" class="form-control" placeholder="Confirm Password" runat="server"/>
                            </div>
                            <div class="text-center p-1">
                                <asp:Button ID="RegisterBtn" type="submit" class="btn btn-secondary" Text="Register" OnClick="RegisterBtn_Click" runat="server"/>
                                <p>Already have an account?&nbsp;<a href="index.aspx">Login</a></p>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa"
            crossorigin="anonymous"></script>
    </body>

    </html>