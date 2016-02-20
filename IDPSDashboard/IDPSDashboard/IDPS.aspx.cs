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
    public partial class IDPS : System.Web.UI.Page
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
            getIDPSData();
            getIDPSTypeData();
            getDatabasesData();
        }

        protected void getIDPSData()
        {
            DataTable dttIDPS = new DataTable();
            dttIDPS.Columns.Add(new DataColumn("idsId"           , System.Type.GetType("System.Int32")));
            dttIDPS.Columns.Add(new DataColumn("idsName"         , System.Type.GetType("System.String")));
            dttIDPS.Columns.Add(new DataColumn("idsversion"      , System.Type.GetType("System.String")));
            dttIDPS.Columns.Add(new DataColumn("idsTypeId"       , System.Type.GetType("System.Int32")));
            dttIDPS.Columns.Add(new DataColumn("idsTypeDesc"     , System.Type.GetType("System.String")));
            dttIDPS.Columns.Add(new DataColumn("databaseTypeId"  , System.Type.GetType("System.Int32")));
            dttIDPS.Columns.Add(new DataColumn("databaseTypeDesc", System.Type.GetType("System.String")));
            dttIDPS.Columns.Add(new DataColumn("idsIP"           , System.Type.GetType("System.String")));
            dttIDPS.Columns.Add(new DataColumn("active"          , System.Type.GetType("System.Boolean")));

            List<ids> lstIDPS = new List<ids>();
            idsBus oIDPS = new idsBus();

            idstype auxIDPSType = new idstype();
            idstypeBus oIDPSType = new idstypeBus();

            databasestype auxDatabaseType = new databasestype();
            databasestypeBus oDatabaseType = new databasestypeBus();

            lstIDPS = oIDPS.idsGetAll();

            if (lstIDPS.Count > 0)
            {
                foreach (ids row in lstIDPS)
                {
                    auxIDPSType = oIDPSType.idstypeGetById(row.IdsTypeId);
                    auxDatabaseType = oDatabaseType.databasestypeGetById(row.DatabaseTypeId);

                    dttIDPS.Rows.Add( row.IdsId,
                                      row.idsName,
                                      row.IdsVersion,
                                      row.IdsTypeId,
                                      auxIDPSType.IdsTypeName,
                                      row.DatabaseTypeId,
                                      auxDatabaseType.DatabaseName,
                                      row.IdsIP,
                                      row.Active);
                }
                
                gvIDPS.DataSource = dttIDPS;
                gvIDPS.DataBind();
            }
        }

        protected void getIDPSTypeData()
        {
            List<idstype> lstIDPSType = new List<idstype>();
            idstypeBus oIDPSType = new idstypeBus();

            lstIDPSType = oIDPSType.idstypeGetAll();

            if (lstIDPSType.Count > 0)
            {
                ddlIDPSType.DataSource = lstIDPSType;
                ddlIDPSType.DataValueField = "idsTypeId";
                ddlIDPSType.DataTextField = "idsTypeName";
                ddlIDPSType.DataBind();
            }
        }

        protected void getDatabasesData()
        {
            List<databasestype> lstDatabasesType = new List<databasestype>();
            databasestypeBus oDatabasesType = new databasestypeBus();

            lstDatabasesType = oDatabasesType.databasestypeGetAll();

            if (lstDatabasesType.Count > 0)
            {
                ddlDatabaseType.DataSource = lstDatabasesType;
                ddlDatabaseType.DataValueField= "databaseTypeId";
                ddlDatabaseType.DataTextField = "databaseName";
                ddlDatabaseType.DataBind();            
            }
        }

        protected void gvIDPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvIDPS.SelectedRow;

            ids auxIDPS = new ids();
            idsBus oIDPS = new idsBus();
            
            try 
            { 
                ddlIDPSType.SelectedValue= ((Label)row.FindControl("idsTypeId")).Text;
                ddlDatabaseType.SelectedValue = ((Label)row.FindControl("databaseTypeId")).Text;
            }
            catch 
            { 
            
            }

            if ((Label)row.FindControl("idsId") != null) { txtIDPSId.Text = ((Label)row.FindControl("idsId")).Text; } else { txtIDPSId.Text = ""; }
            if ((Label)row.FindControl("idsName") != null) { txtIDPSName.Text = ((Label)row.FindControl("idsName")).Text; } else { txtIDPSName.Text = ""; }
            if ((Label)row.FindControl("idsVersion") != null) { txtIDPSVersion.Text = ((Label)row.FindControl("idsVersion")).Text; } else { txtIDPSVersion.Text = ""; }
            if ((Label)row.FindControl("idsIP") != null) { txtIP.Text = ((Label)row.FindControl("idsIP")).Text; } else { txtIP.Text = ""; }
            if ((CheckBox)row.FindControl("active") != null) { chkActive.Checked = ((CheckBox)row.FindControl("active")).Checked; } else { chkActive.Checked = false; }

            auxIDPS = oIDPS.idsGetById(Convert.ToInt32(txtIDPSId.Text));
            txtUserDataBase.Text = auxIDPS.DatabaseUser;
            txtPassDataBase.Text = auxIDPS.DatabasePass;
            txtSourceDataBase.Text = auxIDPS.DatabaseName;
            txtHostDatabase.Text = auxIDPS.DatabaseHost;
            activateFields(true, false);
            btnSave.Enabled = true;
        }

        protected void gvIDPS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIDPS.PageIndex = e.NewPageIndex;
            getIDPSData();
        }
        
        protected void activateFields(bool enable, bool disable)
        {
            if (enable)
            {
                txtIDPSId.Enabled = true;
                txtIDPSName.Enabled = true;
                txtIP.Enabled = true;
                txtIDPSVersion.Enabled = true;
                ddlIDPSType.Enabled = true;
                ddlDatabaseType.Enabled = true;
                txtUserDataBase.Enabled = true;
                txtPassDataBase.Enabled = true;
                txtSourceDataBase.Enabled = true;
                txtHostDatabase.Enabled = true;
                chkActive.Enabled = true;
            }
        
            if (disable)
            {
                txtIDPSId.Enabled = false;
                txtIDPSName.Enabled = false;
                txtIDPSVersion.Enabled = false;
                txtIP.Enabled = false;
                ddlIDPSType.Enabled = false;
                ddlDatabaseType.Enabled = false;
                txtUserDataBase.Enabled = false;
                txtPassDataBase.Enabled = false;
                txtSourceDataBase.Enabled = false;
                txtHostDatabase.Enabled = false;
                chkActive.Enabled = false;
            }
        }

        protected void clearFields()
        {
            txtIDPSId.Text = "";
            txtIDPSName.Text = "";
            txtIDPSVersion.Text = "";
            txtIP.Text = "";
            txtUserDataBase.Text = "";
            txtPassDataBase.Text = "";
            txtSourceDataBase.Text = "";
            txtHostDatabase.Text = "";
            chkActive.Checked = false;
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
            ids auxNewIDPS = new ids();
            idsBus oIDS = new idsBus();
            bool needRequiredFields = false;
            int saveType = 0;

            if (btnNew.Enabled)  saveType = 2;
            if (!btnNew.Enabled) saveType = 1; 

            if (String.IsNullOrEmpty(txtIDPSName.Text)) needRequiredFields = true;
            if (String.IsNullOrEmpty(txtIP.Text)) needRequiredFields = true;

            if (!needRequiredFields)
            {
                auxNewIDPS.idsName = txtIDPSName.Text;
                auxNewIDPS.IdsTypeId = Convert.ToInt32(ddlIDPSType.SelectedValue);
                auxNewIDPS.DatabaseTypeId = Convert.ToInt32(ddlDatabaseType.SelectedValue);
                auxNewIDPS.IdsIP = txtIP.Text;
                auxNewIDPS.DatabaseUser = txtUserDataBase.Text;
                auxNewIDPS.DatabasePass = txtPassDataBase.Text;
                auxNewIDPS.DatabaseName = txtSourceDataBase.Text;
                auxNewIDPS.DatabaseHost = txtHostDatabase.Text;
                auxNewIDPS.IdsVersion = txtIDPSVersion.Text;
                auxNewIDPS.Active = Convert.ToSByte(chkActive.Checked);

                switch (saveType)
                { 
                    case 1: //save
                        if (oIDS.idsAdd(auxNewIDPS) > 0)
                        {
                            lblMessage.Text = "Datos guardados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnNew.Enabled = true;
                            getIDPSData();
                        }
                        else
                            lblMessage.Text = "Error al guardar los datos!";
                    break;
                    case 2: //update
                        auxNewIDPS.IdsId = Convert.ToInt32(txtIDPSId.Text);
                        if (oIDS.idsUpdate(auxNewIDPS))
                        {
                            lblMessage.Text = "Datos actualizados correctamente!";
                            clearFields();
                            activateFields(false, true);
                            btnSave.Enabled = false;
                            getIDPSData();
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