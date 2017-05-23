namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class Speciality : ISelpEntity<string>
	{
		public Speciality()
		{
			ScientificSpecialities = new List<ScientificSpeciality>();
		}

		public string Name { get; set; }

		public string Code { get; set; }

		public List<ScientificSpeciality> ScientificSpecialities { get; set; }

		public List<string> EducationLevel { get; set; }
		public string Id { get; set; }
	}
}