import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefectDetailsComponent } from './defect-details/defect-details.component';
import { DefectsListComponent } from './defects-list/defects-list.component';
import { NewDefectComponent } from './new-defect/new-defect.component';

const routes: Routes = [  
  {path: 'newdefect', component: NewDefectComponent}, 
  {path: 'defects', component: DefectsListComponent},
  {path: 'defects/:id', component: DefectDetailsComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
