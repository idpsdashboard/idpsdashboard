using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["theme"] = "skin"; saveThemeCookie();
        //this.Response.Redirect(this.Request.Url.AbsoluteUri);
    }

    private void saveThemeCookie()
    {
        //La cookie
        HttpCookie myCookie = new HttpCookie("theme");
        // Set the cookie value.
        myCookie.Value = Session["theme"].ToString();
        // Set the cookie expiration date.
        myCookie.Expires = DateTime.Now.AddMonths(1);
        // Add the cookie.
        Response.Cookies.Add(myCookie);
    }
}
