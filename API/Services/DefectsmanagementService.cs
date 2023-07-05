namespace API.Services
{
    public class DefectsmanagementService : IDefectsManagementService
    {
        private readonly AppIdentityDbContext _dbContext;

        public DefectsmanagementService(AppIdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateDefect(DefectDto defect)
        {

            if (defect == null)
            {
                throw new ArgumentNullException(nameof(defect));
            }
            Defect df = new()
            {
                Title = defect.Title,
                DefectDetails = defect.DefectDetails,
                StepsToReproduce = defect.StepsToReproduce,
                Priority = defect.Priority,
                Severity = defect.Severity,
                DetectedOn = defect.DetectedOn,
                ExpectedResolution = defect.ExpectedResolution,
                ReportedByTesterId = defect.ReportedByTesterId,
                AssignedToDevloperId = defect.AssignedToDevloperId,
                Status = Status.Active.ToString(),
            };
            await _dbContext.Defects.AddAsync(df);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Defect>> GetAllDefects()
        {
            List<Defect> defects = new();
            defects = await _dbContext.Defects.Where(t => t.Status != Status.Resolved.ToString()).ToListAsync();

            return defects;
        }

        public async Task<Defect> GetDefectById(int id)
        {
            Defect defect = new();
            defect = await _dbContext.Defects.Where(t => t.Id == id).FirstOrDefaultAsync();

            return defect;
        }
        public async Task ProvideResolution(ResolutionDto resolution)
        {           
            var x = await _dbContext.Defects.Where(t => t.Id == resolution.DefectId).FirstOrDefaultAsync();
            if(x != null)
            {
                Resolution res = new()
                {
                    ResolutionDesc = resolution.Resolution,
                    ResolutionDate = DateTime.Now.ToString(),
                    DefectId = resolution.DefectId,
                };
                x.Status = Status.Resolved.ToString();
                await _dbContext.Resolutions.AddAsync(res);
                await _dbContext.SaveChangesAsync();
            }            
        }
    }
}
