namespace Infraestructure.User;

using Domain.User;
using Microsoft.EntityFrameworkCore;
using Utils;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    private readonly AppDbContext _dbContext = appDbContext;

    public async Task<UserDto> GetUserByEmail(string email)
    {
        return await IQuerableUser.FirstAsync(x => x.UserEmail == email);
    }
    public async Task<OperationResult<UserDto>> CreateNewUser(UserDto userDto)
    {
        bool userExist = await ExistUser(userDto.UserEmail);
        if (userExist)
        {
            OperationResult<UserDto>.Fail("User with this email already exists.");
        }

        string encryptedPassword = PasswordHasher.Hash(userDto.Password);
        User user = new User(userDto.UserName, userDto.UserEmail, encryptedPassword);

        await _dbContext.AddAsync(user);
        
        await _dbContext.SaveChangesAsync();

        return OperationResult<UserDto>.Ok("User Created Successfuly");
    }
    public async Task<bool> ExistUser(string email)
    {
        return await IQuerableUser.AnyAsync(x => x.UserEmail == email);
    }
     public IQueryable<UserDto> IQuerableUser
    {
        get
        {
            return _dbContext.Users.Select(u => new UserDto
            {
                Password = u.Password,
                UserEmail = u.UserEmail,
                UserName = u.UserName,
            });
        }
    }
}