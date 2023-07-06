import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Defect } from '../shared/models/defect';


@Injectable({
  providedIn: 'root'
})
export class DefectsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDefects() {
    return this.http.get<Defect[]>(this.baseUrl + 'defects');
  }
  getDefectById(id: number) {
    return this.http.get<Defect>(this.baseUrl + 'defects/' + id);
  }

  provideResolution(values: any, id: number) {
    return this.http.post(this.baseUrl + 'defects/resolve/' + id, values);
  }
}