
using System;

namespace IDPSDashboard.Model
{
	public class eventsalarm
	{
		#region Private Properties

        private int _EventsAlarmId;
        private int _IdsId;
		private int _IdsSignatureCategoryId;
		private sbyte _Active;
		private int _CheckFrecuency;
		private int _Severity;
        private sbyte _AffectConfidence;
        private sbyte _AffectIntegrity;
        private sbyte _AffectAvailability;
        private string _EventsAlarmTittle;

		#endregion
		
		#region Constructors
		
		public eventsalarm()
		{

		}

        public eventsalarm(int EventsAlarmId, int IdsId, int IdsSignatureCategoryId, sbyte Active, int CheckFrecuency, int Severity, sbyte AffectConfidence, sbyte AffectIntegrity, sbyte AffectAvailability, string EventsAlarmTittle)
		{
            _EventsAlarmId = EventsAlarmId;
            _IdsId = IdsId;
            _IdsSignatureCategoryId = IdsSignatureCategoryId;
			_Active = Active;
			_CheckFrecuency = CheckFrecuency;
			_Severity = Severity;
            _AffectConfidence = AffectConfidence;
            _AffectIntegrity = AffectIntegrity;
            _AffectAvailability = AffectAvailability;
            _EventsAlarmTittle = EventsAlarmTittle;
		}

		#endregion

		#region Properties

        public int EventsAlarmId
        {
            get { return _EventsAlarmId; }
            set { _EventsAlarmId = value; }
        }

        public int IdsId
        {
            get { return _IdsId; }
            set { _IdsId = value; }
        }

        public int IdsSignatureCategoryId
		{
            get { return _IdsSignatureCategoryId; }
            set { _IdsSignatureCategoryId = value; }
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

        public sbyte AffectConfidence
        {
            get { return _AffectConfidence; }
            set { _AffectConfidence = value; }
        }

        public sbyte AffectIntegrity
        {
            get { return _AffectIntegrity; }
            set { _AffectIntegrity = value; }
        }

        public sbyte AffectAvailability
        {
            get { return _AffectAvailability; }
            set { _AffectAvailability = value; }
        }

        public string EventsAlarmTittle
        {
            get { return _EventsAlarmTittle; }
            set { _EventsAlarmTittle = value; }
        }

		#endregion
	}
}
