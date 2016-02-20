using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using IDPSDashboard.Business;
using IDPSDashboard.Model;


namespace IDPSDashboard
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }

        protected void _Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            users auxUser = new users();
            usersBus oUser = new usersBus();
            auxUser = oUser.usersGetByUserName(_Login.UserName);

            string hashPwd = Services.Utility.ResumeSHA1(_Login.Password);

            if (auxUser != null)
            {
                if (String.Compare(hashPwd, auxUser.UserPassword) == 0)
                    FormsAuthentication.RedirectFromLoginPage(_Login.UserName, _Login.RememberMeSet);
            }
        }
    }
}