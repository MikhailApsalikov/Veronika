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

	public class DissertationCouncilRepository : SemanticRepositoryBase<DissertationCouncil>,
		IDissertationCouncilRepository
	{
		public DissertationCouncilRepository(IGraphProxy graphProxy) : base(graphProxy)
		{
		}

		protected override string EntityName => "dissertationCouncil";

		public List<DissertationCouncil> GetAll(DissertationCouncilFilter filter)
		{
			IEnumerable<DissertationCouncil> result = base.GetAll();
			if (filter != null)
			{
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityCode))
				{
					result = result.Where(s => s.ScientificSpecialities.Any(ss=>ss.Code.ToUpperInvariant().Contains(filter.ScientificSpecialityCode.ToUpperInvariant())));
				}
				if (!string.IsNullOrWhiteSpace(filter.ScientificSpecialityName))
				{
					result = result.Where(s => s.ScientificSpecialities.Any(ss => ss.Name.ToUpperInvariant().Contains(filter.ScientificSpecialityName.ToUpperInvariant())));
				}
			}
			return result.OrderBy(s => s.Code).ToList();
		}

		protected override DissertationCouncil Map(OntologyResource instance)
		{
			var entity = new DissertationCouncil
			{
				Id = instance.GetId(),
				OrderId = instance.GetStringProperty("hasOrderNumber"),
				Code = instance.GetStringProperty("hasCode"),
				ScientificSpecialities = instance.GetObjectProperties("associatedWith")
					.Select(s => GraphProxy.Graph.CreateOntologyResource(s))
					.Select(s => new ScientificSpeciality()
					{
						Id = s.GetId(),
						Name = s.GetStringProperty("label"),
						Code = s.GetStringProperty("hasCode")
					})
					.ToList()
			};

			List<OntologyResource> universities = instance.GetObjectProperties("createdIn")
				.Select(s => GraphProxy.Graph.CreateOntologyResource(s))
				.ToList();
			if (universities.Any())
			{
				entity.University = new University
				{
					Id = universities[0].GetId(),
					Name = universities[0].GetStringProperty("label")
				};
			}

			return entity;
		}

		protected override OntologyClass GetClass(string name)
		{
			return GraphProxy.Graph.OwlClasses.FirstOrDefault(c => c.Resource.ToString().EndsWith($"#{name}"));
		}
	}
}