using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDPSDashboard.Model;
using IDPSDashboard.Business;
using Microsoft.Reporting.WebForms;

namespace IDPSDashboard
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                    getIDPSData();
            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]);
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            genReport();
        }

        protected void genReport()
        {

            DataTable dttEvents = new DataTable();
            eventsdetectionBus oEvents = new eventsdetectionBus();
            int idsId = Convert.ToInt32(ddlIDPS.SelectedValue);

            dttEvents = oEvents.eventsdetectionGetAllByIDPSId(idsId);

            rpvEvents.LocalReport.DataSources.Clear();
            rpvEvents.LocalReport.DataSources.Add(new ReportDataSource("dtsEventsDetection", dttEvents));
            rpvEvents.Enabled = true;
            rpvEvents.LocalReport.Refresh();

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

    }
}