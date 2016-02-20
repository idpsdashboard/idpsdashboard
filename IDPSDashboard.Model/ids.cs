
using System;

namespace IDPSDashboard.Model
{
	public class ids
	{
		#region Private Properties

		private int _IdsId;
        private string _IdsName;
		private int _DatabaseTypeId;
		private int _IdsTypeId;
		private sbyte _Active;
		private string _IdsIP;
        private string _DatabaseUser;
        private string _DatabasePass;
        private string _DatabaseName;
        private string _DatabaseHost;
        private string _IdsVersion;

		#endregion
		
		#region Constructors
		
		public ids()
		{

		}

		public ids(int IdsId, string IdsName, int DatabaseTypeId, int IdsTypeId, sbyte Active, string IdsIP, string DatabaseUser, string DatabasePass, string DatabaseName, string DatabaseHost, string IdsVersion)
		{
			_IdsId = IdsId;
            _IdsName = IdsName;
			_DatabaseTypeId = DatabaseTypeId;
			_IdsTypeId = IdsTypeId;
			_Active = Active;
			_IdsIP = IdsIP;
            _DatabaseUser = DatabaseUser;
            _DatabasePass = DatabasePass;
            _DatabaseName = DatabaseName;
            _DatabaseHost = DatabaseHost;
            _IdsVersion    = IdsVersion;
		}

		#endregion

		#region Properties
		
		public int IdsId
		{
			get	{ return _IdsId; }
			set	{ _IdsId = value; }
		}

        public string idsName
        {
            get { return _IdsName; }
            set { _IdsName = value; }
        }

        public int DatabaseTypeId
		{
			get	{ return _DatabaseTypeId; }
			set	{ _DatabaseTypeId = value; }
		}
		
		public int IdsTypeId
		{
			get	{ return _IdsTypeId; }
			set	{ _IdsTypeId = value; }
		}
		
		public sbyte Active
		{
			get	{ return _Active; }
			set	{ _Active = value; }
		}
		
		public string IdsIP
		{
			get	{ return _IdsIP; }
			set	{ _IdsIP = value; }
		}

        public string DatabaseUser
        {
            get { return _DatabaseUser; }
            set { _DatabaseUser = value; }
        }

        public string DatabasePass
        {
            get { return _DatabasePass; }
            set { _DatabasePass = value; }
        }

        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }

        public string DatabaseHost
        {
            get { return _DatabaseHost; }
            set { _DatabaseHost = value; }
        }

        public string IdsVersion
        {
            get { return _IdsVersion; }
            set { _IdsVersion = value; }
        }


		#endregion
	}
}
