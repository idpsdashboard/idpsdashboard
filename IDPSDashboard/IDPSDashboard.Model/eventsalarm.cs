
using System;

namespace IDPSDashboard.Model
{
	public class eventsalarm
	{
		#region Private Properties

		private int _EventsAlarmId;
		private int _EventsTypeId;
		private sbyte _Active;
		private int _CheckFrecuency;
		private int _Severity;

		#endregion
		
		#region Constructors
		
		public eventsalarm()
		{

		}

		public eventsalarm(int EventsAlarmId, int EventsTypeId, sbyte Active, int CheckFrecuency, int Severity)
		{
			_EventsAlarmId = EventsAlarmId;
			_EventsTypeId = EventsTypeId;
			_Active = Active;
			_CheckFrecuency = CheckFrecuency;
			_Severity = Severity;
		}

		#endregion

		#region Properties
		
		public int EventsAlarmId
		{
			get	{ return _EventsAlarmId; }
			set	{ _EventsAlarmId = value; }
		}
		
		public int EventsTypeId
		{
			get	{ return _EventsTypeId; }
			set	{ _EventsTypeId = value; }
		}
		
		public sbyte Active
		{
			get	{ return _Active; }
			set	{ _Active = value; }
		}
		
		public int CheckFrecuency
		{
			get	{ return _CheckFrecuency; }
			set	{ _CheckFrecuency = value; }
		}
		
		public int Severity
		{
			get	{ return _Severity; }
			set	{ _Severity = value; }
		}
		
		#endregion
	}
}
