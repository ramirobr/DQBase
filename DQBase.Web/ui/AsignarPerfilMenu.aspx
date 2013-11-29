<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarPerfilMenu.aspx.cs" Inherits="DQBase.Web.ui.AsignarPerfilMenu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Asignacion de perfiles"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombrePerfil" runat="server" CssClass="LabelNormal"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3" valign="top">
                            <asp:CheckBoxList ID="chkMenus" runat="server" CssClass="LabelNormal">
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Grabar" onclick="btnSave_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
                                            Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
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
            width: 238px;
        }
    </style>
</asp:Content>

