<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="IDPSDashboard.Tasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 577px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tarea de Tratamiento de Eventos de Intrusion"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr align="right">
            <td align="right" class="auto-style1">
                Buscar</td>
            <td align="right" ="auto-style2" class="auto-style2">
                <asp:TextBox ID="txtSearch" runat="server" style="margin-left: 0px" Width="326px"></asp:TextBox>         
            </td>
            <td align="right">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Buscar" Width="103px" />
            </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
            <asp:GridView ID="gvTasks" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="100%" OnSelectedIndexChanged="gvTasks_SelectedIndexChanged" PageSize="20" OnPageIndexChanging="gvTasks_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Tarea">
                        <ItemTemplate><asp:Label ID="taskId" runat="server" Text='<%# Bind("taskId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate><asp:Label ID="datetime" runat="server" Text='<%# Bind("datetime","{0:d}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Titulo">
                        <ItemTemplate><asp:Label ID="taskTittle" runat="server" Text='<%# Bind("taskTittle") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Evento Detección">
                        <ItemTemplate><asp:Label ID="eventsDetectionId" runat="server" Text='<%# Bind("eventsDetectionId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="taskStatusId" Visible="false">
                        <ItemTemplate><asp:Label ID="taskStatusId" runat="server" Text='<%# Bind("taskStatusId") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate><asp:Label ID="statusDescription" runat="server" Text='<%# Bind("statusDescription") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="userId" Visible="false">
                        <ItemTemplate><asp:Label ID="userId" runat="server" Text='<%# Bind("userId") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate><asp:Label ID="userName" runat="server" Text='<%# Bind("userName") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="serverityId" Visible="false">
                        <ItemTemplate><asp:Label ID="serverityId" runat="server" Text='<%# Bind("serverityId") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Criticidad">
                        <ItemTemplate><asp:Label ID="sererityDescription" runat="server" Text='<%# Bind("sererityDescription") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SLA">
                        <ItemTemplate><asp:Label ID="SLAStatus" runat="server" Text='<%# Bind("SLAStatus") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" SelectText="+" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
            <td class="auto-style6">
                <div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
