
using System;

namespace IDPSDashboard.Model
{
	public class userroles
	{
		#region Private Properties

		private int _UserRoleId;
		private string _UserRoleDescription;

		#endregion
		
		#region Constructors
		
		public userroles()
		{

		}

		public userroles(int UserRoleId, string UserRoleDescription)
		{
			_UserRoleId = UserRoleId;
			_UserRoleDescription = UserRoleDescription;
		}

		#endregion

		#region Properties
		
		public int UserRoleId
		{
			get	{ return _UserRoleId; }
			set	{ _UserRoleId = value; }
		}
		
		public string UserRoleDescription
		{
			get	{ return _UserRoleDescription; }
			set	{ _UserRoleDescription = value; }
		}
		
		#endregion
	}
}
