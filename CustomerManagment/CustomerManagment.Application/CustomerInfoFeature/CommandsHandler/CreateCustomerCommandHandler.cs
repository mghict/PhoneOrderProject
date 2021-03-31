using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagment.Application.CustomerInfoFeature.Commands;
using CustomerManagment.Persistence;
using FluentResults;

namespace CustomerManagment.Application.CustomerInfoFeature.CommandsHandler
{
    public class CreateCustomerCommandHandler:
        Object,
        MediatR.IRequestHandler
        <Commands.CreateCustomerCommand,FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }
        public CreateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,IQueryUnitOfWork queryUnitOfWork )
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }


        public async Task<Result<long>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<long> result = new FluentResults.Result<long>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateCustomerCommand, long>
                        (validator: new Validators.CreateCustomerValidator(), command: request);

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
                        result.WithError("تلفن برای مشتری دیگری ثبت شده است");
                        return result;
                    }
                }
                catch(Exception ex)
                {
                    
                }

                entity.CustomerCode = generateID();

                var customer = await UnitOfWork.CustomerRepository.InsertAsync(entity);
                if (customer == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.UserNamePassNotFound);
                }

                result.WithValue(customer.Id);
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

        private string generateID()
        {
            long i = 1;

            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }

            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            return number;
        }

    }
}
