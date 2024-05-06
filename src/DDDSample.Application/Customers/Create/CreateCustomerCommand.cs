namespace DDDSample.Application.Customers.Create
{
    using ErrorOr;
    using MediatR;

    public record CreateCustomerCommand(
		string Name,
		string LastName,
		string Email,
		string PhoneNumber,
		string Country,
		string Line1,
		string Line2,
		string City,
		string State,
		string ZipCode) : IRequest<ErrorOr<Unit>>;
}

