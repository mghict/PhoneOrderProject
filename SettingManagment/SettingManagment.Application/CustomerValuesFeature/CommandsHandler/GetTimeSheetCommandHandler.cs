using BehsamFramework.Models;
using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class GetTimeSheetCommandHandler :
        MediatR.IRequestHandler<Commands.GetTimeSheetCommand, FluentResults.Result<List<BehsamFramework.Models.TimeSheetTableModel>>>
    {
        protected Persistence.IQueryUnitOfWork UnitOfWork { get; }
        public GetTimeSheetCommandHandler(Persistence.IQueryUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<TimeSheetTableModel>>> Handle(GetTimeSheetCommand request, CancellationToken cancellationToken)
        {
            Result<List<TimeSheetTableModel>> result = new Result<List<TimeSheetTableModel>>();
            List<TimeSheetTableModel> lstTimeSheet = new List<TimeSheetTableModel>();
            try
            {
                result =
                    await BehsamFramework.Util.Utility.Validate<Commands.GetTimeSheetCommand, List<BehsamFramework.Models.TimeSheetTableModel>>
                        (validator: new Validators.GetTimeSheetValidator(), command: request);

                if(result.IsSuccess)
                {
                    var entity = await UnitOfWork.TimeSheetQueryRepository.GetTimeSheet(request.RequestDate);
                    
                    if(entity!=null)
                    {
                        TimeSpan step =TimeSpan.FromHours(entity.StepTime);

                        int rownum = 1;
                        TimeSpan nowTime = DateTime.Now.TimeOfDay;

                        for(TimeSpan time=entity.StartTime;time<entity.EndTime;time+=step)
                        {
                            var row = new BehsamFramework.Models.TimeSheetTableModel();
                            row.RowNum = rownum;
                            row.StartTime = time;
                            row.EndTime = time + step;
                            if(row.EndTime>entity.EndTime)
                            {
                                row.EndTime = entity.EndTime;
                            }
                            row.Status = true;

                            if(nowTime>=row.StartTime)
                            {
                                row.Status = false;
                            }

                            if (nowTime >= row.EndTime)
                            {
                                row.Status = false;
                            }

                            lstTimeSheet.Add(row);
                            rownum++;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.WithError(ex.Message);
            }

            result.WithValue(lstTimeSheet);

            return result;
        }
    }
}
