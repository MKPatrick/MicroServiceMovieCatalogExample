namespace MovieCatalog.Domain.Contracts
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}