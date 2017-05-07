namespace Beskova.Ontology.Repositories
{
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Entities;
	using Entities.Enums;

	public class TestDataInitializer : DropCreateDatabaseIfModelChanges<UserDbContext>
	{
		protected override void Seed(UserDbContext context) { InitializeTestAccounts(context); }

		private void InitializeTestAccounts(UserDbContext context)
		{
			if (context.Accounts.Any()) { return; }

			var accounts = new List<Account>
			{
				new Account
				{
					Name = "Administrator",
					Password = "123456",
					Role = AccountRole.Admin
				},
				new Account
				{
					Name = "MinistryAdmin",
					Password = "123456",
					Role = AccountRole.MinistryAdmin
				}
			};

			context.Accounts.AddRange(accounts);
		}
	}
}