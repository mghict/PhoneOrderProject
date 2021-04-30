using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderUserActiveFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.CommandsHandler
{
    public class CreateUserActiveCommandHandler:
        Object,
        MediatR.IRequestHandler
        <Commands.CreateUserActiveCommand, FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public CreateUserActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<long>> Handle(CreateUserActiveCommand request, CancellationToken cancellationToken)
        {
            Result<long> result = new Result<long>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.CreateUserActiveCommand, long>
                            (validator: new Validators.CreateUserActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var entity = Mapper.Map<Domain.Entities.CustomerPreOrderUserActive>(request);             
                var resp=await UnitOfWork.UserActiveRepository.InsertAsync(entity);
                if (resp != null && resp.Id > 0)
                {
                    result.WithSuccess("اطلاعات ذخیره شد");
                    result.WithValue(resp.Id);
                }
                else
                {
                    result.WithError("اطلاعات ذخیره نشد");
                }
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
