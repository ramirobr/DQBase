<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerificarVentas.aspx.cs" Inherits="DQBase.Web.ui.VerificarVentas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" id="UpdatePanel">
        <ContentTemplate>
             <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="LabelTitulo" 
                    Text="Verificación de ventas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelNormal" Text="Periodo"></asp:Label>
                        </td>
                        <td class="style4">
                            <asp:DropDownList ID="ddlPeriodo" runat="server" Height="22px" 
                                style="margin-left: 0px" Width="188px">
                               
                            </asp:DropDownList>
                        </td>
                        <td class="style5">
                            <asp:Button ID="btnBuscar" runat="server" Text="Visualizar ventas" 
                                onclick="btnBuscar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnPublicar" runat="server" 
                                Text="Publicar ventas" Width="136px" onclick="btnPublicar_Click" 
                                Visible="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridCiclos" runat="server" CellPadding="4" 
                    CssClass="LabelNormal" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    onpageindexchanging="GridCiclos_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Es correcto">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkPublicar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Laboratorio" HeaderText="Laboratorio" 
                            FooterText="Total:" />
                        <asp:TemplateField HeaderText="Unidades vendidas ciclo anterior" FooterStyle-Font-Bold="true">
                            <ItemTemplate>
                                <%# GetUnidadesAnterior(int.Parse(Eval("CantidadVentaAnterior").ToString())).ToString("N2")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# GetSumUnidadesAnterior().ToString("N2")%>
                            </FooterTemplate>

<FooterStyle Font-Bold="True"></FooterStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total ventas ciclo anterior" FooterStyle-Font-Bold="true">
                            <ItemTemplate>
                                <%# GetVentasAnterior(decimal.Parse(Eval("TotalVentaAnterior").ToString())).ToString("c")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# GetSumVentasAnterior().ToString("c")%>
                            </FooterTemplate>

<FooterStyle Font-Bold="True"></FooterStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unidades vendidas ciclo actual" FooterStyle-Font-Bold="true">
                            <ItemTemplate>
                                <%# GetUnidadesActual(int.Parse(Eval("CantidadVentaActual").ToString())).ToString("N2")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# GetSumUnidadesActual().ToString("N2")%>
                            </FooterTemplate>

<FooterStyle Font-Bold="True"></FooterStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total ventas ciclo actual" FooterStyle-Font-Bold="true">
                            <ItemTemplate>
                                <%# GetVentasActual(decimal.Parse(Eval("TotalVentaActual").ToString())).ToString("c")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# GetSumVentasActual().ToString("c")%>
                            </FooterTemplate>

<FooterStyle Font-Bold="True"></FooterStyle>
                        </asp:TemplateField>
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
        <tr>
            <td>
                <asp:UpdateProgress runat="server" id="UpdateProgress" 
                    AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="100">
                    <ProgressTemplate>
                        <div class="progress" style="font-family: Helvetica; font-size:12px;">
                            <img src="../images/loader.gif" />
                            Por favor espere ...
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 57px;
        }
        .style4
        {
            width: 207px;
        }
        .style5
        {
            width: 153px;
        }
    </style>
    <script runat="server">
        int sumUnidadesAnterior;
        int sumUnidadesActual;
        decimal sumVentasAnterior;
        decimal sumVentasActual;
        int GetUnidadesAnterior(int unidad)
        {
            sumUnidadesAnterior += unidad;
            return unidad;
        }
        int GetUnidadesActual(int unidad)
        {
            sumUnidadesActual += unidad;
            return unidad;
        }
        int GetSumUnidadesAnterior()
        {
            return sumUnidadesAnterior;
        }
        int GetSumUnidadesActual()
        {
            return sumUnidadesActual;
        }
        decimal GetVentasAnterior(decimal venta)
        {
            sumVentasAnterior += venta;
            return venta;
        }
        decimal GetVentasActual(decimal venta)
        {
            sumVentasActual += venta;
            return venta;
        }
        decimal GetSumVentasAnterior()
        {
            return sumVentasAnterior;
        }
        decimal GetSumVentasActual()
        {
            return sumVentasActual;
        }
        
</script>
<script type="text/javascript" language="javascript">
    function ConfirmPublish() {
        for (i = 0; i < document.forms[0].elements.length; i++) {
            elm = document.forms[0].elements[i]
            if (elm.name.indexOf('chkPublicar') != -1) {
                if (elm.checked) {
                    if (confirm('Esta seguro que desea publicar las ventas seleccionadas?')) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        alert('Seleccione por lo menos una venta para publicar');
        return false;
    }
</script>
</asp:Content>

