namespace Beskova.Ontology.Entities
{
	using Selp.Interfaces;
	public class ScientificSpeciality : ISelpEntity<int>
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public int SpecialityId { get; set; }

		public int DissertationCouncilId { get; set; }
	}
}
