using AutoMapper;
using SettingManagment.Persistence;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.TimeSheetFeature.CommandsHandler
{
    public class UpdateTimeSheetCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.UpdateTimeSheetCommand, FluentResults.Result>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }
        protected Persistence.IQueryUnitOfWork QueryUnitOfWork { get; }

        public UpdateTimeSheetCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IQueryUnitOfWork queryUnitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            QueryUnitOfWork = queryUnitOfWork;
        }

        public async Task<FluentResults.Result> Handle(Commands.UpdateTimeSheetCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result result = new FluentResults.Result();

            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.UpdateTimeSheetCommand>
                        (validator: new Validators.UpdateTimeSheetValidator(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                // **************************************************

                var existsId = await QueryUnitOfWork.TimeSheetQueryRepository.GetByIdAsync(request.Id);
                if(existsId==null)
                {
                    throw new Exception("کلید یافت نشد");
                }
                existsId.StartTime = request.FromTime;
                existsId.ToTime = request.ToTime;
                existsId.StepTime = request.StepTime;
                existsId.Status = request.Status;

                var cust = await UnitOfWork.TimeSheetRepository.UpdateAsync(existsId);


                // **************************************************

                // **************************************************

                if (cust)
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                else
                {
                    result.WithError
                        (BehsamFramework.Resources.Messages.ErrorDone);
                }
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
