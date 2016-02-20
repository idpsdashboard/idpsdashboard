
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiaamSoft.dal.SqlServerLibrary;
using IDPSDahboard.Model;

namespace IDPSDahboard.SqlServerImpl
{
	public class idsImpl	
	{
		#region ids methods

		public int idsAdd( ids ids)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "idsAdd",   
														                                ids.DatabaseTypeId, 
														                                ids.IdsTypeId, 
														                                ids.Active, 
														                                ids.IdsIP);
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
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "idsUpdate",   
														                                    ids.IdsId, 
														                                    ids.DatabaseTypeId, 
														                                    ids.IdsTypeId, 
														                                    ids.Active, 
														                                    ids.IdsIP);
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
					NewEnt.DatabaseTypeId = Int32.Parse(dr["DatabaseTypeId"].ToString());
					NewEnt.IdsTypeId = Int32.Parse(dr["IdsTypeId"].ToString());
					NewEnt.Active = sbyte.Parse(dr["Active"].ToString());
					NewEnt.IdsIP = dr["IdsIP"].ToString();
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
					int colDatabaseTypeId =  dt.Columns["DatabaseTypeId"].Ordinal;
					int colIdsTypeId =  dt.Columns["IdsTypeId"].Ordinal;
					int colActive =  dt.Columns["Active"].Ordinal;
					int colIdsIP =  dt.Columns["IdsIP"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						ids NewEnt = new ids();
						NewEnt.IdsId = Int32.Parse(dt.Rows[i].ItemArray[colIdsId].ToString());
						NewEnt.DatabaseTypeId = Int32.Parse(dt.Rows[i].ItemArray[colDatabaseTypeId].ToString());
						NewEnt.IdsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colIdsTypeId].ToString());
						NewEnt.Active = sbyte.Parse(dt.Rows[i].ItemArray[colActive].ToString());
						NewEnt.IdsIP = dt.Rows[i].ItemArray[colIdsIP].ToString();
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
