
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class tasksImpl	
	{
		#region tasks methods

		public int tasksAdd( tasks tasks)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "tasksAdd",
                                                                                        tasks.EventsDetectionId,
														                                tasks.TaskStatudId, 
														                                tasks.UserId, 
														                                tasks.TaskTittle, 
														                                tasks.DateTime);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool tasksUpdate( tasks tasks)
		{
			try
			{
				int update = (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "tasksUpdate",  
														                                    tasks.TaskId,
                                                                                            tasks.EventsDetectionId,
														                                    tasks.TaskStatudId, 
														                                    tasks.UserId, 
														                                    tasks.TaskTittle, 
														                                    tasks.DateTime);
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

        public bool tasksUpdateStatus(int TaskId, int TaskStatudId)
        {
            try
            {
                int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "tasksUpdateStatus",
                                                                                                TaskId,
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool tasksUpdateUser(int TaskId, int UserId)
        {
            try
            {
                int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "tasksUpdateUser",
                                                                                                TaskId,
                                                                                                UserId);
                if (update > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool tasksDelete( int TaskId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "tasksDelete",  
                                            														TaskId);
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

		public tasks tasksGetById(int TaskId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "tasksGetById",
                                            														TaskId).Tables[0];
				tasks NewEnt = new tasks();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.TaskId = Int32.Parse(dr["TaskId"].ToString());
                    NewEnt.EventsDetectionId = Int32.Parse(dr["EventsDetectionId"].ToString());
					NewEnt.TaskStatudId = Int32.Parse(dr["TaskStatudId"].ToString());
					NewEnt.UserId = Int32.Parse(dr["UserId"].ToString());
					NewEnt.TaskTittle = dr["TaskTittle"].ToString();
					NewEnt.DateTime = DateTime.Parse(dr["DateTime"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public tasks tasksGetByEventsDetectionId(int EventsDetectionId)
        {
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "tasksGetByIntrusionDetectionId",
                                                                                                    EventsDetectionId).Tables[0];
                tasks NewEnt = new tasks();

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    NewEnt.TaskId = Int32.Parse(dr["TaskId"].ToString());
                    NewEnt.EventsDetectionId = Int32.Parse(dr["EventsDetectionId"].ToString());
                    NewEnt.TaskStatudId = Int32.Parse(dr["TaskStatudId"].ToString());
                    NewEnt.UserId = Int32.Parse(dr["UserId"].ToString());
                    NewEnt.TaskTittle = dr["TaskTittle"].ToString();
                    NewEnt.DateTime = DateTime.Parse(dr["DateTime"].ToString());
                }
                return NewEnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<tasks> tasksGetAll()
		{
			List<tasks> lsttasks = new List<tasks>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "tasksGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colTaskId =  dt.Columns["TaskId"].Ordinal;
                    int colEventsDetectionId = dt.Columns["EventsDetectionId"].Ordinal;
					int colTaskStatudId =  dt.Columns["TaskStatudId"].Ordinal;
					int colUserId =  dt.Columns["UserId"].Ordinal;
					int colTaskTittle =  dt.Columns["TaskTittle"].Ordinal;
					int colDateTime =  dt.Columns["DateTime"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						tasks NewEnt = new tasks();
						NewEnt.TaskId = Int32.Parse(dt.Rows[i].ItemArray[colTaskId].ToString());
                        NewEnt.EventsDetectionId= Int32.Parse(dt.Rows[i].ItemArray[colEventsDetectionId].ToString());
						NewEnt.TaskStatudId = Int32.Parse(dt.Rows[i].ItemArray[colTaskStatudId].ToString());
						NewEnt.UserId = Int32.Parse(dt.Rows[i].ItemArray[colUserId].ToString());
						NewEnt.TaskTittle = dt.Rows[i].ItemArray[colTaskTittle].ToString();
						NewEnt.DateTime = DateTime.Parse(dt.Rows[i].ItemArray[colDateTime].ToString());
						lsttasks.Add(NewEnt);
					}
				}
				return lsttasks;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
