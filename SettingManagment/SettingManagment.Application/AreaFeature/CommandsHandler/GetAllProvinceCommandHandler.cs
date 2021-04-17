using AutoMapper;
using SettingManagment.Application.AreaFeature.Commands;
using SettingManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.CommandsHandler
{
    public class GetAllProvinceCommandHandler :
        MediatR.IRequestHandler<Commands.GetAllProvinceCommand, FluentResults.Result<List<Domain.Entities.ProvinceTbl>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

        public GetAllProvinceCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<FluentResults.Result<List<Domain.Entities.ProvinceTbl>>> Handle(GetAllProvinceCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<Domain.Entities.ProvinceTbl>> result =
                new FluentResults.Result<List<Domain.Entities.ProvinceTbl>>();

            try
            {


                // **************************************************

                var lst = await UnitOfWork.ProvinceQueryRepository.GetAllAsync();
                
                // **************************************************

                // **************************************************

                if (lst != null)
                {
                    result.WithSuccess
                        (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
                    result.WithValue(lst.ToList());
                }
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
