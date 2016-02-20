
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using dal.SqlServerLibrary;
using IDPSDashboard.Model;

namespace IDPSDashboard.Implement
{
	public class idstypeImpl	
	{
		#region idstype methods

		public int idstypeAdd( idstype idstype)
		{
			try
			{
				return (int)SqlHelper.ExecuteScalar(SqlImplHelper.getConnectionString(), "idstypeAdd",  
														                                    idstype.IdsTypeName);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public bool idstypeUpdate( idstype idstype)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "idstypeUpdate",  
														                                    idstype.IdsTypeId, 
														                                    idstype.IdsTypeName);
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

		public bool idstypeDelete( int IdsTypeId)
		{
			try
			{
				int update = SqlHelper.ExecuteNonQuery(SqlImplHelper.getConnectionString(), "idstypeDelete",  
                                    														IdsTypeId);
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

		public idstype idstypeGetById(int IdsTypeId)
		{
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "idstypeGetById",
                                            														IdsTypeId).Tables[0];
				idstype NewEnt = new idstype();

				if(dt.Rows.Count > 0)
				{
					DataRow dr = dt.Rows[0];
					NewEnt.IdsTypeId = Int32.Parse(dr["IdsTypeId"].ToString());
					NewEnt.IdsTypeName = dr["IdsTypeName"].ToString();
				}
				return NewEnt;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public List<idstype> idstypeGetAll()
		{
			List<idstype> lstidstype = new List<idstype>();
			try
			{
				DataTable dt = SqlHelper.ExecuteDataset(SqlImplHelper.getConnectionString(), "idstypeGetAll").Tables[0];
				if (dt.Rows.Count > 0)
				{
					int colIdsTypeId =  dt.Columns["IdsTypeId"].Ordinal;
					int colIdsTypeName =  dt.Columns["IdsTypeName"].Ordinal;
					for (int i = 0; dt.Rows.Count > i; i++)
					{
						idstype NewEnt = new idstype();
						NewEnt.IdsTypeId = Int32.Parse(dt.Rows[i].ItemArray[colIdsTypeId].ToString());
						NewEnt.IdsTypeName = dt.Rows[i].ItemArray[colIdsTypeName].ToString();
						lstidstype.Add(NewEnt);
					}
				}
				return lstidstype;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion

	}
}
