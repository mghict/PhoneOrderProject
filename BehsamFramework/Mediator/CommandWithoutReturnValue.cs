﻿namespace BehsamFramework.Mediator
{
	public class CommandWithoutReturnValue :
		object, MediatR.IRequest<FluentResults.Result>
	{
		public CommandWithoutReturnValue() : base()
		{
		}
	}
}
