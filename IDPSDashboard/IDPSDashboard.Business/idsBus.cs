
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class idsBus
	{
		#region Business

		public int idsAdd(ids ids)
		{
			idsImpl oidsImpl = new idsImpl();
			return oidsImpl.idsAdd( ids);
		}

		public bool idsUpdate(ids ids)
		{
			idsImpl oidsImpl = new idsImpl();
			return oidsImpl.idsUpdate( ids);
		}

		public bool idsDelete(int IdsId)
		{
			idsImpl oidsImpl = new idsImpl();
			return oidsImpl.idsDelete( IdsId);
		}

		public ids idsGetById(int IdsId)
		{
			idsImpl oidsImpl = new idsImpl();
			return oidsImpl.idsGetById(IdsId);
		}

		public List<ids> idsGetAll()
		{
			idsImpl oidsImpl = new idsImpl();
			return oidsImpl.idsGetAll();
		}

		#endregion
	}
}
