namespace Beskova.Ontology.Entities
{
	using Enums;
	using Selp.Interfaces;

	public class Account : ISelpEntity<int>
	{
		public string Name { get; set; }

		public AccountRole Role { get; set; }
		public int Id { get; set; }
	}
}