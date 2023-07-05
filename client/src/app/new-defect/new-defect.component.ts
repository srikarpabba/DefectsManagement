import { Component, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Priority } from '../models/priority';
import { Severity } from '../models/severity';
import { NewDefectService } from '../new-defect/new-defect.service';

@Component({
  selector: 'app-new-defect',
  templateUrl: './new-defect.component.html',
  styleUrls: ['./new-defect.component.scss']
})
export class NewDefectComponent implements OnInit, ControlValueAccessor {

  errors: string[] | null = null;
  priorities: Priority[] = [];
  severities: Severity[] = [];
  @Input() type = 'text';
  @Input() label = '';


  constructor(private fb: FormBuilder, private router: Router, private newDefectService: NewDefectService, private toast: ToastrService) { }

  ngOnInit(): void {
    this.getPriorities();
    this.getSeverities();
  }
  writeValue(obj: any): void {
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }

  newDefectForm = this.fb.group({
    title: ['', Validators.required],
    defectDetails: ['', [Validators.required]],
    stepsToReproduce: ['', [Validators.required]],
    priority: ['', [Validators.required]],
    severity: ['', [Validators.required]],
    detectedOn: ['', Validators.required],
    expectedResolution: ['', Validators.required],
    reportedByTesterId: ['', Validators.required],
    assignedToDevloperId: ['', Validators.required],
    //status: ['', Validators.required],
    //resolution: ['', Validators.required],
  })

  // convenience getter for easy access to form fields
  get f() { return this.newDefectForm.controls; }

  onSubmit() {    
    this.newDefectService.newDefectReport(this.newDefectForm.value).subscribe({
      next: () => {
        this.toast.success('Successfully submitted new defect', 'Success')
        this.router.navigateByUrl('/newdefect')
        this.newDefectForm.reset({
          severity: ""
        })
      },
      error: error => {
        this.toast.error('Problem adding new defect', 'Error');
        console.log(error);
      }
    })
  }

  getPriorities() {
    this.newDefectService.getPriorities().subscribe({
      next: pr => this.priorities = pr
    })
  }
  getSeverities() {
    this.newDefectService.getSeverties().subscribe({
      next: response => this.severities = response
    })
  }

  onSeverityChange(event: any) {
    this.severity?.setValue(event.target.value);
  }

  get severity() {
    return this.newDefectForm.get('severity');
  }

}
