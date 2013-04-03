using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrmLiteHelper
{
	public class ResultBase
	{
		public bool Error { get; internal set; }

		public List<string> Messages { get; internal set; }

		public ResultBase()
		{
			this.Error = true;
			this.Messages = new List<string>();
		}

		

		#region Helper methods

		/// <summary>
		/// Get a string with all messages for current result instance
		/// </summary>
		/// <returns></returns>
		public string GetMessagesAsString()
		{
			return string.Join(";", this.Messages.ToArray());
		}

		#endregion
	}
}
