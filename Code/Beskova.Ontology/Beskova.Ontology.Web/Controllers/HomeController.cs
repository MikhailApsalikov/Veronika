namespace Beskova.Ontology.Web.Controllers
{
	using System.Web.Mvc;

	[Authorize]
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View();
		}
	}
}