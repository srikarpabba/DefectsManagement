import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefectDetailsComponent } from './defect-details/defect-details.component';
import { DefectsListComponent } from './defects-list/defects-list.component';
import { NewDefectComponent } from './new-defect/new-defect.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'newdefect', component: NewDefectComponent },
  { path: 'defects', component: DefectsListComponent },
  { path: 'defects/:id', component: DefectDetailsComponent },
  {
    path: 'account',
    loadChildren: () => import('./account/account.module').then((mod) => mod.AccountModule),
  },
  {
    path: 'server-error',
    component: ServerErrorComponent
  },
  {
    path: 'not-found',
    component: NotFoundComponent
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
