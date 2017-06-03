namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class DissertationCouncilModel : ISelpEntity<string>
	{
		public string Code { get; set; }

		public string OrderId { get; set; }

		public UniversityModel University { get; set; }

		public List<ScientificSpecialityModel> ScientificSpecialities { get; set; }

		public string Id { get; set; }
	}
}