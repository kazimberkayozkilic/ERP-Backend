using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERP.Backend.Application.Features.Customers.DeleteCustomerById
{
    internal sealed class DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (customer is null)
            {
                return Result<string>.Failure("Müşteri Bulunamadı");
            }
            customerRepository.Delete(customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return ("Müşteri Silindi");
        }
    }
}
