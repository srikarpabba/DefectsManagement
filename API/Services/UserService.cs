using API.Dtos;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly AppIdentityDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public UserService(AppIdentityDbContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _tokenService = tokenService;

        }

        public async Task<List<AppUser>> GetDevelopers()
        {
            var developers = await (from user in _dbContext.Users
                                    join userRole in _dbContext.UserRoles
                                    on user.Id equals userRole.UserId
                                    join role in _dbContext.Roles
                                    on userRole.RoleId equals role.Id
                                    where role.Name == "Developer"
                                    select user)
                                 .ToListAsync();
            return developers;
        }

        public async Task<List<string>> GetRoles()
        {
            var roles = await _dbContext.Roles.Where(t => t.Name != "Admin").Select(t => t.Name).ToListAsync();                                 
            return roles;
        }

        public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto register)
        {
            if (CheckUserNameExistsAsync(register.UserName).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse
                { Errors = new[] { "Username is in use" } });
            }

            if (CheckEmailExistsAsync(register.EmailAddress).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse
                { Errors = new[] { "Email address is in use" } });
            }
            var user = new AppUser
            {
                UserName = register.UserName,
                Email = register.EmailAddress,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(new ApiValidationErrorResponse
            { Errors = new[] { "Not Authorized" } });

            if (register.RoleName == "Developer" && await _roleManager.RoleExistsAsync("Developer"))

                await _userManager.AddToRoleAsync(user, "Developer");

            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email
            };


        }
        public async Task<ActionResult<bool>> CheckUserNameExistsAsync([FromQuery] string username)
        {
            return await _userManager.FindByNameAsync(username) != null;
        }
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
