<%@ Page Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="IDPSDashboard.Dashboard" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .auto-style2 {
            width: 290px;
        }
        .auto-style3 {
            width: 299px;
        }
        .auto-style4 {
            width: 833px;
        }
        .auto-style5 {
            width: 1098px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"><br />
<table style="border: thin solid #808080; width: 100%;">
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Dashboard"></asp:Label>
    </td>
    </tr>
</table>
<table style="border: thin solid #808080; width: 100%;">
    <tr>
    <td class="auto-style3" width="25%">

        <asp:Chart ID="pieChart" runat="server" ToolTip="Dimensión de Seguridad afectada por Eventos de Intrusión" AlternateText="Sin datos para mostrar...">
            <series>
                <asp:Series ChartType="Pie" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>

    </td>
    <td class="auto-style2" width="25%">
        <asp:Chart ID="barChartUsers" runat="server" ToolTip="Tareas Pendientes por Tecnico" AlternateText="Sin datos para mostrar...">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </td>
    <td class="auto-style2" width="25%">
        <asp:Chart ID="barChartTasks" runat="server" ToolTip="Tareas Pendientes por Estado" AlternateText="Sin datos para mostrar...">
            <series>
                <asp:Series Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </td>
    <td width="25%">
        <asp:Chart ID="funnelChart" runat="server" ToolTip="Intrusiones detectadas por IDPS" AlternateText="Sin datos para mostrar...">
            <series>
                <asp:Series ChartType="Funnel" Name="Series1" YValuesPerPoint="2">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </td>
    </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Eventos de Intrusión detectados"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr align="right">
            <td align="right" class="auto-style5" width="60%">
                Buscar</td>
            <td align="right" ="auto-style2" class="auto-style4" width="30%">
                <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 0px" Width="310px"></asp:TextBox>         
            </td>
            <td align="right" width="10%">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Buscar" Width="103px" />
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
            <asp:GridView ID="gvEventsDetection" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvEventsDetection_SelectedIndexChanged" ToolTip="Ir a Tarea asociada" OnPageIndexChanging="gvEventsDetection_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Detección">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate><asp:Label ID="eventsDetectionId" runat="server" Text='<%# Bind("eventsDetectionId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha" >
                        <ItemTemplate><asp:Label ID="datetime" DataFormatString="{0:d}" runat="server" Text='<%# Bind("datetime","{0:d}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="eventStauts" Visible="false">
                        <ItemTemplate><asp:Label ID="eventStauts" runat="server" Text='<%# Bind("eventStauts") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate><asp:Label ID="eventStatusDescription" runat="server" Text='<%# Bind("eventStatusDescription") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IDPSId" Visible="false">
                        <ItemTemplate><asp:Label ID="IDSId" runat="server" Text='<%# Bind("IDSId", "{0:00}") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IDPS">
                        <ItemTemplate><asp:Label ID="IDPS" runat="server" Text='<%# Bind("IDPS") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre IDPS">
                        <ItemTemplate><asp:Label ID="idsName" runat="server" Text='<%# Bind("idsName") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Control">
                        <ItemTemplate><asp:Label ID="eventsAlarmId" runat="server" Text='<%# Bind("eventsAlarmId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="severityId" Visible="false">
                        <ItemTemplate><asp:Label ID="severityId" runat="server" Text='<%# Bind("severityId") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Criticidad">
                        <ItemTemplate><asp:Label ID="severityDescription" runat="server" Text='<%# Bind("severityDescription") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SLA TTR">
                        <ItemTemplate><asp:Label ID="SLATimeToResponse" runat="server" Text='<%# Bind("SLATimeToResponse") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tarea">
                        <ItemTemplate><asp:Label ID="TaskId" runat="server" Text='<%# Bind("TaskId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IDPSEventId" Visible="false">
                        <ItemTemplate><asp:Label ID="IDPSEventId" runat="server" Text='<%# Bind("IDPSEventId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
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
        <td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </td>
        </tr>
    </table>
</asp:Content>