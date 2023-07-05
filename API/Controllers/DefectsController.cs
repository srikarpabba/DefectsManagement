namespace API.Controllers
{
    public class DefectsController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IDefectsManagementService _defectsManagement;
        public DefectsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IDefectsManagementService defectsManagement)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _defectsManagement = defectsManagement;

        }

        [HttpPost("new")]
        public async Task<ActionResult> AddNewDefect(DefectDto defect)
        {
            if (defect == null)
            {
                return BadRequest();
            }
            try
            {
                await _defectsManagement.CreateDefect(defect);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDefects()
        {
            try
            {
                var defects = await _defectsManagement.GetAllDefects();
                return Ok(defects);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{defectid}")]
        public async Task<IActionResult> GetDefectById(int defectid)
        {
            try
            {
                var defect = await _defectsManagement.GetDefectById(defectid);
                return Ok(defect);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("resolve/{defectid}")]
        public async Task<IActionResult> SubmitResolution(int defectid, ResolutionDto resolution)
        {
            try
            {                
                await _defectsManagement.ProvideResolution(resolution);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("priorities")]
        public List<string> GetPriorities()
        {
            List<string> priorities = Enum.GetNames(typeof(Priority)).ToList();
            return priorities;
        }

        [HttpGet("severities")]
        public List<string> GetSeverities()
        {
            List<string> severities = Enum.GetNames(typeof(Severity)).ToList();
            return severities;
        }
    }
}
