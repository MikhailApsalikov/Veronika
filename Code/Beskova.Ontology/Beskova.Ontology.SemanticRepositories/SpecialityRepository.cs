﻿namespace Beskova.Ontology.SemanticRepositories
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
		private const string PostgraduateEducationLevel = "аспирантура";

		public SpecialityRepository(IGraphProxy graphProxy) : base(graphProxy)
		{
		}

		protected override string EntityName => "Speciality";

		public List<Speciality> GetAll(SpecialityFilter filter)
		{
			IEnumerable<Speciality> result = base.GetAll();
			result = result.Where(s => s.EducationLevel.Any(el => el.ToUpperInvariant() == PostgraduateEducationLevel.ToUpperInvariant()));
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.SpecialityCode))
				{
					result = result.Where(s => s.Code.ToUpperInvariant().Contains(filter.SpecialityCode.ToUpperInvariant()));
				}
				if (!string.IsNullOrWhiteSpace(filter.SpecialityName))
				{
					result = result.Where(s => s.Name.ToUpperInvariant().Contains(filter.SpecialityName.ToUpperInvariant()));
				}
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
					.ToList(),
				EducationLevel = instance.GetObjectProperties("hasLevelEducation")
					.Select(level => GraphProxy.Graph.CreateOntologyResource(level).GetStringProperty("label"))
					.ToList()
			};


			return entity;
		}
	}
}