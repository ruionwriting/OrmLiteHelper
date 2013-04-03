using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ServiceStack.OrmLite;
using OrmLiteHelper.MySql.Tests.Models;

namespace OrmLiteHelper.MySql.Tests
{
	public class InsertTests : TestBase
	{
		[Fact]
		public void Can_insert_into_Users_table()
		{
			long lastInsertId = 0;

			using (var db = ConnectionString.OpenDbConnection())
			{
				db.CreateTable<User>(true);

				db.Insert(User.Create());

				lastInsertId = db.GetLastInsertId();
			}

			Assert.Equal(1, lastInsertId);
		}

		[Fact]
		public void Can_insert_into_Users_table_using_OrmLiteHelper()
		{
			var user = User.Create();
			var insertResult = Insert<User>(user);

			Assert.NotNull(insertResult);
			Assert.False(insertResult.Error);
			Assert.True(insertResult.LastInsertId > 0);
		}

		[Fact]
		public void Can_insert_and_select_from_Users_table()
		{
			using (var db = ConnectionString.OpenDbConnection())
			{
				db.CreateTable<User>(true);

				var user = User.Create();

				db.Insert(user);

				var users = db.Select<User>();

				Assert.True(users.Count == 1);
			}
		}

		[Fact]
		public void Can_insert_and_select_from_Users_table_using_OrmLiteHelper()
		{
			var user = User.Create();
			Insert<User>(user);

			var users = Select<User>();

			Assert.True(users.Count > 0);
			Assert.Equal(user.Id, users[users.Count - 1].Id);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_insert_table_with_null_fields()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_retrieve_LastInsertId_from_inserted_table()
		{
			Assert.True(false);
		}
	}
}