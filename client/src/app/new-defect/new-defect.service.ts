import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../environments/environment';
import { Priority } from '../models/priority';
import { Severity } from '../models/severity';


@Injectable({
  providedIn: 'root'
})
export class NewDefectService {
  baseUrl = environment.apiUrl;


  constructor(private http: HttpClient, private router: Router) { }

  newDefectReport(values: any) {
        return this.http.post(this.baseUrl + 'defects/new', values)
  }

  getPriorities() {    
    return this.http.get<Priority[]>(this.baseUrl + 'defects/priorities');
  }
  getSeverties() {
    return this.http.get<Severity[]>(this.baseUrl + 'defects/severities');
  }
}
