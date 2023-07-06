import { Component } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { DefectsService } from '../../defects-list/defects-list.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {

  constructor(public accountService: AccountService,private defectsService: DefectsService) { }
  
  logout() {
    this.accountService.logout();
  }  
}