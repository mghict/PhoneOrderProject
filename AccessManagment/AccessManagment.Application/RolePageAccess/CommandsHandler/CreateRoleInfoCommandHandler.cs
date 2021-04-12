using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RolePageAccess.CommandsHandler
{
    public class CreateRolePageAccessCommandHandler :
        MediatR.IRequestHandler<Commands.CreateRolePageAccessCommand, FluentResults.Result<bool>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateRolePageAccessCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(Commands.CreateRolePageAccessCommand request, CancellationToken cancellationToken)
        {
            Result<bool> result = new Result<bool>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateRolePageAccessCommand, bool>
                        (validator: new Validators.CreateRolePageAccessValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = request.Permision.ToList();

                await UnitOfWork.RolePageAccessRepository.CreatePermision(entity);

                result.WithValue(true);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(false);
            }

            return result;
        }
    }
}
