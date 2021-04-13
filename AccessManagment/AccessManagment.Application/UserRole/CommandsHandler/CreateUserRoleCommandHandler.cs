using AccessManagment.Application.UserRole.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserRole.CommandsHandler
{
    public class CreateUserRoleCommandHandler:
        MediatR.IRequestHandler<Commands.CreateUserRoleCommand, FluentResults.Result<long>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateUserRoleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<long>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            Result<long> result = new Result<long>();
            result.WithValue(0);

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateUserRoleCommand, long>
                        (validator: new Validations.CreateUserRoleValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.UserRoleAccessTbl>(request);

                var resp = await UnitOfWork.UserRoleRepository.InsertAsync(entity);

                if (resp != null)
                {
                    result.WithValue(resp.Id);
                    result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
                }

            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
                result.WithValue(0);
            }

            return result;
        }
    }
}
