
using System;

namespace IDPSDashboard.Model
{
	public class eventsdetection
	{
		#region Private Properties

        private int _EventsDetectionId;
        private int _IdsId;
		private DateTime _DateTime;
		private int _EventStatus;
		private int _EventsAlarmId;

		#endregion
		
		#region Constructors
		
		public eventsdetection()
		{

		}

        public eventsdetection(int EventsDetectionId, int IdsId, DateTime DateTime, int EventStatus, int EventsAlarmId)
		{
            _EventsDetectionId = EventsDetectionId;
            _IdsId = IdsId;
			_DateTime = DateTime;
			_EventStatus = EventStatus;
			_EventsAlarmId = EventsAlarmId;
		}

		#endregion

		#region Properties

        public int EventsDetectionId
        {
            get { return _EventsDetectionId; }
            set { _EventsDetectionId = value; }
        }
        
        public int IdsId
		{
			get	{ return _IdsId; }
			set	{ _IdsId = value; }
		}
		
		public DateTime DateTime
		{
			get	{ return _DateTime; }
			set	{ _DateTime = value; }
		}
		
		public int EventStatus
		{
			get	{ return _EventStatus; }
			set	{ _EventStatus = value; }
		}
		
		public int EventsAlarmId
		{
			get	{ return _EventsAlarmId; }
			set	{ _EventsAlarmId = value; }
		}
		
		#endregion
	}
}
