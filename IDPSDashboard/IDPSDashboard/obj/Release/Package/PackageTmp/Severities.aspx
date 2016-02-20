<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Severities.aspx.cs" Inherits="IDPSDashboard.Severities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Configuracion de Niveles de Criticidad"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvSeverities" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="gvSeverities_SelectedIndexChanged" PageSize="5" Width="100%" OnPageIndexChanging="gvSeverities_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Criticidad ID">
                            <ItemTemplate><asp:Label ID="severityId" runat="server" Text='<%# Bind("severityId","{0:0000}") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripcion">
                            <ItemTemplate><asp:Label ID="severityDescription" runat="server" Text='<%# Bind("severityDescription") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SLA TTR">
                            <ItemTemplate><asp:Label ID="SLATimeToResponse" runat="server" Text='<%# Bind("SLATimeToResponse") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
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
                Criticidad ID</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtSeverityId" runat="server" ReadOnly="True" Width="119px" Enabled="False" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                Descripcion del Nivel Criticidad</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtSeverityDescription" runat="server" Width="329px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" Enabled="False" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6" width="40%">
                [SLA] Service Level Agreement
                <br />
                Tiempo de Respuesta máximo en minutos</td>
            <td class="auto-style7" width="50%">
                <asp:TextBox ID="txtSLATTR" runat="server" Width="119px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style8" width="10%">
                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" Width="100px" Enabled="False" />
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
