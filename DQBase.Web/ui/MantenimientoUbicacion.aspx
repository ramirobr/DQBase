<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoUbicacion.aspx.cs" Inherits="DQBase.Web.ui.MantenimientoUbicacion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" Text="Paises"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNewPais" runat="server" onclick="btnNewPais_Click" 
                                Text="Nuevo" />
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtBuscar" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style6">
                            <asp:Button ID="btnBuscarPais" runat="server" onclick="btnBuscarPais_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style7">
                            <asp:Button ID="btnVerTodosPais" runat="server" onclick="btnVerTodosPais_Click" 
                                Text="Ver todos" />
                        </td>
                        <td>
                            <asp:Button ID="btnBorrarPais" runat="server" onclick="btnBorrarPais_Click" 
                                Text="Borrar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gridPaises" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" CssClass="LabelNormal" 
                    ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="gridPaises_PageIndexChanging" 
                    onrowcommand="gridPaises_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField Text="Editar" CommandName="editar" />
                        <asp:BoundField DataField="NOMBREUBICACION" HeaderText="Nombre" />
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
                <asp:Label ID="lblErrorPais" runat="server" CssClass="LabelError" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="label2" runat="server" CssClass="LabelTitulo" Text="Regiones"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style8">
                            <asp:Button ID="btnNuevoRegion" runat="server" onclick="btnNuevoRegion_Click" 
                                Text="Nuevo" />
                        </td>
                        <td class="style9">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelNormal" Text="Buscar por"></asp:Label>
                        </td>
                        <td class="style10">
                            <asp:DropDownList ID="ddPropRegiones" runat="server" Width="150px">
                                <asp:ListItem>Pais</asp:ListItem>
                                <asp:ListItem>Nombre</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style11">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style12">
                            <asp:TextBox ID="txtBuscarRegion" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style13">
                            <asp:Button ID="btnBuscarRegion" runat="server" onclick="btnBuscarRegion_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style14">
                            <asp:Button ID="btnVerTodosRegion" runat="server" 
                                onclick="btnVerTodosRegion_Click" Text="Ver Todos" />
                        </td>
                        <td>
                            <asp:Button ID="btnBorrarRegion" runat="server" onclick="btnBorrarRegion_Click" 
                                Text="Borrar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gridRegiones" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" CssClass="LabelNormal" 
                    ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="gridRegiones_PageIndexChanging" 
                    onrowcommand="gridRegiones_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="Pais" HeaderText="País" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
                <asp:Label ID="lblErrorRegion" runat="server" CssClass="LabelError" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="LabelTitulo" Text="Ciudades"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNewCiudad" runat="server" Text="Nuevo" 
                                onclick="btnNewCiudad_Click" />
                        </td>
                        <td class="style15">
                            <asp:Label ID="Label7" runat="server" CssClass="LabelNormal" Text="Buscar por"></asp:Label>
                        </td>
                        <td class="style16">
                            <asp:DropDownList ID="ddlPropCiudad" runat="server" Width="150px">
                                <asp:ListItem>Region</asp:ListItem>
                                <asp:ListItem>Nombre</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style17">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style18">
                            <asp:TextBox ID="txtBuscarCiudad" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style19">
                            <asp:Button ID="btnBuscarCiudad" runat="server" onclick="btnBuscarCiudad_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style20">
                            <asp:Button ID="btnVerTodosCiudad" runat="server" 
                                onclick="btnVerTodosCiudad_Click" Text="Button" />
                        </td>
                        <td>
                            <asp:Button ID="btnBorrarCiudad" runat="server" onclick="btnBorrarCiudad_Click" 
                                Text="Borrar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gridCiudades" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" CssClass="LabelNormal" 
                    ForeColor="#333333" GridLines="None" 
                    onpageindexchanging="gridCiudades_PageIndexChanging" 
                    onrowcommand="gridCiudades_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="Region" HeaderText="Region" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
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
                <asp:Label ID="lblErrorCiudad" runat="server" CssClass="LabelError"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 60px;
        }
        .style4
        {
            width: 49px;
        }
        .style5
        {
            width: 170px;
        }
        .style6
        {
            width: 72px;
        }
        .style7
        {
            width: 88px;
        }
        .style8
        {
            width: 63px;
        }
        .style9
        {
            width: 75px;
        }
        .style10
        {
            width: 160px;
        }
        .style11
        {
            width: 50px;
        }
        .style12
        {
            width: 166px;
        }
        .style13
        {
            width: 68px;
        }
        .style14
        {
            width: 93px;
        }
        .style15
        {
            width: 70px;
        }
        .style16
        {
            width: 159px;
        }
        .style17
        {
            width: 44px;
        }
        .style18
        {
            width: 175px;
        }
        .style19
        {
            width: 69px;
        }
        .style20
        {
            width: 67px;
        }
    </style>
</asp:Content>

