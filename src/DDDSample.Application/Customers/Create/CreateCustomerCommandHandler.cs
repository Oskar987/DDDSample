namespace DDDSample.Application.Customers.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using DDDSample.Domain.Customers;
    using DDDSample.Domain.Primitives;
    using DDDSample.Domain.ValueObjects;
    using MediatR;

    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                throw new ArgumentException(nameof(phoneNumber));
            }

            if(Address.Create(command.Country, command.Line1, command.Line2, command.City, command.State, command.ZipCode) is not Address address)
            {
                throw new ArgumentException(nameof(address));
            }

            Customer customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                command.Name,
                command.LastName,
                command.Email,
                phoneNumber,
                address,
                true);

            await _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

