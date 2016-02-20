
using System;

namespace IDPSDashboard.Model
{
	public class idstype
	{
		#region Private Properties

		private int _IdsTypeId;
		private string _IdsTypeName;

		#endregion
		
		#region Constructors
		
		public idstype()
		{

		}

		public idstype(int IdsTypeId, string IdsTypeName)
		{
			_IdsTypeId = IdsTypeId;
			_IdsTypeName = IdsTypeName;
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
		
		#endregion
	}
}
