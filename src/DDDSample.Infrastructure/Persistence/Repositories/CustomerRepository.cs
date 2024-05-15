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

        public void Add(Customer customer) => _applicationDbContext.Customers.Add(customer);
        public void Delete(Customer customer) => _applicationDbContext.Customers.Remove(customer);
        public void Update(Customer customer) => _applicationDbContext.Customers.Update(customer);
        public async Task<bool> ExistsAsync(CustomerId id) => await _applicationDbContext.Customers.AnyAsync(customer => customer.Id == id);
        public async Task<Customer?> GetByIdAsync(CustomerId id) => await _applicationDbContext.Customers.SingleOrDefaultAsync(c => c.Id == id);
        public async Task<List<Customer>> GetAll() => await _applicationDbContext.Customers.ToListAsync();
    }
}

