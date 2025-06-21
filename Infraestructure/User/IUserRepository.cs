using Domain.User;

namespace Infraestructure.User;

public interface IUserRepository
{
    Task<UserDto> GetUserByEmail(string email);
}