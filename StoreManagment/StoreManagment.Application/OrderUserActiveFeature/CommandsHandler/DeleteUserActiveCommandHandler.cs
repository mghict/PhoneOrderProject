using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderUserActiveFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.CommandsHandler
{
    public class DeleteUserActiveCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.DeleteUserActiveCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        public DeleteUserActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteUserActiveCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.DeleteUserActiveCommand, bool>
                            (validator: new Validators.DeleteUserActiveValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                var entity = Mapper.Map<Domain.Entities.CustomerPreOrderUserActive>(request);
                var resp = await UnitOfWork.UserActiveRepository.DeleteAsync(entity);
                if (resp )
                {
                    result.WithSuccess("اطلاعات ذخیره شد");
                }
                else
                {
                    result.WithError("اطلاعات ذخیره نشد");
                }

                result.WithValue(resp);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
