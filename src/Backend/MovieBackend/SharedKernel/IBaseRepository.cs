using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity> AddAsync(TEntity entity);
		Task DeleteAsync(int id);
		Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true);
		Task<TEntity> GetByIdAsync(int id, bool tracking = true);
		Task UpdateAsync(TEntity entity);

	}
}
