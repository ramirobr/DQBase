<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportVentasProducLab.aspx.cs" Inherits="DQBase.Web.ui.ReportVentasProducLab" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContenedorPrincipal">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" ProcessingMode="Remote" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <ServerReport ReportPath="/ReportProjectDQBase/ReportVentasLaboratorioProductos" />
    </rsweb:ReportViewer>
</asp:Content>


