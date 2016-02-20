
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class eventsdetectionImpl	
	{
		#region eventsdetection methods

		public int eventsdetectionAdd(eventsdetection eventsdetection)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventsdetectionAdd",
														                                    eventsdetection.IdsId, 
														                                    eventsdetection.DateTime, 
														                                    eventsdetection.EventStatus, 
														                                    eventsdetection.EventsAlarmId,
                                                                                            eventsdetection.IDPSEventId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool eventsdetectionUpdate(eventsdetection eventsdetection)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsdetectionUpdate",
                                                                                            eventsdetection.EventsDetectionId, 
                                                                                            eventsdetection.IdsId, 
														                                    eventsdetection.DateTime, 
														                                    eventsdetection.EventStatus, 
														                                    eventsdetection.EventsAlarmId,
                                                                                            eventsdetection.IDPSEventId);
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

        public bool eventsdetectionUpdateStatus(int EventsDetectionId, int EventStatusId)
        {
            try
            {
                int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsdetectionUpdateStatus",
                                                                                            EventsDetectionId,
                                                                                            EventStatusId);
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

		public bool eventsdetectionDelete(eventsdetection eventsdetection)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsdetectionDelete", 
                                        												     eventsdetection.EventsDetectionId);
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

		public eventsdetection eventsdetectionGetById(int eventsdetectionId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsdetectionGetById",
                                                                                              eventsdetectionId).Tables[0];
				eventsdetection NewEnt = new eventsdetection();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
                    NewEnt.EventsDetectionId = Int32.Parse(dr["EventsDetectionId"].ToString());
                    NewEnt.IdsId = Int32.Parse(dr["IdsId"].ToString());
					NewEnt.DateTime = DateTime.Parse(dr["DateTime"].ToString());
					NewEnt.EventStatus = Int32.Parse(dr["EventStatus"].ToString());
					NewEnt.EventsAlarmId = Int32.Parse(dr["EventsAlarmId"].ToString());
                    NewEnt.IDPSEventId = Int32.Parse(dr["IDPSEventId"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<eventsdetection> eventsdetectionGetAll()
		{
			List<eventsdetection> lsteventsdetection = new List<eventsdetection>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsdetectionGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
                    int colEventsDetectionId = dt.Columns["EventsDetectionId"].Ordinal;
                    int colIdsId =  dt.Columns["IdsId"].Ordinal;
					int colDateTime =  dt.Columns["DateTime"].Ordinal;
					int colEventStatus =  dt.Columns["EventStatus"].Ordinal;
					int colEventsAlarmId =  dt.Columns["EventsAlarmId"].Ordinal;
                    int colEventsIDPSEventId = dt.Columns["IDPSEventId"].Ordinal;

					for (int i = 0; dt.Rows.Count > i; i++)
					{
						eventsdetection NewEnt = new eventsdetection();
                        NewEnt.EventsDetectionId = Int32.Parse(dt.Rows[i].ItemArray[colEventsDetectionId].ToString());
                        NewEnt.IdsId = Int32.Parse(dt.Rows[i].ItemArray[colIdsId].ToString());
						NewEnt.DateTime = DateTime.Parse(dt.Rows[i].ItemArray[colDateTime].ToString());
						NewEnt.EventStatus = Int32.Parse(dt.Rows[i].ItemArray[colEventStatus].ToString());
						NewEnt.EventsAlarmId = Int32.Parse(dt.Rows[i].ItemArray[colEventsAlarmId].ToString());
                        NewEnt.IDPSEventId = Int32.Parse(dt.Rows[i].ItemArray[colEventsIDPSEventId].ToString());
						lsteventsdetection.Add(NewEnt);
					}
				}
				return lsteventsdetection;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
