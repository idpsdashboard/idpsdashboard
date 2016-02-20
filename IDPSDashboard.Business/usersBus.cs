
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
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

		public users usersGetById(int UserId)
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersGetById(UserId);
		}

        public users usersGetByUserName(string userName)
        {
            usersImpl ousersImpl = new usersImpl();
            return ousersImpl.usersGetByUserName(userName);
        }


		public List<users> usersGetAll()
		{
			usersImpl ousersImpl = new usersImpl();
			return ousersImpl.usersGetAll();
		}

		#endregion
	}
}
