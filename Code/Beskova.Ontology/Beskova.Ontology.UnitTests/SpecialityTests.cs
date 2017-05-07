namespace Beskova.Ontology.UnitTests
{
	using System.Collections.Generic;
	using Entities;
	using Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SemanticRepositories;

	[TestClass]
	public class SpecialityTests
	{
		private IGraphProxy graph;
		private ISpecialityRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			graph = new FakeGraph();
			graph.LoadGraph();
			repository = new SpecialityRepository(graph);
		}

		[TestMethod]
		public void GetAllShouldReturnEntities()
		{
			List<Speciality> result =
				repository.GetAll(null);
			Assert.AreNotEqual(0, result, "GetAll ничего не вернул");
		}

		[TestMethod]
		public void GetByIdShouldReturnValidEntity()
		{
			Speciality result =
				repository.GetById("http://localhost:3030/speciality-vocabulary/lists/3/speciality/44.03.05/1");
			Assert.AreNotEqual(null, result, "Get ничего не вернул");
		}

		[TestMethod]
		public void DeleteShouldWork()
		{
			repository.Remove("http://localhost:3030/speciality-vocabulary/lists/3/speciality/44.03.05/1");
		}
	}
}