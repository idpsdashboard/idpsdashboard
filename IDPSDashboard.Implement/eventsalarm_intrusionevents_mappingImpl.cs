
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class eventsalarm_intrusionevents_mappingImpl
	{
		#region eventsalarm_intrusionevents_mapping methods

		public int eventsalarm_intrusionevents_mappingAdd(eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mapping)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingAdd",
																						eventsalarm_intrusionevents_mapping.EventsAlarmId,
																						eventsalarm_intrusionevents_mapping.IntrusionEventId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool eventsalarm_intrusionevents_mappingUpdate(eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mapping)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingUpdate",
																							eventsalarm_intrusionevents_mapping.EventsAlarmId,
																							eventsalarm_intrusionevents_mapping.IntrusionEventId);
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

		public bool eventsalarm_intrusionevents_mappingDelete(int EventsAlarmId, int IntrusionEventId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingDelete",
																							EventsAlarmId,
																							IntrusionEventId);
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

		public eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mappingGetById(int EventsAlarmId, int IntrusionEventId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingGetById",
														                                     EventsAlarmId, 
                                                                                             IntrusionEventId).Tables[0];
				eventsalarm_intrusionevents_mapping NewEnt = new eventsalarm_intrusionevents_mapping();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.EventsAlarmId = Int32.Parse(dr["EventsAlarmId"].ToString());
                    NewEnt.IntrusionEventId = Int32.Parse(dr["IntrusionEventId"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public List<eventsalarm_intrusionevents_mapping> eventsalarm_intrusionevents_mappingGetByEventsAlarmId(int EventsAlarmId)
        {
            List<eventsalarm_intrusionevents_mapping> lsteventsalarm_intrusionevents_mapping = new List<eventsalarm_intrusionevents_mapping>();
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingGetByEventsAlarmId",
                                                                                              EventsAlarmId).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int colEventsAlarmId = dt.Columns["EventsAlarmId"].Ordinal;
                    int colIntrusionEventId = dt.Columns["IntrusionEventId"].Ordinal;
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        eventsalarm_intrusionevents_mapping NewEnt = new eventsalarm_intrusionevents_mapping();
                        NewEnt.EventsAlarmId = Int32.Parse(dt.Rows[i].ItemArray[colEventsAlarmId].ToString());
                        NewEnt.IntrusionEventId = Int32.Parse(dt.Rows[i].ItemArray[colIntrusionEventId].ToString());
                        lsteventsalarm_intrusionevents_mapping.Add(NewEnt);
                    }
                }
                return lsteventsalarm_intrusionevents_mapping;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<eventsalarm_intrusionevents_mapping> eventsalarm_intrusionevents_mappingGetAll()
		{
			List<eventsalarm_intrusionevents_mapping> lsteventsalarm_intrusionevents_mapping = new List<eventsalarm_intrusionevents_mapping>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsalarm_intrusionevents_mappingGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colEventsAlarmId =  dt.Columns["EventsAlarmId"].Ordinal;
					int colIntrusionEventId =  dt.Columns["IntrusionEventId"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						eventsalarm_intrusionevents_mapping NewEnt = new eventsalarm_intrusionevents_mapping();
						NewEnt.EventsAlarmId = Int32.Parse(dt.Rows[i].ItemArray[colEventsAlarmId].ToString());
						NewEnt.IntrusionEventId = Int32.Parse(dt.Rows[i].ItemArray[colIntrusionEventId].ToString());
						lsteventsalarm_intrusionevents_mapping.Add(NewEnt);
					}
				}
				return lsteventsalarm_intrusionevents_mapping;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
