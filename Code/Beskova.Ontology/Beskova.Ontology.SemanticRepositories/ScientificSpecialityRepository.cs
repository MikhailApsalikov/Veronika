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

	public class ScientificSpecialityRepository : SemanticRepositoryBase<ScientificSpeciality>,
		IScientificSpecialityRepository
	{
		public ScientificSpecialityRepository(IGraphProxy graphProxy) : base(graphProxy) { }

		protected override string EntityName => "ScientificSpeciality";

		public List<ScientificSpeciality> GetAll(SpecialityFilter filter)
		{
			IEnumerable<ScientificSpeciality> result = base.GetAll();
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityCode))
				{
					result = result.Where(s => s.Code.ToUpperInvariant().Contains(filter.ScientificSpecialityCode.ToUpperInvariant()));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityName))
				{
					result = result.Where(s => s.Name.ToUpperInvariant().Contains(filter.ScientificSpecialityName.ToUpperInvariant()));
				}
				if (!string.IsNullOrWhiteSpace(filter.SpecialityCode))
				{
					result = result.Where(s => s.Specialities.Any(d => d.Code.ToUpperInvariant()
						.Contains(filter.SpecialityCode.ToUpperInvariant())));
				}
				if (!string.IsNullOrWhiteSpace(filter.SpecialityName))
				{
					result = result.Where(s => s.Specialities.Any(d => d.Name.ToUpperInvariant()
						.Contains(filter.SpecialityName.ToUpperInvariant())));
				}
			}
			return result.OrderBy(s => s.Name).ToList();
		}

		public void Remove(string id) { throw new NotImplementedException(); }

		protected override ScientificSpeciality Map(OntologyResource instance)
		{
			var entity = new ScientificSpeciality
			{
				Id = instance.GetId(),
				Name = instance.GetStringProperty("label"),
				Code = instance.GetStringProperty("hasCode"),
				Specialities = instance.GetSubjectsByObjectProperty("specialityConsistsOf")
					.Select(s => new Speciality
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