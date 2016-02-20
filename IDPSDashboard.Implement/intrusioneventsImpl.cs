
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class intrusioneventsImpl
	{
		#region intrusionevents methods

		public int intrusioneventsAdd(intrusionevents intrusionevents)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "intrusioneventsAdd",
																						intrusionevents.IntrusionEventDetail,
																						intrusionevents.CVEId,
																						intrusionevents.CWEId,
                                                                                        intrusionevents.CAPECId,
                                                                                        intrusionevents.OWASPId);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool intrusioneventsUpdate(intrusionevents intrusionevents)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "intrusioneventsUpdate",
																							intrusionevents.IntrusionEventsId,
																							intrusionevents.IntrusionEventDetail,
																							intrusionevents.CVEId,
																							intrusionevents.CWEId,
                                                                                            intrusionevents.CAPECId,
                                                                                            intrusionevents.OWASPId);
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

		public bool intrusioneventsDelete(int IntrusionEventsId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "intrusioneventsDelete",
																							IntrusionEventsId);
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

		public intrusionevents intrusioneventsGetById(int IntrusionEventsId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "intrusioneventsGetById",
																							IntrusionEventsId).Tables[0];
				intrusionevents NewEnt = new intrusionevents();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.IntrusionEventsId = Int32.Parse(dr["IntrusionEventsId"].ToString());
					NewEnt.IntrusionEventDetail = dr["IntrusionEventDetail"].ToString();
					NewEnt.CVEId = dr["CVEId"].ToString();
					NewEnt.CWEId = dr["CWEId"].ToString();
                    NewEnt.CWEId = dr["CAPECId"].ToString();
                    NewEnt.CWEId = dr["OWASPId"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public List<intrusionevents> intrusioneventsGetByEventDetail(string eventDetail)
        {
            List<intrusionevents> lstintrusionevents = new List<intrusionevents>();
            try
            {
                DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "intrusioneventsGetByEventTypeId",
                                                                                                eventDetail).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int colIntrusionEventsId = dt.Columns["IntrusionEventsId"].Ordinal;
                    int colIntrusionEventDetail = dt.Columns["IntrusionEventDetail"].Ordinal;
                    int colCVEId = dt.Columns["CVEId"].Ordinal;
                    int colCWEId = dt.Columns["CWEId"].Ordinal;
                    int colCAPECId = dt.Columns["CAPECId"].Ordinal;
                    int colOWASPId = dt.Columns["OWASPId"].Ordinal;

                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        intrusionevents NewEnt = new intrusionevents();
                        NewEnt.IntrusionEventsId = Int32.Parse(dt.Rows[i].ItemArray[colIntrusionEventsId].ToString());
                        NewEnt.IntrusionEventDetail = dt.Rows[i].ItemArray[colIntrusionEventDetail].ToString();
                        NewEnt.CVEId = dt.Rows[i].ItemArray[colCVEId].ToString();
                        NewEnt.CWEId = dt.Rows[i].ItemArray[colCWEId].ToString();
                        NewEnt.CAPECId = dt.Rows[i].ItemArray[colCAPECId].ToString();
                        NewEnt.OWASPId = dt.Rows[i].ItemArray[colOWASPId].ToString();
                        lstintrusionevents.Add(NewEnt);
                    }
                }
                return lstintrusionevents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<intrusionevents> intrusioneventsGetAll()
		{
			List<intrusionevents> lstintrusionevents = new List<intrusionevents>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "intrusioneventsGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colIntrusionEventsId =  dt.Columns["IntrusionEventsId"].Ordinal;
					int colIntrusionEventDetail =  dt.Columns["IntrusionEventDetail"].Ordinal;
					int colCVEId =  dt.Columns["CVEId"].Ordinal;
					int colCWEId =  dt.Columns["CWEId"].Ordinal;
                    int colCAPECId = dt.Columns["CAPECId"].Ordinal;
                    int colOWASPId = dt.Columns["OWASPId"].Ordinal;

					for (int i = 0; dt.Rows.Count > i; i++)
					{
						intrusionevents NewEnt = new intrusionevents();
						NewEnt.IntrusionEventsId = Int32.Parse(dt.Rows[i].ItemArray[colIntrusionEventsId].ToString());
						NewEnt.IntrusionEventDetail = dt.Rows[i].ItemArray[colIntrusionEventDetail].ToString();
						NewEnt.CVEId = dt.Rows[i].ItemArray[colCVEId].ToString();
						NewEnt.CWEId = dt.Rows[i].ItemArray[colCWEId].ToString();
                        NewEnt.CAPECId = dt.Rows[i].ItemArray[colCAPECId].ToString();
                        NewEnt.OWASPId = dt.Rows[i].ItemArray[colOWASPId].ToString();

						lstintrusionevents.Add(NewEnt);
					}
				}
				return lstintrusionevents;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion
	}
}
