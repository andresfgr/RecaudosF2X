import { Component, OnInit } from '@angular/core';

import { Recaudos } from './../../models/recaudos';
import { RecaudosService } from './../../services/recaudos.service';

@Component({
  selector: 'app-exportar-recaudos',
  templateUrl: './exportar-recaudos.component.html',
  styleUrls: ['./exportar-recaudos.component.css']
})
export class ExportarRecaudosComponent implements OnInit {
  listadoRecaudos: Recaudos[] = [];
  recaudos: Recaudos[] = [];
  estaciones: String[] = [];
  fechas: String[] = [];
  fecha:any;
  estacion:any;
  totalesCantidad:any;
  totalesValor:any;
  totalCantidad:any;
  totalValor:any;
  totalesFoot: any[] = [];

  constructor(private _recaudoService: RecaudosService) { }

  ngOnInit(): void {
    this.exportarRecaudos();
  }

  exportarRecaudos() {
    this._recaudoService.exportRecaudos().subscribe(data => {
      this.listadoRecaudos = data.recaudos;
      this.estaciones = data.estaciones;
      this.fechas = data.fechas;
      this.totalesCantidad = 0;
      this.totalesValor = 0;

      for (const keyEstacion in  data.estaciones) {
        this.totalCantidad = 0;
        this.totalValor = 0;
        if (Object.prototype.hasOwnProperty.call(data.estaciones, keyEstacion)) {
          this.estacion =  data.estaciones[keyEstacion];
          for (const key in data.recaudos) {
            if (Object.prototype.hasOwnProperty.call(data.recaudos, key)) {
              const element = data.recaudos[key];
              if (element.estacion == this.estacion) {
                this.totalCantidad = this.totalCantidad + element.cantidad;
                this.totalValor = this.totalValor + element.valorTabulado;
              }
            }
          }
        }
        this.totalesFoot.push([this.totalCantidad, this.totalValor]);
        this.totalesCantidad = this.totalesCantidad + this.totalCantidad;
        this.totalesValor = this.totalesValor + this.totalValor;
      }

      for (const keyFecha in  data.fechas) {
        if (Object.prototype.hasOwnProperty.call(data.fechas, keyFecha)) {
          this.fecha =  data.fechas[keyFecha];
          for (const keyEstacion in  data.estaciones) {
            if (Object.prototype.hasOwnProperty.call(data.estaciones, keyEstacion)) {
              this.estacion =  data.estaciones[keyEstacion];
              for (const key in data.recaudos) {
                if (Object.prototype.hasOwnProperty.call(data.recaudos, key)) {
                  const element = data.recaudos[key];
                  if (element.fecha == this.fecha && element.estacion == this.estacion) {
                    this.recaudos.push(element);
                  }
                }
              }
            }
          }
        }
      }
    }, errror => {
      console.log(errror);
    }); 
  }
}
