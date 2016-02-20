using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using IDPSDashboard.Model;
using IDPSDashboard.Business;
using System.Web.UI.DataVisualization.Charting;

namespace IDPSDashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.AppendHeader("Refresh", 30 + "; URL=Dashboard.aspx");
                gvGetData();
                generateCharts();
            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]); 
            }
        }

        protected void gvGetData()
        {
            lblMessage.Text = "";
            getEventsDetectionData();
        }

        protected void getEventsDetectionData()
        {
            DataTable dttEventsDetection = new DataTable();
            dttEventsDetection.Columns.Add(new DataColumn("eventsDetectionId", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
            dttEventsDetection.Columns.Add(new DataColumn("eventStauts", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("eventStatusDescription", System.Type.GetType("System.String")));
            dttEventsDetection.Columns.Add(new DataColumn("IDSId", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("IDPS", System.Type.GetType("System.String")));
            dttEventsDetection.Columns.Add(new DataColumn("idsName", System.Type.GetType("System.String")));
            dttEventsDetection.Columns.Add(new DataColumn("eventsAlarmId", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("severityId", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("severityDescription", System.Type.GetType("System.String")));
            dttEventsDetection.Columns.Add(new DataColumn("SLATimeToResponse", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("TaskId", System.Type.GetType("System.Int32")));
            dttEventsDetection.Columns.Add(new DataColumn("IDPSEventId", System.Type.GetType("System.Int32")));

            List<eventsdetection> lstEvetnsDetection = new List<eventsdetection>();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();

            idsBus oIDPS = new idsBus();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();
            severityBus oSeverity = new severityBus();
            tasksBus oTask = new tasksBus();
            taskstatusBus oTaskStatus = new taskstatusBus();

            lstEvetnsDetection = oEventsDetection.eventsdetectionGetAll();

            if (lstEvetnsDetection.Count > 0)
            {
                foreach (eventsdetection row in lstEvetnsDetection)
                {
                    if (row.EventStatus == 2 || row.EventStatus == 5) //Closed, Rejected
                        continue;
                    
                    ids auxIDPS = new ids();
                    eventsalarm auxEventAlarm = new eventsalarm();
                    severity auxSeverity = new severity();
                    tasks auxTask = new tasks();
                    taskstatus auxTaskStatus = new taskstatus();

                    auxIDPS = oIDPS.idsGetById(row.IdsId);
                    auxEventAlarm = oEventsAlarm.eventsalarmGetById(row.EventsAlarmId);
                    auxSeverity = oSeverity.severityGetById(auxEventAlarm.Severity);
                    auxTask = oTask.tasksGetByEventsDetectionId(row.EventsDetectionId);
                    auxTaskStatus = oTaskStatus.taskstatusGetById(row.EventStatus);

                    dttEventsDetection.Rows.Add(row.EventsDetectionId,
                                                row.DateTime,
                                                row.EventStatus,
                                                auxTaskStatus.TaskStatusDescription,
                                                row.IdsId,
                                                auxIDPS.IdsIP,
                                                auxIDPS.idsName,
                                                row.EventsAlarmId,
                                                auxSeverity.SeverityId,
                                                auxSeverity.SeverityDescription,
                                                auxSeverity.SLATimeToResponse,
                                                auxTask.TaskId,
                                                row.IDPSEventId);
                }

                gvEventsDetection.DataSource = dttEventsDetection;
                gvEventsDetection.DataBind();
            }
        }

        protected void gvEventsDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEventsDetection.SelectedRow;

            try
            {
                Session["TaskId"] = ((Label)row.FindControl("taskId")).Text;
                Response.Redirect("~/TaskDetails.aspx");
            }
            catch
            {

            }
        }

        protected void gvEventsDetection_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventsDetection.PageIndex = e.NewPageIndex;
            getEventsDetectionData();            
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                DataTable dttEventsDetection = new DataTable();
                dttEventsDetection.Columns.Add(new DataColumn("eventsDetectionId", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
                dttEventsDetection.Columns.Add(new DataColumn("eventStauts", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("eventStatusDescription", System.Type.GetType("System.String")));
                dttEventsDetection.Columns.Add(new DataColumn("IDSId", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("IDPS", System.Type.GetType("System.String")));
                dttEventsDetection.Columns.Add(new DataColumn("idsName", System.Type.GetType("System.String")));
                dttEventsDetection.Columns.Add(new DataColumn("eventsAlarmId", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("severityId", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("severityDescription", System.Type.GetType("System.String")));
                dttEventsDetection.Columns.Add(new DataColumn("SLATimeToResponse", System.Type.GetType("System.Int32")));
                dttEventsDetection.Columns.Add(new DataColumn("TaskId", System.Type.GetType("System.Int32")));

                eventsdetection auxEvetnsDetection = new eventsdetection();
                eventsdetectionBus oEventsDetection = new eventsdetectionBus();

                idsBus oIDPS = new idsBus();
                eventsalarmBus oEventsAlarm = new eventsalarmBus();
                severityBus oSeverity = new severityBus();
                tasksBus oTask = new tasksBus();

                auxEvetnsDetection = oEventsDetection.eventsdetectionGetById(Convert.ToInt32(txtSearch.Text));

                if (auxEvetnsDetection != null)
                {
                    string strStatus = "";
                    ids auxIDPS = new ids();
                    eventsalarm auxEventAlarm = new eventsalarm();
                    severity auxSeverity = new severity();
                    tasks auxTask = new tasks();

                    switch (auxEvetnsDetection.EventStatus)
                    {
                        case 1: strStatus = "Pendiente"; break;
                        case 2: strStatus = "En tratamiento"; break;
                        case 3: strStatus = "Cerrado"; break;
                    }

                    auxIDPS = oIDPS.idsGetById(auxEvetnsDetection.IdsId);
                    auxEventAlarm = oEventsAlarm.eventsalarmGetById(auxEvetnsDetection.EventsAlarmId);
                    auxSeverity = oSeverity.severityGetById(auxEventAlarm.Severity);
                    auxTask = oTask.tasksGetByEventsDetectionId(auxEvetnsDetection.EventsDetectionId);

                    dttEventsDetection.Rows.Add(auxEvetnsDetection.EventsDetectionId,
                                                auxEvetnsDetection.DateTime,
                                                auxEvetnsDetection.EventStatus,
                                                strStatus,
                                                auxEvetnsDetection.IdsId,
                                                auxIDPS.IdsIP,
                                                auxIDPS.idsName,
                                                auxEvetnsDetection.EventsAlarmId,
                                                auxSeverity.SeverityId,
                                                auxSeverity.SeverityDescription,
                                                auxSeverity.SLATimeToResponse,
                                                auxTask.TaskId);

                    gvEventsDetection.DataSource = dttEventsDetection;
                    gvEventsDetection.DataBind();
                }
                else
                {
                    lblMessage.Text = "Busqueda sin resultados...";
                }
            }
        }

        protected void generateCharts()
        {
            generatePieChart();
            generateBarChartUsers();
            generateBarChartTasks();
            generateFunnelChart();
        }

        protected void generatePieChart()
        {
            DataTable dttSecurityDimensionAffected = new DataTable();
            dttSecurityDimensionAffected.Columns.Add(new DataColumn("dimensionId", System.Type.GetType("System.Int32")));
            dttSecurityDimensionAffected.Columns.Add(new DataColumn("Dimension", System.Type.GetType("System.String")));
            dttSecurityDimensionAffected.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));

            List<eventsdetection> lstEventsDetection = new List<eventsdetection>();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();

            eventsalarm auxEventsAlarm = new eventsalarm();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();

            lstEventsDetection = oEventsDetection.eventsdetectionGetAll();

            if (lstEventsDetection.Count > 0)
            {
                int qtyConfidence = 0;
                int qtyIntegrity = 0;
                int qtyAvailability = 0;

                foreach (eventsdetection detectionRow in lstEventsDetection)
                {
                    auxEventsAlarm = oEventsAlarm.eventsalarmGetById(detectionRow.EventsAlarmId);

                    if (Convert.ToBoolean(auxEventsAlarm.AffectConfidence))
                        qtyConfidence++;
                    if (Convert.ToBoolean(auxEventsAlarm.AffectIntegrity))
                        qtyIntegrity++;
                    if (Convert.ToBoolean(auxEventsAlarm.AffectAvailability))
                        qtyAvailability++;
                }

                dttSecurityDimensionAffected.Rows.Add(1, "Confidencialidad", qtyConfidence);
                dttSecurityDimensionAffected.Rows.Add(2, "Integridad"      , qtyIntegrity);
                dttSecurityDimensionAffected.Rows.Add(3, "Disponibilidad"  , qtyAvailability);

                pieChart.Series[0].XValueMember = "Dimension";
                pieChart.Series[0].YValueMembers = "Quantity";
                pieChart.DataSource = dttSecurityDimensionAffected;
                pieChart.DataBind();
            }
        }

        protected void generateBarChartUsers()
        {
            DataTable dttTaskByUser = new DataTable();
            dttTaskByUser.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
            dttTaskByUser.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
            dttTaskByUser.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));
            
            List<users> lstUsers = new List<users>();
            usersBus oUsers = new usersBus();

            List<tasks> lstTasks = new List<tasks>();
            tasksBus oTask = new tasksBus();

            lstUsers = oUsers.usersGetAll();

            if (lstUsers.Count > 0)
            {
                foreach (users rowUser in lstUsers)
                {
                    int qtyTask = 0;
                    if (Convert.ToBoolean(rowUser.UserActive))
                    {
                        lstTasks = oTask.tasksGetAll();
                        foreach (tasks rowTask in lstTasks)
                        {
                            if (rowTask.UserId == rowUser.UserId)
                                if (rowTask.TaskStatudId != 2) //Closed
                                    if (rowTask.TaskStatudId != 5) //Rejected
                                        qtyTask++;
                        }

                        dttTaskByUser.Rows.Add(rowUser.UserId, rowUser.UserName, qtyTask);                                    
                    }
                }
            }

            //Task without User
            int qtyWithoutUser = 0;
            lstTasks = oTask.tasksGetAll();
            if (lstTasks.Count > 0)
            {
                foreach (tasks row in lstTasks)
                    if (row.UserId < 1)
                        qtyWithoutUser++;

                if (qtyWithoutUser > 0)
                    dttTaskByUser.Rows.Add(0, "No asignado", qtyWithoutUser);                                    
            }

            barChartUsers.Series[0].XValueMember = "userName";
            barChartUsers.Series[0].YValueMembers = "Quantity";
            barChartUsers.DataSource = dttTaskByUser;
            barChartUsers.DataBind();          
        }

        protected void generateBarChartTasks()
        {
            DataTable dttTaskByStatus = new DataTable();
            dttTaskByStatus.Columns.Add(new DataColumn("statusId", System.Type.GetType("System.Int32")));
            dttTaskByStatus.Columns.Add(new DataColumn("StatusName", System.Type.GetType("System.String")));
            dttTaskByStatus.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));

            List<taskstatus> lstTaskStatus = new List<taskstatus>();
            taskstatusBus oTaskStatus = new taskstatusBus();

            List<tasks> lstTasks = new List<tasks>();
            tasksBus oTask = new tasksBus();

            lstTaskStatus = oTaskStatus.taskstatusGetAll();

            if (lstTaskStatus.Count > 0)
            {
                foreach (taskstatus rowTaskStatus in lstTaskStatus)
                {
                    int qtyTask = 0;
       
                    lstTasks = oTask.tasksGetAll();
                    
                    foreach (tasks rowTask in lstTasks)
                    {
                        if (rowTask.TaskStatudId == rowTaskStatus.TaskStatusId)
                            if (rowTask.TaskStatudId != 2) //Closed
                                if (rowTask.TaskStatudId != 5) //Rejected
                                    qtyTask++;
                    }

                   dttTaskByStatus.Rows.Add(rowTaskStatus.TaskStatusId, rowTaskStatus.TaskStatusDescription, qtyTask);
                }
             }

            barChartTasks.Series[0].XValueMember = "StatusName";
            barChartTasks.Series[0].YValueMembers = "Quantity";
            barChartTasks.DataSource = dttTaskByStatus;
            barChartTasks.DataBind();
        }

        protected void generateFunnelChart()
        {
            DataTable dttIntrusionByIDPS = new DataTable();
            dttIntrusionByIDPS.Columns.Add(new DataColumn("idpsId", System.Type.GetType("System.Int32")));
            dttIntrusionByIDPS.Columns.Add(new DataColumn("idpsName", System.Type.GetType("System.String")));
            dttIntrusionByIDPS.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));

            List<eventsdetection> lstEventsDetection = new List<eventsdetection>();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();

            List<ids> lstIDPS = new List<ids>();
            idsBus oIDPS = new idsBus();

            lstIDPS = oIDPS.idsGetAll();

            if (lstIDPS.Count > 0)
            {
                foreach (ids rowIDPS in lstIDPS)
                {
                    int qtyIntrusion = 0;
                    if (Convert.ToBoolean(rowIDPS.Active))
                    {
                        lstEventsDetection = oEventsDetection.eventsdetectionGetAll();
                        foreach (eventsdetection rowEvent in lstEventsDetection)
                        {
                            if (rowEvent.IdsId == rowIDPS.IdsId)
                                qtyIntrusion++;
                        }

                        dttIntrusionByIDPS.Rows.Add(rowIDPS.IdsId, rowIDPS.idsName, qtyIntrusion);
                    }
                }
            }

            funnelChart.Legends.Add(new Legend("Leyenda"));
            funnelChart.Legends["Leyenda"].DockedToChartArea = "ChartArea1";
            funnelChart.Legends["Leyenda"].IsDockedInsideChartArea = false;
            funnelChart.Series["Series1"].Legend = "Leyenda";
            funnelChart.Series["Series1"].IsVisibleInLegend = true;

            funnelChart.Series[0].XValueMember = "idpsName";
            funnelChart.Series[0].YValueMembers = "Quantity";
            funnelChart.DataSource = dttIntrusionByIDPS;
            funnelChart.DataBind();                  
        }
    }
}