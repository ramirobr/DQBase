<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="DQBase.Web.ui.MantenimientoUsuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Mantenimiento de usuarios"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" 
                                onclick="btnNuevo_Click" />
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                        </td>
                        <td class="style6">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" Text="Buscar por"></asp:Label>
                        </td>
                        <td class="style7">
                            <asp:DropDownList ID="ddlPropiedades" runat="server" Height="22px" 
                                Width="125px">
                            </asp:DropDownList>
                        </td>
                        <td class="style8">
                            <asp:Button ID="btnBuscas" runat="server" Text="Buscar" 
                                onclick="btnBuscas_Click" />
                        </td>
                        <td class="style9">
                            <asp:Button ID="btnVerTodos" runat="server" Text="Ver todos" 
                                onclick="btnVerTodos_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnBorrar" runat="server" Text="Borrar" 
                                onclick="btnBorrar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridUsuarios" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" Font-Names="Helvetica" 
                    Font-Size="10pt" ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="GridUsuarios_PageIndexChanging" 
                    onrowcommand="GridUsuarios_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="asignaPerfil" Text="Asignar perfil" />
                        <asp:ButtonField CommandName="cambiarClave" Text="Cambiar clave" />
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="Laboratorio" HeaderText="Laboratorio" 
                            NullDisplayText="(Sin Laboratorio)" />
                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre completo" />
                        <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de usuario " />
                        <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación "
                        NullDisplayText="(Sin fecha de creación)" />
                        <asp:BoundField DataField="FechaCaducidad" HeaderText="Fecha de caducidad "
                        NullDisplayText="(Sin fecha de caducidad)" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
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
            width: 56px;
        }
        .style4
        {
            width: 49px;
        }
        .style5
        {
            width: 134px;
        }
        .style6
        {
            width: 71px;
        }
        .style7
        {
            width: 133px;
        }
        .style8
        {
            width: 68px;
        }
        .style9
        {
            width: 95px;
        }
    </style>
</asp:Content>

