namespace API.Dtos
{
    public class DefectDto
    {
        public int DefectId { get; set; }
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

    public class ResolutionDto
    {
        public int ResolutionId { get; set; }
        public int DefectId { get; set; }
        public string ResolutionDate { get; set; }
        public string Resolution { get; set; }
    }
}
