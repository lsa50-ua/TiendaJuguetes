<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaJuguetes.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-register">
        <h4>Formulario Registro</h4>
        <asp:TextBox class=controls ID="TextBoxEmail" placeholder="Introduzca Email" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="EmailValidator" runat="server" ControlToValidate="TextBoxEmail" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ErrorMessage="Introduzca un email valido!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyEmail" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="El campo email esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class="controls" ID="TextBoxNombre" placeholder="Introduzca Nombre" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="NombreValidator" runat="server" ControlToValidate="TextBoxNombre" ValidationExpression="[a-z,A-Z, \s]{1,16}" ErrorMessage="Introduzca un nombre valido, max 16 caracteres"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyName" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="El campo nombre esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class="controls" ID="TextBoxApellidos" placeholder="Introduzca Apellidos" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="ApellidosValidator" runat="server" ControlToValidate="TextBoxApellidos" ValidationExpression="[a-z,A-Z, \s]{1,48}" ErrorMessage="Introduzca apellidos validos, max 48 caracteres"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyApellidos" runat="server" ControlToValidate="TextBoxApellidos" ErrorMessage="El campo apellidos esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TextBoxDNI" class="controls" placeholder="Introduzca DNI" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="DNIValidator" runat="server" ControlToValidate="TextBoxDNI" ValidationExpression="^([0-9]{8})+([A-Z]{1})$" ErrorMessage="Introduzca un DNI valido!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyDNI" runat="server" ControlToValidate="TextBoxDNI" ErrorMessage="El campo DNI esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class ="controls" ID="TextBoxTelefono" placeholder="Introduzca Nº de Telefono" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="TelefonoValidator" runat="server" ControlToValidate="TextBoxTelefono" ValidationExpression="^\d{9}$" ErrorMessage="Introduzca un nº de telefono valido!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyTelefono" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="El campo nº de telefono esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class ="controls" ID="TextBoxContrasena" placeholder="Introduzca Contraseña" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="ContrasenaValidator" runat="server" ControlToValidate="TextBoxContrasena" ValidationExpression="^\d{1,15}$" ErrorMessage="La contraseña debe ser numerica y de maximo 15 numeros!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyContrasena" runat="server" ControlToValidate="TextBoxContrasena" ErrorMessage="El campo contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class ="controls" ID="TextBoxContrasena2" TextMode="Password" placeholder="Repita la Contraseña" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="Contrasena2Validator" ControlToCompare="TextBoxContrasena" ControlToValidate="TextBoxContrasena2" Type="Integer" ErrorMessage="Las contraseñas no coinciden!!" runat="server"></asp:CompareValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyContrasena2" runat="server" ControlToValidate="TextBoxContrasena2" ErrorMessage="El campo de repetir la contraseña esta vacio!!"></asp:RequiredFieldValidator>
        <asp:DropDownList class="controls" ID="DropDownList" runat="server"></asp:DropDownList>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <asp:TextBox class ="controls" ID="TextBoxCalle" placeholder="Introduzca Calle" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="CalleValidator" runat="server" ControlToValidate="TextBoxCalle" ValidationExpression="[a-z, A-Z, 0-9, ., ',' , \s]{1,64}" ErrorMessage="Introduzca una calle valida"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyCalle" runat="server" ControlToValidate="TextBoxCalle" ErrorMessage="El campo calle esta vacio!!"></asp:RequiredFieldValidator>
        <asp:TextBox class ="controls" ID="TextBoxCodPostal" placeholder="Introduzca Cod.Postal" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator id="CodPostalValidator" runat="server" ControlToValidate="TextBoxCodPostal" ValidationExpression="^\d{5}$" ErrorMessage="El codigo postal tiene que contener 5 numeros!!"></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="EmptyCodPostal" runat="server" ControlToValidate="TextBoxCodPostal" ErrorMessage="El campo cod. Postal esta vacio!!"></asp:RequiredFieldValidator>
        <asp:Button class="botons" ID="BtnRegistr" runat="server" Text="Registrar" OnClick="ButtonRegister"/>
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </section>
</asp:Content>
