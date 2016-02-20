
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class taskstatusImpl	
	{
		#region taskstatus methods

		public int taskstatusAdd( taskstatus taskstatus)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "taskstatusAdd",  
                                														taskstatus.TastkStatusDescription);
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
														                                    taskstatus.TaskStatudId, 
														                                    taskstatus.TastkStatusDescription);
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

		public bool taskstatusDelete( int TaskStatudId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "taskstatusDelete",  
                                    														TaskStatudId);
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

		public taskstatus taskstatusGetById(int TaskStatudId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "taskstatusGetById",
									                                            					TaskStatudId).Tables[0];
				taskstatus NewEnt = new taskstatus();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.TaskStatudId = Int32.Parse(dr["TaskStatudId"].ToString());
					NewEnt.TastkStatusDescription = dr["TastkStatusDescription"].ToString();
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
					int colTaskStatudId =  dt.Columns["TaskStatudId"].Ordinal;
					int colTastkStatusDescription =  dt.Columns["TastkStatusDescription"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						taskstatus NewEnt = new taskstatus();
						NewEnt.TaskStatudId = Int32.Parse(dt.Rows[i].ItemArray[colTaskStatudId].ToString());
						NewEnt.TastkStatusDescription = dt.Rows[i].ItemArray[colTastkStatusDescription].ToString();
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
