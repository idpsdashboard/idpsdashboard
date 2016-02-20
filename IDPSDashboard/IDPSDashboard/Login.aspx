<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IDPSDashboard.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.ico" />
<link runat="server" rel="icon" href="~/images/favicon.ico" type="image/ico"/>
<title>:: IDPS Dashboard :: For Open Source IDPS</title>
<style type="text/css">
    html, body
    {
        height: 100%;
        font-family: Arial, Helvetica, sans-serif;
        margin: 0;
    }
    .full-height
    {
        height: 100%;
        width: 100%;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <table 
            border="0" cellpadding="0" cellspacing="0" class="header" width="100%">
            <tr>
                <td>
                    <br />
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="70px" ImageUrl="~/images/logo.png" Width="70px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                 <asp:Image ID="Image2" runat="server" Height="68px" ImageUrl="~/images/idps.png" Width="327px" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
            </table>
    <table>
        <tr>
            <td>
                <div>&nbsp;</div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
        <td>&nbsp;&nbsp; &nbsp;</td>
        <td>&nbsp;&nbsp; &nbsp;</td>
        <td>
        <div>
            <asp:Login ID="_Login" runat="server" DestinationPageUrl="Dashboard.aspx" OnAuthenticate="_Login_Authenticate" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="left" colspan="2">Inicio de sesión</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="_Login">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="_Login">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Autenticar" ValidationGroup="_Login" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            </asp:Login>
        </div>
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
