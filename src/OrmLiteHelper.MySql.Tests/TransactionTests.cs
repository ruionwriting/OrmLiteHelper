using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrmLiteHelper.MySql.Tests
{
	public class TransactionTests
	{
		[Fact(Skip = "TO-DO")]
		public void Transaction_commit_persists_data_to_the_db()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Transaction_rollsback_if_not_committed()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Transaction_rollsback_transactions_to_different_tables()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Transaction_commits_inserts_to_different_tables()
		{
			Assert.True(false);
		}
	}
}