<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="DQBase.Web.ui.EditarProducto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Productos" Font-Names="helvetica" 
                    Font-Size="10pt" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Nombre del producto" 
                                Font-Names="helvetica" Font-Size="10pt"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombreProducto" runat="server" Width="248px"></asp:TextBox>
                        &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Grabar" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                    ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
