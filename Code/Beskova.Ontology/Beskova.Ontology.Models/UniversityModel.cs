namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class UniversityModel : ISelpEntity<string>
	{
		public UniversityModel()
		{
			ScientificSpecialities = new List<ScientificSpecialityModel>();
		}

		public string Name { get; set; }

		public List<ScientificSpecialityModel> ScientificSpecialities { get; set; }

		public string Id { get; set; }
	}
}