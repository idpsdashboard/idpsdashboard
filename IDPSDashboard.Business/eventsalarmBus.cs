
using System;
using System.Data;
using System.Web;
using dal.SqlServerLibrary;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class eventsalarmBus
	{
		#region Business

		public int eventsalarmAdd(eventsalarm eventsalarm)
		{
            eventsalarmImpl oeventsalarmImpl = new eventsalarmImpl();
			return oeventsalarmImpl.eventsalarmAdd( eventsalarm);
		}

		public bool eventsalarmUpdate(eventsalarm eventsalarm)
		{
			eventsalarmImpl oeventsalarmImpl = new eventsalarmImpl();
			return oeventsalarmImpl.eventsalarmUpdate( eventsalarm);
		}

		public bool eventsalarmDelete(int EventsAlarmId)
		{
			eventsalarmImpl oeventsalarmImpl = new eventsalarmImpl();
			return oeventsalarmImpl.eventsalarmDelete( EventsAlarmId);
		}

		public eventsalarm eventsalarmGetById(int EventsAlarmId)
		{
			eventsalarmImpl oeventsalarmImpl = new eventsalarmImpl();
			return oeventsalarmImpl.eventsalarmGetById(EventsAlarmId);
		}

		public List<eventsalarm> eventsalarmGetAll()
		{
			eventsalarmImpl oeventsalarmImpl = new eventsalarmImpl();
			return oeventsalarmImpl.eventsalarmGetAll();
		}

		#endregion
	}
}
