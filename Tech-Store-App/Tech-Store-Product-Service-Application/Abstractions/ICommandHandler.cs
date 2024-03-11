using MediatR;
using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : ICommand
{
    
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse>, IRequest<Result<TResponse>>
{
    
}