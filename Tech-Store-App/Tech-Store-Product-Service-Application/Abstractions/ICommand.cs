using MediatR;

namespace Tech_Store_Product_Service_Application.Abstractions;

public interface ICommand : IRequest
{
    
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
    
}