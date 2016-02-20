
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class databasestypeImpl	
	{
		#region databasestype methods

		public int databasestypeAdd(databasestype databasestype)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "databasestypeAdd", 
														                                  databasestype.DatabaseName);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool databasestypeUpdate(databasestype databasestype)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "databasestypeUpdate", 
														                                    databasestype.DatabaseTypeId, 
														                                    databasestype.DatabaseName);
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

		public bool databasestypeDelete(int DatabaseTypeId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "databasestypeDelete", 
														                                     DatabaseTypeId);
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

		public databasestype databasestypeGetById(int DatabaseTypeId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "databasestypeGetById",
														                                       DatabaseTypeId).Tables[0];
				databasestype NewEnt = new databasestype();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.DatabaseTypeId = Int32.Parse(dr["DatabaseTypeId"].ToString());
					NewEnt.DatabaseName = dr["DatabaseName"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<databasestype> databasestypeGetAll()
		{
			List<databasestype> lstdatabasestype = new List<databasestype>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "databasestypeGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colDatabaseTypeId =  dt.Columns["DatabaseTypeId"].Ordinal;
					int colDatabaseName =  dt.Columns["DatabaseName"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						databasestype NewEnt = new databasestype();
						NewEnt.DatabaseTypeId = Int32.Parse(dt.Rows[i].ItemArray[colDatabaseTypeId].ToString());
						NewEnt.DatabaseName = dt.Rows[i].ItemArray[colDatabaseName].ToString();
						lstdatabasestype.Add(NewEnt);
					}
				}
				return lstdatabasestype;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
