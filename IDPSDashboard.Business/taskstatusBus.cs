
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class taskstatusBus
	{
		#region Business

		public int taskstatusAdd(taskstatus taskstatus)
		{
			taskstatusImpl otaskstatusImpl = new taskstatusImpl();
			return otaskstatusImpl.taskstatusAdd( taskstatus);
		}

		public bool taskstatusUpdate(taskstatus taskstatus)
		{
			taskstatusImpl otaskstatusImpl = new taskstatusImpl();
			return otaskstatusImpl.taskstatusUpdate( taskstatus);
		}

		public bool taskstatusDelete(int TaskStatudId)
		{
			taskstatusImpl otaskstatusImpl = new taskstatusImpl();
			return otaskstatusImpl.taskstatusDelete( TaskStatudId);
		}

		public taskstatus taskstatusGetById(int TaskStatudId)
		{
			taskstatusImpl otaskstatusImpl = new taskstatusImpl();
			return otaskstatusImpl.taskstatusGetById(TaskStatudId);
		}

		public List<taskstatus> taskstatusGetAll()
		{
			taskstatusImpl otaskstatusImpl = new taskstatusImpl();
			return otaskstatusImpl.taskstatusGetAll();
		}

		#endregion
	}
}
