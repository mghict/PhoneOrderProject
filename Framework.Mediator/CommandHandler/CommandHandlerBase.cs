using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataDapper;
using AutoMapper;
using Dapper;

namespace Common.Base.CommandHandlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommandClass">The Name Of Class That You Create it</typeparam>
    public abstract class CommandHandlerBase<TCommandClass> : MediatR.IRequestHandler<TCommandClass, FluentResults.Result> where TCommandClass : MediatR.IRequest<FluentResults.Result>
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected AutoMapper.IMapper Mapper { get; }
        public CommandHandlerBase(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<Result> Handle(TCommandClass request, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result();
            try
            {
                
                
                result =await Handler(request, cancellationToken);

                result.WithSuccess(successMessage: GeneralMessages.Operation_Success);
            }
            catch(Exception ex)
            {
                result.WithError(errorMessage: GeneralMessages.Operation_Error);
                result.WithError(errorMessage: ex.Message);
            }

            return result;
        }
        public abstract Task<Result> Handler(TCommandClass request, CancellationToken cancellationToken);
        
    }

    public abstract class CommandHandlerBase<TCommandClass,TResultDtoClass> : MediatR.IRequestHandler<TCommandClass, FluentResults.Result<TResultDtoClass>> where TCommandClass : MediatR.IRequest<FluentResults.Result<TResultDtoClass>>
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected AutoMapper.IMapper Mapper { get; }
        public CommandHandlerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<Result<TResultDtoClass>> Handle(TCommandClass request, CancellationToken cancellationToken)
        {
            var result = new FluentResults.Result<TResultDtoClass>();
            try
            {
                result = await Handler(request, cancellationToken);

                result.WithSuccess(successMessage: GeneralMessages.Operation_Success);
            }
            catch (Exception ex)
            {
                result.WithError(errorMessage: GeneralMessages.Operation_Error);
                result.WithError(errorMessage: ex.Message);
            }

            return result;
        }
        public abstract Task<Result<TResultDtoClass>> Handler(TCommandClass request, CancellationToken cancellationToken);

        
    }

}
