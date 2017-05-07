namespace Beskova.Ontology.Models
{
	using System.Collections.Generic;
	using Selp.Interfaces;

	public class UniversityModel : ISelpEntity<string>
	{
		public UniversityModel()
		{
			DissertationCouncils = new List<DissertationCouncilModel>();
		}

		public string Name { get; set; }
		
		public List<DissertationCouncilModel> DissertationCouncils { get; set; }

		public string Id { get; set; }
	}
}