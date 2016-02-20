
using System;

namespace IDPSDashboard.Model
{
	public class taskdetails
	{
		#region Private Properties

		private int _TaskDetailsId;
		private int _TaskId;
		private string _Details;
		private DateTime _DateTime;
		private decimal _EffortHours;
        private int _UserId;

		#endregion
		
		#region Constructors
		
		public taskdetails()
		{

		}

		public taskdetails(int TaskDetailsId, int TaskId, string Details, DateTime DateTime, decimal EffortHours, int UserId)
		{
			_TaskDetailsId = TaskDetailsId;
			_TaskId = TaskId;
			_Details = Details;
			_DateTime = DateTime;
			_EffortHours = EffortHours;
            _UserId = UserId;
		}

		#endregion

		#region Properties
		
		public int TaskDetailsId
		{
			get	{ return _TaskDetailsId; }
			set	{ _TaskDetailsId = value; }
		}
		
		public int TaskId
		{
			get	{ return _TaskId; }
			set	{ _TaskId = value; }
		}
		
		public string Details
		{
			get	{ return _Details; }
			set	{ _Details = value; }
		}
		
		public DateTime DateTime
		{
			get	{ return _DateTime; }
			set	{ _DateTime = value; }
		}
		
		public decimal EffortHours
		{
			get	{ return _EffortHours; }
			set	{ _EffortHours = value; }
		}

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        
        #endregion
	}
}
