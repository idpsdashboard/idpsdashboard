
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class severityBus
	{
		#region Business

		public int severityAdd(severity severity)
		{
			severityImpl oseverityImpl = new severityImpl();
			return oseverityImpl.severityAdd( severity);
		}

		public bool severityUpdate(severity severity)
		{
			severityImpl oseverityImpl = new severityImpl();
			return oseverityImpl.severityUpdate( severity);
		}

		public bool severityDelete(int SeverityId)
		{
			severityImpl oseverityImpl = new severityImpl();
			return oseverityImpl.severityDelete( SeverityId);
		}

		public severity severityGetById(int SeverityId)
		{
			severityImpl oseverityImpl = new severityImpl();
			return oseverityImpl.severityGetById(SeverityId);
		}

		public List<severity> severityGetAll()
		{
			severityImpl oseverityImpl = new severityImpl();
			return oseverityImpl.severityGetAll();
		}

		#endregion
	}
}
