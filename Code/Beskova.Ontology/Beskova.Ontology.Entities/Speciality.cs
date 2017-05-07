namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;
	public class Speciality : ISelpEntity<string>
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public List<ScientificSpeciality> ScientificSpecialities { get; set; }

		public Speciality()
		{
			ScientificSpecialities = new List<ScientificSpeciality>();
		}
	}
}
