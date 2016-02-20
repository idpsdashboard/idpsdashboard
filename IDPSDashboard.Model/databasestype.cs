
using System;

namespace IDPSDashboard.Model
{
	public class databasestype
	{
		#region Private Properties

		private int _DatabaseTypeId;
		private string _DatabaseName;

		#endregion
		
		#region Constructors
		
		public databasestype()
		{

		}

		public databasestype(int DatabaseTypeId, string DatabaseName)
		{
			_DatabaseTypeId = DatabaseTypeId;
			_DatabaseName = DatabaseName;
		}

		#endregion

		#region Properties
		
		public int DatabaseTypeId
		{
			get	{ return _DatabaseTypeId; }
			set	{ _DatabaseTypeId = value; }
		}
		
		public string DatabaseName
		{
			get	{ return _DatabaseName; }
			set	{ _DatabaseName = value; }
		}
		
		#endregion
	}
}
