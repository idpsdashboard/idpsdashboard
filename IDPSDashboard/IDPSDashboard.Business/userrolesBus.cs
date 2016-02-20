
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class userrolesBus
	{
		#region Business

		public int userrolesAdd(userroles userroles)
		{
			userrolesImpl ouserrolesImpl = new userrolesImpl();
			return ouserrolesImpl.userrolesAdd( userroles);
		}

		public bool userrolesUpdate(userroles userroles)
		{
			userrolesImpl ouserrolesImpl = new userrolesImpl();
			return ouserrolesImpl.userrolesUpdate( userroles);
		}

		public bool userrolesDelete(int UserRoleId)
		{
			userrolesImpl ouserrolesImpl = new userrolesImpl();
			return ouserrolesImpl.userrolesDelete( UserRoleId);
		}

		public userroles userrolesGetById(int UserRoleId)
		{
			userrolesImpl ouserrolesImpl = new userrolesImpl();
			return ouserrolesImpl.userrolesGetById(UserRoleId);
		}

		public List<userroles> userrolesGetAll()
		{
			userrolesImpl ouserrolesImpl = new userrolesImpl();
			return ouserrolesImpl.userrolesGetAll();
		}

		#endregion
	}
}
