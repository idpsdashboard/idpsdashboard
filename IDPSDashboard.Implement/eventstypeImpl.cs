
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class eventstypeImpl	
	{
		#region eventstype methods

		public int eventstypeAdd( eventstype eventstype)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "eventstypeAdd",   
														                                  eventstype.Description);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool eventstypeUpdate( eventstype eventstype)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventstypeUpdate",   
														                                    eventstype.EventsTypeId, 
														                                    eventstype.Description);
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

		public bool eventstypeDelete( int EventsTypeId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "eventstypeDelete",   
														                                     EventsTypeId);
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

		public eventstype eventstypeGetById(int EventsTypeId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventstypeGetById",
														                                      EventsTypeId).Tables[0];
				eventstype NewEnt = new eventstype();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.EventsTypeId = Int32.Parse(dr["EventsTypeId"].ToString());
					NewEnt.Description = dr["Description"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public List<eventstype> eventstypeGetByDescription(string description)
        {
            List<eventstype> lsteventstype = new List<eventstype>();
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventstypeGetByDescription" ,
                                                                                             description).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int colEventsTypeId = dt.Columns["EventsTypeId"].Ordinal;
                    int colDescription = dt.Columns["Description"].Ordinal;
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        eventstype NewEnt = new eventstype();
                        NewEnt.EventsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colEventsTypeId].ToString());
                        NewEnt.Description = dt.Rows[i].ItemArray[colDescription].ToString();
                        lsteventstype.Add(NewEnt);
                    }
                }
                return lsteventstype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<eventstype> eventstypeGetAll()
		{
			List<eventstype> lsteventstype = new List<eventstype>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "eventstypeGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colEventsTypeId =  dt.Columns["EventsTypeId"].Ordinal;
					int colDescription =  dt.Columns["Description"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						eventstype NewEnt = new eventstype();
						NewEnt.EventsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colEventsTypeId].ToString());
						NewEnt.Description = dt.Rows[i].ItemArray[colDescription].ToString();
						lsteventstype.Add(NewEnt);
					}
				}
				return lsteventstype;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
