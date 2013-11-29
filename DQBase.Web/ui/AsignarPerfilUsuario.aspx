<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarPerfilUsuario.aspx.cs" Inherits="DQBase.Web.ui.AsignarPerfilUsuario" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Asignación de perfiles de usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" 
                                Text="Nombre de usuario"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreUsuario" runat="server" CssClass="LabelNormal"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style4">
                            <asp:RadioButtonList ID="rblPerfiles" runat="server" CssClass="LabelNormal">
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td><asp:Button Text="Grabar" runat="server" ID="btnSave" onclick="btnSave_Click" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button Text="Cancelar" runat="server" ID="btnCancel" 
                                            onclick="btnCancel_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="LabelError"></asp:Label></td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 166px;
        }
        .style4
        {
            width: 171px;
        }
    </style>
</asp:Content>

