namespace Beskova.Ontology.Web.Controllers
{
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
			return new AccountModel
			{
				Id = entity.Id,
				Name = entity.Name,
				Role = entity.Role
			};
		}

		protected override Account MapModelToEntity(AccountModel model)
		{
			return new Account
			{
				Id = model.Id,
				Name = model.Name,
				Role = model.Role
			};
		}

		protected override AccountModel MapEntityToShortModel(Account entity)
		{
			return MapEntityToModel(entity);
		}
	}
}