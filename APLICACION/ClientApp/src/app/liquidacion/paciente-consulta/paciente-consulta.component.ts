import { Component, OnInit } from '@angular/core';
import { Paciente } from '../models/paciente';
import { PacienteService } from 'src/app/services/paciente.service';

@Component({
  selector: 'app-paciente-consulta',
  templateUrl: './paciente-consulta.component.html',
  styleUrls: ['./paciente-consulta.component.css']
})
export class PacienteConsultaComponent implements OnInit {

  pacientes:Paciente[];
  constructor(private pacienteService: PacienteService) { }

  ngOnInit() {

    this.pacienteService.get().subscribe(result => {
      this.pacientes = result;
    });

  }
}