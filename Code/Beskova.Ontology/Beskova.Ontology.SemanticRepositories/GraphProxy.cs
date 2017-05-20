namespace Beskova.Ontology.SemanticRepositories
{
	using System.IO;
	using System.Text;
	using System.Web.Hosting;
	using Interfaces;
	using VDS.RDF;
	using VDS.RDF.Ontology;
	using VDS.RDF.Parsing;

	public class GraphProxy : IGraphProxy
	{
		public const string OntologyPath = "~/App_Data/ontology.owl";
		public const string Ontology1Path = "~/App_Data/david.owl";
		public const string Ontology2Path = "~/App_Data/ontology-src.owl";

		private readonly object _lock = new object();
		public OntologyGraph Graph { get; private set; }

		public void LoadGraph()
		{
			if (Graph == null)
			{
				Graph = new OntologyGraph();
				if (File.Exists(HostingEnvironment.MapPath(OntologyPath)))
				{
					Graph.LoadFromFile(HostingEnvironment.MapPath(OntologyPath));
				}
			}
		}

		public int AddTripplesFromStream(Stream stream)
		{
			using (var reader = new StreamReader(stream, Encoding.UTF8))
			{
				IGraph graph = new Graph();
				graph.LoadFromString(reader.ReadToEnd(), new RdfXmlParser());
				Graph.Assert(graph.Triples);
				SaveChanges();
				return graph.Triples.Count;
			}
		}

		public void SaveChanges()
		{
			lock (_lock)
			{
				Graph.SaveToFile(HostingEnvironment.MapPath(OntologyPath));
			}
		}
	}
}