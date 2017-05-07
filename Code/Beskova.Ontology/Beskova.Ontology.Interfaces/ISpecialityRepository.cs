namespace Beskova.Ontology.Interfaces
{
	using System.Collections.Generic;
	using Entities;
	using Entities.Filters;

	public interface ISpecialityRepository
	{
		List<Speciality> GetAll(SpecialityFilter filter);
		Speciality GetById(string id);
		void Remove(string id);
	}
}