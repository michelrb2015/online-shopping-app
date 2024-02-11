namespace OnlineShoppingApp.Application.Commands.Handlers
{
    public interface IRegisterUserCommandHandler
    {
        Task<bool> HandleAsync(RegisterUserCommand command);
    }
}
