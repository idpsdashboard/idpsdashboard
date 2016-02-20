
using System;

namespace IDPSDashboard.Model
{
	public class intrusionevents
	{
		#region Private Properties

		private int _IntrusionEventsId;
		private string _IntrusionEventDetail;
		private string _CVEId;
		private string _CWEId;
        private string _CAPECId;
        private string _OWASPId;

		#endregion
		
		#region Constructors
		
		public intrusionevents()
		{

		}

		public intrusionevents(int IntrusionEventsId, string IntrusionEventDetail, string CVEId, string CWEId, string CAPECId, string OWASPId)
		{
			_IntrusionEventsId = IntrusionEventsId;
			_IntrusionEventDetail = IntrusionEventDetail;
			_CVEId = CVEId;
			_CWEId = CWEId;
            _CAPECId = CAPECId;
            _OWASPId = OWASPId;
		}

		#endregion

		#region Properties
		
		public int IntrusionEventsId
		{
			get	{ return _IntrusionEventsId; }
			set	{ _IntrusionEventsId = value; }
		}
		
		public string IntrusionEventDetail
		{
			get	{ return _IntrusionEventDetail; }
			set	{ _IntrusionEventDetail = value; }
		}
		
		public string CVEId
		{
			get	{ return _CVEId; }
			set	{ _CVEId = value; }
		}
		
		public string CWEId
		{
			get	{ return _CWEId; }
			set	{ _CWEId = value; }
		}

        public string CAPECId
        {
            get { return _CWEId; }
            set { _CWEId = value; }
        }

        public string OWASPId
        {
            get { return _OWASPId; }
            set { _OWASPId = value; }
        }

		#endregion
	}
}
