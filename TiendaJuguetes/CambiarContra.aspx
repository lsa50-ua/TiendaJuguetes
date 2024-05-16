<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="CambiarContra.aspx.cs" Inherits="TiendaJuguetes.CambiarContra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-login">
        <h4>Cambiar Contraseña</h4>
        <h3>Contraseña Actual</h3>
        <asp:TextBox class ="controls" ID="TextBoxContrasena" placeholder="Introduzca la Contraseña Actual" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="ContrasenaValidator" runat="server" ControlToValidate="TextBoxContrasena" ValidationExpression="^\d{1,15}$" ErrorMessage="La contraseña debe ser numerica y de maximo 15 numeros!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyContrasena" runat="server" ControlToValidate="TextBoxContrasena" ErrorMessage="El campo contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <h3>Contraseña Nueva</h3>
        <asp:TextBox class ="controls" ID="TextBoxContrasena2" TextMode="Password" placeholder="Introduzca la Nueva Contraseña" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="ContrasenaValidator2" runat="server" ControlToValidate="TextBoxContrasena" ValidationExpression="^\d{1,15}$" ErrorMessage="La contraseña debe ser numerica y de maximo 15 numeros!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyContrasena2" runat="server" ControlToValidate="TextBoxContrasena2" ErrorMessage="El campo de repetir la contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <asp:Button class="botons" ID="Modificar" runat="server" Text="Modificar" OnClick="ModificarB" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </section>
</asp:Content>
