namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class ScientificSpecialityModel : ISelpEntity<string>
	{
		public ScientificSpecialityModel()
		{
			Speciality = new List<SpecialityModel>();
		}

		public string Name { get; set; }

		public string Code { get; set; }

		public List<SpecialityModel> Speciality { get; set; }
		public string Id { get; set; }
	}
}