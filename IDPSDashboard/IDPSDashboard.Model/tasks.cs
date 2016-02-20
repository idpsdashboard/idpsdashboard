
using System;

namespace IDPSDashboard.Model
{
	public class tasks
	{
		#region Private Properties

		private int _TaskId;
		private string _UserGroupId;
		private int _TaskStatudId;
		private int _UserId;
		private string _TaskTittle;
		private DateTime _DateTime;

		#endregion
		
		#region Constructors
		
		public tasks()
		{

		}

		public tasks(int TaskId, string UserGroupId, int TaskStatudId, int UserId, string TaskTittle, DateTime DateTime)
		{
			_TaskId = TaskId;
			_UserGroupId = UserGroupId;
			_TaskStatudId = TaskStatudId;
			_UserId = UserId;
			_TaskTittle = TaskTittle;
			_DateTime = DateTime;
		}

		#endregion

		#region Properties
		
		public int TaskId
		{
			get	{ return _TaskId; }
			set	{ _TaskId = value; }
		}
		
		public string UserGroupId
		{
			get	{ return _UserGroupId; }
			set	{ _UserGroupId = value; }
		}
		
		public int TaskStatudId
		{
			get	{ return _TaskStatudId; }
			set	{ _TaskStatudId = value; }
		}
		
		public int UserId
		{
			get	{ return _UserId; }
			set	{ _UserId = value; }
		}
		
		public string TaskTittle
		{
			get	{ return _TaskTittle; }
			set	{ _TaskTittle = value; }
		}
		
		public DateTime DateTime
		{
			get	{ return _DateTime; }
			set	{ _DateTime = value; }
		}
		
		#endregion
	}
}
