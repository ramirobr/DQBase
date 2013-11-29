<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="DQBase.Web.ui.CambiarClave" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Cambio de clave" 
                    CssClass="LabelTitulo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" 
                                Text="Nombre de usuario"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreUsuario" runat="server" CssClass="LabelNormal"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Clave" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Repita la clave" 
                                CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReClave" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Guardar" 
                    onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" CssClass="LabelError" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
