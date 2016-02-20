
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class usersBus
	{
		#region Business

		public int usersAdd(users users)
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersAdd( users);
		}

		public bool usersUpdate(users users)
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersUpdate( users);
		}

		public bool usersDelete(int UserId, int UserGroupId)
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersDelete( UserId, UserGroupId);
		}

		public users usersGetById(int UserId, int UserGroupId)
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersGetById(UserId, UserGroupId);
		}

		public List<users> usersGetAll()
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersGetAll();
		}

		#endregion
	}
}
