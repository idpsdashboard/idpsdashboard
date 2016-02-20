
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class eventsalarm_intrusionevents_mappingBus
	{
		#region Business

		public int eventsalarm_intrusionevents_mappingAdd(eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mapping)
		{
			eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
			return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingAdd(eventsalarm_intrusionevents_mapping);
		}

		public bool eventsalarm_intrusionevents_mappingUpdate(eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mapping)
		{
			eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
			return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingUpdate(eventsalarm_intrusionevents_mapping);
		}

        //public bool eventsalarm_intrusionevents_mappingDelete(int EventsAlarmId, string IntrusionEventId)
        //{
        //    eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
        //    return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingDelete(IntrusionEventId);
        //}

		public eventsalarm_intrusionevents_mapping eventsalarm_intrusionevents_mappingGetById(int EventsAlarmId, int IntrusionEventId)
		{
			eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
            return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingGetById(EventsAlarmId, IntrusionEventId);
		}

        public List<eventsalarm_intrusionevents_mapping> eventsalarm_intrusionevents_mappingGetByEventsAlarmId(int EventsAlarmId)
        {
            eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
            return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingGetByEventsAlarmId(EventsAlarmId);
        }

		public List<eventsalarm_intrusionevents_mapping> eventsalarm_intrusionevents_mappingGetAll()
		{
			eventsalarm_intrusionevents_mappingImpl oeventsalarm_intrusionevents_mappingImpl = new eventsalarm_intrusionevents_mappingImpl();
			return oeventsalarm_intrusionevents_mappingImpl.eventsalarm_intrusionevents_mappingGetAll();
		}

		#endregion
	}
}
