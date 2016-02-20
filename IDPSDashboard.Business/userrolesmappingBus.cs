
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class userrolesmappingBus
	{
		#region Business

		public int userrolesmappingAdd(userrolesmapping userrolesmapping)
		{
			userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
			return ouserrolesmappingImpl.userrolesmappingAdd( userrolesmapping);
		}

		public bool userrolesmappingUpdate(userrolesmapping userrolesmapping)
		{
			userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
			return ouserrolesmappingImpl.userrolesmappingUpdate( userrolesmapping);
		}

		public bool userrolesmappingDelete(int UserRoleId, int UserGroupId)
		{
			userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
			return ouserrolesmappingImpl.userrolesmappingDelete( UserRoleId, UserGroupId);
		}

		public userrolesmapping userrolesmappingGetById(int UserRoleId, int UserGroupId)
		{
			userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
			return ouserrolesmappingImpl.userrolesmappingGetById(UserRoleId, UserGroupId);
		}

        public List<userrolesmapping> userrolesmappingGetByUserGroupId(int UserGroupId)
        {
            userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
            return ouserrolesmappingImpl.userrolesmappingGetByUserGroupId(UserGroupId);
        }


		public List<userrolesmapping> userrolesmappingGetAll()
		{
			userrolesmappingImpl ouserrolesmappingImpl = new userrolesmappingImpl();
			return ouserrolesmappingImpl.userrolesmappingGetAll();
		}

		#endregion
	}
}
