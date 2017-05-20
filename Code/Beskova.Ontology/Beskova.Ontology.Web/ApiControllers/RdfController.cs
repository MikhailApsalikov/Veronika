namespace Beskova.Ontology.Web.ApiControllers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;
	using System.Web;
	using System.Web.Http;
	using Interfaces;
	using VDS.RDF;
	using VDS.RDF.Parsing;

	public class RdfController : ApiController
	{
		private readonly IGraphProxy graphProxy;

		public RdfController(IGraphProxy graphProxy)
		{
			this.graphProxy = graphProxy;
		}

		[HttpPost]
		public IHttpActionResult Import()
		{
			try
			{
				using (var reader = new StreamReader(HttpContext.Current.Request.Files[0].InputStream, Encoding.UTF8))
				{
					IGraph graph = new Graph();
					graph.LoadFromString(reader.ReadToEnd(), new RdfXmlParser());
					IEnumerable<Triple> tripples = new List<Triple>();
					graphProxy.Graph.Assert(tripples);
					return Ok(tripples.Count());
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}