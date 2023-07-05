namespace API.Interfaces
{
    public interface IDefectsManagementService
    {
        Task CreateDefect(DefectDto defect);
        Task<List<Defect>> GetAllDefects();
        Task<Defect> GetDefectById(int id);
        Task ProvideResolution(ResolutionDto resolution);
    }
}
