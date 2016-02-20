
using System;
using System.Data;
using System.Web;
using dal.SqlServerLibrary;
using IDPSDashboard.Implement;
using IDPSDashboard.Model;
using System.Collections.Generic;

namespace IDPSDashboard.Business
{
	public class intrusioneventsBus
	{
		#region Business

		public int intrusioneventsAdd(intrusionevents intrusionevents)
		{
            intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
            return ointrusioneventsImpl.intrusioneventsAdd(intrusionevents);
		}

		public bool intrusioneventsUpdate(intrusionevents intrusionevents)
		{
			intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
			return ointrusioneventsImpl.intrusioneventsUpdate(intrusionevents);
		}

		public bool intrusioneventsDelete(int IntrusionEventsId)
		{
			intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
			return ointrusioneventsImpl.intrusioneventsDelete(IntrusionEventsId);
		}

		public intrusionevents intrusioneventsGetById(int IntrusionEventsId)
		{
			intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
			return ointrusioneventsImpl.intrusioneventsGetById(IntrusionEventsId);
		}

        public List<intrusionevents> intrusioneventsGetByEventDetail(string eventDetail)
        {
            intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
            return ointrusioneventsImpl.intrusioneventsGetByEventDetail(eventDetail);
        }

        public List<intrusionevents> intrusioneventsGetAll()
		{
			intrusioneventsImpl ointrusioneventsImpl = new intrusioneventsImpl();
			return ointrusioneventsImpl.intrusioneventsGetAll();
		}

		#endregion
	}
}
