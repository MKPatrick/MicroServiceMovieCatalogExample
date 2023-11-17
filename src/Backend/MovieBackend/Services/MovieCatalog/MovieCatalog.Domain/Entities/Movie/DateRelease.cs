using SharedKernel;
using System.IO;
using System.Reflection.Emit;

namespace MovieCatalog.Domain.Entities.Movie
{
	public class DateRelease : ValueObject
	{
		public int Day { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }

		public override string ToString()
		{
			return $"{Day}.{Month}.{Year}";
		}
		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return Day;
			yield return Month;
			yield return Year;
		}
	}
}
