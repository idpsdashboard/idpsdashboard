
using System;
using System.Data;
using System.Web;
using IDPSDahboard.SqlServerImpl;
using IDPSDahboard.Model;
using System.Collections.Generic;

namespace IDPSDahboard.Business
{
	public class smtpserversBus
	{
		#region Business

		public int smtpserversAdd(smtpservers smtpservers)
		{
			smtpserversImpl osmtpserversImpl = new smtpserversImpl();
			return osmtpserversImpl.smtpserversAdd( smtpservers);
		}

		public bool smtpserversUpdate(smtpservers smtpservers)
		{
			smtpserversImpl osmtpserversImpl = new smtpserversImpl();
			return osmtpserversImpl.smtpserversUpdate( smtpservers);
		}

		public bool smtpserversDelete(int SmtpServerId)
		{
			smtpserversImpl osmtpserversImpl = new smtpserversImpl();
			return osmtpserversImpl.smtpserversDelete( SmtpServerId);
		}

		public smtpservers smtpserversGetById(int SmtpServerId)
		{
			smtpserversImpl osmtpserversImpl = new smtpserversImpl();
			return osmtpserversImpl.smtpserversGetById(SmtpServerId);
		}

		public List<smtpservers> smtpserversGetAll()
		{
			smtpserversImpl osmtpserversImpl = new smtpserversImpl();
			return osmtpserversImpl.smtpserversGetAll();
		}

		#endregion
	}
}
