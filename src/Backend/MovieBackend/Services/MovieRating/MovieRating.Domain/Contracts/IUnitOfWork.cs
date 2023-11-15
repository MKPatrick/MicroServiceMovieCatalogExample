using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRating.Domain.Contracts
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
