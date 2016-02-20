
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
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

        public bool eventsdetectionUpdateStatus(int EventsDetectionId, int EventStatusId)
        {
            eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
            return oeventsdetectionImpl.eventsdetectionUpdateStatus(EventsDetectionId, EventStatusId);        
        }

        public bool eventsdetectionDelete(eventsdetection eventsdetection)
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
            return oeventsdetectionImpl.eventsdetectionDelete(eventsdetection);
		}

        public eventsdetection eventsdetectionGetById(int eventsDetectionId)
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
            return oeventsdetectionImpl.eventsdetectionGetById(eventsDetectionId);
		}

		public List<eventsdetection> eventsdetectionGetAll()
		{
			eventsdetectionImpl oeventsdetectionImpl = new eventsdetectionImpl();
			return oeventsdetectionImpl.eventsdetectionGetAll();
		}

		#endregion
	}
}
