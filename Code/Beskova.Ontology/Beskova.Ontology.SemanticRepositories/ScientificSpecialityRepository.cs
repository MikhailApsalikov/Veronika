using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beskova.Ontology.SemanticRepositories
{
	using Entities;
	using Entities.Filters;
	using Interfaces;
	using VDS.RDF.Ontology;

	public class ScientificSpecialityRepository : SemanticRepositoryBase<ScientificSpeciality>, IScientificSpecialityRepository
	{
		public ScientificSpecialityRepository(IGraphProxy graphProxy) : base(graphProxy)
		{
		}

		protected override string EntityName => "ScientificSpeciality";

		protected override ScientificSpeciality Map(OntologyResource instance)
		{
			return new ScientificSpeciality()
			{

			};
		}

		public List<ScientificSpeciality> GetAll(SpecialityFilter filter)
		{
			return base.GetAll();
		}
	}
}
