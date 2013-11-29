<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCorporacion.aspx.cs" Inherits="DQBase.Web.ui.EditarCorporacion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Corporaciones"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Nombre"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="30" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" Text="Abreviatura"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAbreviatura" runat="server" MaxLength="6" Width="160px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                    Text="Guardar" />
&nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" CssClass="LabelError" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 152px;
        }
    </style>
</asp:Content>

