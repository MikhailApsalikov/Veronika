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

	public class DissertationCouncilController : ApiController
	{
		private readonly IDissertationCouncilRepository _repository;

		public DissertationCouncilController(IDissertationCouncilRepository repository)
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
		public IHttpActionResult Get([FromUri]DissertationCouncilFilter filter)
		{
			try
			{
				List<DissertationCouncilModel> list = _repository.GetAll(filter).Select(MapEntityToModel).ToList();
				var content = new EntitiesListResult<DissertationCouncilModel>
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

		private DissertationCouncilModel MapEntityToModel(DissertationCouncil entity)
		{
			return Mapper.Map<DissertationCouncilModel>(entity);
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