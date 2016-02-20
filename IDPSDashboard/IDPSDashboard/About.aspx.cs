using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IDPSDashboard
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

            }
            else
            {
                Response.Redirect("~/Login.aspx?returnUrl=" + Request.ServerVariables["SCRIPT_NAME"]);
            }
        }
    }
}