namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class University : ISelpEntity<string>
	{
		public string Id { get; set; }

		public string Name { get; set; }

		// revert IsIn
		public List<DissertationCouncil> DissertationCouncils { get; set; }

		public University()
		{
			DissertationCouncils = new List<DissertationCouncil>();
		}
	}
}