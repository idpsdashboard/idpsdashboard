<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="IDPSDashboard.TaskDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 529px;
        }
        .auto-style3 {
            width: 524px;
        }
        .auto-style4 {
            width: 774px;
        }
        .auto-style5 {
            width: 524px;
            height: 27px;
        }
        .auto-style6 {
            width: 774px;
            height: 27px;
        }
        .auto-style7 {
            width: 524px;
            height: 30px;
        }
        .auto-style8 {
            width: 774px;
            height: 30px;
        }
        .auto-style9 {
            width: 783px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tarea ID: "></asp:Label>
        <asp:Label ID="lblTaskId" runat="server" Font-Bold="True" Text=""></asp:Label>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080;width: 100%;">
        <tr align="right">
            <td align="right" class="auto-style9">
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
            <asp:GridView ID="gvTask" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%">
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
                </Columns>
            </asp:GridView>
       </td>
       </tr>
     </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Detalles de la Tarea"></asp:Label>
       </td>
       </tr>
     </table>
    <table style="border: thin solid #808080; width: 100%;">
        <tr>
        <td>
            <asp:GridView ID="gvTaskDetails" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" Width="100%" OnSelectedIndexChanged="gvTaskDetails_SelectedIndexChanged" OnPageIndexChanging="gvTaskDetails_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Detalle ID">
                        <ItemTemplate><asp:Label ID="taskDetailsId" runat="server" Text='<%# Bind("taskDetailsId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="taskId" Visible="False">
                        <ItemTemplate><asp:Label ID="taskId" runat="server" Text='<%# Bind("taskId","{0:00000}") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Detalle">
                        <ItemTemplate><asp:Label ID="taskDetails" runat="server" Text='<%# Bind("taskDetails") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate><asp:Label ID="datetime" runat="server" Text='<%# Bind("datetime","{0:d}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hs Duracion">
                        <ItemTemplate><asp:Label ID="effortHours" runat="server" Text='<%# Bind("effortHours","{0:00.00}") %>'>></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="userId" Visible="False">
                        <ItemTemplate><asp:Label ID="userId" runat="server" Text='<%# Bind("userId") %>'>></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario">
                        <ItemTemplate><asp:Label ID="userName" runat="server" Text='<%# Bind("userName") %>'>></asp:Label>
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
    <table  style="border: thin solid #808080; width: 100%">
        <tr>
        <td>
        </td>
        </tr>
    </table>
    <table style="border: thin solid #808080; width: 100%">
        <tr>
        <td class="auto-style7" width="30%">
            Detalle ID</td>
        <td class="auto-style8" width="60%">
            <asp:TextBox ID="txtTaskDetailId" runat="server" Enabled="False" Height="16px"></asp:TextBox>
        </td>
        <td class="auto-style7" width="10%">
            <asp:Button ID="btnNew" runat="server" Text="Nuevo" Width="100px" OnClick="btnNew_Click" />
        </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Fecha
        </td>
        <td class="auto-style8" width="60%">
            <asp:TextBox ID="txtDateTime" runat="server" Enabled="False" ToolTip="Click para desplegar Calendario" Height="16px" Width="196px"></asp:TextBox>  
            <ajaxToolkit:CalendarExtender   Format="dd/MM/yyyy" ID="CalendarExtender"   TargetControlID="txtDateTime" runat="server" /> 
        </td>
        <td class="auto-style7" width="10%">
            <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100px" Enabled="False" OnClick="btnSave_Click" />
        </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Horas Esfuerzo</td>
        <td class="auto-style8" width="60%">
            <asp:TextBox ID="txtEffortHours" runat="server" Enabled="False" Height="16px"></asp:TextBox>
        </td>
        <td class="auto-style7" width="10%">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" Width="100px" Enabled="False" />
        </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Usuario</td>
        <td class="auto-style8" width="60%">
            <asp:DropDownList ID="ddlUsers" runat="server" Enabled="False" Width="200px">
            </asp:DropDownList>
        </td>
        <td class="auto-style7" width="10%">
            </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Cambiar Estado Tarea</td>
        <td class="auto-style8" width="60%">
            <asp:DropDownList ID="ddlTaskStatus" runat="server" Enabled="False" Height="22px" Width="126px" AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td class="auto-style7" width="10%">
            </td>        
        </tr>
        <tr>
        <td class="auto-style3" width="30%">
            Detalle</td>
        <td class="auto-style4" width="60%">
            <asp:TextBox ID="txtDetail" runat="server" Enabled="False" Height="125px" TextMode="MultiLine" Width="421px"></asp:TextBox>
        </td>
        <td class="auto-style5" width="10%">
        </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Subir imagen</td>
        <td class="auto-style8" width="60%">
            <asp:FileUpload ID="fileUpload" runat="server" Enabled="False" Height="22px" Width="336px" />
        </td>
        <td class="auto-style7" width="10%">
            </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            Enviar Detalle por mail</td>
        <td class="auto-style8" width="60%">
            <asp:TextBox ID="txtTaskId0" runat="server" Enabled="False" TextMode="Email" Width="415px" Height="16px"></asp:TextBox>
        </td>
        <td class="auto-style7" width="10%">
            <asp:Button ID="btnSendMail" runat="server" Enabled="False" Height="26px" Text="Enviar" Width="100px" />
            </td>        
        </tr>
        <tr>
        <td class="auto-style7" width="30%">
            </td>
        <td class="auto-style8" width="60%">
            <asp:TextBox ID="txtTaskId" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:HiddenField ID="hfTaskStatusOrigin" runat="server" />
            <asp:HiddenField ID="hfUserOrigin" runat="server" />
        </td>
        <td class="auto-style7" width="10%">
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
