using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace OrmLiteHelper.MySql.Tests.Models
{
	public enum UserType
	{
		Default,
		Admin
	}

	[Alias("Users")]
	public class User : ModelBase
	{
		[AutoIncrement]
		public long Id { get; set; }

		public UserType Type { get; set; }

		[Index]
		public string Name { get; set; }

		[Index(true)]
		public string EmailAddress { get; set; }

		public string Password { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateUpdated { get; set; }

		public bool Active { get; set; }

		public static User Create()
		{
			var guidString = Guid.NewGuid().ToString();

			var user = new User()
			{
				Type = UserType.Default,
				Name = guidString,
				EmailAddress = string.Format("{0}@example.com", guidString),
				DateCreated = DateTime.Now,
				Active = true
			};

			return user;
		}
	}
}