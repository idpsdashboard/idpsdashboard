
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class taskstatusImpl	
	{
		#region taskstatus methods

		public int taskstatusAdd( taskstatus taskstatus)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "taskstatusAdd",  
                                														taskstatus.TaskStatusDescription);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool taskstatusUpdate( taskstatus taskstatus)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "taskstatusUpdate",  
														                                    taskstatus.TaskStatusId, 
														                                    taskstatus.TaskStatusDescription);
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

		public bool taskstatusDelete( int TaskStatusId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "taskstatusDelete",  
                                    														TaskStatusId);
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

		public taskstatus taskstatusGetById(int TaskStatusId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "taskstatusGetById",
									                                            					TaskStatusId).Tables[0];
				taskstatus NewEnt = new taskstatus();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.TaskStatusId = Int32.Parse(dr["TaskStatusId"].ToString());
					NewEnt.TaskStatusDescription = dr["TaskStatusDescription"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<taskstatus> taskstatusGetAll()
		{
			List<taskstatus> lsttaskstatus = new List<taskstatus>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "taskstatusGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colTaskStatusId =  dt.Columns["TaskStatusId"].Ordinal;
					int colTaskStatusDescription =  dt.Columns["TaskStatusDescription"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						taskstatus NewEnt = new taskstatus();
						NewEnt.TaskStatusId = Int32.Parse(dt.Rows[i].ItemArray[colTaskStatusId].ToString());
						NewEnt.TaskStatusDescription = dt.Rows[i].ItemArray[colTaskStatusDescription].ToString();
						lsttaskstatus.Add(NewEnt);
					}
				}
				return lsttaskstatus;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
