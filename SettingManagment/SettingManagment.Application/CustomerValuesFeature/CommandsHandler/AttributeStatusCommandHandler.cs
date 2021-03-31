using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using SettingManagment.Application.CustomerValuesFeature.Commands;
using SettingManagment.Domain.Entities;
using SettingManagment.Persistence;

namespace SettingManagment.Application.CustomerValuesFeature.CommandsHandler
{
    public class AttributeStatusCommandHandler:
        Object,
        MediatR.IRequestHandler
        <Commands.AttributeStatusCommand, FluentResults.Result<List<AttributeStatus>>>
    {

        protected Persistence.IUnitOfWork UnitOfWork { get; }

        public AttributeStatusCommandHandler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<Result<List<AttributeStatus>>> Handle(AttributeStatusCommand request, CancellationToken cancellationToken)
        {
            FluentResults.Result<List<AttributeStatus>> result = new FluentResults.Result<List<AttributeStatus>>();

            try
            {
                

                // **************************************************
                

                var values = await UnitOfWork.AttributeStatusRepository.GetAllAsync();
                if (values == null)
                {
                    throw new Exception(BehsamFramework.Resources.Messages.DataNotFound);
                }

                result.WithValue(values.ToList());
                // **************************************************

                // **************************************************


                result.WithSuccess
                    (successMessage: BehsamFramework.Resources.Messages.SuccessInsert);
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
