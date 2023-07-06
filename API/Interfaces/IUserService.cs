namespace API.Interfaces
{
    public interface IUserService
    {
        Task<List<AppUser>> GetDevelopers();
        Task<List<string>> GetRoles();
        Task<ActionResult<UserDto>> RegisterUser(RegisterDto register);
    }
}
