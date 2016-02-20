
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class eventsalarmImpl	
	{
		#region eventsalarm methods

		public int eventsalarmAdd(eventsalarm eventsalarm)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventsalarmAdd",
                                                                                            eventsalarm.IdsId,
                                                                                            eventsalarm.IdsSignatureCategoryId, 
														                                    eventsalarm.Active, 
														                                    eventsalarm.CheckFrecuency, 
														                                    eventsalarm.Severity,
                                                                                            eventsalarm.AffectConfidence,
                                                                                            eventsalarm.AffectIntegrity,
                                                                                            eventsalarm.AffectAvailability,
                                                                                            eventsalarm.EventsAlarmTittle);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool eventsalarmUpdate(eventsalarm eventsalarm)
		{
			try
			{
                int update = (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventsalarmUpdate",
                                                                                            eventsalarm.EventsAlarmId,
                                                                                            eventsalarm.IdsId,
                                                                                            eventsalarm.IdsSignatureCategoryId, 
														                                    eventsalarm.Active, 
														                                    eventsalarm.CheckFrecuency, 
														                                    eventsalarm.Severity,
                                                                                            eventsalarm.AffectConfidence,
                                                                                            eventsalarm.AffectIntegrity,
                                                                                            eventsalarm.AffectAvailability,
                                                                                            eventsalarm.EventsAlarmTittle);
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
                    NewEnt.IdsId = Int32.Parse(dr["IdsId"].ToString());
                    NewEnt.IdsSignatureCategoryId = Int32.Parse(dr["IdsSignatureCategoryId"].ToString());
					NewEnt.Active = sbyte.Parse(dr["Active"].ToString());
					NewEnt.CheckFrecuency = Int32.Parse(dr["CheckFrecuency"].ToString());
					NewEnt.Severity = Int32.Parse(dr["Severity"].ToString());
                    NewEnt.AffectConfidence = sbyte.Parse(dr["AffectConfidence"].ToString());
                    NewEnt.AffectIntegrity = sbyte.Parse(dr["AffectIntegrity"].ToString());
                    NewEnt.AffectAvailability =sbyte.Parse(dr["AffectAvailability"].ToString());
                    NewEnt.EventsAlarmTittle= dr["AffectAvailability"].ToString();
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
                    int colEventsAlarmId = dt.Columns["EventsAlarmId"].Ordinal;
                    int colIdsId = dt.Columns["IdsId"].Ordinal;
                    int colIdsSignatureCategoryId = dt.Columns["IdsSignatureCategoryId"].Ordinal;
					int colActive =  dt.Columns["Active"].Ordinal;
					int colCheckFrecuency =  dt.Columns["CheckFrecuency"].Ordinal;
					int colSeverity =  dt.Columns["Severity"].Ordinal;
                    int colAffectConfidence = dt.Columns["AffectConfidence"].Ordinal;
                    int colAffectIntegrity = dt.Columns["AffectIntegrity"].Ordinal;
                    int colAffectAvailability = dt.Columns["AffectAvailability"].Ordinal;
                    int colEventsAlarmTittle = dt.Columns["EventsAlarmTittle"].Ordinal;

					for (int i = 0; dt.Rows.Count > i; i++)
					{
						eventsalarm NewEnt = new eventsalarm();
                        NewEnt.EventsAlarmId = Int32.Parse(dt.Rows[i].ItemArray[colEventsAlarmId].ToString());
                        NewEnt.IdsId = Int32.Parse(dt.Rows[i].ItemArray[colIdsId].ToString());
                        NewEnt.IdsSignatureCategoryId = Int32.Parse(dt.Rows[i].ItemArray[colIdsSignatureCategoryId].ToString());
						NewEnt.Active = sbyte.Parse(dt.Rows[i].ItemArray[colActive].ToString());
						NewEnt.CheckFrecuency = Int32.Parse(dt.Rows[i].ItemArray[colCheckFrecuency].ToString());
						NewEnt.Severity = Int32.Parse(dt.Rows[i].ItemArray[colSeverity].ToString());
                        NewEnt.AffectConfidence = sbyte.Parse(dt.Rows[i].ItemArray[colAffectConfidence].ToString());
                        NewEnt.AffectIntegrity = sbyte.Parse(dt.Rows[i].ItemArray[colAffectIntegrity].ToString());
                        NewEnt.AffectAvailability = sbyte.Parse(dt.Rows[i].ItemArray[colAffectAvailability].ToString());
                        NewEnt.EventsAlarmTittle = dt.Rows[i].ItemArray[colEventsAlarmTittle].ToString();
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
