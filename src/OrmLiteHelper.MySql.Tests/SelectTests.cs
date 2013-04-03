using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrmLiteHelper.MySql.Tests.Models;
using Xunit;

namespace OrmLiteHelper.MySql.Tests
{
	public class SelectTests : TestBase
	{
		[Fact]
		public void Can_GetById_from_Users_table_using_OrmLiteHelper()
		{
			var user = User.Create();
			Insert<User>(user);

			var storedUser = GetById<User>(user.Id);

			Assert.Equal(user.Id, storedUser[0].Id);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_GetByIds_from_Users_table()
		{
			Assert.True(false);
		}
	
		[Fact(Skip = "TO-DO")]
		public void Can_select_with_filter_from_Users_table()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_select_scalar_value()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_GetFirstColumn()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_GetFirstColumnDistinct()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_GetDictionary()
		{
			Assert.True(false);
		}

		[Fact(Skip = "TO-DO")]
		public void Can_Select_In_for_string_value()
		{
			Assert.True(false);
		}
	}
}