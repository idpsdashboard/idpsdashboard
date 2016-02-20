
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class eventsdetectionBus
	{
		#region Business

		public int eventsdetectionAdd(eventsdetection eventsdetection)
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
			return oeventsdetectionImpl.eventsdetectionAdd( eventsdetection);
		}

		public bool eventsdetectionUpdate(eventsdetection eventsdetection)
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
			return oeventsdetectionImpl.eventsdetectionUpdate( eventsdetection);
		}

		public bool eventsdetectionDelete(int eventsdetectionId)
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
            return oeventsdetectionImpl.eventsdetectionDelete(eventsdetectionId);
		}

		public eventsdetection eventsdetectionGetById()
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
			return oeventsdetectionImpl.eventsdetectionGetById();
		}

		public List<eventsdetection> eventsdetectionGetAll()
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
			return oeventsdetectionImpl.eventsdetectionGetAll();
		}

		#endregion
	}
}
