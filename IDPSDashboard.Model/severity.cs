
using System;

namespace IDPSDashboard.Model
{
	public class severity
	{
		#region Private Properties

		private int _SeverityId;
		private string _SeverityDescription;
		private int _SLATimeToResponse;

		#endregion
		
		#region Constructors
		
		public severity()
		{

		}

		public severity(int SeverityId, string SeverityDescription, int SLATimeToResponse)
		{
			_SeverityId = SeverityId;
			_SeverityDescription = SeverityDescription;
			_SLATimeToResponse = SLATimeToResponse;
		}

		#endregion

		#region Properties
		
		public int SeverityId
		{
			get	{ return _SeverityId; }
			set	{ _SeverityId = value; }
		}
		
		public string SeverityDescription
		{
			get	{ return _SeverityDescription; }
			set	{ _SeverityDescription = value; }
		}
		
		public int SLATimeToResponse
		{
			get	{ return _SLATimeToResponse; }
			set	{ _SLATimeToResponse = value; }
		}
		
		#endregion
	}
}
