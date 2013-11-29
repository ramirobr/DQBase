<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DQBase.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DQBase Web</title>
    <link href="css/estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server" id="UpdatePanel">
            <ContentTemplate>
                <table align="center">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" 
                                    ImageUrl="~/images/data_quest_pequenia.jpg" Height="80px" 
                        Width="100%"  />
                </td>
            </tr>
            <tr>
                <td>
                    
                    <table class="style1">
                        <tr>
                            <td>
                                
                                <table class="style1">
                                    <tr>
                                        <td>
                                            <table class="style1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Nombre de usuario" 
                                                            CssClass="LabelNormal"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsuario" runat="server" Width="150px" />
                                                        <asp:RequiredFieldValidator ID="Validador1" runat="server" 
                                                            ErrorMessage="Ingrese el usuario" CssClass="LabelError" 
                                                            ControlToValidate="txtUsuario">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="LabelNormal"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="150px"/>
                                                        <asp:RequiredFieldValidator ID="Validador2" runat="server" 
                                                            ErrorMessage="Escriba la contraseña" ControlToValidate="txtClave" 
                                                            CssClass="LabelError">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" 
                                                onclick="btnLogin_Click" />
                                        </td>
                                    </tr>
                                </table>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelError" runat="server" Visible="False" 
                        Font-Names="helvetica" ForeColor="Red" CssClass="LabelError"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        CssClass="LabelError" />
                </td>
            </tr>
            <tr>
                <td>
                     <asp:UpdateProgress runat="server" id="UpdateProgress" 
                    AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="100">
                    <ProgressTemplate>
                        <div class="progress" style="font-family: Helvetica; font-size:12px;">
                            <img src="images/loader.gif" />
                            Por favor espere ...
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                </td>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
