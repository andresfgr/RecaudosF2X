import { Recaudos } from './../../models/recaudos';
import { RecaudosService } from './../../services/recaudos.service';
import { Component, OnInit } from '@angular/core';
import { ColDef } from 'ag-grid-community';
// import rxjs/Rx;

@Component({
  selector: 'app-listar-recaudos',
  templateUrl: './listar-recaudos.component.html',
  styleUrls: ['./listar-recaudos.component.css']
})
export class ListarRecaudosComponent implements OnInit {
  listadoRecaudos: Recaudos[] = [];
  iscarga : boolean = false;
  columnDefs: ColDef[] = [
      { headerName: 'Estación', field: 'estacion', sortable: true, filter: true },
      { headerName: 'Sentido', field: 'sentido', sortable: true, filter: true },
      { headerName: 'Hora', field: 'hora', sortable: true, filter: true },
      { headerName: 'Categoría', field: 'categoria', sortable: true, filter: true },
      { headerName: 'Cantidad', field: 'cantidad', sortable: true, filter: true },
      { headerName: 'Valor Tabulado', field: 'valorTabulado', sortable: true, filter: true },
      { headerName: 'Fecha', field: 'fecha', sortable: true, filter: true}
  ];

  rowData = [];

  constructor(private _recaudoService: RecaudosService) { }

  ngOnInit(): void {
    this.obtenerRecaudos();
  }

  obtenerRecaudos() {
    this._recaudoService.getRecaudos().subscribe(data => {
      console.log(data);
      this.listadoRecaudos = data;
      this.rowData = data;
      this.iscarga = true;
    }, errror => {
      console.log(errror);
    });
  }

  exportarExcelRecaudos() {
    this._recaudoService.exportExcelRecaudos().subscribe(data => {
      console.log(data);
      
      this.downloadFile(data);
    }, errror => {
      console.log(errror);
    });
    
  }

  downloadFile(data: any) {
    const blob = new Blob([data], { type: 'application/octet-stream' });
    const url= window.URL.createObjectURL(blob);
    window.open(url);
  }
}
