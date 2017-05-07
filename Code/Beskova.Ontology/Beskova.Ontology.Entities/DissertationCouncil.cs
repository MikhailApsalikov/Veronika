namespace Beskova.Ontology.Entities
{
	using Selp.Interfaces;

	public class DissertationCouncil : ISelpEntity<string>
	{
		//hasCode
		public string Code { get; set; }

		//hasOrderNumber
		public string OrderId { get; set; }

		//createdIn
		public University University { get; set; }

		//associatedWith
		public ScientificSpeciality ScientificSpeciality { get; set; }

		public string Id { get; set; }
	}
}