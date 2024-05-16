<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="TiendaJuguetes.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-login">
        <div>
            <h4>Formulario de Pago</h4>
            <asp:TextBox class="controls" ID="TextBoxTarjeta" runat="server" placeholder="Numero de la tarjeta"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmptyTarjeta" runat="server" ControlToValidate="TextBoxTarjeta" ErrorMessage="Introduzca una tarjeta!!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="TarjetaValidator" runat="server" ControlToValidate="TextBoxTarjeta" ValidationExpression="^\d{16}$" ErrorMessage="Introduzca una tarjeta valida!!"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox class="controls" ID="TextBoxFecha" runat="server" placeholder="Fecha de caducidad"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmptyFecha" runat="server" ControlToValidate="TextBoxFecha" ErrorMessage="La fecha esta vacia!!"></asp:RequiredFieldValidator>            <br />
            <asp:TextBox class="controls" ID="TextBoxcvv" runat="server" placeholder="Numero secreto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CvvEmpty" runat="server" ControlToValidate="TextBoxcvv" ErrorMessage="Introduzca un cvv!!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="cvvValidator" runat="server" ControlToValidate="TextBoxcvv" ValidationExpression="^\d{3}$" ErrorMessage="Introduzca un cvv valido!!"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:ImageButton ID="ImagenMetodos" runat="server" ImageUrl="fotos/Pagos.png" width="100%" Height="100%" ToolTip="Pagar" OnClick="Pago"/>
         </div>
    </section>

</asp:Content>
