namespace Beskova.Ontology.UnitTests
{
	using System.Collections.Generic;
	using Entities;
	using Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SemanticRepositories;

	[TestClass]
	public class UniversityTests
	{
		private IGraphProxy graph;
		private IUniversityRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			graph = new FakeGraph();
			graph.LoadGraph();
			repository = new UniversityRepository(graph);
		}

		[TestMethod]
		public void GetAllShouldReturnEntities()
		{
			List<University> result =
				repository.GetAll(null);
			Assert.AreNotEqual(0, result, "GetAll ничего не вернул");
		}

		[TestMethod]
		public void GetByIdShouldReturnValidEntity()
		{
			University result =
				repository.GetById("http://www.semanticweb.org/давид/ontologies/2017/4/untitled-ontology-25#Научно-исследовательский_институт_фундаментальной_и_клинической_иммунологии");
			Assert.AreNotEqual(null, result, "Get ничего не вернул");
		}

		[TestMethod]
		public void DeleteShouldWork()
		{
			repository.Remove("http://www.semanticweb.org/давид/ontologies/2017/4/untitled-ontology-25#Научно-исследовательский_институт_фундаментальной_и_клинической_иммунологии");
		}
	}
}