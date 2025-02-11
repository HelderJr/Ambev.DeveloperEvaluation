using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    public class GetProductCommand : IRequest<GetProductResult>
    {
        public int Id { get; set; }

        public GetProductCommand(int id)
        {
            Id = id;
        }
    }
}
