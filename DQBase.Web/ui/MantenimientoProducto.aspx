<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoProducto.aspx.cs" Inherits="DQBase.Web.ui.MantenimientoProducto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">

    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Productos" Font-Names="helvetica" 
                    Font-Size="10pt" CssClass="LabelTitulo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Button ID="btnNewProd" runat="server" onclick="btnNewProd_Click" 
                                Text="Nuevo producto" Width="129px" />
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label2" runat="server" Text="Buscar producto" 
                                Font-Names="helvetica" Font-Size="10pt"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:TextBox ID="txtBuscaProd" runat="server" Width="164px"></asp:TextBox>
                        </td>
                        <td class="style6">
                            <asp:Button ID="btnBuscaProd" runat="server" onclick="btnBuscaProd_Click" 
                                Text="Buscar" Width="79px" />
                        </td>
                        <td class="style13">
                            <asp:Button ID="btnViewAll" runat="server" 
                                Text="Ver todos" onclick="btnViewAll_Click" />
                        </td>
                        <td>

                            <asp:Button ID="btnBorrar" runat="server" onclick="btnBorrar_Click" 
                                Text="Borrar" Width="61px" />

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridProducts" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" onpageindexchanging="GridProduct_PageIndexChanging" 
                    onrowcommand="GridProduct_RowCommand" Width="379px" Font-Names="helvetica" 
                    Font-Size="10pt">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Agregar" Text="Añadir sub producto" />
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:ButtonField CommandName="SubProductos" Text="SubProductos" />
                        <asp:BoundField DataField="NOMBREPRODUCTO" HeaderText="Producto" />
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
        <tr id="trSubProd" runat="server" visible="false">
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Sub productos" 
                                Font-Names="helvetica" Font-Size="10pt" CssClass="LabelTitulo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td class="style7">
                                    <asp:Button ID="btnNewSubProd" runat="server" onclick="btnNewSubProd_Click" 
                                        Text="Nuevo sub producto" Width="156px" />
                                </td>
                                <td class="style8">
                                    <asp:Label ID="Label4" runat="server" Text="Buscar sub producto" 
                                        Font-Names="helvetica" Font-Size="10pt"></asp:Label>
                                </td>
                                <td class="style9">
                                    <asp:TextBox ID="txtBuscaSubProd" runat="server" Width="164px"></asp:TextBox>
                                </td>
                                <td class="style11">

                                    <asp:Label ID="Label5" runat="server" Font-Names="helvetica" Font-Size="10pt" 
                                        Text="Buscar por"></asp:Label>

                                </td>
                                <td class="style12">

                                    <asp:DropDownList ID="ddlPropSubProducts" runat="server" Height="22px" 
                                        Width="192px">
                                    </asp:DropDownList>

                                </td>
                                <td class="style10">
                                    <asp:Button ID="btnBuscaSubProd" runat="server" onclick="btnBuscaSubProd_Click" 
                                        Text="Buscar" Width="79px" />
                                </td>
                                <td>
                                    <asp:Button ID="btnViewAllSub" runat="server" 
                                        Text="Ver todos" onclick="btnViewAllSub_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnBorrarSubProducts" runat="server" 
                                            Text="Borrar" onclick="btnBorrarSubProducts_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    </tr>
                    <tr>
            <td>
                <asp:GridView ID="GridSubProductos" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    Font-Names="helvetica" Font-Size="10pt" 
                    onrowcommand="GridSubProductos_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Borrar">
                            <ItemTemplate>
                                <asp:CheckBox ID="checkBorrar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="editar" Text="Editar" />
                        <asp:BoundField DataField="Orden">
                        <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GrupoTerapeutico" HeaderText="Grupo terapeutico" />
                        <asp:BoundField DataField="Aplicacion" HeaderText="Aplicación " />
                        <asp:BoundField DataField="Forma" HeaderText="Forma" />
                        <asp:BoundField DataField="TipoMercado" HeaderText="Tipo de mercado" />
                        <asp:BoundField DataField="TipoProducto" HeaderText="Tipo de producto" />
                        <asp:BoundField DataField="Presentacion" HeaderText="Presentación" />
                        <asp:BoundField DataField="Concentracion" HeaderText="Concentración" />
                        <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="PrincipioActivo" HeaderText="Principio activo" />
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
                </table>
            </td>
        </tr>
        
       
    </table>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 109px;
        }
        .style4
        {
            width: 115px;
        }
        .style5
        {
            width: 177px;
        }
        .style6
        {
            width: 62px;
        }
        .style7
        {
            width: 173px;
        }
        .style8
        {
            width: 136px;
        }
        .style9
        {
            width: 183px;
        }
        .style10
        {
            width: 87px;
        }
        .style11
        {
            width: 76px;
        }
        .style12
        {
            width: 211px;
        }
        .style13
        {
            width: 85px;
        }
    </style>
</asp:Content>

