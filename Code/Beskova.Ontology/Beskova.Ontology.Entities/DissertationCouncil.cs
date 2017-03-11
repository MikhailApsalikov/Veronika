using System;

namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;
	public class DissertationCouncil : ISelpEntity<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public DateTime CreationDate { get; set; }

		public int OrderNumber { get; set; }

		public List<ScientificSpeciality> ScientificSpecialities { get; set; }

		public int UniversityId { get; set; }

		public DissertationCouncil()
		{
			ScientificSpecialities = new List<ScientificSpeciality>();
		}
	}
}
