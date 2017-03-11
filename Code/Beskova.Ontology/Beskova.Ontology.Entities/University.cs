namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class University : ISelpEntity<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public List<DissertationCouncil> DissertationCouncils { get; set; }

		public University()
		{
			DissertationCouncils = new List<DissertationCouncil>();
		}
	}
}