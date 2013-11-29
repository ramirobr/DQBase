<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CearPerfil.aspx.cs" Inherits="DQBase.Web.ui.CearPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" Text="Perfiles"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Descripción"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Grabar" />
&nbsp;<asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" CssClass="LabelError"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 120px;
        }
    </style>
</asp:Content>

