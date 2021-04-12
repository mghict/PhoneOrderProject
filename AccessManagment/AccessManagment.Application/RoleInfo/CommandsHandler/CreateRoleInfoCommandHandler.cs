using AccessManagment.Application.RoleInfo.Commands;
using AccessManagment.Persistence;
using AutoMapper;
using FluentResults;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccessManagment.Application.RoleInfo.CommandsHandler
{
    public class CreateRoleInfoCommandHandler:
        MediatR.IRequestHandler<Commands.CreateRoleInfoCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateRoleInfoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateRoleInfoCommand request, CancellationToken cancellationToken)
        {
            Result<int> result = new Result<int>();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.CreateRoleInfoCommand, int>
                        (validator: new Validators.CreateRoleInfoValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************
                var entity = Mapper.Map<Domain.Entities.RoleInfoTbl>(request);

                var isTrue = await UnitOfWork.RoleInfoRepository.InsertAsync(entity);

                if (isTrue == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.ErrorDone);
                }

                result.WithValue(isTrue.Id);
                result.WithSuccess(BehsamFramework.Resources.Messages.SuccessDone);
            }
            catch (Exception ex)
            {
                result.WithError(ex.Message);
            }

            return result;
        }
    }
}
