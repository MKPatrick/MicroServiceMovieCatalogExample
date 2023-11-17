using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStreaming.Domain.Contracts
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}
