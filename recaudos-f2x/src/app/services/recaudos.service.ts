import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecaudosService {
  urlRecaudos = 'http://localhost:24353/api/RecaudoVehiculos';
  urlExportExcelRecaudos = 'http://localhost:24353/api/RecaudoVehiculos/ExportExcel';
  
  constructor(private http: HttpClient) { }

  getRecaudos(): Observable<any> {
    return this.http.get(this.urlRecaudos);
  }

  exportExcelRecaudos(): Observable<any> {
    return this.http.post(this.urlExportExcelRecaudos, '');
  }
}
