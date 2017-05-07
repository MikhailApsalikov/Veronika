namespace Beskova.Ontology.Web
{
	using AutoMapper;
	using Entities;
	using Models;

	public static class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<AccountModel, Account>().ReverseMap();
				cfg.CreateMap<Speciality, SpecialityModel>();
				cfg.CreateMap<ScientificSpeciality, ScientificSpecialityModel>();
				cfg.CreateMap<DissertationCouncil, DissertationCouncilModel>();
				cfg.CreateMap<University, UniversityModel>();
			});
		}
	}
}