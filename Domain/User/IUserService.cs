namespace Domain.User;

public interface IUserService : IServiceBase<UserDto>
{
    Task<UserDto> GetUserByEmail(string email);
}