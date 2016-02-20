
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class usergroupBus
	{
		#region Business

		public int usergroupAdd(usergroup usergroup)
		{
			usergroupImpl ousergroupImpl = new usergroupImpl();
			return ousergroupImpl.usergroupAdd( usergroup);
		}

		public bool usergroupUpdate(usergroup usergroup)
		{
			usergroupImpl ousergroupImpl = new usergroupImpl();
			return ousergroupImpl.usergroupUpdate( usergroup);
		}

		public bool usergroupDelete(int UserGroupId)
		{
			usergroupImpl ousergroupImpl = new usergroupImpl();
			return ousergroupImpl.usergroupDelete( UserGroupId);
		}

		public usergroup usergroupGetById(int UserGroupId)
		{
			usergroupImpl ousergroupImpl = new usergroupImpl();
			return ousergroupImpl.usergroupGetById(UserGroupId);
		}

		public List<usergroup> usergroupGetAll()
		{
			usergroupImpl ousergroupImpl = new usergroupImpl();
			return ousergroupImpl.usergroupGetAll();
		}

		#endregion
	}
}
