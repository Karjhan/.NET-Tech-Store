using MediatR;
using Tech_Store_Product_Service_Domain.Primitives;

namespace Tech_Store_Product_Service_Application.Abstractions;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
    
}