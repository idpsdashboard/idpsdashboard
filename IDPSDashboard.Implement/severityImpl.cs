
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class severityImpl	
	{
		#region severity methods

		public int severityAdd( severity severity)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "severityAdd",  
														                                severity.SeverityDescription, 
														                                severity.SLATimeToResponse);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool severityUpdate( severity severity)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "severityUpdate",  
														                                        severity.SeverityId, 
														                                        severity.SeverityDescription, 
														                                        severity.SLATimeToResponse);
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

		public bool severityDelete( int SeverityId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "severityDelete",  
                                    														SeverityId);
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

		public severity severityGetById(int SeverityId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "severityGetById",
														                                            SeverityId).Tables[0];
				severity NewEnt = new severity();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.SeverityId = Int32.Parse(dr["SeverityId"].ToString());
					NewEnt.SeverityDescription = dr["SeverityDescription"].ToString();
					NewEnt.SLATimeToResponse = Int32.Parse(dr["SLATimeToResponse"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<severity> severityGetAll()
		{
			List<severity> lstseverity = new List<severity>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "severityGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colSeverityId =  dt.Columns["SeverityId"].Ordinal;
					int colSeverityDescription =  dt.Columns["SeverityDescription"].Ordinal;
					int colSLATimeToResponse =  dt.Columns["SLATimeToResponse"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						severity NewEnt = new severity();
						NewEnt.SeverityId = Int32.Parse(dt.Rows[i].ItemArray[colSeverityId].ToString());
						NewEnt.SeverityDescription = dt.Rows[i].ItemArray[colSeverityDescription].ToString();
						NewEnt.SLATimeToResponse = Int32.Parse(dt.Rows[i].ItemArray[colSLATimeToResponse].ToString());
						lstseverity.Add(NewEnt);
					}
				}
				return lstseverity;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
