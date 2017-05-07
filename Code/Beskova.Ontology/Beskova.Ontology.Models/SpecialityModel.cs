namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class SpecialityModel : ISelpEntity<string>
	{
		public SpecialityModel()
		{
			ScientificSpecialities = new List<ScientificSpecialityModel>();
		}

		public string Name { get; set; }

		public string Code { get; set; }

		public List<ScientificSpecialityModel> ScientificSpecialities { get; set; }
		public string Id { get; set; }
	}
}