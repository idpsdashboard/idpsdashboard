
using System;

namespace IDPSDashboard.Model
{
	public class users
	{
		#region Private Properties

		private int _UserId;
		private int _UserGroupId;
		private string _UserName;
		private string _UserFirstName;
		private string _UserLastName;
		private string _UserMail;
		private string _UserSMSNumber;
		private string _UserPassword;
		private sbyte _UserActive;

		#endregion
		
		#region Constructors
		
		public users()
		{

		}

		public users(int UserId, int UserGroupId, string UserName, string UserFirstName, string UserLastName, string UserMail, string UserSMSNumber, string UserPassword, sbyte UserActive)
		{
			_UserId = UserId;
			_UserGroupId = UserGroupId;
			_UserName = UserName;
			_UserFirstName = UserFirstName;
			_UserLastName = UserLastName;
			_UserMail = UserMail;
			_UserSMSNumber = UserSMSNumber;
			_UserPassword = UserPassword;
			_UserActive = UserActive;
		}

		#endregion

		#region Properties
		
		public int UserId
		{
			get	{ return _UserId; }
			set	{ _UserId = value; }
		}
		
		public int UserGroupId
		{
			get	{ return _UserGroupId; }
			set	{ _UserGroupId = value; }
		}
		
		public string UserName
		{
			get	{ return _UserName; }
			set	{ _UserName = value; }
		}
		
		public string UserFirstName
		{
			get	{ return _UserFirstName; }
			set	{ _UserFirstName = value; }
		}
		
		public string UserLastName
		{
			get	{ return _UserLastName; }
			set	{ _UserLastName = value; }
		}
		
		public string UserMail
		{
			get	{ return _UserMail; }
			set	{ _UserMail = value; }
		}
		
		public string UserSMSNumber
		{
			get	{ return _UserSMSNumber; }
			set	{ _UserSMSNumber = value; }
		}
		
		public string UserPassword
		{
			get	{ return _UserPassword; }
			set	{ _UserPassword = value; }
		}
		
		public sbyte UserActive
		{
			get	{ return _UserActive; }
			set	{ _UserActive = value; }
		}
		
		#endregion
	}
}
