
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class smtpserversImpl	
	{
		#region smtpservers methods

		public int smtpserversAdd( smtpservers smtpservers)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "smtpserversAdd",  
														                                smtpservers.SmtpServerHostname, 
														                                smtpservers.SmtpServerPort, 
														                                smtpservers.SmtpServerAccount, 
														                                smtpservers.SmtpServerPassword, 
														                                smtpservers.StmpServerEnabled);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool smtpserversUpdate( smtpservers smtpservers)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "smtpserversUpdate",  
														                                    smtpservers.SmtpServerId, 
														                                    smtpservers.SmtpServerHostname, 
														                                    smtpservers.SmtpServerPort, 
														                                    smtpservers.SmtpServerAccount, 
														                                    smtpservers.SmtpServerPassword, 
														                                    smtpservers.StmpServerEnabled);
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

		public bool smtpserversDelete( int SmtpServerId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "smtpserversDelete",  
                                    														SmtpServerId);
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

		public smtpservers smtpserversGetById(int SmtpServerId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "smtpserversGetById",
                                            														SmtpServerId).Tables[0];
				smtpservers NewEnt = new smtpservers();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.SmtpServerId = Int32.Parse(dr["SmtpServerId"].ToString());
					NewEnt.SmtpServerHostname = dr["SmtpServerHostname"].ToString();
					NewEnt.SmtpServerPort = dr["SmtpServerPort"].ToString();
					NewEnt.SmtpServerAccount = dr["SmtpServerAccount"].ToString();
					NewEnt.SmtpServerPassword = dr["SmtpServerPassword"].ToString();
					NewEnt.StmpServerEnabled = sbyte.Parse(dr["StmpServerEnabled"].ToString());
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<smtpservers> smtpserversGetAll()
		{
			List<smtpservers> lstsmtpservers = new List<smtpservers>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "smtpserversGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colSmtpServerId =  dt.Columns["SmtpServerId"].Ordinal;
					int colSmtpServerHostname =  dt.Columns["SmtpServerHostname"].Ordinal;
					int colSmtpServerPort =  dt.Columns["SmtpServerPort"].Ordinal;
					int colSmtpServerAccount =  dt.Columns["SmtpServerAccount"].Ordinal;
					int colSmtpServerPassword =  dt.Columns["SmtpServerPassword"].Ordinal;
					int colStmpServerEnabled =  dt.Columns["StmpServerEnabled"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						smtpservers NewEnt = new smtpservers();
						NewEnt.SmtpServerId = Int32.Parse(dt.Rows[i].ItemArray[colSmtpServerId].ToString());
						NewEnt.SmtpServerHostname = dt.Rows[i].ItemArray[colSmtpServerHostname].ToString();
						NewEnt.SmtpServerPort = dt.Rows[i].ItemArray[colSmtpServerPort].ToString();
						NewEnt.SmtpServerAccount = dt.Rows[i].ItemArray[colSmtpServerAccount].ToString();
						NewEnt.SmtpServerPassword = dt.Rows[i].ItemArray[colSmtpServerPassword].ToString();
						NewEnt.StmpServerEnabled = sbyte.Parse(dt.Rows[i].ItemArray[colStmpServerEnabled].ToString());
						lstsmtpservers.Add(NewEnt);
					}
				}
				return lstsmtpservers;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
