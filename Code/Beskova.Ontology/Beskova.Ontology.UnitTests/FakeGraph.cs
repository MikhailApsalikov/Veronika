namespace Beskova.Ontology.UnitTests
{
	using System;
	using System.IO;
	using Interfaces;
	using VDS.RDF;
	using VDS.RDF.Ontology;

	internal class FakeGraph : IGraphProxy
	{
		private IGraphProxy graphProxyImplementation;
		public OntologyGraph Graph { get; private set; }

		public void LoadGraph()
		{
			if (Graph == null)
			{
				Graph = new OntologyGraph();
				if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Ontology.owl")))
				{
					Graph.LoadFromFile(Path.Combine(Environment.CurrentDirectory, "Ontology.owl"));
				}
			}
		}

		public void SaveChanges()
		{
		}

		public int AddTripplesFromStream(Stream stream)
		{
			return 0;
		}
	}
}