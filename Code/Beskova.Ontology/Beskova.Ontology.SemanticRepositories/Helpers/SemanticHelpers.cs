namespace Beskova.Ontology.SemanticRepositories.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using VDS.RDF;
	using VDS.RDF.Ontology;

	internal static class SemanticHelpers
	{
		public static int? GetIntProperty(this OntologyResource resource, string propertyName)
		{
			var ln = resource.GetProperty(propertyName) as LiteralNode;
			if (ln == null)
			{
				return null;
			}
			try
			{
				return (int?) double.Parse(ln.Value);
			}
			catch (FormatException)
			{
				return null;
			}
		}

		public static string GetStringProperty(this OntologyResource resource, string propertyName)
		{
			return (resource.GetProperty(propertyName) as LiteralNode)?.Value;
		}

		public static List<UriNode> GetObjectProperties(this OntologyResource resource, string propertyName)
		{
			return resource.GetProperties(propertyName).Cast<UriNode>().ToList();
		}

		public static List<OntologyResource> GetSubjectsByObjectProperty(this OntologyResource resource, string propertyName)
		{
			List<Triple> triples = resource.TriplesWithObject.Where(s => s.Predicate.ToString().EndsWith(propertyName))
				.ToList();
			return triples.Select(t => t.Subject)
				.Cast<UriNode>()
				.Select(s => (resource.Graph as OntologyGraph).CreateOntologyResource(s))
				.ToList();
		}

		// Common
		public static INode GetProperty(this OntologyResource resource, string propertyName)
		{
			Triple triple = resource.TriplesWithSubject.FirstOrDefault(s => s.Predicate.ToString().EndsWith(propertyName));
			return triple?.Object;
		}

		public static List<INode> GetProperties(this OntologyResource resource, string propertyName)
		{
			List<Triple> triples = resource.TriplesWithSubject.Where(s => s.Predicate.ToString().EndsWith(propertyName))
				.ToList();
			return triples.Select(t => t.Object).ToList();
		}

		public static void RemoveProperty(this OntologyResource resource, string propertyName)
		{
			resource.Graph.Retract(
				resource.TriplesWithSubject.Where(s => s.Predicate.ToString().EndsWith(propertyName)).ToList());
		}

		public static string GetId(this OntologyResource resource)
		{
			var node = resource.Resource as UriNode;
			return GetId(node);
		}

		public static string GetId(this UriNode uriNode)
		{
			// ReSharper disable once PossibleNullReferenceException
			return uriNode.Uri.ToString();
		}
	}
}