﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoPerfiles.aspx.cs" Inherits="DQBase.Web.ui.MantenimientoPerfiles" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" Text="Perfiles"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNuevo" runat="server" onclick="btnNuevo_Click" 
                                Text="Nuevo" />
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Buscar"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtBuscar" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td class="style6">
                            <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                                Text="Buscar" />
                        </td>
                        <td class="style7">
                            <asp:Button ID="btnVerTodos" runat="server" onclick="btnVerTodos_Click" 
                                Text="Ver Todos" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridRoles" runat="server" AllowPaging="True" CellPadding="4" 
                    CssClass="LabelNormal" ForeColor="#333333" GridLines="None" 
                    AutoGenerateColumns="False" onpageindexchanging="GridRoles_PageIndexChanging" 
                    onrowcommand="GridRoles_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField CommandName="asignarMenu" Text="Asignar menu(s)" />
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="DESCRIPCIONROL" HeaderText="Descripción" />
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
        width: 66px;
    }
    .style4
    {
        width: 51px;
    }
    .style5
    {
        width: 178px;
    }
    .style6
    {
        width: 72px;
    }
    .style7
    {
        width: 99px;
    }
</style>
</asp:Content>

