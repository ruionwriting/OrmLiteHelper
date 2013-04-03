using System;
using System.Collections.Generic;

namespace OrmLiteHelper
{
	public sealed class GenericResult<T> : ResultBase //where T : new()
	{
		//public CommandResult CommandResult { get; set; }
		
		internal List<T> ResultItems { get; set; }
		
		public int Count 
		{
			get
			{
				return ResultItems.Count;
			}
		}

		// Indexer to allow direct access to result items.
		public T this[int index]
		{
			get
			{
				if (this.ResultItems != null && this.ResultItems.Count >= index)
					return ResultItems[index];
				else
					throw new IndexOutOfRangeException();
			}
		}

		public GenericResult()
		{
			//this.CommandResult = new CommandResult();
			this.ResultItems = new List<T>();
		}
	}
}