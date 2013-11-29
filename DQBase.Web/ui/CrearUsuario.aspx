<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="DQBase.Web.ui.CrearUsuario" %>

<%@ Register assembly="Infragistics4.Web.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenedorPrincipal" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Creación de usuarios" 
                    CssClass="LabelTitulo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style4">
                            <asp:Label ID="Label1" runat="server" Text="Laboratorio" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td class="style5">
                            <asp:DropDownList ID="ddlLaboratorio" runat="server" Height="22px" 
                                Width="199px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label2" runat="server" Text="Nombre Completo" 
                                CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server" MaxLength="70" Width="189px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidatorName" runat="server" 
                                ControlToValidate="txtNombre" ErrorMessage="Escriba el nombre" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label3" runat="server" Text="Usuario" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" MaxLength="30" Width="189px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidatorUser" runat="server" 
                                ControlToValidate="txtUsuario" ErrorMessage="Escriba el usuario" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="LabelNormal" 
                                Text="Fecha de caducidad"></asp:Label>
                        </td>
                        <td>
                            <asp:ScriptManager runat="server">
                            </asp:ScriptManager>
                            <ig:WebDatePicker ID="dtpCaducidad" runat="server" DataMode="DateOrDBNull" 
                                DisplayModeFormat="d" Height="20px" Width="236px">
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label4" runat="server" Text="Clave" CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClave" runat="server" MaxLength="15" TextMode="Password" 
                                Width="189px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidatorClave" runat="server" 
                                ControlToValidate="txtClave" ErrorMessage="Escriba la clave" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            <asp:Label ID="Label5" runat="server" Text="Repita Clave" 
                                CssClass="LabelNormal"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtClaveRepeat" runat="server" MaxLength="15" 
                                TextMode="Password" Width="189px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidatorPassword" runat="server" 
                                ControlToValidate="txtClaveRepeat" ErrorMessage="Reescriba la clave" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorClaves" runat="server" 
                                ControlToCompare="txtClaveRepeat" ControlToValidate="txtClave" 
                                ErrorMessage="Las claves ingresadas no son iguales" ForeColor="Red">*</asp:CompareValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Grabar" onclick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnReset" runat="server" Text="Cancelar" 
                    onclick="btnReset_Click" />
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="lblErrores" runat="server" ForeColor="Red" Visible="False" 
                    CssClass="LabelError"></asp:Label>
                <asp:ValidationSummary ID="ValidationSumary" runat="server" ForeColor="Red" 
                    CssClass="LabelError" />

            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style3
        {
            width: 131px;
        }
        .style4
        {
            width: 131px;
            height: 26px;
        }
        .style5
        {
            height: 26px;
        }
    </style>
</asp:Content>

