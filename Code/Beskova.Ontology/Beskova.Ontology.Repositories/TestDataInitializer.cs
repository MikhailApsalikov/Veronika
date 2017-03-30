namespace Beskova.Ontology.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using Entities;
	using Entities.Enums;

	public class TestDataInitializer : DropCreateDatabaseIfModelChanges<UserDbContext>
	{
		private readonly Random random = new Random();

		protected override void Seed(UserDbContext context)
		{
			InitializeTestAccounts(context);
		}

		private void InitializeTestAccounts(UserDbContext context)
		{
			if (context.Accounts.Any())
			{
				return;
			}

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
					Name = "Expert",
					Password = "123456",
					Role = AccountRole.Expert
				},
				new Account
				{
					Name = "User",
					Password = "123456",
					Role = AccountRole.User
				},
				new Account
				{
					Name = "Inactive",
					Password = "123456",
					Role = AccountRole.User,
					IsRemoved = true
				}
			};

			context.Accounts.AddRange(accounts);
		}
	}
}