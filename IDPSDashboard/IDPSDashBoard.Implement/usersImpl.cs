
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class usersImpl	
	{
		#region users methods

		public int usersAdd( users users)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "usersAdd",  
														                                users.UserGroupId, 
														                                users.UserName, 
														                                users.UserFirstName, 
														                                users.UserLastName, 
														                                users.UserMail, 
														                                users.UserSMSNumber, 
														                                users.UserPassword, 
														                                users.UserActive);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool usersUpdate( users users)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "usersUpdate",  
														                                    users.UserId, 
														                                    users.UserGroupId, 
														                                    users.UserName, 
														                                    users.UserFirstName, 
														                                    users.UserLastName, 
														                                    users.UserMail, 
														                                    users.UserSMSNumber, 
														                                    users.UserPassword, 
														                                    users.UserActive);
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

		public bool usersDelete( int UserId, int UserGroupId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "usersDelete",  
                                    														UserId, UserGroupId);
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

		public users usersGetById(int UserId, int UserGroupId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "usersGetById",
									                                					UserId, UserGroupId).Tables[0];
				users NewEnt = new users();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.UserId = Int32.Parse(dr["UserId"].ToString());
					NewEnt.UserGroupId = Int32.Parse(dr["UserGroupId"].ToString());
					NewEnt.UserName = dr["UserName"].ToString();
					NewEnt.UserFirstName = dr["UserFirstName"].ToString();
					NewEnt.UserLastName = dr["UserLastName"].ToString();
					NewEnt.UserMail = dr["UserMail"].ToString();
					NewEnt.UserSMSNumber = dr["UserSMSNumber"].ToString();
					NewEnt.UserPassword = dr["UserPassword"].ToString();
					NewEnt.UserActive = sbyte.Parse(dr["UserActive"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<users> usersGetAll()
		{
			List<users> lstusers = new List<users>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "usersGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colUserId =  dt.Columns["UserId"].Ordinal;
					int colUserGroupId =  dt.Columns["UserGroupId"].Ordinal;
					int colUserName =  dt.Columns["UserName"].Ordinal;
					int colUserFirstName =  dt.Columns["UserFirstName"].Ordinal;
					int colUserLastName =  dt.Columns["UserLastName"].Ordinal;
					int colUserMail =  dt.Columns["UserMail"].Ordinal;
					int colUserSMSNumber =  dt.Columns["UserSMSNumber"].Ordinal;
					int colUserPassword =  dt.Columns["UserPassword"].Ordinal;
					int colUserActive =  dt.Columns["UserActive"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						users NewEnt = new users();
						NewEnt.UserId = Int32.Parse(dt.Rows[i].ItemArray[colUserId].ToString());
						NewEnt.UserGroupId = Int32.Parse(dt.Rows[i].ItemArray[colUserGroupId].ToString());
						NewEnt.UserName = dt.Rows[i].ItemArray[colUserName].ToString();
						NewEnt.UserFirstName = dt.Rows[i].ItemArray[colUserFirstName].ToString();
						NewEnt.UserLastName = dt.Rows[i].ItemArray[colUserLastName].ToString();
						NewEnt.UserMail = dt.Rows[i].ItemArray[colUserMail].ToString();
						NewEnt.UserSMSNumber = dt.Rows[i].ItemArray[colUserSMSNumber].ToString();
						NewEnt.UserPassword = dt.Rows[i].ItemArray[colUserPassword].ToString();
						NewEnt.UserActive = sbyte.Parse(dt.Rows[i].ItemArray[colUserActive].ToString());
						lstusers.Add(NewEnt);
					}
				}
				return lstusers;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
