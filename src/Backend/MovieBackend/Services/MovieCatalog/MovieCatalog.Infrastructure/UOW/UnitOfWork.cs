using MovieCatalog.Domain.Contracts;
using MovieCatalog.Infrastructure.Data;

namespace MovieCatalog.Infrastructure.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MovieDatabaseContext dbContext;

		public UnitOfWork(MovieDatabaseContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await dbContext.SaveChangesAsync();
		}
	}
}