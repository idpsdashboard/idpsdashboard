<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="EventsAlarms.aspx.cs" Inherits="IDPSDashboard.EventosAlarmas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 400px;
            height: 35px;
        }
        .auto-style5 {
            height: 35px;
        }
    .auto-style6 {
        height: 36px;
    }
        .auto-style7 {
            height: 36px;
            width: 400px;
        }
        .auto-style8 {
            height: 36px;
            width: 133px;
        }
        .auto-style9 {
            width: 343px;
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Eventos controlados"></asp:Label>
        </td>
        </tr>
    </table>
    <table  style="border: thin solid #808080; width: 100%">
        <tr>
        <td>
            <asp:GridView ID="gvAlarms" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" PageSize="5" Width="100%" OnSelectedIndexChanged="gvAlarms_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Evento ID">
                        <ItemTemplate><asp:Label ID="eventsAlarmId" runat="server" Text='<%# Bind("eventsAlarmId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Detalle">
                        <ItemTemplate><asp:Label ID="eventsAlarmTittle" runat="server" Text='<%# Bind("eventsAlarmTittle") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Frecuecia Checkeo">
                        <ItemTemplate><asp:Label ID="checkFrecuency" runat="server" Text='<%# Bind("checkFrecuency") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="serverity" Visible="False">
                        <ItemTemplate><asp:Label ID="serverity" runat="server" Text='<%# Bind("serverity") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Criticidad">
                        <ItemTemplate><asp:Label ID="severityDescription" runat="server" Text='<%# Bind("severityDescription") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SLA TTR">
                        <ItemStyle HorizontalAlign="Right" />
                        <ItemTemplate><asp:Label ID="SLATimeToResponse" runat="server" Text='<%# Bind("SLATimeToResponse") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activo">
                        <ItemTemplate>
                        <asp:CheckBox ID="active" runat="server" Checked='<%# Bind("active") %>' Enabled="false" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" SelectText="+" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </td>
        </tr>
    </table>
    <table  style="border: thin solid #808080; width: 100%">
        <tr>
        <td>
        </td>
        </tr>
    </table>
        <table style="border: thin solid #808080; width: 100%">
            <tr>
            <td class="auto-style9">
                ID Evento Controlado</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtEventAlarmId" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
            </td>        
            </tr>
            <tr>
            <td class="auto-style9">
                Descripción del Control
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtEventsAlarmTittle" runat="server" Enabled="False" Width="360px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" Enabled="False" OnClick="btnSave_Click" />
            </td>        
            </tr>
            <tr>
            <td class="auto-style9">
                Frecuencia de Checkeo en Minutos</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtCheckFrequency" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" Width="100px" Enabled="False" />
            </td>        
            </tr>
            <tr>
            <td class="auto-style9">
                Nivel de Criticidad</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlSeverity" runat="server" Height="27px" Width="200px" Enabled="False">
                </asp:DropDownList>
            </td>
            <td class="auto-style5">
                &nbsp;</td>        
            </tr>
            <tr>
            <td class="auto-style9">
                Activo</td>
            <td class="auto-style4">
                <asp:CheckBox ID="chkActive" runat="server" Enabled="False" />
            </td>
            <td class="auto-style5">
            </td>        
            </tr>
            <tr>
            <td class="auto-style9">
                IDPS Responsable</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlIDPS" runat="server" Height="27px" Width="200px" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlIDPS_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            <td class="auto-style5">
                &nbsp;</td>        
            </tr>
            <tr>
            <td class="auto-style9">
                Categoria de Firma en IDPS</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlIDPSSignatures" runat="server" Height="27px" Width="200px" Enabled="False">
                </asp:DropDownList>
                </td>
            <td class="auto-style5">
                &nbsp;</td>        
            </tr>
            <tr>
            <td class="auto-style9">
                [BIA] Business Impact Analisys</td>
            <td class="auto-style4">
                <asp:CheckBoxList ID="chkBIA" runat="server" Width="380px" Enabled="False" ToolTip="Análisis de Impacto en el Negocio">
                    <asp:ListItem Value="1">Confidencialidad</asp:ListItem>
                    <asp:ListItem Value="2">Integridad</asp:ListItem>
                    <asp:ListItem Value="3">Disponibilidad</asp:ListItem>
                </asp:CheckBoxList>
                </td>
            <td class="auto-style5">
                &nbsp;</td>        
            </tr>
        </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Referencias sobre el Evento"></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
            <td valign="top" width="45%">
                <asp:GridView ID="gvIntrusionEvents" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" PageSize="5" Enabled="False" OnPageIndexChanging="gvIntrusionEvents_PageIndexChanging" OnSelectedIndexChanged="gvIntrusionEvents_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="intrusionEventsId" Visible="False">
                        <ItemTemplate><asp:Label ID="intrusionEventsId" runat="server" Text='<%# Bind("intrusionEventsId") %>'>></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalle" Visible="False">
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
                        <asp:CommandField ButtonType="Button" SelectText="Asociar" ShowSelectButton="True" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
            <td class="auto-style8" align="center" width="10%">
                <asp:ImageButton ID="btnSendRigth" runat="server" ImageUrl="~/images/rigth.png" Enabled="False" />
                <br />
                <br />
                <asp:ImageButton ID="btnSendLeft" runat="server" ImageUrl="~/images/left.png" Enabled="False" />
            </td>
            <td valign="top" width="45%">
                <asp:GridView ID="gvIntrusionEventsAssigned" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" ShowHeaderWhenEmpty="True" EmptyDataText="Sin Referencias asignadas" PageSize="5" Enabled="False" OnRowDeleting="gvIntrusionEventsAssigned_RowDeleting" OnPageIndexChanging="gvIntrusionEventsAssigned_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="intrusionEventsId" Visible="False">
                        <ItemTemplate><asp:Label ID="intrusionEventsId" runat="server" Text='<%# Bind("intrusionEventsId") %>'>></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Detalle" Visible="False">
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
                        <asp:CommandField ButtonType="Button" DeleteText="Quitar" ShowDeleteButton="True" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
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

