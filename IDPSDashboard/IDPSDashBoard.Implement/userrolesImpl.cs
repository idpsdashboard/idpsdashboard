
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class userrolesImpl	
	{
		#region userroles methods

		public int userrolesAdd( userroles userroles)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "userrolesAdd",  
                                														userroles.UserRoleDescription);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool userrolesUpdate( userroles userroles)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "userrolesUpdate",  
														                                    userroles.UserRoleId, 
														                                    userroles.UserRoleDescription);
				if (update > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool userrolesDelete( int UserRoleId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "userrolesDelete",  
                                    														UserRoleId);
				if (update > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public userroles userrolesGetById(int UserRoleId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "userrolesGetById",
									                                            					UserRoleId).Tables[0];
				userroles NewEnt = new userroles();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.UserRoleId = Int32.Parse(dr["UserRoleId"].ToString());
					NewEnt.UserRoleDescription = dr["UserRoleDescription"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<userroles> userrolesGetAll()
		{
			List<userroles> lstuserroles = new List<userroles>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "userrolesGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colUserRoleId =  dt.Columns["UserRoleId"].Ordinal;
					int colUserRoleDescription =  dt.Columns["UserRoleDescription"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						userroles NewEnt = new userroles();
						NewEnt.UserRoleId = Int32.Parse(dt.Rows[i].ItemArray[colUserRoleId].ToString());
						NewEnt.UserRoleDescription = dt.Rows[i].ItemArray[colUserRoleDescription].ToString();
						lstuserroles.Add(NewEnt);
					}
				}
				return lstuserroles;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
