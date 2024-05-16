<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="TiendaJuguetes.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-login">
        <h4>Inicio de Sesion</h4>
        <asp:TextBox class="controls" ID="TextBoxEmail" runat="server" placeholder="Introduzca Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmptyEmail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="El campo email esta vacio!!"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator id="EmailValidator" runat="server" ControlToValidate="TextBoxEmail" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ErrorMessage="Introduzca un email valido!!"></asp:RegularExpressionValidator>
        <asp:TextBox class="controls" ID="TextBoxContrasena" runat="server" TextMode="Password" placeholder="Introduzca Contraseña"></asp:TextBox>
        <asp:RequiredFieldValidator ID="EmptyContrasena" runat="server" ControlToValidate="TextBoxContrasena" ErrorMessage="El campo contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <br />
        <asp:RegularExpressionValidator id="ContrasenaValidator" runat="server" ControlToValidate="TextBoxContrasena" ValidationExpression="^\d{1,15}$" ErrorMessage="La contraseña debe ser numerica y de maximo 15 numeros!!"></asp:RegularExpressionValidator>
        <asp:Button class="botons" ID="Button1" runat="server" Text="Login" OnClick="Login_Click" />
        <asp:Label ID="Mensaje" runat="server"></asp:Label><br />
        <br />
        <br />
        <a runat="server" href="Registro.aspx">¿No tienes cuenta?<br />¡Registrate aqui!</a>

    </section>

</asp:Content>
