import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PacienteRegistroComponent } from './liquidacion/paciente-registro/paciente-registro.component';
import { PacienteConsultaComponent } from './liquidacion/paciente-consulta/paciente-consulta.component';



const routes: Routes = [
  {
  path: 'pacienteRegistro',
  component: PacienteRegistroComponent
  },

  {
    path: 'pacienteConsulta',
    component: PacienteConsultaComponent
  }
];



@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
