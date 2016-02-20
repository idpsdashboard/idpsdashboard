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
    public partial class IDPSEventos : System.Web.UI.Page
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
            getIntrusionEventsData();
        }

        protected void getIntrusionEventsData()
        {
            DataTable dttIntrusionEvents = new DataTable();
            dttIntrusionEvents.Columns.Add(new DataColumn("intrusionEventId", System.Type.GetType("System.Int32")));
            dttIntrusionEvents.Columns.Add(new DataColumn("intrusionEventDetail", System.Type.GetType("System.String")));
            dttIntrusionEvents.Columns.Add(new DataColumn("CVEId", System.Type.GetType("System.String")));
            dttIntrusionEvents.Columns.Add(new DataColumn("CWEId", System.Type.GetType("System.String")));
            dttIntrusionEvents.Columns.Add(new DataColumn("CAPECId", System.Type.GetType("System.String")));
            dttIntrusionEvents.Columns.Add(new DataColumn("OWASPId", System.Type.GetType("System.String")));

            List<intrusionevents> lstInstrusionEvents = new List<intrusionevents>();
            intrusioneventsBus oIntrusionEvents = new intrusioneventsBus();

            lstInstrusionEvents = oIntrusionEvents.intrusioneventsGetAll();    

            if (lstInstrusionEvents.Count > 0)
            {
                foreach (intrusionevents row in lstInstrusionEvents)
                {
                    dttIntrusionEvents.Rows.Add(row.IntrusionEventsId,
                                                row.IntrusionEventDetail,
                                                row.CVEId,
                                                row.CWEId,
                                                row.CAPECId,
                                                row.OWASPId);
                }

                gvEvents.DataSource = dttIntrusionEvents;
                gvEvents.DataBind();
            }
        }

        protected void gvEvents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvents.PageIndex = e.NewPageIndex;
            getIntrusionEventsData();
        }

        protected void btnSearchEvent_Click(object sender, EventArgs e)
        {

        }

        protected void gvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEvents.SelectedRow;

            intrusionevents auxIntrusionEvents = new intrusionevents();
            intrusioneventsBus oIntrusionEvent = new intrusioneventsBus();

            if ((Label)row.FindControl("intrusionEventId") != null) { txtIntrusionEventId.Text = ((Label)row.FindControl("intrusionEventId")).Text; } else { txtIntrusionEventId.Text = ""; }
            if ((Label)row.FindControl("intrusionEventDetail") != null) { txtIntrusionDetail.Text = ((Label)row.FindControl("intrusionEventDetail")).Text; } else { txtIntrusionDetail.Text = ""; }
            if ((Label)row.FindControl("CVEId") != null) { txtCVEId.Text = ((Label)row.FindControl("CVEId")).Text; } else { txtCVEId.Text = ""; }
            if ((Label)row.FindControl("CWEId") != null) { txtCWEId.Text = ((Label)row.FindControl("CWEId")).Text; } else { txtCWEId.Text = ""; }
            if ((Label)row.FindControl("CAPECId") != null) { txtCAPECId.Text = ((Label)row.FindControl("CAPECId")).Text; } else { txtCAPECId.Text = ""; }
            if ((Label)row.FindControl("OWASPId") != null) { txtOWASPId.Text = ((Label)row.FindControl("OWASPId")).Text; } else { txtOWASPId.Text = ""; }

            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtIntrusionDetail.Enabled = true;
                txtCVEId.Enabled = true;
                txtCWEId.Enabled = true;
                txtCAPECId.Enabled = true;
                txtOWASPId.Enabled = true;
            }

            if (disable)
            {
                txtIntrusionDetail.Enabled = false;
                txtCVEId.Enabled = false;
                txtCWEId.Enabled = false;
                txtCAPECId.Enabled = false;
                txtOWASPId.Enabled = false;
            }
        }

        protected void clearFields()
        {
            txtIntrusionEventId.Text = "";
            txtIntrusionDetail.Text = "";
            txtCVEId.Text = "";
            txtCWEId.Text = "";
            txtCAPECId.Text = "";
            txtOWASPId.Text = "";
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
            intrusionevents auxNewIntrusionEvents = new intrusionevents();
            intrusioneventsBus oIntrusionEvents = new intrusioneventsBus();
            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled)  saveType = 2;
            if (!btnNew.Enabled) saveType = 1; 

            if (String.IsNullOrEmpty(txtIntrusionDetail.Text)) needRequiredFields = true;
            if ((String.IsNullOrEmpty(txtCVEId.Text)) 
                && (String.IsNullOrEmpty(txtCWEId.Text))
                && (String.IsNullOrEmpty(txtCAPECId.Text))
                && (String.IsNullOrEmpty(txtOWASPId.Text)))
                    needRequiredFields = true;

            if (!needRequiredFields)
            {
                if (txtIntrusionDetail.Text.Length > 49)
                    auxNewIntrusionEvents.IntrusionEventDetail = txtIntrusionDetail.Text.Substring(0, 49);
                else
                    auxNewIntrusionEvents.IntrusionEventDetail = txtIntrusionDetail.Text;
                auxNewIntrusionEvents.CVEId = txtCVEId.Text;
                auxNewIntrusionEvents.CWEId = txtCWEId.Text;
                auxNewIntrusionEvents.CAPECId = txtCAPECId.Text;
                auxNewIntrusionEvents.OWASPId = txtOWASPId.Text;

                switch (saveType)
                {
                    case 1: //save
                        if (oIntrusionEvents.intrusioneventsAdd(auxNewIntrusionEvents) > 0)
                        {
                            lblMessage.Text = "Datos guardados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            getIntrusionEventsData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                    case 2: //update
                        auxNewIntrusionEvents.IntrusionEventsId = Convert.ToInt32(txtIntrusionEventId.Text);
                        if (oIntrusionEvents.intrusioneventsUpdate(auxNewIntrusionEvents))
                        {
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            getIntrusionEventsData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                }
            }
        }
    }
}