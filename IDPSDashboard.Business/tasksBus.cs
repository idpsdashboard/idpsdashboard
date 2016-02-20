
using System;
using System.Data;
using System.Web;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class tasksBus
	{
		#region Business

		public int tasksAdd(tasks tasks)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksAdd(tasks);
		}

		public bool tasksUpdate(tasks tasks)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksUpdate( tasks);
		}

        public bool tasksUpdateStatus(int TaskId, int TaskStatudId)
        {
            tasksImpl otasksImpl = new tasksImpl();
            return otasksImpl.tasksUpdateStatus(TaskId, TaskStatudId);
        }

        public bool tasksUpdateUser(int TaskId, int UserId)
        {
            tasksImpl otasksImpl = new tasksImpl();
            return otasksImpl.tasksUpdateUser(TaskId, UserId);
        }

        public bool tasksDelete(int TaskId)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksDelete( TaskId);
		}

		public tasks tasksGetById(int TaskId)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksGetById(TaskId);
		}


        public tasks tasksGetByEventsDetectionId(int EventsDetectionId)
		{
			tasksImpl otasksImpl = new tasksImpl();
            return otasksImpl.tasksGetById(EventsDetectionId);
		}

		public List<tasks> tasksGetAll()
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksGetAll();
		}

		#endregion
	}
}
