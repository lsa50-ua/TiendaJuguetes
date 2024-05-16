<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="CambiarUsu.aspx.cs" Inherits="TiendaJuguetes.CambiarUsu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-login">
        <h4>Modificar Usuario</h4>
        <h3>Email</h3>
        <asp:TextBox class=controls ID="TextBoxEmail" placeholder="Introduzca Email" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="EmailValidator" runat="server" ControlToValidate="TextBoxEmail" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ErrorMessage="Introduzca un email valido!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyEmail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="El campo email esta vacio!!"></asp:RequiredFieldValidator>
        <h3>Nombre</h3>
        <asp:TextBox class="controls" ID="TextBoxNombre" placeholder="Introduzca Nombre" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="NombreValidator" runat="server" ControlToValidate="TextBoxNombre" ValidationExpression="[a-z,A-Z, \s]{1,16}" ErrorMessage="Introduzca un nombre valido, max 16 caracteres"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyName" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="El campo nombre esta vacio!!"></asp:RequiredFieldValidator>
        <h3>Apellidos</h3>
        <asp:TextBox class="controls" ID="TextBoxApellidos" placeholder="Introduzca Apellidos" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="ApellidosValidator" runat="server" ControlToValidate="TextBoxApellidos" ValidationExpression="[a-z,A-Z, \s]{1,48}" ErrorMessage="Introduzca apellidos validos, max 48 caracteres"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyApellidos" runat="server" ControlToValidate="TextBoxApellidos" ErrorMessage="El campo apellidos esta vacio!!"></asp:RequiredFieldValidator>
        <asp:Button class="botons" ID="Modificar" runat="server" Text="Modificar" OnClick="BModificar" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </section>
</asp:Content>
