
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class taskdetailsBus
	{
		#region Business

		public int taskdetailsAdd(taskdetails taskdetails)
		{
			taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
			return otaskdetailsImpl.taskdetailsAdd( taskdetails);
		}

		public bool taskdetailsUpdate(taskdetails taskdetails)
		{
			taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
			return otaskdetailsImpl.taskdetailsUpdate( taskdetails);
		}

		public bool taskdetailsDelete(int TaskDetailsId)
		{
			taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
			return otaskdetailsImpl.taskdetailsDelete( TaskDetailsId);
		}

		public taskdetails taskdetailsGetById(int TaskDetailsId)
		{
			taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
			return otaskdetailsImpl.taskdetailsGetById(TaskDetailsId);
		}

        public List<taskdetails> taskdetailsGetByTaskId(int TaskId)
        {
            taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
            return otaskdetailsImpl.taskdetailsGetByTaskId(TaskId);
        }

		public List<taskdetails> taskdetailsGetAll()
		{
			taskdetailsImpl otaskdetailsImpl = new taskdetailsImpl();
			return otaskdetailsImpl.taskdetailsGetAll();
		}

		#endregion
	}
}
