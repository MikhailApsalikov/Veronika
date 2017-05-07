namespace Beskova.Ontology.SemanticRepositories
{
	using System.Collections.Generic;
	using System.Linq;
	using Interfaces;
	using Selp.Interfaces;
	using VDS.RDF.Ontology;

	public abstract class SemanticRepositoryBase<TEntity> where TEntity : ISelpEntity<string>
	{
		protected SemanticRepositoryBase(IGraphProxy graphProxy)
		{
			GraphProxy = graphProxy;
			GraphProxy.LoadGraph();
		}

		protected IGraphProxy GraphProxy { get; }

		protected abstract string EntityName { get; }

		public virtual List<TEntity> GetAll()
		{
			OntologyClass ontClass = GetClass(EntityName);
			return ontClass.Instances.Select(Map).ToList();
		}

		public virtual TEntity GetById(string id)
		{
			return GetAll().FirstOrDefault(s => s.Id == id);
		}

		protected OntologyClass GetClass(string name)
		{
			return GraphProxy.Graph.OwlClasses.FirstOrDefault(c => c.Resource.ToString().EndsWith($"/{name}"));
		}

		protected abstract TEntity Map(OntologyResource instance);
	}
}