<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Interfase.aspx.cs" Inherits="DQBase.Web.ui.Interfase" %>

<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>


<%@ Register assembly="Infragistics4.Web.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.LayoutControls" tagprefix="ig" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
 <script language="javascript" type="text/javascript">
     function OnFileUploadComplete(s, e) {
         alert('Archivo subido con exito: ' + e.callbackData);
         document.forms[0].submit();
     }
 </script>
    <asp:ScriptManager runat="server" ID="scriptManager"/>
    <asp:UpdatePanel runat="server" id="UpdatePanel">
        <ContentTemplate>
            <div>
            <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Configuración de parametros" 
                    CssClass="LabelTitulo"></asp:Label>
            </td>
        </tr>
        <tr>
         <td>
            
             <asp:RadioButtonList ID="RadioOptions" runat="server" 
                 RepeatDirection="Horizontal" AutoPostBack="True" 
                 onselectedindexchanged="RadioOptions_SelectedIndexChanged" 
                 CssClass="LabelNormal">
                 <asp:ListItem Value="1">Corporación</asp:ListItem>
                 <asp:ListItem Value="2">Laboratorio</asp:ListItem>
             </asp:RadioButtonList>
            
         </td>
        </tr>
        <tr runat="server" id="trProceso">
                        

            <td>
                <table class="style1">
                    <tr id="trCorp" runat="server">
                        <td class="style3" height="30">
                            <asp:Label ID="Label2" runat="server" Text="Corporación" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td height="30">
                            <asp:DropDownList ID="ddlCorporaciones" runat="server" Height="22px" 
                                Width="151px">
                            </asp:DropDownList>
                        &nbsp;</td>
                    </tr>
                    <tr id="trLab" runat="server">
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" Text="Laboratorio" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td height="30">
                            <asp:DropDownList ID="ddlLaboratorios" runat="server" Height="22px" 
                                Width="151px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" Text="Periodo" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMesPeriodo" runat="server" Height="22px" 
                                Width="151px" AutoPostBack="True" 
                                ontextchanged="ddlMesPeriodo_TextChanged"/>
                        </td>
                    </tr>
                    <tr id="trTipoInfo" runat="server" visible="false">
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" Text="Tipo de información" 
                                CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="checkPublicPrivate" runat="server" Text="Publico/Privado" 
                                CssClass="LabelNormal" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label6" runat="server" Text="Cargar Archivo" 
                                CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:FileUpload ID="ExcelFileUpload" runat="server" />
                            <asp:Button ID="btnSaveFile" runat="server" onclick="btnSaveFile_Click" 
                                Text="Cargar archivo" />--%>

                <dx:ASPxUploadControl ID="UploadControl" runat="server" 
                    AddUploadButtonsHorizontalPosition="Right" ShowProgressPanel="True" 
                    ShowUploadButton="True" 
                    onfileuploadcomplete="UploadControl_FileUploadComplete" ClientIDMode="AutoID" 
                                Enabled="False">
                    <ValidationSettings 
                        FileDoesNotExistErrorText="El archivo cargado no existe" 
                        GeneralErrorText="La carga de archivos ha fallado debido a un error externo" 
                        MaxFileSizeErrorText="Tamaño del archivo supera el tamaño máximo permitido, que es {0} bytes" 
                        NotAllowedFileExtensionErrorText="Extensión no permitida">
                    </ValidationSettings>
                    <ClientSideEvents FileUploadComplete="function(s, e) {
	alert('Archivo subido con exito: ' + e.callbackData);
         document.forms[0].submit();
}" />
                    <UploadButton Text="Cargar">
                    </UploadButton>
                </dx:ASPxUploadControl>

                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td align="left" valign="top">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False" 
                                CssClass="LabelError"></asp:Label>
                            <asp:BulletedList ID="Errores" runat="server" CssClass="LabelError" 
                                Visible="False">
                            </asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:Button ID="btnCargar" name="btnCargar" runat="server" 
                    Text="Guardar información" Enabled="False" onclick="btnCargar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
            onclick="btnLimpiar_Click" />
                    
                
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
        </div>
        </ContentTemplate>
        
    </asp:UpdatePanel>
    

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 167px;
        }
        </style>
</asp:Content>

