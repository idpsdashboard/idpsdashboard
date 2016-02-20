
using System;

namespace IDPSDashboard.Model
{
	public class usergroup
	{
		#region Private Properties

		private int _UserGroupId;
		private string _UserGroupDescription;

		#endregion
		
		#region Constructors
		
		public usergroup()
		{

		}

		public usergroup(int UserGroupId, string UserGroupDescription)
		{
			_UserGroupId = UserGroupId;
			_UserGroupDescription = UserGroupDescription;
		}

		#endregion

		#region Properties
		
		public int UserGroupId
		{
			get	{ return _UserGroupId; }
			set	{ _UserGroupId = value; }
		}
		
		public string UserGroupDescription
		{
			get	{ return _UserGroupDescription; }
			set	{ _UserGroupDescription = value; }
		}
		
		#endregion
	}
}
