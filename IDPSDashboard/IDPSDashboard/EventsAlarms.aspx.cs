using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDPSDashboard.Model;
using IDPSDashboard.Business;
using IDPSWatcher.libIDPSWatcher;


namespace IDPSDashboard
{
    public partial class EventosAlarmas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!Page.IsPostBack)
                {
                    gvGetData();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]);
            }
        }

        protected void gvGetData()
        {
            lblMessage.Text = "";
            getEventsAlarmData();
            getIntrusionEventsData();
            getSeverityData();
            getIDPSData();
        }

        protected void getEventsAlarmData()
        {
            DataTable dttEventsAlarm = new DataTable();
            dttEventsAlarm.Columns.Add(new DataColumn("eventsAlarmId", System.Type.GetType("System.Int32")));
            dttEventsAlarm.Columns.Add(new DataColumn("eventsAlarmTittle", System.Type.GetType("System.String")));
            dttEventsAlarm.Columns.Add(new DataColumn("checkFrecuency", System.Type.GetType("System.Int32")));
            dttEventsAlarm.Columns.Add(new DataColumn("serverity", System.Type.GetType("System.Int32")));
            dttEventsAlarm.Columns.Add(new DataColumn("severityDescription", System.Type.GetType("System.String")));
            dttEventsAlarm.Columns.Add(new DataColumn("SLATimeToResponse", System.Type.GetType("System.Int32")));
            dttEventsAlarm.Columns.Add(new DataColumn("active", System.Type.GetType("System.Boolean")));

            List<eventsalarm> lstEventsAlarm = new List<eventsalarm>();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();
            intrusioneventsBus oIntrusionEvents = new intrusioneventsBus();
            severityBus oSeverity = new severityBus();

            lstEventsAlarm = oEventsAlarm.eventsalarmGetAll();

            if (lstEventsAlarm.Count > 0)
            {
                foreach (eventsalarm row in lstEventsAlarm)
                {
                    intrusionevents auxIntrusionEvent = new intrusionevents();
                    severity auxSeverity = new severity();

                    auxSeverity = oSeverity.severityGetById(row.Severity);

                    dttEventsAlarm.Rows.Add(row.EventsAlarmId,
                                            row.EventsAlarmTittle,
                                            row.CheckFrecuency,
                                            row.Severity,
                                            auxSeverity.SeverityDescription,
                                            auxSeverity.SLATimeToResponse,
                                            row.Active);
                }

                gvAlarms.DataSource = dttEventsAlarm;
                gvAlarms.DataBind();
            }

        }

        protected void getIntrusionEventsData()
        {
            List<intrusionevents> lstIntrusionEvent = new List<intrusionevents>();
            intrusioneventsBus oIntrusionEvents = new intrusioneventsBus();

            ListItem intrusionItems = new ListItem();
            
            lstIntrusionEvent = oIntrusionEvents.intrusioneventsGetAll();

            if (lstIntrusionEvent.Count > 0)
            {
                gvIntrusionEvents.DataSource = lstIntrusionEvent;
                gvIntrusionEvents.DataBind();
            }
        }

        protected void getSeverityData()
        {
            List<severity> lstSeverity = new List<severity>();
            severityBus oSeverity = new severityBus();

            lstSeverity = oSeverity.severityGetAll();

            if (lstSeverity.Count > 0)
            {
                ddlSeverity.DataSource = lstSeverity;
                ddlSeverity.DataValueField = "severityId";
                ddlSeverity.DataTextField = "severityDescription";
                ddlSeverity.DataBind();
            }
        }

        protected void getIDPSData()
        {
            List<ids> lstIDPS = new List<ids>();
            idsBus oIDPS = new idsBus();

            lstIDPS = oIDPS.idsGetAll();

            if (lstIDPS.Count > 0)
            {
                ddlIDPS.DataSource = lstIDPS;
                ddlIDPS.DataValueField = "idsId";
                ddlIDPS.DataTextField = "idsName";
                ddlIDPS.DataBind();                   
            }
        }

        protected void getSignatureData(int idpsId)
        {
            libIDPSWatcherImpl libWatcher = new libIDPSWatcherImpl();
            DataSet dtsSignature = new DataSet();
            dtsSignature = libWatcher.getIDPSSignaturesCategory(idpsId);

            if (dtsSignature != null)
            {
                DataTable dttSignature = dtsSignature.Tables[0];
                ddlIDPSSignatures.DataSource = dttSignature;
                ddlIDPSSignatures.DataValueField= "SignatureCategoryId";
                ddlIDPSSignatures.DataTextField = "SignatureCategoryName";
                ddlIDPSSignatures.DataBind();                                 
            }
        }

        protected void gvAlarms_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAlarms.SelectedRow;

            eventsalarm auxEventsAlarm = new eventsalarm();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();

            intrusionevents auxIntrusionEvent = new intrusionevents();
            List<intrusionevents> lstIntrusionEventsAssigned = new List<intrusionevents>();
            intrusioneventsBus oIntrusionEvents = new intrusioneventsBus();

            List<eventsalarm_intrusionevents_mapping> lstEventsMapping = new List<eventsalarm_intrusionevents_mapping>();
            eventsalarm_intrusionevents_mappingBus oEventsMapping = new eventsalarm_intrusionevents_mappingBus();

            try
            {
                ddlSeverity.SelectedValue = ((Label)row.FindControl("severity")).Text;
            }
            catch
            {

            }

            if ((Label)row.FindControl("eventsAlarmId") != null) { txtEventAlarmId.Text = ((Label)row.FindControl("eventsAlarmId")).Text; } else { txtEventAlarmId.Text = ""; }
            if ((Label)row.FindControl("eventsAlarmTittle") != null) { txtEventsAlarmTittle.Text = ((Label)row.FindControl("eventsAlarmTittle")).Text; } else { txtEventsAlarmTittle.Text = ""; }            
            if ((Label)row.FindControl("checkFrecuency") != null) { txtCheckFrequency.Text = ((Label)row.FindControl("checkFrecuency")).Text; } else { txtCheckFrequency.Text = ""; }
            if ((CheckBox)row.FindControl("active") != null) { chkActive.Checked = ((CheckBox)row.FindControl("active")).Checked; } else { chkActive.Checked = false; }

            auxEventsAlarm = oEventsAlarm.eventsalarmGetById(Convert.ToInt32(txtEventAlarmId.Text));
            lstEventsMapping = oEventsMapping.eventsalarm_intrusionevents_mappingGetByEventsAlarmId(Convert.ToInt32(txtEventAlarmId.Text));

            if (lstEventsMapping.Count > 0)
            {
                foreach (eventsalarm_intrusionevents_mapping rowMapping in lstEventsMapping)
                {
                    auxIntrusionEvent = oIntrusionEvents.intrusioneventsGetById(rowMapping.IntrusionEventId);
                    lstIntrusionEventsAssigned.Add(auxIntrusionEvent);
                }

                gvIntrusionEventsAssigned.DataSource = lstIntrusionEventsAssigned;
                gvIntrusionEventsAssigned.DataBind();
            }

            ddlIDPS.SelectedValue = auxEventsAlarm.IdsId.ToString();
            chkBIA.Items[0].Selected = Convert.ToBoolean(auxEventsAlarm.AffectConfidence);
            chkBIA.Items[1].Selected = Convert.ToBoolean(auxEventsAlarm.AffectIntegrity);
            chkBIA.Items[2].Selected = Convert.ToBoolean(auxEventsAlarm.AffectAvailability);
            getSignatureData(auxEventsAlarm.IdsId);
            ddlIDPSSignatures.SelectedValue = auxEventsAlarm.IdsSignatureCategoryId.ToString();

            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void gvIntrusionEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIntrusionEvents.PageIndex = e.NewPageIndex;
            getIntrusionEventsData();
        }

        protected void gvIntrusionEventsAssigned_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIntrusionEventsAssigned.PageIndex = e.NewPageIndex;

            DataTable dttIntrusionEventsAssigned = new DataTable();
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventsId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventDetail", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CVEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CWEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CAPECId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("OWASPId", System.Type.GetType("System.String")));

            foreach (GridViewRow intrusionEventAssignedRow in gvIntrusionEventsAssigned.Rows)
            {
                DataRow currentIntrusionAssignedRow = dttIntrusionEventsAssigned.NewRow();
                currentIntrusionAssignedRow[0] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventsId")).Text;
                currentIntrusionAssignedRow[1] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventDetail")).Text;
                currentIntrusionAssignedRow[2] = ((Label)intrusionEventAssignedRow.FindControl("CVEId")).Text;
                currentIntrusionAssignedRow[3] = ((Label)intrusionEventAssignedRow.FindControl("CWEId")).Text;
                currentIntrusionAssignedRow[4] = ((Label)intrusionEventAssignedRow.FindControl("CAPECId")).Text;
                currentIntrusionAssignedRow[5] = ((Label)intrusionEventAssignedRow.FindControl("OWASPId")).Text;
                dttIntrusionEventsAssigned.Rows.Add(currentIntrusionAssignedRow);
            }

            gvIntrusionEventsAssigned.DataSource = dttIntrusionEventsAssigned;
            gvIntrusionEventsAssigned.DataBind();
        }

        protected void gvIntrusionEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rowIntrusionEvent = gvIntrusionEvents.SelectedRow;

            DataTable dttIntrusionEventsAssigned = new DataTable();
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventsId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventDetail", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CVEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CWEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CAPECId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("OWASPId", System.Type.GetType("System.String")));

            foreach (GridViewRow intrusionEventAssignedRow in gvIntrusionEventsAssigned.Rows)
            {
                DataRow currentIntrusionAssignedRow = dttIntrusionEventsAssigned.NewRow();
                currentIntrusionAssignedRow[0] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventsId")).Text;
                currentIntrusionAssignedRow[1] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventDetail")).Text;
                currentIntrusionAssignedRow[2] = ((Label)intrusionEventAssignedRow.FindControl("CVEId")).Text;
                currentIntrusionAssignedRow[3] = ((Label)intrusionEventAssignedRow.FindControl("CWEId")).Text;
                currentIntrusionAssignedRow[4] = ((Label)intrusionEventAssignedRow.FindControl("CAPECId")).Text;
                currentIntrusionAssignedRow[5] = ((Label)intrusionEventAssignedRow.FindControl("OWASPId")).Text;
                dttIntrusionEventsAssigned.Rows.Add(currentIntrusionAssignedRow);
            }

            if (rowIntrusionEvent != null)
            {
                DataRow newIntrusionAssignedRow = dttIntrusionEventsAssigned.NewRow();
                newIntrusionAssignedRow[0] = ((Label)rowIntrusionEvent.FindControl("intrusionEventsId")).Text;
                newIntrusionAssignedRow[1] = ((Label)rowIntrusionEvent.FindControl("intrusionEventDetail")).Text;
                newIntrusionAssignedRow[2] = ((Label)rowIntrusionEvent.FindControl("CVEId")).Text;
                newIntrusionAssignedRow[3] = ((Label)rowIntrusionEvent.FindControl("CWEId")).Text;
                newIntrusionAssignedRow[4] = ((Label)rowIntrusionEvent.FindControl("CAPECId")).Text;
                newIntrusionAssignedRow[5] = ((Label)rowIntrusionEvent.FindControl("OWASPId")).Text;
                dttIntrusionEventsAssigned.Rows.Add(newIntrusionAssignedRow);

            }

            gvIntrusionEventsAssigned.DataSource = dttIntrusionEventsAssigned;
            gvIntrusionEventsAssigned.DataBind();
        }

        protected void gvIntrusionEventsAssigned_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //gvIntrusionEventsAssigned.DeleteRow(e.RowIndex);
            DataTable dttIntrusionEventsAssigned = new DataTable();
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventsId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("intrusionEventDetail", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CVEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CWEId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("CAPECId", System.Type.GetType("System.String")));
            dttIntrusionEventsAssigned.Columns.Add(new DataColumn("OWASPId", System.Type.GetType("System.String")));

            foreach (GridViewRow intrusionEventAssignedRow in gvIntrusionEventsAssigned.Rows)
            {
                if (intrusionEventAssignedRow.RowIndex != e.RowIndex)
                {
                    DataRow currentIntrusionAssignedRow = dttIntrusionEventsAssigned.NewRow();
                    currentIntrusionAssignedRow[0] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventsId")).Text;
                    currentIntrusionAssignedRow[1] = ((Label)intrusionEventAssignedRow.FindControl("intrusionEventDetail")).Text;
                    currentIntrusionAssignedRow[2] = ((Label)intrusionEventAssignedRow.FindControl("CVEId")).Text;
                    currentIntrusionAssignedRow[3] = ((Label)intrusionEventAssignedRow.FindControl("CWEId")).Text;
                    currentIntrusionAssignedRow[4] = ((Label)intrusionEventAssignedRow.FindControl("CAPECId")).Text;
                    currentIntrusionAssignedRow[5] = ((Label)intrusionEventAssignedRow.FindControl("OWASPId")).Text;
                    dttIntrusionEventsAssigned.Rows.Add(currentIntrusionAssignedRow);
                }
            }

            gvIntrusionEventsAssigned.DataSource = dttIntrusionEventsAssigned;
            gvIntrusionEventsAssigned.DataBind();
        }

        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtEventsAlarmTittle.Enabled = true;
                txtCheckFrequency.Enabled = true;
                ddlSeverity.Enabled = true;
                chkActive.Enabled = true;
                chkBIA.Enabled = true;
                gvIntrusionEvents.Enabled = true;
                gvIntrusionEventsAssigned.Enabled = true;
                btnSendLeft.Enabled = true;
                btnSendRigth.Enabled = true;
                ddlIDPS.Enabled = true;
                ddlIDPSSignatures.Enabled = true;
                lblMessage.Text = "";
            }

            if (disable)
            {
                txtEventsAlarmTittle.Enabled = false;
                txtCheckFrequency.Enabled = false;
                ddlSeverity.Enabled = false;
                chkActive.Enabled = false;
                chkBIA.Enabled = false;
                gvIntrusionEvents.Enabled = false;
                gvIntrusionEventsAssigned.Enabled = false;
                btnSendLeft.Enabled = false;
                btnSendRigth.Enabled = false;
                ddlIDPS.Enabled = false;
                ddlIDPSSignatures.Enabled = false;
            }
        }

        protected void clearFields()
        {
            txtEventsAlarmTittle.Text = "";
            txtEventAlarmId.Text = "";
            txtCheckFrequency.Text = "";
            chkActive.Checked = false;
            gvIntrusionEventsAssigned.DataSource = null;
            gvIntrusionEventsAssigned.DataBind();
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
            eventsalarm auxNewEventAlarm = new eventsalarm();
            eventsalarmBus oEventsAlarm = new eventsalarmBus();

            eventsalarm_intrusionevents_mapping auxIntrusionEventMapping = new eventsalarm_intrusionevents_mapping();
            eventsalarm_intrusionevents_mappingBus oIntrusionEventsMapping = new eventsalarm_intrusionevents_mappingBus();

            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled) saveType = 2;
            if (!btnNew.Enabled) saveType = 1;

            if (String.IsNullOrEmpty(txtCheckFrequency.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtEventsAlarmTittle.Text)) needRequiredFields = true;

            if (!needRequiredFields)
            {
                auxNewEventAlarm.Severity = Convert.ToInt32(ddlSeverity.SelectedValue);
                auxNewEventAlarm.EventsAlarmTittle = txtEventsAlarmTittle.Text;
                auxNewEventAlarm.CheckFrecuency = Convert.ToInt32(txtCheckFrequency.Text);
                auxNewEventAlarm.Active = Convert.ToSByte(chkActive.Checked);
                auxNewEventAlarm.AffectConfidence = Convert.ToSByte(chkBIA.Items[0].Selected);
                auxNewEventAlarm.AffectIntegrity  = Convert.ToSByte(chkBIA.Items[1].Selected);
                auxNewEventAlarm.AffectAvailability = Convert.ToSByte(chkBIA.Items[2].Selected);
                auxNewEventAlarm.IdsId = Convert.ToInt32(ddlIDPS.SelectedValue);
                auxNewEventAlarm.IdsSignatureCategoryId = Convert.ToInt32(ddlIDPSSignatures.SelectedValue);

                switch (saveType)
                {
                    case 1: //save
                        if (oEventsAlarm.eventsalarmAdd(auxNewEventAlarm) > 0)
                        {
                            if (gvIntrusionEventsAssigned.Rows.Count > 0)
                            {
                                foreach (GridViewRow rowIntrusion in gvIntrusionEventsAssigned.Rows)
                                {
                                    auxIntrusionEventMapping.EventsAlarmId = Convert.ToInt32(txtEventAlarmId.Text);
                                    auxIntrusionEventMapping.IntrusionEventId = Convert.ToInt32(((Label)rowIntrusion.FindControl("intrusionEventsId")).Text);

                                    if (oIntrusionEventsMapping.eventsalarm_intrusionevents_mappingAdd(auxIntrusionEventMapping) <= 0)
                                    {
                                        lblMessage.Text = "Error al guardar Referencias del Evento [Evento de Intrusion] " + ((Label)rowIntrusion.FindControl("intrusionEventsId")).Text;
                                    }
                                }
                            }
                            
                            lblMessage.Text = "Datos guardados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            getEventsAlarmData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                    case 2: //update
                        auxNewEventAlarm.EventsAlarmId = Convert.ToInt32(txtEventAlarmId.Text);
                        if (oEventsAlarm.eventsalarmUpdate(auxNewEventAlarm))
                        {
                            if (gvIntrusionEventsAssigned.Rows.Count > 0)
                            {
                                foreach (GridViewRow rowIntrusion in gvIntrusionEventsAssigned.Rows)
                                {
                                    auxIntrusionEventMapping.EventsAlarmId = Convert.ToInt32(txtEventAlarmId.Text);
                                    auxIntrusionEventMapping.IntrusionEventId = Convert.ToInt32(((Label)rowIntrusion.FindControl("intrusionEventsId")).Text);

                                    if (oIntrusionEventsMapping.eventsalarm_intrusionevents_mappingAdd(auxIntrusionEventMapping) <= 0)
                                    {
                                        lblMessage.Text = "Error al guardar Referencias del Evento [Evento de Intrusion] " + ((Label)rowIntrusion.FindControl("intrusionEventsId")).Text;
                                    }
                                }
                            }
                            
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            getEventsAlarmData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                }
            }
            else
            {
                lblMessage.Text = "Error, existen campos sin completar!";
            }
        }

        protected void ddlIDPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSignatureData(Convert.ToInt32(ddlIDPS.SelectedValue));
        }

    }
}