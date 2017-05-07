using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beskova.Ontology.SemanticRepositories
{
	using Entities;
	using Entities.Filters;
	using Helpers;
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
				Id = instance.GetId(),
				Name = instance.GetStringProperty("label"),
				Code = instance.GetStringProperty("hasCode")
			};
		}

		public List<ScientificSpeciality> GetAll(SpecialityFilter filter)
		{
			IEnumerable<ScientificSpeciality> result = base.GetAll();
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.SpecialtyCode))
				{
					result = result.Where(s => s.Code.Contains(filter.SpecialtyCode));
				}
				if (!string.IsNullOrWhiteSpace(filter.SpecialtyName))
				{
					result = result.Where(s => s.Code.Contains(filter.SpecialtyName));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialtyCode))
				{
					result = result.Where(s => s.Code.Contains(filter.ScientificSpecialtyCode));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialtyName))
				{
					result = result.Where(s => s.Code.Contains(filter.ScientificSpecialtyName));
				}
			}
			return result.OrderBy(s => s.Name).ToList();
		}

		public void Remove(string id)
		{
			throw new NotImplementedException();
		}
	}
}
