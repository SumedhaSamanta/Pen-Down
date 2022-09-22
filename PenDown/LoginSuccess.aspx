<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginSuccess.aspx.cs" Inherits="PenDown.LoginSuccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <a class="nav-link" href="Index.aspx?action=logout">Logout</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h4>Hi <%= Session["Username"] %>! You have logged in successfully.</h4>
</asp:Content>
