using System;
using System.Collections.Generic;
using System.Linq;

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
				if (!string.IsNullOrWhiteSpace(filter.SpecialityCode))
				{
					result = result.Where(s => s.Code.Contains(filter.SpecialityCode));
				}
				if (!string.IsNullOrWhiteSpace(filter.SpecialityName))
				{
					result = result.Where(s => s.Code.Contains(filter.SpecialityName));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityCode))
				{
					result = result.Where(s => s.Code.Contains(filter.ScientificSpecialityCode));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityName))
				{
					result = result.Where(s => s.Code.Contains(filter.ScientificSpecialityName));
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
