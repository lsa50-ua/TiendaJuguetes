<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="CambiarDir.aspx.cs" Inherits="TiendaJuguetes.CambiarDir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="form-login"> 
         <h4>Modificar Direccion</h4>
         <h3>Provincia</h3>
        <asp:DropDownList class="controls" ID="DropDownList" runat="server"></asp:DropDownList>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
         <h3>Calle</h3>
        <asp:TextBox class ="controls" ID="TextBoxCalle" placeholder="Introduzca Calle" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="CalleValidator" runat="server" ControlToValidate="TextBoxCalle" ValidationExpression="[a-z, A-Z, 0-9, ., ',' , \s]{1,64}" ErrorMessage="Introduzca una calle valida"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyCalle" runat="server" ControlToValidate="TextBoxCalle" ErrorMessage="El campo calle esta vacio!!"></asp:RequiredFieldValidator>
        <h3>Codigo Postal</h3>
         <asp:TextBox class ="controls" ID="TextBoxCodPostal" placeholder="Introduzca Cod.Postal" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="CodPostalValidator" runat="server" ControlToValidate="TextBoxCodPostal" ValidationExpression="^\d{5}$" ErrorMessage="El codigo postal tiene que contener 5 numeros!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyCodPostal" runat="server" ControlToValidate="TextBoxCodPostal" ErrorMessage="El campo cod. Postal esta vacio!!"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="EmptyContrasena2" runat="server" ControlToValidate="TextBoxContrasena2" ErrorMessage="El campo de repetir la contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <asp:Button class="botons" ID="Modificar" runat="server" Text="Modificar" OnClick="Modificarb" />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </section>
</asp:Content>
