
using System;

namespace IDPSDashboard.Model
{
	public class eventsalarm_intrusionevents_mapping
	{
		#region Private Properties

		private int _EventsAlarmId;
		private int _IntrusionEventId;

		#endregion
		
		#region Constructors
		
		public eventsalarm_intrusionevents_mapping()
		{

		}

		public eventsalarm_intrusionevents_mapping(int EventsAlarmId, int IntrusionEventId)
		{
			_EventsAlarmId = EventsAlarmId;
			_IntrusionEventId = IntrusionEventId;
		}

		#endregion

		#region Properties
		
		public int EventsAlarmId
		{
			get	{ return _EventsAlarmId; }
			set	{ _EventsAlarmId = value; }
		}
		
		public int IntrusionEventId
		{
			get	{ return _IntrusionEventId; }
			set	{ _IntrusionEventId = value; }
		}
		
		#endregion
	}
}
