<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarLaboratorio.aspx.cs" Inherits="DQBase.Web.ui.EditarLaboratorio" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Laboratorios"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Ubicación"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUbicacion" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" Text="Corporación"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCorporacion" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" Text="Nombre"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelNormal" Text="Abreviatura"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAbreviatura" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelNormal" Text="Dirección"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDireccion1" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label7" runat="server" CssClass="LabelNormal" Text="Dirección 2"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDireccion2" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelNormal" Text="Telefono"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefono" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelNormal" Text="Orígen"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrigen" runat="server" Width="150px">
                                <asp:ListItem>Int</asp:ListItem>
                                <asp:ListItem>Lat</asp:ListItem>
                                <asp:ListItem>Nac</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelNormal" 
                                Text="Observación"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtObservacion" runat="server" Height="65px" 
                                TextMode="MultiLine" Width="210px"></asp:TextBox>
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
                <asp:Label ID="lblError" runat="server" CssClass="LabelError"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 75px;
        }
    </style>
</asp:Content>

