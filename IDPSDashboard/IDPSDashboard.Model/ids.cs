
using System;

namespace IDPSDashboard.Model
{
	public class ids
	{
		#region Private Properties

		private int _IdsId;
		private int _DatabaseTypeId;
		private int _IdsTypeId;
		private sbyte _Active;
		private string _IdsIP;

		#endregion
		
		#region Constructors
		
		public ids()
		{

		}

		public ids(int IdsId, int DatabaseTypeId, int IdsTypeId, sbyte Active, string IdsIP)
		{
			_IdsId = IdsId;
			_DatabaseTypeId = DatabaseTypeId;
			_IdsTypeId = IdsTypeId;
			_Active = Active;
			_IdsIP = IdsIP;
		}

		#endregion

		#region Properties
		
		public int IdsId
		{
			get	{ return _IdsId; }
			set	{ _IdsId = value; }
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
		
		#endregion
	}
}
