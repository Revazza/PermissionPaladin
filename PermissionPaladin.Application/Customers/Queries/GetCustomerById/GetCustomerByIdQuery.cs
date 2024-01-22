using MediatR;
using PermissionPaladin.Domain.Users.Customers;

namespace PermissionPaladin.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(int CustomerId) : IRequest<Customer?>;
