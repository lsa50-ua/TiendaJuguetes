<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaJuguetes.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="estilosDefault.css" />
        <div id="orderSelector">
            Ordenar por:
            <asp:DropDownList ID="OrdenarPor" CssClass="orderSelector" runat="server" align="right" AutoPostBack="true" OnSelectedIndexChanged="onOrdenar">
                <asp:ListItem Value="0">Orden por defecto</asp:ListItem>
                <asp:ListItem Value="1">Precio: más bajo a más alto</asp:ListItem>
                <asp:ListItem Value="2">Precio: más alto a más bajo</asp:ListItem>
                <asp:ListItem Value="3">Nombre: de la A a la Z</asp:ListItem>
            </asp:DropDownList>
        </div>

    <div id="mainTitle">
        <h1>Listado Juguetes</h1>
    </div>

    <div id="listado" class="listado" runat="server">
        <asp:ListView ID="lvArticulos" runat="server">
            <LayoutTemplate>
                    <div runat="server" id="itemPlaceholder"/>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="producto">
                    <div class="fotoProducto zoom">
                        <asp:ImageButton OnClick="foto_Click" CommandArgument='<%# Eval("cod") %>' ID="ImageButton1" CssClass="fotoProducto" runat="server" ImageUrl='<%# Eval("urlimagen") %>' /> 
                    </div>
                    <div class="tituloProducto">
                        <%# Eval("nombre") %>
                    </div>
                </div>
                </ItemTemplate>
        </asp:ListView>
    </div>
  
</asp:Content>