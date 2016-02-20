
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class eventstypeBus
	{
		#region Business

		public int eventstypeAdd(eventstype eventstype)
		{
			eventstypeImpl oeventstypeImpl = new eventstypeImpl();
			return oeventstypeImpl.eventstypeAdd( eventstype);
		}

		public bool eventstypeUpdate(eventstype eventstype)
		{
			eventstypeImpl oeventstypeImpl = new eventstypeImpl();
			return oeventstypeImpl.eventstypeUpdate( eventstype);
		}

		public bool eventstypeDelete(int EventsTypeId)
		{
			eventstypeImpl oeventstypeImpl = new eventstypeImpl();
			return oeventstypeImpl.eventstypeDelete( EventsTypeId);
		}

		public eventstype eventstypeGetById(int EventsTypeId)
		{
			eventstypeImpl oeventstypeImpl = new eventstypeImpl();
			return oeventstypeImpl.eventstypeGetById(EventsTypeId);
		}

        public List<eventstype> eventstypeGetByDescription(string description)
        {
            eventstypeImpl oeventstypeImpl = new eventstypeImpl();
            return oeventstypeImpl.eventstypeGetByDescription(description);
        }

		public List<eventstype> eventstypeGetAll()
		{
			eventstypeImpl oeventstypeImpl = new eventstypeImpl();
			return oeventstypeImpl.eventstypeGetAll();
		}

		#endregion
	}
}
