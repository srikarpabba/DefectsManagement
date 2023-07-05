namespace API.Entities
{
    public class Defect : BaseEntity
    {        
        public string Title { get; set; }
        public string DefectDetails { get; set; }
        public string StepsToReproduce { get; set; }
        public string Severity { get; set; }
        public string Priority { get; set; }
        public string DetectedOn { get; set; }
        public string ExpectedResolution { get; set; }
        public string Status { get; set; }
        public string ReportedByTesterId { get; set; }
        public string AssignedToDevloperId { get; set; }        

    }
}
