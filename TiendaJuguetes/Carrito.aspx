<%@ Page Title="" Language="C#" MasterPageFile="~/TiendaJuguetesMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TiendaJuguetes.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table id="TablaCarrito"
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="12pt" 
        CellPadding="25" 
        CellSpacing="0"
        runat="server">
        <asp:TableRow>
            <asp:TableCell>
                
            </asp:TableCell>
            <asp:TableCell>
                Producto
            </asp:TableCell>
            <asp:TableCell
                HorizontalAlign="Center">
                Precio Unitario
            </asp:TableCell>
            <asp:TableCell
                HorizontalAlign="Center">
                Cantidad
            </asp:TableCell>
            <asp:TableCell
                HorizontalAlign="Center">
                Total
            </asp:TableCell>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
    </asp:table>

    <asp:Table id="TablaPrecio"
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="12pt"
        style="font-weight:bold"
        CellPadding="15" 
        CellSpacing="0"
        runat="server">
        <asp:TableRow>
            <asp:TableCell>

            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
