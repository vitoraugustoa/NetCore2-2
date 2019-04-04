import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

import { Cliente } from '../Models/Cliente';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

const UrlBase = "https://localhost:5001/";

@Injectable() // Todo serviço utiliza este decorator
export class ClienteService {
  constructor(private http: HttpClient) { }

  // GET
  public getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(UrlBase + "api/clientes")
      .pipe(
         tap(clientes => console.log('leu os clientes')),
      catchError(this.handdleError('getClientes', []))
      );
  }

  // GET {id}
  public getClienteById(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(UrlBase + "api/clientes/" + id)
      .pipe(
         tap(_ => console.log(`Leu o cliente id= ${id}`)),
      catchError(this.handdleError<Cliente>(`get Cliente id=${id}`))
      );
  }

  // POST
public addCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(UrlBase + "api/clientes/", cliente, httpOptions).pipe(
      tap((cliente: Cliente) => console.log(`adicionou o cliente com w/ id=${cliente.id}`)),
      catchError(this.handdleError<Cliente>('addCliente'))
    );
  }

  // PUT
  public updateCliente(id: number, cliente: Cliente): Observable<any> {
    return this.http.put(UrlBase + "api/clientes/" + id, cliente, httpOptions).pipe(
      tap(_ => console.log(`atualiza o cliente com id=${id}`)),
      catchError(this.handdleError<any>('updateCliente'))
    );
  }

  //DELETE
  public deleteCliente(id: number): Observable<Cliente> {
    return this.http.delete<Cliente>(UrlBase + "api/clientes/" + id, httpOptions).pipe(
      tap(_ => console.log(`remove o cliente com id=${id}`)),
      catchError(this.handdleError<Cliente>('deleteCliente'))
    );
  }

  private handdleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    }
  }

}
