
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class idstypeBus
	{
		#region Business

		public int idstypeAdd(idstype idstype)
		{
			idstypeImpl oidstypeImpl = new idstypeImpl();
			return oidstypeImpl.idstypeAdd( idstype);
		}

		public bool idstypeUpdate(idstype idstype)
		{
			idstypeImpl oidstypeImpl = new idstypeImpl();
			return oidstypeImpl.idstypeUpdate( idstype);
		}

		public bool idstypeDelete(int IdsTypeId)
		{
			idstypeImpl oidstypeImpl = new idstypeImpl();
			return oidstypeImpl.idstypeDelete( IdsTypeId);
		}

		public idstype idstypeGetById(int IdsTypeId)
		{
			idstypeImpl oidstypeImpl = new idstypeImpl();
			return oidstypeImpl.idstypeGetById(IdsTypeId);
		}

		public List<idstype> idstypeGetAll()
		{
			idstypeImpl oidstypeImpl = new idstypeImpl();
			return oidstypeImpl.idstypeGetAll();
		}

		#endregion
	}
}
