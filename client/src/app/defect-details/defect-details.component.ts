import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DefectsService } from '../defects-list/defects-list.service';
import { Defect } from '../models/defect';

@Component({
  selector: 'app-defect-details',
  templateUrl: './defect-details.component.html',
  styleUrls: ['./defect-details.component.scss']
})
export class DefectDetailsComponent implements OnInit {
  defect?: Defect;

  constructor(private defectsService: DefectsService, private activatedRoute: ActivatedRoute, private fb: FormBuilder, private toast: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.getDefect();
  }

  getDefect() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.defectsService.getDefectById(+id).subscribe({
      next: defect => this.defect = defect
    })
  }

  resolutionForm = this.fb.group({
    resolution: ['', Validators.required],
  })

  onSubmit() {
    debugger;    
    this.defectsService.provideResolution(this.resolutionForm.value, +this.defect?.id!).subscribe({
      next: () => {
        this.toast.success('Successfully provided resolution', 'Success')
        this.toast.success('Closing resolution', 'Success')
        this.router.navigateByUrl('/defects')        
      },
      error: error => {
        this.toast.error('Problem providing resolution', 'Error');
        console.log(error);
      }
    })
  }
}
