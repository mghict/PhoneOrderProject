using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Base.Command
{

    public class CommandBase:object
    {
        public CommandBase():base()
        {
                
        }
        public string Operator { get; set; }
    }
    public class CommandBase<TInputDtoClass> : CommandBase, ICommandBase<TInputDtoClass>
    where TInputDtoClass:DTOs.Base.DtoInputBase
    {
        public TInputDtoClass Data { get ; set ; }
        
    }


    public class CommandBase<TInputDtoClass, TResultDtoClass> : CommandBase, ICommandBase<TInputDtoClass, TResultDtoClass>
    where TInputDtoClass : DTOs.Base.DtoInputBase
    {
        public TInputDtoClass Data { get ; set ; }
        
    }
}
