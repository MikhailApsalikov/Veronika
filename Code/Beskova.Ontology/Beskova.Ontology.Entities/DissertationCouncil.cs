namespace Beskova.Ontology.Entities
{
	using System.Collections.Generic;
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
		public List<ScientificSpeciality> ScientificSpecialities { get; set; }

		public string Id { get; set; }
	}
}