using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class CreateAreaGeoCommandHandler :
        MediatR.IRequestHandler<Commands.CreateAreaGeoCommand, FluentResults.Result<int>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public CreateAreaGeoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<int>> Handle(Commands.CreateAreaGeoCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<int> result =
                new FluentResults.Result<int>();

            try
            {
                //result =
                //    await BehsamFramework.Util.Utility.Validate<Commands.CreateAreaInfoCommand, int>
                //        (validator: new Validators.CreateAreaInfoValidator(), command: request);

                //if (result.IsFailed)
                //{
                //    return result;
                //}

                // **************************************************

                //var entity = Mapper.Map<Domain.Entities.AreaInfoTbl>(request);

                var inActive = await UnitOfWork.AreaGeoRepository.InsertEnumerableAsync(request.Points);


                // **************************************************

                // **************************************************

                if (inActive >0 )
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
