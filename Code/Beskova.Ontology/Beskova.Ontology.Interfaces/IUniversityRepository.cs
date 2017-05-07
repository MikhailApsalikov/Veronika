namespace Beskova.Ontology.Interfaces
{
	using System.Collections.Generic;
	using Entities;
	using Entities.Filters;

	public interface IUniversityRepository
	{
		List<University> GetAll(UniversityFilter filter);
		University GetById(string id);
		void Remove(string id);
	}
}