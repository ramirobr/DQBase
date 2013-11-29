<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarSubProductos.aspx.cs" Inherits="DQBase.Web.ui.EditarSubProductos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="helvetica" 
                    Font-Size="10pt" Text="Sub producto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Grupo terapeutico"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGrupoTerapeutico" runat="server" Width="220px">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Aplicación"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAplicacion" runat="server" Width="220px">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Forma"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlForma" runat="server" Width="220px">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Tipo de mercado"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoMercado" runat="server" Width="220px">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label6" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Tipo de producto"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoProducto" runat="server" Width="220px">
                            </asp:DropDownList>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label7" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Presentación"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPresentacion" runat="server" Width="220px"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label8" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Concentración"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConcentracion" runat="server" Width="220px" onchange = "validar(this)" ></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label9" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Unidad"></asp:Label> 
                        </td>
                        <td>
                        
                            <asp:TextBox ID="txtUnidad" runat="server" Width="220px" MaxLength="3"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label10" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Cantidad"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCantidad" runat="server" Width="220px" onchange = "validar(this)"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label11" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Principio activo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrincipio" runat="server" Width="220px"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label12" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                Text="Indicaciones de uso"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIndicaciones" runat="server" Width="220px" Height="73px" 
                                TextMode="MultiLine"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Guardar" 
                    onclick="btnSave_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancelar" onclick="btnCancel_Click" />
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 128px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function validar(texto) {
            if (isNaN(texto.value)) {
                alert("Solo puedes ingresar números");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>

