using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerAddressFeature.Commands;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerAddressFeature.CommandsHandler
{
    public class CreateCustomerAddressWithListCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateCustomerAddressWithListCommand,FluentResults.Result<IList<BehsamFramework.Models.CustomerAddressModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public CreateCustomerAddressWithListCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<IList<BehsamFramework.Models.CustomerAddressModel>>> Handle(CreateCustomerAddressWithListCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<IList<BehsamFramework.Models.CustomerAddressModel>> result = 
                new FluentResults.Result<IList<BehsamFramework.Models.CustomerAddressModel>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateCustomerAddressWithListCommand, IList<BehsamFramework.Models.CustomerAddressModel>>
                        (validator: new Validators.CreateCustomerAddressWithListValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerAddressTbl>(request);

                var address = await UnitOfWork.CustomerAddressRepository.InsertAsync(entity);
                
                if (address == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                var lst = await QueryUnitOfWork.CustomerAddressRepository.GetCustomerAddressAsync(request.CustomerId);
                var retVal = Mapper.Map<ICollection<Domain.Entities.CustomerAddressTbl>, ICollection<BehsamFramework.Models.CustomerAddressModel>>(lst);
                result.WithValue(retVal.ToList());
                // **************************************************

                // **************************************************


                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
            }
            catch (Exception e)
            {
                result.WithError(e.Message);
            }
            finally
            {

            }
            return result;
        }
    }
}
