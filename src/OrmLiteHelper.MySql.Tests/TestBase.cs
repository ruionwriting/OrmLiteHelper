using System.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;

namespace OrmLiteHelper.MySql.Tests
{
	public class TestBase : OrmLiteHelper
	{
		//protected virtual string ConnectionString { get; set; }

		public TestBase()
		{
			OrmLiteConfig.DialectProvider = MySqlDialectProvider.Instance;

			base.Verbose = true;
			base.ConnectionString = ConfigurationManager.ConnectionStrings["testDb"].ConnectionString;
		}
	}
}