<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="IDPSDashboard.Reports" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 133px;
        }
        .auto-style4 {
            width: 106px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td class="auto-style3">
            Seleccione
            <asp:Label runat="server" >IDPS</asp:Label>
        </td>
            <td class="auto-style4">

                <asp:DropDownList ID="ddlIDPS" runat="server">
                </asp:DropDownList>

            </td>
            <td>

                <asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Reportar" Width="82px" />

            </td>
        </tr>
    </table>
<table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
            <rsweb:ReportViewer ID="rpvEvents" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Enabled="False">
                <LocalReport ReportPath="Reports\EventsDetection.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </td>
        </tr>
    </table>
</asp:Content>
