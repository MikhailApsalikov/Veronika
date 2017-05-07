namespace Beskova.Ontology.SemanticRepositories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Entities;
	using Entities.Filters;
	using Helpers;
	using Interfaces;
	using VDS.RDF.Ontology;

	public class UniversityRepository : SemanticRepositoryBase<University>, IUniversityRepository
	{
		public UniversityRepository(IGraphProxy graphProxy) : base(graphProxy)
		{
		}

		protected override string EntityName => "University";

		public List<University> GetAll(UniversityFilter filter)
		{
			IEnumerable<University> result = base.GetAll();
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityCode))
				{
					result = result.Where(s => s.ScientificSpecialities.Any(d => d.Code.ToUpperInvariant()
						.Contains(filter.ScientificSpecialityCode.ToUpperInvariant())));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityName))
				{
					result = result.Where(s => s.ScientificSpecialities.Any(d => d.Name.ToUpperInvariant()
						.Contains(filter.ScientificSpecialityName.ToUpperInvariant())));
				}
			}
			return result.OrderBy(s => s.Name).ToList();
		}

		public void Remove(string id)
		{
			throw new NotImplementedException();
		}

		protected override University Map(OntologyResource instance)
		{
			var entity = new University
			{
				Id = instance.GetId(),
				Name = instance.GetStringProperty("label"),
				ScientificSpecialities = instance.GetSubjectsByObjectProperty("isIn")
					.Select(s => new ScientificSpeciality
					{
						Id = s.GetId(),
						Name = s.GetStringProperty("label"),
						Code = s.GetStringProperty("hasCode")
					})
					.ToList()
			};


			return entity;
		}

		protected override OntologyClass GetClass(string name)
		{
			return GraphProxy.Graph.OwlClasses.FirstOrDefault(c => c.Resource.ToString().EndsWith($"#{name}"));
		}
	}
}