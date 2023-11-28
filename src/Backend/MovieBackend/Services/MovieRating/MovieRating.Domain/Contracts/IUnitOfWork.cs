namespace MovieRating.Domain.Contracts
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
	}
}