<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TiendaJuguetes.WebForm2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="estilosArticulo.css" />
    <div id="todoArticulo">
        <div id="jugueteContainer">
            <div id="imageContainer">
                <asp:Image ID="Image1" runat="server" />
            </div>
            <div id="infoContainer">
                <asp:Label ID="nombreJuguete" runat="server"></asp:Label><br />
                <asp:ImageButton onclick="botoncarritoClick" ID="botoncarrito" runat="server" ImageUrl="~/fotos/botoncarrito.png" Width="150px"/>
            </div>
        
        </div>
        <div id="propiedadesArticulo">
            <div class="carArticulo">Nombre:
                <asp:Label ID="nombreArt" runat="server"></asp:Label>
            </div>
            <div class="carArticulo">Categoria:
                <asp:Label ID="categoriaArt" runat="server"></asp:Label>
            </div>
            <div class="carArticulo">Descripcion: 
                <asp:Label ID="descripcionArt" runat="server"></asp:Label>
            </div>
            <div class="carArticulo">Precio: 
                <asp:Label ID="precioArt" runat="server"></asp:Label>
            </div>
            <div class="carArticulo">Cantidad disponible:
                <asp:Label ID="stockArt" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    
    
</asp:Content>

