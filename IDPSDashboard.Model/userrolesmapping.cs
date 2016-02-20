
using System;

namespace IDPSDashboard.Model
{
	public class userrolesmapping
	{
		#region Private Properties

		private int _UserRoleId;
		private int _UserGroupId;

		#endregion
		
		#region Constructors
		
		public userrolesmapping()
		{

		}

		public userrolesmapping(int UserRoleId, int UserGroupId)
		{
			_UserRoleId = UserRoleId;
			_UserGroupId = UserGroupId;
		}

		#endregion

		#region Properties
		
		public int UserRoleId
		{
			get	{ return _UserRoleId; }
			set	{ _UserRoleId = value; }
		}
		
		public int UserGroupId
		{
			get	{ return _UserGroupId; }
			set	{ _UserGroupId = value; }
		}
		
		#endregion
	}
}
