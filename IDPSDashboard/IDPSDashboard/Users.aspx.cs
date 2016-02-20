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
    public partial class Usuarios : System.Web.UI.Page
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
            getUsersData();
            getUserGroupData();
            //getRolesData();
        }

        protected void getUsersData()
        {
            DataTable dttUsers = new DataTable();
            dttUsers.Columns.Add(new DataColumn("userId", System.Type.GetType("System.Int32")));
            dttUsers.Columns.Add(new DataColumn("userName", System.Type.GetType("System.String")));
            dttUsers.Columns.Add(new DataColumn("userLastName", System.Type.GetType("System.String")));
            dttUsers.Columns.Add(new DataColumn("userFirstName", System.Type.GetType("System.String")));
            dttUsers.Columns.Add(new DataColumn("userGroupId", System.Type.GetType("System.Int32")));
            dttUsers.Columns.Add(new DataColumn("userGroupDescription", System.Type.GetType("System.String")));
            dttUsers.Columns.Add(new DataColumn("userActive", System.Type.GetType("System.Boolean")));

            List<users> lstUsers = new List<users>();
            usersBus oUsers = new usersBus();

            usergroup auxGroup = new usergroup();
            usergroupBus oGroup = new usergroupBus();

            lstUsers = oUsers.usersGetAll();

            if (lstUsers.Count > 0)
            {
                foreach (users row in lstUsers)
                {
                    auxGroup = oGroup.usergroupGetById(row.UserGroupId);

                    dttUsers.Rows.Add(row.UserId,
                                      row.UserName,
                                      row.UserLastName,
                                      row.UserFirstName,
                                      row.UserGroupId,
                                      auxGroup.UserGroupDescription,
                                      row.UserActive);
                }

                gvUsers.DataSource = dttUsers;
                gvUsers.DataBind();
            }
        }

        protected void getUserGroupData()
        {
            List<usergroup> lstGroup = new List<usergroup>();
            usergroupBus oGroup = new usergroupBus();

            lstGroup = oGroup.usergroupGetAll();

            if (lstGroup.Count > 0)
            {
                ddlUserGroup.DataSource = lstGroup;
                ddlUserGroup.DataValueField = "userGroupId";
                ddlUserGroup.DataTextField = "userGroupDescription";
                ddlUserGroup.DataBind();
            }
        }

        protected void getRolesData()
        {
            List<userroles> lstRoles = new List<userroles>();
            userrolesBus oRoles = new userrolesBus();

            lstRoles = oRoles.userrolesGetAll();

            if (lstRoles.Count > 0)
            {
                foreach (userroles row in lstRoles)
                {
                    cblRolesRoles.Items.Add(row.UserRoleDescription);
                }
            }
        }

        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtUserName.Enabled = true;
                txtUserFirstName.Enabled = true;
                txtUserLastName.Enabled = true;
                txtMail.Enabled = true;
                txtPassword.Enabled = true;
                txtSMS.Enabled = true;
                ddlUserGroup.Enabled = true;
                chkActive.Enabled = true;
            }

            if (disable)
            {
                txtUserName.Enabled = false;
                txtUserFirstName.Enabled = false;
                txtUserLastName.Enabled = false;
                txtMail.Enabled = false;
                txtPassword.Enabled = false;
                txtSMS.Enabled = false;
                ddlUserGroup.Enabled = false;
                chkActive.Enabled = false;
            }
        }

        protected void clearFields()
        {
            txtUserName.Text = ""; ;
            txtUserFirstName.Text = "";
            txtUserLastName.Text = "";
            txtMail.Text = "";
            txtPassword.Text = "";
            txtSMS.Text = "";
            chkActive.Enabled = false;
            cblRolesRoles.Items.Clear();
       }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvUsers.SelectedRow;

            users auxUser = new users();
            usersBus oUser = new usersBus();

            List<userrolesmapping> lstGroupRolesMapping = new List<userrolesmapping>();
            userrolesmappingBus oRolesMapping = new userrolesmappingBus();

            userroles auxRol = new userroles();
            userrolesBus oRoles = new userrolesBus();

            try
            {
                ddlUserGroup.SelectedValue = ((Label)row.FindControl("userGroupId")).Text;
            }
            catch
            {

            }

            if ((Label)row.FindControl("userId") != null) { userId.Value = ((Label)row.FindControl("userId")).Text; } else { userId.Value = ""; }
            if ((Label)row.FindControl("userName") != null) { txtUserName.Text = ((Label)row.FindControl("userName")).Text; } else { txtUserName.Text = ""; }
            if ((Label)row.FindControl("userLastName") != null) { txtUserLastName.Text = ((Label)row.FindControl("userLastName")).Text; } else { txtUserLastName.Text = ""; }
            if ((Label)row.FindControl("userFirstName") != null) { txtUserFirstName.Text = ((Label)row.FindControl("userFirstName")).Text; } else { txtUserFirstName.Text = ""; }
            if ((CheckBox)row.FindControl("userActive") != null) { chkActive.Checked = ((CheckBox)row.FindControl("userActive")).Checked; } else { chkActive.Checked = false; }

            auxUser = oUser.usersGetById(Convert.ToInt32(userId.Value));
            txtMail.Text = auxUser.UserMail;
            txtPassword.Text = auxUser.UserPassword;
            txtSMS.Text = auxUser.UserSMSNumber;

            cblRolesRoles.Items.Clear();
            lstGroupRolesMapping = oRolesMapping.userrolesmappingGetByUserGroupId(Convert.ToInt32(ddlUserGroup.SelectedValue));           
            if (lstGroupRolesMapping.Count > 0)
            {
                int index = 0;
                foreach (userrolesmapping rowRolMapping in lstGroupRolesMapping)
                {
                    auxRol = oRoles.userrolesGetById(rowRolMapping.UserRoleId);
                    cblRolesRoles.Items.Add(auxRol.UserRoleDescription);
                    cblRolesRoles.Items[index].Selected = true;
                    index++;
                }
            }
            
            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            getUsersData();
        }

        protected void ddlUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<userrolesmapping> lstGroupRolesMapping = new List<userrolesmapping>();
            userrolesmappingBus oRolesMapping = new userrolesmappingBus();

            userroles auxRol = new userroles();
            userrolesBus oRoles = new userrolesBus();
            
            cblRolesRoles.Items.Clear();
            if (lstGroupRolesMapping.Count > 0)
            {
                int index = 0;
                foreach (userrolesmapping rowRolMapping in lstGroupRolesMapping)
                {
                    auxRol = oRoles.userrolesGetById(rowRolMapping.UserRoleId);
                    cblRolesRoles.Items.Add(auxRol.UserRoleDescription);
                    cblRolesRoles.Items[index].Selected = true;
                    index++;
                }
            }

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
            users auxNewUser = new users();
            usersBus oUsers = new usersBus();

            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled) saveType = 2;
            if (!btnNew.Enabled) saveType = 1;

            if (String.IsNullOrEmpty(txtUserName.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtUserLastName.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtUserFirstName.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtPassword.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtMail.Text)) needRequiredFields = true;

            if (!needRequiredFields)
            {
                auxNewUser.UserName = txtUserName.Text;
                auxNewUser.UserFirstName = txtUserFirstName.Text;
                auxNewUser.UserLastName = txtUserLastName.Text;
                auxNewUser.UserMail = txtMail.Text;
                auxNewUser.UserPassword = txtPassword.Text;
                auxNewUser.UserActive = Convert.ToSByte(chkActive.Checked);
                auxNewUser.UserSMSNumber = txtSMS.Text;
                auxNewUser.UserGroupId = Convert.ToInt32(ddlUserGroup.SelectedValue);

                switch (saveType)
                {
                    case 1: //save
                        if (oUsers.usersAdd(auxNewUser)> 0)
                        {
                            lblMessage.Text = "Datos guardados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            getUsersData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                        break;
                    case 2: //update
                        auxNewUser.UserId = Convert.ToInt32(userId.Value);
                        if (oUsers.usersUpdate(auxNewUser))
                        {
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            getUsersData();
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

    }
}