using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Domain.Entities
{
	public class MovieStream
	{
		public int ID { get; set; }
		public int MovieID { get; set; }
		public string? MovieFile { get; set; }
	}
}
