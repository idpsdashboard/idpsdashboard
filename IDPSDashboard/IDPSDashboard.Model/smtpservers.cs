
using System;

namespace IDPSDashboard.Model
{
	public class smtpservers
	{
		#region Private Properties

		private int _SmtpServerId;
		private string _SmtpServerHostname;
		private string _SmtpServerPort;
		private string _SmtpServerAccount;
		private string _SmtpServerPassword;
		private sbyte _StmpServerEnabled;

		#endregion
		
		#region Constructors
		
		public smtpservers()
		{

		}

		public smtpservers(int SmtpServerId, string SmtpServerHostname, string SmtpServerPort, string SmtpServerAccount, string SmtpServerPassword, sbyte StmpServerEnabled)
		{
			_SmtpServerId = SmtpServerId;
			_SmtpServerHostname = SmtpServerHostname;
			_SmtpServerPort = SmtpServerPort;
			_SmtpServerAccount = SmtpServerAccount;
			_SmtpServerPassword = SmtpServerPassword;
			_StmpServerEnabled = StmpServerEnabled;
		}

		#endregion

		#region Properties
		
		public int SmtpServerId
		{
			get	{ return _SmtpServerId; }
			set	{ _SmtpServerId = value; }
		}
		
		public string SmtpServerHostname
		{
			get	{ return _SmtpServerHostname; }
			set	{ _SmtpServerHostname = value; }
		}
		
		public string SmtpServerPort
		{
			get	{ return _SmtpServerPort; }
			set	{ _SmtpServerPort = value; }
		}
		
		public string SmtpServerAccount
		{
			get	{ return _SmtpServerAccount; }
			set	{ _SmtpServerAccount = value; }
		}
		
		public string SmtpServerPassword
		{
			get	{ return _SmtpServerPassword; }
			set	{ _SmtpServerPassword = value; }
		}
		
		public sbyte StmpServerEnabled
		{
			get	{ return _StmpServerEnabled; }
			set	{ _StmpServerEnabled = value; }
		}
		
		#endregion
	}
}
