
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class taskdetailsImpl	
	{
		#region taskdetails methods

		public int taskdetailsAdd( taskdetails taskdetails)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "taskdetailsAdd",  
														                                taskdetails.TaskId, 
														                                taskdetails.Details, 
														                                taskdetails.DateTime, 
														                                taskdetails.EffortHours,
                                                                                        taskdetails.UserId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool taskdetailsUpdate( taskdetails taskdetails)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "taskdetailsUpdate",  
														                                    taskdetails.TaskDetailsId, 
														                                    taskdetails.TaskId, 
														                                    taskdetails.Details, 
														                                    taskdetails.DateTime, 
														                                    taskdetails.EffortHours,
                                                                                            taskdetails.UserId);
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

		public bool taskdetailsDelete( int TaskDetailsId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "taskdetailsDelete",  
                                        														TaskDetailsId);
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

		public taskdetails taskdetailsGetById(int TaskDetailsId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "taskdetailsGetById",
										                                        				TaskDetailsId).Tables[0];
				taskdetails NewEnt = new taskdetails();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.TaskDetailsId = Int32.Parse(dr["TaskDetailsId"].ToString());
					NewEnt.TaskId = Int32.Parse(dr["TaskId"].ToString());
					NewEnt.Details = dr["Details"].ToString();
					NewEnt.DateTime = DateTime.Parse(dr["DateTime"].ToString());
					NewEnt.EffortHours = Decimal.Parse(dr["EffortHours"].ToString());
                    NewEnt.UserId = Int32.Parse(dr["UserId"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<taskdetails> taskdetailsGetAll()
		{
			List<taskdetails> lsttaskdetails = new List<taskdetails>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "taskdetailsGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colTaskDetailsId =  dt.Columns["TaskDetailsId"].Ordinal;
					int colTaskId =  dt.Columns["TaskId"].Ordinal;
					int colDetails =  dt.Columns["Details"].Ordinal;
					int colDateTime =  dt.Columns["DateTime"].Ordinal;
					int colEffortHours =  dt.Columns["EffortHours"].Ordinal;
                    int colUserId = dt.Columns["UserId"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						taskdetails NewEnt = new taskdetails();
						NewEnt.TaskDetailsId = Int32.Parse(dt.Rows[i].ItemArray[colTaskDetailsId].ToString());
						NewEnt.TaskId = Int32.Parse(dt.Rows[i].ItemArray[colTaskId].ToString());
						NewEnt.Details = dt.Rows[i].ItemArray[colDetails].ToString();
						NewEnt.DateTime = DateTime.Parse(dt.Rows[i].ItemArray[colDateTime].ToString());
						NewEnt.EffortHours = Decimal.Parse(dt.Rows[i].ItemArray[colEffortHours].ToString());
                        NewEnt.UserId = Int32.Parse(dt.Rows[i].ItemArray[colUserId].ToString());
						lsttaskdetails.Add(NewEnt);
					}
				}
				return lsttaskdetails;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
