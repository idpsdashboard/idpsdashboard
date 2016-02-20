
using System;

namespace IDPSDashboard.Model
{
	public class idstype
	{
		#region Private Properties

		private int _IdsTypeId;
		private string _IdsTypeName;
		private string _IdsTypeVersion;

		#endregion
		
		#region Constructors
		
		public idstype()
		{

		}

		public idstype(int IdsTypeId, string IdsTypeName, string IdsTypeVersion)
		{
			_IdsTypeId = IdsTypeId;
			_IdsTypeName = IdsTypeName;
			_IdsTypeVersion = IdsTypeVersion;
		}

		#endregion

		#region Properties
		
		public int IdsTypeId
		{
			get	{ return _IdsTypeId; }
			set	{ _IdsTypeId = value; }
		}
		
		public string IdsTypeName
		{
			get	{ return _IdsTypeName; }
			set	{ _IdsTypeName = value; }
		}
		
		public string IdsTypeVersion
		{
			get	{ return _IdsTypeVersion; }
			set	{ _IdsTypeVersion = value; }
		}
		
		#endregion
	}
}
