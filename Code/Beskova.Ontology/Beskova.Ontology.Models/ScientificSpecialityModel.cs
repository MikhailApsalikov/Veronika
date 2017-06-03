namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class ScientificSpecialityModel : ISelpEntity<string>
	{
		public ScientificSpecialityModel()
		{
			Specialities = new List<SpecialityModel>();
		}

		public string Name { get; set; }

		public string Code { get; set; }

		public List<SpecialityModel> Specialities { get; set; }

		public List<DissertationCouncilModel> DissertationCouncils { get; set; }
		public string Id { get; set; }
	}
}