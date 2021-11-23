import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListarRecaudosComponent } from './components/listar-recaudos/listar-recaudos.component';

import { HttpClientModule } from '@angular/common/http';
import { AgGridModule } from 'ag-grid-angular';
import { ExportarRecaudosComponent } from './components/exportar-recaudos/exportar-recaudos.component';

@NgModule({
  declarations: [
    AppComponent,
    ListarRecaudosComponent,
    ExportarRecaudosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AgGridModule.withComponents([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
