
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class idsImpl	
	{
		#region ids methods

		public int idsAdd( ids ids)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "idsAdd",   
														                                ids.idsName,
                                                                                        ids.DatabaseTypeId, 
														                                ids.IdsTypeId, 
														                                ids.Active, 
														                                ids.IdsIP,
                                                                                        ids.DatabaseUser,
                                                                                        ids.DatabasePass,
                                                                                        ids.DatabaseName,
                                                                                        ids.DatabaseHost,
                                                                                        ids.IdsVersion);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool idsUpdate( ids ids)
		{
			try
			{
                int update = (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "idsUpdate",   
														                                    ids.IdsId,
                                                                                            ids.idsName,
														                                    ids.DatabaseTypeId, 
														                                    ids.IdsTypeId, 
														                                    ids.Active, 
														                                    ids.IdsIP,
                                                                                            ids.DatabaseUser,
                                                                                            ids.DatabasePass,
                                                                                            ids.DatabaseName,
                                                                                            ids.DatabaseHost,
                                                                                            ids.IdsVersion);
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

		public bool idsDelete( int IdsId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "idsDelete",   
                                    														IdsId);
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

		public ids idsGetById(int IdsId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "idsGetById",
                                														      IdsId).Tables[0];
				ids NewEnt = new ids();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.IdsId = Int32.Parse(dr["IdsId"].ToString());
                    NewEnt.idsName = dr["IdsName"].ToString();
					NewEnt.DatabaseTypeId = Int32.Parse(dr["DatabaseTypeId"].ToString());
					NewEnt.IdsTypeId = Int32.Parse(dr["IdsTypeId"].ToString());
					NewEnt.Active = sbyte.Parse(dr["Active"].ToString());
					NewEnt.IdsIP = dr["IdsIP"].ToString();
                    NewEnt.DatabaseUser = dr["DatabaseUser"].ToString();
                    NewEnt.DatabasePass = dr["DatabasePass"].ToString();
                    NewEnt.DatabaseName = dr["DatabaseName"].ToString();
                    NewEnt.DatabaseHost = dr["DatabaseHost"].ToString();
                    NewEnt.IdsVersion = dr["IdsVersion"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<ids> idsGetAll()
		{
			List<ids> lstids = new List<ids>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "idsGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colIdsId =  dt.Columns["IdsId"].Ordinal;
                    int colIdsName = dt.Columns["IdsName"].Ordinal;
					int colDatabaseTypeId =  dt.Columns["DatabaseTypeId"].Ordinal;
					int colIdsTypeId =  dt.Columns["IdsTypeId"].Ordinal;
					int colActive =  dt.Columns["Active"].Ordinal;
					int colIdsIP =  dt.Columns["IdsIP"].Ordinal;
                    int colDatabaseUser = dt.Columns["DatabaseUser"].Ordinal;
                    int colDatabasePass = dt.Columns["DatabasePass"].Ordinal;
                    int colDatabaseName = dt.Columns["DatabaseName"].Ordinal;
                    int colDatabaseHost = dt.Columns["DatabaseHost"].Ordinal;
                    int colIdsVersion   = dt.Columns["IdsVersion"].Ordinal;

					for (int i = 0; dt.Rows.Count > i; i++)
					{
						ids NewEnt = new ids();
						NewEnt.IdsId = Int32.Parse(dt.Rows[i].ItemArray[colIdsId].ToString());
                        NewEnt.idsName = dt.Rows[i].ItemArray[colIdsName].ToString();
						NewEnt.DatabaseTypeId = Int32.Parse(dt.Rows[i].ItemArray[colDatabaseTypeId].ToString());
						NewEnt.IdsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colIdsTypeId].ToString());
						NewEnt.Active = sbyte.Parse(dt.Rows[i].ItemArray[colActive].ToString());
						NewEnt.IdsIP = dt.Rows[i].ItemArray[colIdsIP].ToString();
                        NewEnt.DatabaseUser = dt.Rows[i].ItemArray[colDatabaseUser].ToString();
                        NewEnt.DatabasePass = dt.Rows[i].ItemArray[colDatabasePass].ToString();
                        NewEnt.DatabaseName = dt.Rows[i].ItemArray[colDatabaseName].ToString();
                        NewEnt.DatabaseHost = dt.Rows[i].ItemArray[colDatabaseHost].ToString();
                        NewEnt.IdsVersion = dt.Rows[i].ItemArray[colIdsVersion].ToString();
						lstids.Add(NewEnt);
					}
				}
				return lstids;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
