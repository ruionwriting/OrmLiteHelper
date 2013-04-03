using ServiceStack.OrmLite;
using Xunit;

namespace OrmLiteHelper.MySql.Tests
{
	public class ConnectionTests : TestBase
	{
		[Fact]
		public void Can_create_connection()
		{
			var couldConnect = false;

			using (var db = ConnectionString.OpenDbConnection())
			using (var dbCmd = db.CreateCommand())
			{
				couldConnect = true;
			}

			Assert.True(couldConnect);
		}
	}
}