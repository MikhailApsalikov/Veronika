using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beskova.Ontology.Web.ApiControllers
{
	using System.Net;
	using System.Web.Http;
	using AutoMapper;
	using Entities;
	using Entities.Filters;
	using Interfaces;
	using Models;
	using Selp.Common.Entities;
	using Selp.Common.Exceptions;

	public class ScientificSpecialityController : ApiController
	{
		private readonly IScientificSpecialityRepository _repository;

		public ScientificSpecialityController(IScientificSpecialityRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IHttpActionResult Get(string id)
		{
			try
			{
				return Ok(MapEntityToModel(_repository.GetById(id)));
			}
			catch (Exception e)
			{
				return HandleException(e);
			}
		}

		[HttpGet]
		public IHttpActionResult Get([FromUri]SpecialityFilter filter)
		{
			try
			{
				List<ScientificSpecialityModel> list = _repository.GetAll(filter).Select(MapEntityToModel).OrderBy(s => s.Id).ToList();
				var content = new EntitiesListResult<ScientificSpecialityModel>
				{
					Data = list,
					Page = -1,
					PageSize = -1
				};
				;
				content.Total = list.Count;
				return Ok(content);
			}
			catch (Exception e)
			{
				return HandleException(e);
			}
		}

		private ScientificSpecialityModel MapEntityToModel(ScientificSpeciality entity)
		{
			return Mapper.Map<ScientificSpecialityModel>(entity);
		}

		private IHttpActionResult HandleException(Exception e)
		{
			if (e is NotSupportedException)
			{
				return StatusCode(HttpStatusCode.MethodNotAllowed);
			}

			if (e is EntityNotFoundException)
			{
				return NotFound();
			}

			return InternalServerError(e);
		}
	}
}