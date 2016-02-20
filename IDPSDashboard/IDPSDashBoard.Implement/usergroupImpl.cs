
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class usergroupImpl	
	{
		#region usergroup methods

		public int usergroupAdd( usergroup usergroup)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "usergroupAdd",  
                                														usergroup.UserGroupDescription);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool usergroupUpdate( usergroup usergroup)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "usergroupUpdate",  
														                                    usergroup.UserGroupId, 
														                                    usergroup.UserGroupDescription);
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

		public bool usergroupDelete( int UserGroupId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "usergroupDelete",  
                                    														UserGroupId);
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

		public usergroup usergroupGetById(int UserGroupId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "usergroupGetById",
									                                            					UserGroupId).Tables[0];
				usergroup NewEnt = new usergroup();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.UserGroupId = Int32.Parse(dr["UserGroupId"].ToString());
					NewEnt.UserGroupDescription = dr["UserGroupDescription"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<usergroup> usergroupGetAll()
		{
			List<usergroup> lstusergroup = new List<usergroup>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "usergroupGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colUserGroupId =  dt.Columns["UserGroupId"].Ordinal;
					int colUserGroupDescription =  dt.Columns["UserGroupDescription"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						usergroup NewEnt = new usergroup();
						NewEnt.UserGroupId = Int32.Parse(dt.Rows[i].ItemArray[colUserGroupId].ToString());
						NewEnt.UserGroupDescription = dt.Rows[i].ItemArray[colUserGroupDescription].ToString();
						lstusergroup.Add(NewEnt);
					}
				}
				return lstusergroup;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
