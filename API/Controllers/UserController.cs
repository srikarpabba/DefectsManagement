namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IUserService _userService;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;

        }

        [HttpGet("developers")]
        public async Task<IActionResult> GetDevelopers()
        {
            try
            {
                var developers = await _userService.GetDevelopers();
                return Ok(developers);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400));
            }
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _userService.GetRoles();
                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest(new ApiResponse(400));
            }
        }
    }
}
