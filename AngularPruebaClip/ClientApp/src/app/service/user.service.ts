
import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MyResponse } from '../interfaces';
import { error } from 'protractor';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization':'my-auth-token'
  })
}
@Injectable({

  providedIn: 'root'

})

export class UserService {
  public algo: string = 'hola'
  baseUrl: string;


  constructor(protected http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  public Add(nombreUsuario, contraseña) {
    this.http.post<MyResponse>(this.baseUrl + 'api/Cliente/Add',
      { 'NombreUsuario': nombreUsuario, 'Contraseña': contraseña }, httpOptions).
      subscribe
      (result => {
          console.log(result);
      },
        error => console.error(error));
  }

}
