using AutoMapper;
using ERP.Backend.Domain.Entities;
using ERP.Backend.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERP.Backend.Application.Features.Customers.UpdateCustomer
{
    internal sealed class UpdateCustomerCommandHandler( ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper )
        : IRequestHandler<UpdateCustomerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await customerRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
            if (customer is null)
            {
                return Result<string>.Failure("Müşteri Bulunamadı");
            }
            if(customer.TaxNumber != request.TaxNumber)
            {
                bool isTaxNumberExists = await customerRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber, cancellationToken);
                if (isTaxNumberExists)
                {
                    return Result<string>.Failure("Vat number already exists");
                }
            }
            mapper.Map(request, customer);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Müşteri başarıyla güncellendi";
        }
    }
}
