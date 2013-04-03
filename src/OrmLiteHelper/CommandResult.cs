using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrmLiteHelper
{
	public sealed class CommandResult : ResultBase
	{
		#region IResult members

		//public bool Error { get; set; }

		//public List<string> Messages { get; set; }

		#endregion

		#region Public/private members

		/// <summary>
		/// Affected rows by insert/update/delete commands.
		/// </summary>
		public int AffectedRows { get; set; }

		/// <summary>
		/// Last insert id resulting from  sucessfull insert/save action.
		/// </summary>
		public long LastInsertId { get; set; }

		/// <summary>
		/// Page data control navigation/information.
		/// </summary>
		public Page Paging { get; set; }

		#endregion

		#region Ctor's

		public CommandResult()
		{
			//this.Error = true;
			//this.Messages = new List<string>();
		}

		#endregion

		
	}
}