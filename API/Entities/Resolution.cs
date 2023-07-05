namespace API.Entities
{
    public class Resolution : BaseEntity
    {
        public Defect Defects { get; set; }
        public int DefectId { get; set; }
        public string ResolutionDate { get; set; }
        public string ResolutionDesc { get; set; }
    }
}
