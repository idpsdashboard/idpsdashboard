
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class eventsalarmImpl	
	{
		#region eventsalarm methods

		public int eventsalarmAdd(eventsalarm eventsalarm)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventsalarmAdd", 
														                                    eventsalarm.EventsTypeId, 
														                                    eventsalarm.Active, 
														                                    eventsalarm.CheckFrecuency, 
														                                    eventsalarm.Severity);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool eventsalarmUpdate(int idUsuario, string ip, string host, eventsalarm eventsalarm)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsalarmUpdate",
														                                    eventsalarm.EventsAlarmId, 
														                                    eventsalarm.EventsTypeId, 
														                                    eventsalarm.Active, 
														                                    eventsalarm.CheckFrecuency, 
														                                    eventsalarm.Severity);
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

		public bool eventsalarmDelete(int EventsAlarmId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventsalarmDelete", 
														                                      EventsAlarmId);
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

		public eventsalarm eventsalarmGetById(int EventsAlarmId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsalarmGetById",
														EventsAlarmId).Tables[0];
				eventsalarm NewEnt = new eventsalarm();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.EventsAlarmId = Int32.Parse(dr["EventsAlarmId"].ToString());
					NewEnt.EventsTypeId = Int32.Parse(dr["EventsTypeId"].ToString());
					NewEnt.Active = sbyte.Parse(dr["Active"].ToString());
					NewEnt.CheckFrecuency = Int32.Parse(dr["CheckFrecuency"].ToString());
					NewEnt.Severity = Int32.Parse(dr["Severity"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<eventsalarm> eventsalarmGetAll()
		{
			List<eventsalarm> lsteventsalarm = new List<eventsalarm>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventsalarmGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colEventsAlarmId =  dt.Columns["EventsAlarmId"].Ordinal;
					int colEventsTypeId =  dt.Columns["EventsTypeId"].Ordinal;
					int colActive =  dt.Columns["Active"].Ordinal;
					int colCheckFrecuency =  dt.Columns["CheckFrecuency"].Ordinal;
					int colSeverity =  dt.Columns["Severity"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						eventsalarm NewEnt = new eventsalarm();
						NewEnt.EventsAlarmId = Int32.Parse(dt.Rows[i].ItemArray[colEventsAlarmId].ToString());
						NewEnt.EventsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colEventsTypeId].ToString());
						NewEnt.Active = sbyte.Parse(dt.Rows[i].ItemArray[colActive].ToString());
						NewEnt.CheckFrecuency = Int32.Parse(dt.Rows[i].ItemArray[colCheckFrecuency].ToString());
						NewEnt.Severity = Int32.Parse(dt.Rows[i].ItemArray[colSeverity].ToString());
						lsteventsalarm.Add(NewEnt);
					}
				}
				return lsteventsalarm;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
