<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="IDPSDashboard.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
            width: 40%;
        }
        .auto-style2 {
            height: 10px;
        }
        .auto-style3 {
            width: 40%;
        }
        .auto-style4 {
            width: 80px;
        }
        .auto-style5 {
            width: 245px;
        }
        .auto-style6 {
            width: 398px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Usuarios y Roles"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged" PageSize="5" Width="100%" OnPageIndexChanging="gvUsers_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="userid" Visible="false">
                            <ItemTemplate><asp:Label ID="userId" runat="server" Text='<%# Bind("userId","{0:00}") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate><asp:Label ID="userName" runat="server" Text='<%# Bind("userName") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate><asp:Label ID="userLastName" runat="server" Text='<%# Bind("userLastName") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate><asp:Label ID="userFirstName" runat="server" Text='<%# Bind("userFirstName") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="userGroupId" Visible="False">
                            <ItemTemplate><asp:Label ID="userGroupId" runat="server" Text='<%# Bind("userGroupId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Grupo">
                            <ItemTemplate><asp:Label ID="userGroupDescription" runat="server" Text='<%# Bind("userGroupDescription") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:CheckBox ID="userActive" runat="server" Checked='<%# Bind("userActive") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="+" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td class="auto-style1" width="30%">
                <asp:HiddenField ID="userId" runat="server" />
            </td>
            <td class="auto-style4" width="70%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Usuario</td>
            <td class="auto-style7" width="70%">
                <asp:TextBox ID="txtUserName" runat="server" Enabled="False" Width="208px"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Nombre</td>
            <td class="auto-style7" width="70%">
                <asp:TextBox ID="txtUserFirstName" runat="server" Width="329px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" Enabled="False" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Apellido</td>
            <td class="auto-style7" width="70%">
                <asp:TextBox ID="txtUserLastName" runat="server" Width="326px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" Width="100px" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Grupo</td>
            <td class="auto-style7" width="70%">
                <asp:DropDownList ID="ddlUserGroup" runat="server" AutoPostBack="True" Height="26px" Width="334px" Enabled="False" OnSelectedIndexChanged="ddlUserGroup_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Cuenta de Correo</td>
            <td class="auto-style7" width="70%">
                <asp:TextBox ID="txtMail" runat="server" Width="327px" CausesValidation="True" Enabled="False" TextMode="Email"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Numero para SMS</td>
            <td class="auto-style10" width="70%">
                <asp:TextBox ID="txtSMS" runat="server" Width="327px" CausesValidation="True" Enabled="False" TextMode="Email"></asp:TextBox>
            </td>
            <td class="auto-style11" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Contraseña</td>
            <td class="auto-style7" width="70%">
                <asp:TextBox ID="txtPassword" runat="server" Width="157px" Enabled="False" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" width="30%">
                Activo</td>
            <td class="auto-style7" width="60%">
                <asp:CheckBox ID="chkActive" runat="server" Enabled="False" />
            </td>
            <td class="auto-style8" width="10%">
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
            <td class="auto-style5" width="30%">
                Roles heredados del Grupo</td>
            <td class="auto-style6">
                <asp:CheckBoxList ID="cblRolesRoles" runat="server" Enabled="False" Width="300px">
                </asp:CheckBoxList>
           </td>
            <td width="10%">
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
            <td class="auto-style2">
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
