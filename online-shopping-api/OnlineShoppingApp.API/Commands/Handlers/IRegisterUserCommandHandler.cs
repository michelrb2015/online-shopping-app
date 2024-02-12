namespace OnlineShoppingApp.API.Commands.Handlers
{
    public interface IRegisterUserCommandHandler
    {
        Task<bool> HandleAsync(RegisterUserCommand command);
    }
}
