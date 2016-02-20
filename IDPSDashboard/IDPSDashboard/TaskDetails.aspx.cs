using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDPSDashboard.Model;
using IDPSDashboard.Business;
using System.Globalization;
using System.Threading;

namespace IDPSDashboard
{
    public partial class TaskDetails : System.Web.UI.Page
    {
        public int TaskId;
        public bool TaskStatusChanged;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {  
                gvGetData();
            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]);
            }
        }

        protected void gvGetData()
        {
            string auxParam = (string)(Session["TaskId"]);

            if (!String.IsNullOrEmpty(auxParam))
            { 
                TaskId = Convert.ToInt32(auxParam);
                lblTaskId.Text = (string)(Session["TaskId"]);
                txtTaskId.Text = (string)(Session["TaskId"]);
            }

            lblMessage.Text = "";

            if (!Page.IsPostBack)
            {
                getTaskData(TaskId);
                getTaskDetailsData(TaskId);
                getTaskStatus();
                getUsersData();
            }
        }

        protected void getTaskData(int taskId)
        {
            DataTable dttTask = new DataTable();
            dttTask.Columns.Add(new DataColumn("taskId", System.Type.GetType("System.Int32")));
            dttTask.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
            dttTask.Columns.Add(new DataColumn("taskTittle", System.Type.GetType("System.String")));
            dttTask.Columns.Add(new DataColumn("eventsDetectionId", System.Type.GetType("System.Int32")));
            dttTask.Columns.Add(new DataColumn("taskStatusId", System.Type.GetType("System.Int32")));
            dttTask.Columns.Add(new DataColumn("statusDescription", System.Type.GetType("System.String")));
            dttTask.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
            dttTask.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
            dttTask.Columns.Add(new DataColumn("serverityId", System.Type.GetType("System.Int32")));
            dttTask.Columns.Add(new DataColumn("sererityDescription", System.Type.GetType("System.String")));
            dttTask.Columns.Add(new DataColumn("SLAStatus", System.Type.GetType("System.String")));

            tasks auxtTasks = new tasks();
            tasksBus oTasks = new tasksBus();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();
            idsBus oIDPS = new idsBus();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();
            severityBus oSeverity = new severityBus();
            taskstatusBus oTaskStatus = new taskstatusBus();
            usersBus oUsers = new usersBus();

            auxtTasks = oTasks.tasksGetById(taskId);

            if (auxtTasks != null)
            {
                taskstatus auxStatus = new taskstatus();
                users auxUser = new users();
                eventsdetection auxEventDetection = new eventsdetection();
                eventsalarm auxEventAlarm = new eventsalarm();
                severity auxSeverity = new severity();
                string SLASatus = "";

                auxStatus = oTaskStatus.taskstatusGetById(auxtTasks.TaskStatudId);
                auxUser = oUsers.usersGetById(auxtTasks.UserId);
                auxEventDetection = oEventsDetection.eventsdetectionGetById(auxtTasks.EventsDetectionId);
                auxEventAlarm = oEventsAlarm.eventsalarmGetById(auxEventDetection.EventsAlarmId);
                auxSeverity = oSeverity.severityGetById(auxEventAlarm.Severity);

                DateTime deadTime = auxtTasks.DateTime;
                deadTime.AddMinutes(auxSeverity.SLATimeToResponse);
                if (DateTime.Now > deadTime) { SLASatus = "Vencido"; }
                if (DateTime.Now < deadTime) { SLASatus = "En término"; }

                dttTask.Rows.Add(auxtTasks.TaskId,
                                    auxtTasks.DateTime,
                                    auxtTasks.TaskTittle,
                                    auxtTasks.EventsDetectionId,
                                    auxtTasks.TaskStatudId,
                                    auxStatus.TaskStatusDescription,
                                    auxtTasks.UserId,
                                    auxUser.UserName,
                                    auxEventAlarm.Severity,
                                    auxSeverity.SeverityDescription,
                                    SLASatus);

                gvTask.DataSource = dttTask;
                gvTask.DataBind();
            }
        }

        protected void getTaskDetailsData(int taskId)
        {
            DataTable dttTaskDetails = new DataTable();
            dttTaskDetails.Columns.Add(new DataColumn("taskDetailsId", System.Type.GetType("System.Int32")));
            dttTaskDetails.Columns.Add(new DataColumn("taskId", System.Type.GetType("System.Int32")));
            dttTaskDetails.Columns.Add(new DataColumn("taskDetails", System.Type.GetType("System.String")));
            dttTaskDetails.Columns.Add(new DataColumn("datetime", System.Type.GetType("System.DateTime")));
            dttTaskDetails.Columns.Add(new DataColumn("effortHours", System.Type.GetType("System.Decimal")));
            dttTaskDetails.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
            dttTaskDetails.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
            
            List<taskdetails> lstTaskDetails = new List<taskdetails>();
            taskdetailsBus oTaskDetails = new taskdetailsBus();
            usersBus oUsers = new usersBus();

            lstTaskDetails = oTaskDetails.taskdetailsGetByTaskId(taskId);

            if (lstTaskDetails.Count > 0)
            {
                foreach (taskdetails row in lstTaskDetails)
                { 
                    users auxUser = new users();
                    auxUser = oUsers.usersGetById(row.UserId);

                    dttTaskDetails.Rows.Add(row.TaskDetailsId,
                                            row.TaskId,
                                            row.Details,
                                            row.DateTime,
                                            row.EffortHours,
                                            row.UserId,
                                            auxUser.UserName);
                }

                gvTaskDetails.DataSource = dttTaskDetails;
                gvTaskDetails.DataBind();
            }
        }

        protected void getTaskStatus()
        {
            List<taskstatus> lstTaskStatus = new List<taskstatus>();
            taskstatusBus oTaskStatus = new taskstatusBus();

            lstTaskStatus = oTaskStatus.taskstatusGetAll();

            if (lstTaskStatus.Count > 0)
            {
                ddlTaskStatus.DataSource = lstTaskStatus;
                ddlTaskStatus.DataValueField = "taskStatusId";
                ddlTaskStatus.DataTextField = "taskStatusDescription";
                ddlTaskStatus.DataBind(); 
            }        
        }

        protected void getUsersData()
        {
            List<users> lstUsers = new List<users>();
            usersBus oUsers = new usersBus();

            lstUsers = oUsers.usersGetAll();

            if (lstUsers.Count > 0)
            {
                ddlUsers.DataSource = lstUsers;
                ddlUsers.DataValueField = "userId";
                ddlUsers.DataTextField = "userName";
                ddlUsers.DataBind();             
            }
        }

        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtTaskDetailId.Enabled = false;
                txtDateTime.Enabled = true;
                txtEffortHours.Enabled = true;
                txtDetail.Enabled = true;
                fileUpload.Enabled = true;
                ddlTaskStatus.Enabled = true;
                ddlUsers.Enabled = true;
            }

            if (disable)
            {
                txtTaskDetailId.Enabled = false;
                txtDateTime.Enabled = false;
                txtEffortHours.Enabled = false;
                txtDetail.Enabled = false;
                fileUpload.Enabled = false;
                ddlTaskStatus.Enabled = false;
                ddlUsers.Enabled = true;
            }
        }

        protected void clearFields()
        {
            txtTaskDetailId.Text = "";
            txtDateTime.Text = "";
            txtEffortHours.Text = "";
            txtDetail.Text = "";
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void gvTaskDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvTaskDetails.SelectedRow;

            tasks auxTask = new tasks();
            tasksBus oTask = new tasksBus();

            if ((Label)row.FindControl("taskDetailsId") != null) { txtTaskDetailId.Text = ((Label)row.FindControl("taskDetailsId")).Text; } else { txtTaskDetailId.Text = ""; }
            if ((Label)row.FindControl("datetime") != null) { txtDateTime.Text = ((Label)row.FindControl("datetime")).Text; } else { txtDateTime.Text = ""; }
            if ((Label)row.FindControl("effortHours") != null) { txtEffortHours.Text = ((Label)row.FindControl("effortHours")).Text; } else { txtEffortHours.Text = ""; }
            if ((Label)row.FindControl("taskDetails") != null) { txtDetail.Text = ((Label)row.FindControl("taskDetails")).Text; } else { txtDetail.Text = ""; }
            if ((Label)row.FindControl("taskId") != null) { txtTaskId.Text = ((Label)row.FindControl("taskId")).Text; } else { txtTaskId.Text = ""; }

            try
            {
                auxTask = oTask.tasksGetById(Convert.ToInt32(txtTaskId.Text));
                ddlTaskStatus.SelectedValue = auxTask.TaskStatudId.ToString();
                ddlUsers.SelectedValue = auxTask.UserId.ToString();

                hfTaskStatusOrigin.Value = auxTask.TaskStatudId.ToString();
                hfUserOrigin.Value = auxTask.UserId.ToString();
            }
            catch
            {

            }

            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void ddlTsakStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaskStatusChanged = true;
        }

        protected void gvTaskDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTaskDetails.PageIndex = e.NewPageIndex;
            getTaskDetailsData(TaskId);
        }
        
        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            clearFields();
            activateFields(true, false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            
            taskdetails auxNewTaskDetail = new taskdetails();
            taskdetailsBus oTaskDetail = new taskdetailsBus();

            tasks auxTasks = new tasks();
            tasksBus oTasks = new tasksBus();

            users auxUser = new users();
            usersBus oUser = new usersBus();

            eventsdetectionBus oEventsDetection = new eventsdetectionBus();

            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled) saveType = 2;
            if (!btnNew.Enabled) saveType = 1;

            if (String.IsNullOrEmpty(txtDateTime.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtEffortHours.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtDetail.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtTaskId.Text)) needRequiredFields = true;

            if (!needRequiredFields)
            {
                auxUser = oUser.usersGetByUserName(HttpContext.Current.User.Identity.Name);

                DateTime dateTime = DateTime.ParseExact(txtDateTime.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                auxNewTaskDetail.DateTime = dateTime;
                auxNewTaskDetail.EffortHours = Convert.ToDecimal(txtEffortHours.Text);
                auxNewTaskDetail.Details = txtDetail.Text;
                auxNewTaskDetail.TaskId = Convert.ToInt32(txtTaskId.Text);
                auxNewTaskDetail.UserId = Convert.ToInt32(ddlUsers.SelectedValue);
                int auxTaskStatus   = Convert.ToInt32(ddlTaskStatus.SelectedValue);
                int auxUserAssigned = Convert.ToInt32(ddlUsers.SelectedValue);
                switch (saveType)
                {
                    case 1: //save
                        if (oTaskDetail.taskdetailsAdd(auxNewTaskDetail) > 0)
                        {
                            if (!oTasks.tasksUpdateStatus(Convert.ToInt32(txtTaskId.Text), auxTaskStatus ))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Estado de Tarea...\n";
                            }

                            auxTasks = oTasks.tasksGetById(Convert.ToInt32(txtTaskId.Text));
                                
                            if (!oEventsDetection.eventsdetectionUpdateStatus(auxTasks.EventsDetectionId, auxTaskStatus))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Estado del Evento de Intrusión...\n";
                            }

                            if (!oTasks.tasksUpdateUser(Convert.ToInt32(txtTaskId.Text), auxUserAssigned))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Usuario asignado a la Tarea...\n";
                            }                                
                                                       
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            getTaskDetailsData(TaskId);
                            lblMessage.Text = "Datos guardados correctamente!";
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                    case 2: //update

                        if (Convert.ToInt32(hfTaskStatusOrigin.Value) != auxTaskStatus)
                        {
                            if (!oTasks.tasksUpdateStatus(Convert.ToInt32(txtTaskId.Text), auxTaskStatus ))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Estado de Tarea...\n";
                            }

                            if (!oEventsDetection.eventsdetectionUpdateStatus(auxTasks.EventsDetectionId, auxTaskStatus))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Estado del Evento de Intrusión...\n";
                            }
                        }

                        if (Convert.ToInt32(hfUserOrigin.Value) != auxUserAssigned)
                        {
                            if (!oTasks.tasksUpdateUser(Convert.ToInt32(txtTaskId.Text), auxUserAssigned))
                            {
                                lblMessage.Text = "Imposible actualizar nuevo Usuario asignado a la Tarea...\n";
                            }                                
                        }

                        auxNewTaskDetail.TaskDetailsId = Convert.ToInt32(txtTaskDetailId.Text);

                        if (oTaskDetail.taskdetailsUpdate(auxNewTaskDetail))
                        {
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            getTaskDetailsData(TaskId);
                            lblMessage.Text = "Datos actualizados correctamente!";
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                }
            }
            else
            {
                lblMessage.Text = "Datos requeridos no cargados...";
            }
        }

    }
}