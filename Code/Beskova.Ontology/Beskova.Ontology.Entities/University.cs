namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class University : ISelpEntity<string>
	{
		public University()
		{
			ScientificSpecialities = new List<ScientificSpeciality>();
		}

		public string Name { get; set; }

		// revert IsIn
		public List<ScientificSpeciality> ScientificSpecialities { get; set; }

		public string Id { get; set; }
	}
}