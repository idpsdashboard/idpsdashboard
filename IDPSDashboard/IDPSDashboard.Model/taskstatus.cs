
using System;

namespace IDPSDashboard.Model
{
	public class taskstatus
	{
		#region Private Properties

		private int _TaskStatudId;
		private string _TastkStatusDescription;

		#endregion
		
		#region Constructors
		
		public taskstatus()
		{

		}

		public taskstatus(int TaskStatudId, string TastkStatusDescription)
		{
			_TaskStatudId = TaskStatudId;
			_TastkStatusDescription = TastkStatusDescription;
		}

		#endregion

		#region Properties
		
		public int TaskStatudId
		{
			get	{ return _TaskStatudId; }
			set	{ _TaskStatudId = value; }
		}
		
		public string TastkStatusDescription
		{
			get	{ return _TastkStatusDescription; }
			set	{ _TastkStatusDescription = value; }
		}
		
		#endregion
	}
}
