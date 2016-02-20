
using System;

namespace IDPSDashboard.Model
{
	public class taskstatus
	{
		#region Private Properties

		private int _TaskStatusId;
		private string _TaskStatusDescription;

		#endregion
		
		#region Constructors
		
		public taskstatus()
		{

		}

		public taskstatus(int TaskStatusId, string TaskStatusDescription)
		{
			_TaskStatusId = TaskStatusId;
			_TaskStatusDescription = TaskStatusDescription;
		}

		#endregion

		#region Properties
		
		public int TaskStatusId
		{
			get	{ return _TaskStatusId; }
			set	{ _TaskStatusId = value; }
		}
		
		public string TaskStatusDescription
		{
			get	{ return _TaskStatusDescription; }
			set	{ _TaskStatusDescription = value; }
		}
		
		#endregion
	}
}
