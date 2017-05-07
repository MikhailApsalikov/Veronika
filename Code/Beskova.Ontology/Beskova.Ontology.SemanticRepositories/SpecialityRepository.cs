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

	public class SpecialityRepository : SemanticRepositoryBase<Speciality>, ISpecialityRepository
	{
		public SpecialityRepository(IGraphProxy graphProxy) : base(graphProxy)
		{
		}

		protected override string EntityName => "Speciality";

		public List<Speciality> GetAll(SpecialityFilter filter)
		{
			IEnumerable<Speciality> result = base.GetAll();
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.SpecialityCode))
					result = result.Where(s => s.Code.Contains(filter.SpecialityCode));
				if (!string.IsNullOrWhiteSpace(filter.SpecialityName))
					result = result.Where(s => s.Name.Contains(filter.SpecialityName));
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityCode))
					result = result.Where(s => s.ScientificSpecialities.Any(d => d.Code.Contains(filter.ScientificSpecialityCode)));
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityName))
					result = result.Where(s => s.ScientificSpecialities.Any(d => d.Name.Contains(filter.ScientificSpecialityName)));
			}
			return result.OrderBy(s => s.Name).ToList();
		}

		public void Remove(string id)
		{
			throw new NotImplementedException();
		}

		protected override Speciality Map(OntologyResource instance)
		{
			var entity = new Speciality
			{
				Id = instance.GetId(),
				Name = instance.GetStringProperty("label"),
				Code = instance.GetStringProperty("hasCode"),
				ScientificSpecialities = instance.GetObjectProperties("specialityConsistsOf")
					.Select(s => GraphProxy.Graph.CreateOntologyResource(s))
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
	}
}