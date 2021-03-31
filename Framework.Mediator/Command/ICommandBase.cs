using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Base.Command
{
   
    public interface ICommandBase<TInputDtoClass> : MediatR.IRequest<FluentResults.Result>
    {
        TInputDtoClass Data { get; set; }
        string Operator { get; set; }
    }

    public interface ICommandBase<TInputDtoClass, TResultDtoClass> : MediatR.IRequest<FluentResults.Result<TResultDtoClass>>
    {
        TInputDtoClass Data { get; set; }
        string Operator { get; set; }
    }
}
