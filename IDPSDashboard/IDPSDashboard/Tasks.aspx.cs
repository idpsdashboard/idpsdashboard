using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDPSDashboard.Model;
using IDPSDashboard.Business;

namespace IDPSDashboard
{
    public partial class Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.AppendHeader("Refresh", 30 + "; URL=Tasks.aspx");
                gvGetData();
            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]);
            }
        }

        protected void gvGetData()
        {
            lblMessage.Text = "";
            getTasksData();
        }

        private void getTasksData()
        {
            DataTable dttTasks = new DataTable();
            dttTasks.Columns.Add(new DataColumn("taskId", System.Type.GetType("System.Int32")));
            dttTasks.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
            dttTasks.Columns.Add(new DataColumn("taskTittle", System.Type.GetType("System.String")));
            dttTasks.Columns.Add(new DataColumn("eventsDetectionId", System.Type.GetType("System.Int32")));
            dttTasks.Columns.Add(new DataColumn("taskStatusId", System.Type.GetType("System.Int32")));
            dttTasks.Columns.Add(new DataColumn("statusDescription", System.Type.GetType("System.String")));
            dttTasks.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
            dttTasks.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
            dttTasks.Columns.Add(new DataColumn("serverityId", System.Type.GetType("System.Int32")));
            dttTasks.Columns.Add(new DataColumn("sererityDescription", System.Type.GetType("System.String")));
            dttTasks.Columns.Add(new DataColumn("SLAStatus", System.Type.GetType("System.String")));

            List<tasks> lstTasks = new List<tasks>();
            tasksBus oTasks = new tasksBus();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();
            idsBus oIDPS = new idsBus();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();
            severityBus oSeverity = new severityBus();
            taskstatusBus oTaskStatus = new taskstatusBus();
            usersBus oUsers = new usersBus();

            lstTasks = oTasks.tasksGetAll();

            if (lstTasks.Count > 0)
            {
                foreach (tasks row in lstTasks)
                {
                    if (row.TaskStatudId == 2 || row.TaskStatudId == 5) //Closed, Rejected
                        continue;
                   
                    taskstatus auxStatus = new taskstatus();
                    users auxUser = new users();
                    eventsdetection auxEventDetection = new eventsdetection();
                    eventsalarm auxEventAlarm = new eventsalarm();
                    severity auxSeverity = new severity();
                    string SLASatus = "";

                    auxStatus = oTaskStatus.taskstatusGetById(row.TaskStatudId);
                    auxUser = oUsers.usersGetById(row.UserId);
                    auxEventDetection = oEventsDetection.eventsdetectionGetById(row.EventsDetectionId);
                    auxEventAlarm = oEventsAlarm.eventsalarmGetById(auxEventDetection.EventsAlarmId);
                    auxSeverity = oSeverity.severityGetById(auxEventAlarm.Severity);

                    DateTime deadTime = row.DateTime;
                    deadTime.AddMinutes(auxSeverity.SLATimeToResponse);
                    if (DateTime.Now > deadTime) { SLASatus = "Vencido"; }
                    if (DateTime.Now < deadTime) { SLASatus = "En término"; }

                    dttTasks.Rows.Add(row.TaskId,
                                      row.DateTime,
                                      row.TaskTittle,
                                      row.EventsDetectionId,
                                      row.TaskStatudId,
                                      auxStatus.TaskStatusDescription,
                                      row.UserId,
                                      auxUser.UserName,
                                      auxEventAlarm.Severity,
                                      auxSeverity.SeverityDescription,
                                      SLASatus);               
                }

                gvTasks.DataSource = dttTasks;
                gvTasks.DataBind();
            }
            
        }

        protected void gvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTasks.SelectedRow;

           try
            {
                Session["TaskId"] = ((Label)row.FindControl("taskId")).Text;
                Response.Redirect("~/TaskDetails.aspx");
            }
            catch
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                DataTable dttTasks = new DataTable();
                dttTasks.Columns.Add(new DataColumn("taskId", System.Type.GetType("System.Int32")));
                dttTasks.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
                dttTasks.Columns.Add(new DataColumn("taskTittle", System.Type.GetType("System.String")));
                dttTasks.Columns.Add(new DataColumn("eventsDetectionId", System.Type.GetType("System.Int32")));
                dttTasks.Columns.Add(new DataColumn("taskStatusId", System.Type.GetType("System.Int32")));
                dttTasks.Columns.Add(new DataColumn("statusDescription", System.Type.GetType("System.String")));
                dttTasks.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
                dttTasks.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
                dttTasks.Columns.Add(new DataColumn("serverityId", System.Type.GetType("System.Int32")));
                dttTasks.Columns.Add(new DataColumn("sererityDescription", System.Type.GetType("System.String")));
                dttTasks.Columns.Add(new DataColumn("SLAStatus", System.Type.GetType("System.String")));

                tasks auxtTasks = new tasks();
                tasksBus oTasks = new tasksBus();
                eventsdetectionBus oEventsDetection = new eventsdetectionBus();
                idsBus oIDPS = new idsBus();
                eventsalarmBus oEventsAlarm = new eventsalarmBus();
                severityBus oSeverity = new severityBus();
                taskstatusBus oTaskStatus = new taskstatusBus();
                usersBus oUsers = new usersBus();

                auxtTasks = oTasks.tasksGetById(Convert.ToInt32(txtSearch.Text));

                if (auxtTasks != null)
                {
                    taskstatus auxStatus = new taskstatus();
                    users auxUser = new users();
                    eventsdetection auxEventDetection = new eventsdetection();
                    eventsalarm auxEventAlarm = new eventsalarm();
                    severity auxSeverity = new severity();

                    auxStatus = oTaskStatus.taskstatusGetById(auxtTasks.TaskStatudId);
                    auxUser = oUsers.usersGetById(auxtTasks.UserId);
                    auxEventDetection = oEventsDetection.eventsdetectionGetById(auxtTasks.EventsDetectionId);
                    auxEventAlarm = oEventsAlarm.eventsalarmGetById(auxEventDetection.EventsAlarmId);
                    auxSeverity = oSeverity.severityGetById(auxEventAlarm.Severity);

                    //resolver SLAStatus

                    dttTasks.Rows.Add(auxtTasks.TaskId,
                                        auxtTasks.DateTime,
                                        auxtTasks.TaskTittle,
                                        auxtTasks.EventsDetectionId,
                                        auxtTasks.TaskStatudId,
                                        auxStatus.TaskStatusDescription,
                                        auxtTasks.UserId,
                                        auxUser.UserName,
                                        auxEventAlarm.Severity,
                                        auxSeverity.SeverityDescription,
                                        "");

                    gvTasks.DataSource = dttTasks;
                    gvTasks.DataBind();
                }
                else
                {
                    lblMessage.Text = "Busqueda sin resultados...";
                }
            }
        }

        protected void gvTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTasks.PageIndex = e.NewPageIndex;
            getTasksData();
        }
    }
}