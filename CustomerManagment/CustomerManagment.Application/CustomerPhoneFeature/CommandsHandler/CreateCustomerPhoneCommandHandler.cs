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
    public class CreateCustomerPhoneCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.CreateCustomerPhoneCommand, FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public CreateCustomerPhoneCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }
        public async Task<Result<long>> Handle(CreateCustomerPhoneCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<long> result = new FluentResults.Result<long>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateCustomerPhoneCommand, long>
                        (validator: new Validators.CreateCustomerPhoneValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerPhoneTbl>(request);
                try
                {

                    var existPhone = await QueryUnitOfWork.CustomerPhoneRepository.GetByPhoneAsync(request.PhoneValue);

                    if (existPhone != null)
                    {
                        result.WithError("تلفن برای مشتری دیگری ثبت شده است");
                        return result;
                    }
                }
                catch (Exception ex)
                {
                }

                var phone = await UnitOfWork.CustomerPhoneRepository.InsertAsync(entity);
                if (phone == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                result.WithValue(phone.Id);
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