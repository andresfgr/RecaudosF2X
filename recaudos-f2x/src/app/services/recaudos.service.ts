import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecaudosService {
  urlRecaudos = 'http://localhost:24353/api/RecaudoVehiculos';
  urlExportRecaudos = 'http://localhost:24353/api/RecaudoVehiculos/ExportarRecaudos';
  
  constructor(private http: HttpClient) { }

  getRecaudos(): Observable<any> {
    return this.http.get(this.urlRecaudos);
  }

  exportRecaudos(): Observable<any> {
    return this.http.post(this.urlExportRecaudos, '');
  }
}
