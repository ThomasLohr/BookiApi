using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BookApi.Models
{
	public class Book
	{

		public string? Id { get; set; }

		public string? Author { get; set; }

		public string? Title { get; set; }

		public string? Genre { get; set; }

		public decimal Price { get; set; }

		public DateTime Publish_date { get; set; }

		public string? Description { get; set; }

	}

}
