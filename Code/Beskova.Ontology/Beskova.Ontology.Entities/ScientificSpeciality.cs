namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class ScientificSpeciality : ISelpEntity<string>
	{
		public ScientificSpeciality()
		{
			Specialities = new List<Speciality>();
		}

		public string Name { get; set; }

		public string Code { get; set; }

		//specialityConsistsOf
		public List<Speciality> Specialities { get; set; }

		public string Id { get; set; }
	}
}