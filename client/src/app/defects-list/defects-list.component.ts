import { Component, OnInit } from '@angular/core';
import { DefectsService } from '../defects-list/defects-list.service';
import { Defect } from '../models/defect';

@Component({
  selector: 'app-defects-list',
  templateUrl: './defects-list.component.html',
  styleUrls: ['./defects-list.component.scss']
})
export class DefectsListComponent implements OnInit {

  defects: Defect[] = [];

  constructor(private defectsService: DefectsService) { }

  ngOnInit(): void {
    this.getDefects();
  }

  getDefects() {    
    this.defectsService.getDefects().subscribe({
      next: defects => this.defects = defects
    })
  }
}
