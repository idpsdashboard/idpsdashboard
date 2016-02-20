
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class databasestypeBus
	{
		#region Business

		public int databasestypeAdd(databasestype databasestype)
		{
			databasestypeImpl odatabasestypeImpl = new databasestypeImpl();
			return odatabasestypeImpl.databasestypeAdd( databasestype);
		}

		public bool databasestypeUpdate(databasestype databasestype)
		{
			databasestypeImpl odatabasestypeImpl = new databasestypeImpl();
			return odatabasestypeImpl.databasestypeUpdate( databasestype);
		}

		public bool databasestypeDelete(int DatabaseTypeId)
		{
			databasestypeImpl odatabasestypeImpl = new databasestypeImpl();
			return odatabasestypeImpl.databasestypeDelete( DatabaseTypeId);
		}

		public databasestype databasestypeGetById(int DatabaseTypeId)
		{
			databasestypeImpl odatabasestypeImpl = new databasestypeImpl();
			return odatabasestypeImpl.databasestypeGetById(DatabaseTypeId);
		}

		public List<databasestype> databasestypeGetAll()
		{
			databasestypeImpl odatabasestypeImpl = new databasestypeImpl();
			return odatabasestypeImpl.databasestypeGetAll();
		}

		#endregion
	}
}
