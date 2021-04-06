using AutoMapper;
using FluentResults;
using StoreManagment.Application.OrderInfoFeature.Commands;
using StoreManagment.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderInfoFeature.CommandsHandler
{
    public class GetSummeryOrderByDateCommandHandler :
        Object,
        MediatR.IRequestHandler
        <Commands.GetSummeryOrderByDate, FluentResults.Result<List<Domain.Entities.GetSummeryOrderByDate>>>
    {
        protected AutoMapper.IMapper Mapper { get; }
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetSummeryOrderByDateCommandHandler(IMapper mapper, IQueryUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<Domain.Entities.GetSummeryOrderByDate>>> Handle(GetSummeryOrderByDate request, CancellationToken cancellationToken)
        {
            Result<List < Domain.Entities.GetSummeryOrderByDate >> result = new Result<List<Domain.Entities.GetSummeryOrderByDate>>();

            try
            {
                result =
                        await BehsamFramework.Util.Utility.Validate<Commands.GetSummeryOrderByDate, List<Domain.Entities.GetSummeryOrderByDate>>
                            (validator: new Validators.GetSummeryOrderByDate(), command: request);

                if (result.IsFailed)
                {
                    return result;
                }

                                
                var lst=await UnitOfWork.OrderInfoQueryRepository.getSummeryOrderByDates(request.StartDate,request.EndDate);
                if(lst!=null && lst.Count>0)
                { 
                    result.WithValue(lst); 
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
