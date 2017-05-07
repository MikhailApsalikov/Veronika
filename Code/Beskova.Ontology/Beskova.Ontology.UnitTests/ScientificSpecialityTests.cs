namespace Beskova.Ontology.UnitTests
{
	using System.Collections.Generic;
	using Entities;
	using Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SemanticRepositories;

	[TestClass]
	public class ScientificSpecialityTests
	{
		private IGraphProxy graph;
		private IScientificSpecialityRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			graph = new FakeGraph();
			graph.LoadGraph();
			repository = new ScientificSpecialityRepository(graph);
		}

		[TestMethod]
		public void GetAllShouldReturnEntities()
		{
			List<ScientificSpeciality> result =
				repository.GetAll(null);
			Assert.AreNotEqual(0, result, "GetAll ничего не вернул");
		}

		[TestMethod]
		public void GetByIdShouldReturnValidEntity()
		{
			ScientificSpeciality result =
				repository.GetById("http://localhost:3030/speciality-vocabulary/lists/3/scientificspeciality/14.03.08/4");
			Assert.AreNotEqual(null, result, "Get ничего не вернул");
		}

		[TestMethod]
		public void DeleteShouldWork()
		{
			repository.Remove("http://localhost:3030/speciality-vocabulary/lists/3/scientificspeciality/02.00.02/4");
		}
	}
}