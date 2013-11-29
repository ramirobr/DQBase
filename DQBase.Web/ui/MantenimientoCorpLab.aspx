<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoCorpLab.aspx.cs" Inherits="DQBase.Web.ui.MantenimientoCorpLab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Corporaciones"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNuevoCorp" runat="server" Text="Nuevo" 
                                onclick="btnNuevoCorp_Click" />
                        </td>
                        <td class="style5">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelNormal" Text="Buscar por"></asp:Label>
                        </td>
                        <td class="style6">
                            <asp:DropDownList ID="ddlBuscaCorp" runat="server" Height="23px" Width="167px">
                                <asp:ListItem Value="NOMBRECORPORACION">Nombre</asp:ListItem>
                                <asp:ListItem Value="ABREVIATURACORPORACION">Abreviatura</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style7">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style8">
                            <asp:TextBox ID="txtBuscarCorp" runat="server" Height="19px" Width="196px"></asp:TextBox>
                        </td>
                        <td class="style9">
                            <asp:Button ID="btnBuscarCorp" runat="server" onclick="btnBuscarCorp_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style3">
                            <asp:Button ID="btnBorrarCorp" runat="server" onclick="btnBorrarCorp_Click" 
                                Text="Borrar" />
                        </td>
                        <td>
                            <asp:Button ID="btnVerTodosCorp" runat="server" onclick="btnVerTodosCorp_Click" 
                                Text="Ver todos" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridCorporaciones" runat="server" CellPadding="4" 
                    CssClass="LabelNormal" ForeColor="#333333" GridLines="None" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onpageindexchanging="GridCorporaciones_PageIndexChanging" 
                    onrowcommand="GridCorporaciones_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="NOMBRECORPORACION" HeaderText="Nombre" />
                        <asp:BoundField DataField="ABREVIATURACORPORACION" HeaderText="Abreviatura" />
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
                <asp:Label ID="lblErrorCorp" runat="server" CssClass="LabelError" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="LabelTitulo" 
                    Text="Laboratorios"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style4">
                            <asp:Button ID="btnAddLab" runat="server" Text="Nuevo" 
                                onclick="btnAddLab_Click" />
                        </td>
                        <td class="style10">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelNormal" Text="Buscar por:"></asp:Label>
                        </td>
                        <td class="style11">
                            <asp:DropDownList ID="ddlPropLab" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td class="style12">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelNormal" Text="Buscar:"></asp:Label>
                        </td>
                        <td class="style13">
                            <asp:TextBox ID="txtBuscar" runat="server" Width="168px"></asp:TextBox>
                        </td>
                        <td class="style14">
                            <asp:Button ID="btnBuscarLab" runat="server" onclick="btnBuscarLab_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style15">
                            <asp:Button ID="btnVerTodosLab" runat="server" onclick="btnVerTodosLab_Click" 
                                Text="Ver todos" />
                        </td>
                        <td>
                            <asp:Button ID="btnBorrar" runat="server" onclick="btnBorrar_Click" 
                                Text="Borrar" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridLaboratorios" runat="server" CellPadding="4" 
                    CssClass="LabelNormal" ForeColor="#333333" GridLines="None" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onpageindexchanging="GridLaboratorios_PageIndexChanging" 
                    onrowcommand="GridLaboratorios_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="Ubicacion" HeaderText="Ubicación" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Corporacion" HeaderText="Corporación" 
                            NullDisplayText="(Sin corporación)" />
                        <asp:BoundField DataField="Abreviatura" HeaderText="Abreviatura" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="Direccion2" HeaderText="Direccion2" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Origen" HeaderText="Origen" />
                        <asp:BoundField DataField="Observacion" HeaderText="Observación" />
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
                <asp:Label ID="lblErrorLab" runat="server" CssClass="LabelError" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 63px;
        }
        .style4
        {
            width: 62px;
        }
        .style5
        {
            width: 77px;
        }
        .style6
        {
            width: 185px;
        }
        .style7
        {
            width: 74px;
        }
        .style8
        {
            width: 216px;
        }
        .style9
        {
            width: 72px;
        }
        .style10
        {
            width: 79px;
        }
        .style11
        {
            width: 161px;
        }
        .style12
        {
            width: 53px;
        }
        .style13
        {
            width: 189px;
        }
        .style14
        {
            width: 69px;
        }
        .style15
        {
            width: 91px;
        }
    </style>
</asp:Content>

