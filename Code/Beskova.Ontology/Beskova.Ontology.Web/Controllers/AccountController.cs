namespace Beskova.Ontology.Web.Controllers
{
	using System;
	using Entities;
	using Interfaces;
	using Models;
	using Selp.Controller;

	public class AccountController : SelpController<AccountModel, AccountModel, Account, int>
	{
		public AccountController(IAccountRepository repository) : base(repository)
		{
		}

		public override string ControllerName => "Accounts";

		protected override AccountModel MapEntityToModel(Account entity)
		{
			throw new NotImplementedException();
		}

		protected override Account MapModelToEntity(AccountModel model)
		{
			throw new NotImplementedException();
		}

		protected override AccountModel MapEntityToShortModel(Account entity)
		{
			throw new NotImplementedException();
		}
	}
}