import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Paciente } from '../liquidacion/models/paciente';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {



  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) 
    {
      this.baseUrl = baseUrl;
    }

    get(): Observable<Paciente[]> {
      return this.http.get<Paciente[]>(this.baseUrl + 'api/Paciente')
          .pipe(
              tap(_ => this.handleErrorService.log('datos enviados')),
              catchError(this.handleErrorService.handleError<Paciente[]>('Consulta Paciente', null))
          );
    }
    post(paciente: Paciente): Observable<Paciente> {
      return this.http.post<Paciente>(this.baseUrl + 'api/Paciente', paciente)
          .pipe(
              tap(_ => this.handleErrorService.log('datos enviados')),
              catchError(this.handleErrorService.handleError<Paciente>('Registrar Paciente', null))
          );
    }
  }
