import { ExportarRecaudosComponent } from './components/exportar-recaudos/exportar-recaudos.component';
import { ListarRecaudosComponent } from './components/listar-recaudos/listar-recaudos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component:ListarRecaudosComponent},
  {path: 'ExportarRecaudos', component:ExportarRecaudosComponent},
  {path: '**', redirectTo:'', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
