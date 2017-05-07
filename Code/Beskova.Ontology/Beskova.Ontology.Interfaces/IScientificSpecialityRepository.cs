namespace Beskova.Ontology.Interfaces
{
	using System.Collections.Generic;
	using Entities;
	using Entities.Filters;

	public interface IScientificSpecialityRepository
	{
		List<ScientificSpeciality> GetAll(SpecialityFilter filter);
		ScientificSpeciality GetById(string id);
		void Remove(string id);
	}
}