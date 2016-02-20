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
    public partial class Severities : System.Web.UI.Page
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
            List<severity> lstSeverities = new List<severity>();
            severityBus oSeverities = new severityBus();

            lstSeverities = oSeverities.severityGetAll();

            if (lstSeverities.Count > 0)
            {
                gvSeverities.DataSource = lstSeverities;
                gvSeverities.DataBind();
            }
        }

        protected void gvSeverities_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSeverities.SelectedRow;

            if ((Label)row.FindControl("severityId") != null) { txtSeverityId.Text = ((Label)row.FindControl("severityId")).Text; } else { txtSeverityId.Text = ""; }
            if ((Label)row.FindControl("severityDescription") != null) { txtSeverityDescription.Text = ((Label)row.FindControl("severityDescription")).Text; } else { txtSeverityDescription.Text = ""; }
            if ((Label)row.FindControl("SLATimeToResponse") != null) { txtSLATTR.Text = ((Label)row.FindControl("SLATimeToResponse")).Text; } else { txtSLATTR.Text = ""; }

            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtSeverityDescription.Enabled = true;
                txtSLATTR.Enabled = true;
                btnSave.Enabled = true;
                btnNew.Enabled = false;
            }

            if (disable)
            {
                txtSeverityDescription.Enabled = false;
                txtSLATTR.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
            }
        }

        protected void clearFields()
        {
            txtSeverityId.Text = "";
            txtSeverityDescription.Text = "";
            txtSLATTR.Text = "";
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
            severity auxNewSeverity = new severity();
            severityBus oSeverity = new severityBus();

            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled) saveType = 2;
            if (!btnNew.Enabled) saveType = 1;

            if (String.IsNullOrEmpty(txtSeverityDescription.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtSLATTR.Text)) needRequiredFields = true;

            if (!needRequiredFields)
            {
                auxNewSeverity.SeverityDescription = txtSeverityDescription.Text;
                auxNewSeverity.SLATimeToResponse = Convert.ToInt32(txtSLATTR.Text);

                switch (saveType)
                {
                    case 1: //save
                        if (oSeverity.severityAdd(auxNewSeverity) > 0)
                        {
                            lblMessage.Text = "Datos guardados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            gvGetData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                    case 2: //update
                        auxNewSeverity.SeverityId = Convert.ToInt32(txtSeverityId.Text);

                        if (oSeverity.severityUpdate(auxNewSeverity))
                        {
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            btnNew.Enabled = true;
                            gvGetData();
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

        protected void gvSeverities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSeverities.PageIndex = e.NewPageIndex;
            gvGetData();
        }
    }
}