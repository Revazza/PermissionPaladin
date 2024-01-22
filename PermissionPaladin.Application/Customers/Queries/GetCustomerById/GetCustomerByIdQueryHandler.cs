using MediatR;
using PermissionPaladin.Domain.Users.Customers;
using PermissionPaladin.Persistance.Repositories.Interfaces;

namespace PermissionPaladin.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(request.CustomerId);
    }
}
