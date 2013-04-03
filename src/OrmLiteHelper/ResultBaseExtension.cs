using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLiteHelper
{
	public static class ResultBaseExtension
	{
		public static void CollectErrorMessages(this ResultBase result, IDbConnection db, Exception ex)
		{
			result.Messages.Add(ex.ToString());

			if (db != null)
				result.Messages.Add(string.Format("Connection state: {0}", db.State));
		}
	}
}
