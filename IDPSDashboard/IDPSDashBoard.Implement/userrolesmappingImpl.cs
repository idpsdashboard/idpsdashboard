
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class userrolesmappingImpl	
	{
		#region userrolesmapping methods

		public int userrolesmappingAdd( userrolesmapping userrolesmapping)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "userrolesmappingAdd",  
														                                    userrolesmapping.UserRoleId, 
														                                    userrolesmapping.UserGroupId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool userrolesmappingUpdate( userrolesmapping userrolesmapping)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "userrolesmappingUpdate",  
														                                    userrolesmapping.UserRoleId, 
														                                    userrolesmapping.UserGroupId);
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

		public bool userrolesmappingDelete( int UserRoleId, int UserGroupId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "userrolesmappingDelete",  
                                        													UserRoleId, UserGroupId);
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

		public userrolesmapping userrolesmappingGetById(int UserRoleId, int UserGroupId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "userrolesmappingGetById",
										                                        				UserRoleId, UserGroupId).Tables[0];
				userrolesmapping NewEnt = new userrolesmapping();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.UserRoleId = Int32.Parse(dr["UserRoleId"].ToString());
					NewEnt.UserGroupId = Int32.Parse(dr["UserGroupId"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<userrolesmapping> userrolesmappingGetAll()
		{
			List<userrolesmapping> lstuserrolesmapping = new List<userrolesmapping>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "userrolesmappingGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colUserRoleId =  dt.Columns["UserRoleId"].Ordinal;
					int colUserGroupId =  dt.Columns["UserGroupId"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						userrolesmapping NewEnt = new userrolesmapping();
						NewEnt.UserRoleId = Int32.Parse(dt.Rows[i].ItemArray[colUserRoleId].ToString());
						NewEnt.UserGroupId = Int32.Parse(dt.Rows[i].ItemArray[colUserGroupId].ToString());
						lstuserrolesmapping.Add(NewEnt);
					}
				}
				return lstuserrolesmapping;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
