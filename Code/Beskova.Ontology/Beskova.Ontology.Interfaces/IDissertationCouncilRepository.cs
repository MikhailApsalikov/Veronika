namespace Beskova.Ontology.Interfaces
{
	using System.Collections.Generic;
	using Entities;
	using Entities.Filters;

	public interface IDissertationCouncilRepository
	{
		List<DissertationCouncil> GetAll(DissertationCouncilFilter filter);
		DissertationCouncil GetById(string id);
		void Remove(string id);
	}
}