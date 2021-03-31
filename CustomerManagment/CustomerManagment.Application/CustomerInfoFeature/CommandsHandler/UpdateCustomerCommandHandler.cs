using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerInfoFeature.CommandsHandler
{
    public class UpdateCustomerCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdateCustomerCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public UpdateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, Persistence.IQueryUnitOfWork _queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = _queryUnitOfWork;
        }


        public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateCustomerCommand, long>
                        (validator: new Validators.UpdateCustomerValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.CustomerInfoTbl>(request);

                try
                {
                    var existMobile = await QueryUnitOfWork.CustomerRepository.GetCustomerByDefaultMobileAsync(request.DefaultMobile);

                    if (existMobile != null)
                    {
                        if (existMobile.Id != request.Id)
                        {
                            result.WithError("تلفن برای مشتری دیگری ثبت شده است");
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }

                var cust = await UnitOfWork.CustomerRepository.GetByIdAsync(request.Id);
                if (cust == null)
                {
                    throw new Exception(String.Format( BehsamFramework.Resources.Messages.DataNotFound,"Customer"));
                }

                entity.RegisterDate = cust.RegisterDate;
                entity.RegisterTime = cust.RegisterTime;
                entity.Score = cust.Score;
                entity.WaletPrice = cust.WaletPrice;
                entity.CustomerCode = cust.CustomerCode;


                var operationResult = await UnitOfWork.CustomerRepository.UpdateAsync(entity);

                if (operationResult)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                }
                else
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.ErrorDone);
                }

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