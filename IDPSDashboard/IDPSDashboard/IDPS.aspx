<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="IDPS.aspx.cs" Inherits="IDPSDashboard.IDPS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 245px;
        }
        .auto-style4 {
            width: 400px;
        }
        .auto-style6 {
            width: 245px;
            height: 35px;
        }
        .auto-style7 {
            width: 400px;
            height: 35px;
        }
        .auto-style8 {
            height: 35px;
        }
        .auto-style9 {
            width: 245px;
            height: 34px;
        }
        .auto-style10 {
            width: 400px;
            height: 34px;
        }
        .auto-style11 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Configuracion de IPDS"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvIDPS" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvIDPS_SelectedIndexChanged" PageSize="5" Width="100%" OnPageIndexChanging="gvIDPS_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="IDPS Id">
                            <ItemTemplate><asp:Label ID="idsId" runat="server" Text='<%# Bind("idsId","{0:0000}") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate><asp:Label ID="idsName" runat="server" Text='<%# Bind("idsName") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Version">
                            <ItemTemplate><asp:Label ID="idsVersion" runat="server" Text='<%# Bind("idsVersion") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="idsTypeId" Visible="False">
                            <ItemTemplate><asp:Label ID="idsTypeId" runat="server" Text='<%# Bind("idsTypeId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo IDPS">
                            <ItemTemplate><asp:Label ID="idsTypeDesc" runat="server" Text='<%# Bind("idsTypeDesc") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="databaseTypeId" Visible="False">
                            <ItemTemplate><asp:Label ID="databaseTypeId" runat="server" Text='<%# Bind("databaseTypeId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Base de Datos">
                            <ItemTemplate><asp:Label ID="databaseTypeDesc" runat="server" Text='<%# Bind("databaseTypeDesc") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion IP">
                            <ItemTemplate><asp:Label ID="idsIP" runat="server" Text='<%# Bind("idsIP") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activo">
                            <ItemTemplate>
                                <asp:CheckBox ID="active" runat="server" Checked='<%# Bind("active") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="+" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td class="auto-style1" width="40%">
                &nbsp;</td>
            <td class="auto-style4" width="50%">
                &nbsp;</td>
            <td width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                IDPS ID</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtIDPSId" runat="server" ReadOnly="True" Width="119px" Enabled="False" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Nombre IDPS</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtIDPSName" runat="server" Width="329px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" Enabled="False" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Versión IDPS </td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtIDPSVersion" runat="server" Width="119px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" Width="100px" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Tipo IDPS</td>
            <td class="auto-style7" width="50%">
                <asp:DropDownList ID="ddlIDPSType" runat="server" AutoPostBack="True" Height="26px" Width="334px" Enabled="False">
                </asp:DropDownList>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Direccion IP</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtIP" runat="server" Width="327px" CausesValidation="True" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style9" width="40%">
                Motor
                Base de Datos</td>
            <td class="auto-style10" width="50%">
                <asp:DropDownList ID="ddlDatabaseType" runat="server" AutoPostBack="True" Height="26px" Width="333px" Enabled="False">
                </asp:DropDownList>
            </td>
            <td class="auto-style11" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Usuario Base de Datos</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtUserDataBase" runat="server" Width="119px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Password Base de Datos</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtPassDataBase" runat="server" Width="119px" Enabled="False" TextMode="Password"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Nombre Base de Datos</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtSourceDataBase" runat="server" Width="119px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Servidor Base de Datos</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtHostDatabase" runat="server" Width="119px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Activo</td>
            <td class="auto-style7" width="50%">
                <asp:CheckBox ID="chkActive" runat="server" Enabled="False" />
            </td>
            <td class="auto-style8" width="10%">
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
            <td class="auto-style8">
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
