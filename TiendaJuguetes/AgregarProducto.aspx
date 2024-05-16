<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TiendaJuguetes.AñadirProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="form-login">
        <div style="text-align:center; align-items:center; align-content:center; justify-content:center">
            <h1>Formulario para añadir artículos</h1>
            <asp:TextBox class="controls" ID="Nombre" runat="server" placeholder="Nombre del artículo"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox class="controls" ID="Precio" runat="server" placeholder="Precio"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox class="controls" ID="NomImagen" runat="server" placeholder="Nom imagen"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:TextBox class="controls" ID="Descripcion" runat="server" placeholder="Desc"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:DropDownList class="controls" ID="Categoria" runat="server" AutoPostBack="true">
                <asp:ListItem Value="0"    text="Accion"       tooltip="Accion"/>
                <asp:ListItem Value="1"    text="Construccion" tooltip="Construccion"/>
                <asp:ListItem Value="2"    text="Coches"       tooltip="Coches"/>
                <asp:ListItem Value="3"    text="Familiar"     tooltip="Familiar"/>
                <asp:ListItem Value="4"    text="Disfraces"    tooltip="Disfraces"/>
                <asp:ListItem Value="5"    text="Deportes"     tooltip="Deportes"/>
            </asp:DropDownList>
            <asp:Button class="botons" ID="Enviar" runat="server" Text="Enviar" OnClick="Submit" />
        </div>
    </section>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
