<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="IntrusionEvents.aspx.cs" Inherits="IDPSDashboard.IDPSEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 519px;
        }
        .auto-style4 {
            width: 2521px;
        }
        .auto-style5 {
            width: 496px;
        }
        .auto-style6 {
            width: 248px;
        }
        .auto-style7 {
            width: 248px;
            height: 35px;
        }
        .auto-style8 {
            width: 496px;
            height: 35px;
        }
        .auto-style9 {
            height: 35px;
            width: 237px;
        }
        .auto-style10 {
            width: 248px;
            height: 115px;
        }
        .auto-style11 {
            width: 496px;
            height: 115px;
        }
        .auto-style12 {
            height: 115px;
            width: 237px;
        }
        .auto-style13 {
            width: 237px;
        }
        .auto-style14 {
            width: 248px;
            height: 22px;
        }
        .auto-style15 {
            width: 496px;
            height: 22px;
        }
        .auto-style16 {
            width: 237px;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Catálogo de Eventos de Intrusión"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td align="right" class="auto-style4">
                Buscar por
            </td>
            <td align="right" class="auto-style3">
            
                <asp:DropDownList ID="ddlIntrusionFieldSearch" runat="server" Height="20px" ToolTip="Seleccione Campo de busqueda" Width="136px">
                    <asp:ListItem Value="1">CVE</asp:ListItem>
                    <asp:ListItem Value="1">Detalle</asp:ListItem>
                    <asp:ListItem Value="3">CWE</asp:ListItem>
                    <asp:ListItem Value="4">CAPEC</asp:ListItem>
                    <asp:ListItem Value="5">OWASP</asp:ListItem>
                </asp:DropDownList>
            
            </td>
            <td align="right" ="auto-style2">
                <asp:TextBox ID="txtIntrusionEventSearch" runat="server" style="margin-left: 0px" Width="270px"></asp:TextBox>         
            </td>
            <td align="right">
                <asp:Button ID="btnSearchEvent" runat="server" OnClick="btnSearchEvent_Click" Text="Buscar" Width="103px" />
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="gvEvents" runat="server" Width="100%" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPageIndexChanging="gvEvents_PageIndexChanging" PageSize="5" OnSelectedIndexChanged="gvEvents_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Evento ID">
                            <ItemTemplate><asp:Label ID="intrusionEventId" runat="server" Text='<%# Bind("intrusionEventId","{0:00000}") %>'>></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalle">
                            <ItemTemplate><asp:Label ID="intrusionEventDetail" runat="server" Text='<%# Bind("intrusionEventDetail") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CVE">
                            <ItemTemplate><asp:Label ID="CVEId" runat="server" Text='<%# Bind("CVEId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CWE">
                            <ItemTemplate><asp:Label ID="CWEId" runat="server" Text='<%# Bind("CWEId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CAPEC">
                            <ItemTemplate><asp:Label ID="CAPECId" runat="server" Text='<%# Bind("CAPECId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="OWASP">
                            <ItemTemplate><asp:Label ID="OWASPId" runat="server" Text='<%# Bind("OWASPId") %>'>></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" SelectText="+" ShowSelectButton="True" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
            <td class="auto-style6" width="40%">
            </td>
            <td class="auto-style5" width="50%">
            </td>
            <td class="auto-style13" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style7" width="40%">
                Envento ID</td>
            <td class="auto-style8" width="50%">
                <asp:TextBox ID="txtIntrusionEventId" runat="server" TextMode="Number" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style9" width="10%">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10" width="40%">
                Detalle</td>
            <td class="auto-style11" width="50%">
                <asp:TextBox ID="txtIntrusionDetail" runat="server" Height="93px" TextMode="MultiLine" Width="467px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style12" valign="top" width="10%">
            <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7" width="40%">
                Referencia CVE</td>
            <td class="auto-style8" width="50%">
                <asp:TextBox ID="txtCVEId" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style9" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style7" width="40%">
                Referencia CWE</td>
            <td class="auto-style8" width="50%">
                <asp:TextBox ID="txtCWEId" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style9" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style7" width="40%">
                Referencia CAPEC</td>
            <td class="auto-style8" width="50%">
                <asp:TextBox ID="txtCAPECId" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style9" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style7" width="40%">
                Referencia OWASP</td>
            <td class="auto-style8" width="50%">
                <asp:TextBox ID="txtOWASPId" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style9" width="10%">
            </td>
        </tr>
        <tr>
            <td class="auto-style14" width="40%">
            </td>
            <td class="auto-style15" width="50%">
            </td>
            <td class="auto-style16" width="10%">
            </td>
        </tr>
        </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
        </tr>
    </table>
</asp:Content>

