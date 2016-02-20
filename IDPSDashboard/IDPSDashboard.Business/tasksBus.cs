
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class tasksBus
	{
		#region Business

		public int tasksAdd(tasks tasks)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksAdd( tasks);
		}

		public bool tasksUpdate(tasks tasks)
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksUpdate( tasks);
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

		public List<tasks> tasksGetAll()
		{
			tasksImpl otasksImpl = new tasksImpl();
			return otasksImpl.tasksGetAll();
		}

		#endregion
	}
}
