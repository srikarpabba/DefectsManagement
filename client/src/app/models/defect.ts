export interface Defect {
    id: number;
    title: string;
    defectDetails: string;
    stepsToReproduce: string;
    severity: string;
    priority: string;
    detectedOn: string;
    expectedResolution: string;
    reportedByTesterId: string;
    assignedToDevloperId: string;
    status: string;
  }