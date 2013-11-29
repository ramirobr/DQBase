<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearMovimientoProducto.aspx.cs" Inherits="DQBase.Web.ui.CrearMovimientoProducto" %>
<%@ Register assembly="Infragistics4.Web.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Movimiento producto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label7" runat="server" CssClass="LabelNormal" Text="Producto"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProductos" runat="server" Width="150px">
                            </asp:DropDownList>
&nbsp;<asp:Button ID="btnObtenerSubProductos" runat="server" onclick="btnObtenerSubProductos_Click" 
                                Text="Obtener Subproductos" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" Text="Subproducto"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubProducto" runat="server" 
                                Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Laboratorio"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLaboratorios" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" 
                                Text="Codigo del producto"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigo" runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelNormal" Text="Precio"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrecio" runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="LabelNormal" 
                                Text="Nuevo/Antiguo"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkEsNuevo" runat="server" CssClass="LabelNormal" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelNormal" 
                                Text="Fecha de lanzamiento"></asp:Label>
                        </td>
                        <td>
                            <asp:ScriptManager runat="server">
                            </asp:ScriptManager>
                            <ig:WebDatePicker ID="wdpFechaLanzamiento" runat="server" DisplayModeFormat="d" 
                                Width="150px">
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnSave" runat="server" Text="Grabar" onclick="BtnSave_Click" />
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
            width: 194px;
        }
    </style>
</asp:Content>

