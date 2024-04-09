namespace DDDSample.Infrastructure.Persistence.Repositories
{
    using System.Threading.Tasks;
    using DDDSample.Domain.Customers;
    using Microsoft.EntityFrameworkCore;

    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task Add(Customer customer) => await _applicationDbContext.Customers.AddAsync(customer);

        public async Task<Customer?> GetByIdAsync(CustomerId id) => await _applicationDbContext.Customers.SingleOrDefaultAsync(c => c.Id == id);
    }
}

