namespace DDDSample.Domain.Primitives
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}

