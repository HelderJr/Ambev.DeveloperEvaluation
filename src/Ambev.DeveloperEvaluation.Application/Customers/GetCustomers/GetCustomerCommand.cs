using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomers
{
    public class GetCustomerCommand : IRequest<GetCustomerResult>
    {
        public int Id { get; set; }

        public GetCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
