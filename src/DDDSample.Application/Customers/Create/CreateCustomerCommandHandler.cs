namespace DDDSample.Application.Customers.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using DDDSample.Domain.Customers;
    using DDDSample.Domain.Primitives;
    using DDDSample.Domain.ValueObjects;
    using ErrorOr;
    using MediatR;

    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
                {
                    return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format");
                }

                if (Address.Create(command.Country, command.Line1, command.Line2, command.City, command.State, command.ZipCode) is not Address address)
                {
                    return Error.Validation("Customer.Address", "Address is not valid");
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
            catch (Exception ex)
            {
                return Error.Failure($"{nameof(CreateCustomerCommand)}.Failure", ex.Message);
            }
        }
    }
}

