namespace DDDSample.Domain.Primitives
{
	using MediatR;

	public record DomainEvent(Guid id) : INotification
	{
	}
}

