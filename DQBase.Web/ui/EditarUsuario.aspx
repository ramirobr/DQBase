<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="DQBase.Web.ui.EditarUsuario" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="Infragistics4.Web.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Modificación de usuarios"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" 
                                Text="Nombre completo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomCompleto" runat="server" Width="231px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" 
                                Text="Nombre de usuario"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomUsuario" runat="server" Width="231px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" 
                                Text="Fecha de caducidad"></asp:Label>
                        </td>
                        <td>
                            <asp:ScriptManager runat="server">
                            </asp:ScriptManager>
                            <ig:WebDatePicker ID="dtpCaducidad" runat="server" DataMode="DateOrDBNull" 
                                DisplayModeFormat="d" Height="20px" Width="236px">
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                    onclick="btnGuardar_Click" />
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 132px;
        }
    </style>
</asp:Content>

