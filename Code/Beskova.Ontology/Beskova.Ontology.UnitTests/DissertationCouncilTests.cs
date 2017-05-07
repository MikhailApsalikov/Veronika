namespace Beskova.Ontology.UnitTests
{
	using System.Collections.Generic;
	using Entities;
	using Interfaces;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SemanticRepositories;

	[TestClass]
	public class DissertationCouncilTests
	{
		private IGraphProxy graph;
		private IDissertationCouncilRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			graph = new FakeGraph();
			graph.LoadGraph();
			repository = new DissertationCouncilRepository(graph);
		}

		[TestMethod]
		public void GetAllShouldReturnEntities()
		{
			List<DissertationCouncil> result =
				repository.GetAll(null);
			Assert.AreNotEqual(0, result, "GetAll ничего не вернул");
		}

		[TestMethod]
		public void GetByIdShouldReturnValidEntity()
		{
			DissertationCouncil result =
				repository.GetById("http://www.semanticweb.org/давид/ontologies/2017/4/untitled-ontology-25#Д_001.001.01");
			Assert.AreNotEqual(null, result, "Get ничего не вернул");
		}

		[TestMethod]
		public void DeleteShouldWork()
		{
			repository.Remove("http://www.semanticweb.org/давид/ontologies/2017/4/untitled-ontology-25#Д_001.001.01");
		}
	}
}