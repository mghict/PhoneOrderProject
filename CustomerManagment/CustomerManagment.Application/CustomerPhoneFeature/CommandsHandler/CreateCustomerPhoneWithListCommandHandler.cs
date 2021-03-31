using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerPhoneFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerPhoneFeature.CommandsHandler
{
    public class CreateCustomerPhoneWithListCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateCustomerPhoneWithListCommand, FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public CreateCustomerPhoneWithListCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<Result<List<BehsamFramework.Models.CustomerPhoneModel>>> Handle(CreateCustomerPhoneWithListCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>> result = 
                new FluentResults.Result<List<BehsamFramework.Models.CustomerPhoneModel>>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateCustomerPhoneWithListCommand, List<BehsamFramework.Models.CustomerPhoneModel>>
                        (validator: new Validators.CreateCustomerPhoneWithListValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerPhoneTbl>(request);

                var phone = await UnitOfWork.CustomerPhoneRepository.InsertAsync(entity);
                
                if (phone == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                var lst = await QueryUnitOfWork.CustomerPhoneRepository.GetCustomerPhonesAsync(request.CustomerId);

                var retval=Mapper.Map<ICollection<Domain.Entities.CustomerPhoneTbl>,ICollection< BehsamFramework.Models.CustomerPhoneModel>>(lst);
                
                result.WithValue(retval.ToList());
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