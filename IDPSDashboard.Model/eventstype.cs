
using System;

namespace IDPSDashboard.Model
{
	public class eventstype
	{
		#region Private Properties

		private int _EventsTypeId;
		private string _Description;

		#endregion
		
		#region Constructors
		
		public eventstype()
		{

		}

		public eventstype(int EventsTypeId, string Description)
		{
			_EventsTypeId = EventsTypeId;
			_Description = Description;
		}

		#endregion

		#region Properties
		
		public int EventsTypeId
		{
			get	{ return _EventsTypeId; }
			set	{ _EventsTypeId = value; }
		}
		
		public string Description
		{
			get	{ return _Description; }
			set	{ _Description = value; }
		}
		
		#endregion
	}
}
