import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { MyResponse } from "../interfaces";


const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'

})
export class APiauthService {
  url: string = 'https://localhost:44397/api/Verificacion/login';


  constructor(private _http: HttpClient ) {

  }

  login(nombreUsuario: string, contraseña: string): Observable<MyResponse> {
    return this._http.post<MyResponse>(this.url, { nombreUsuario, contraseña }, httpOption);
  }
  

}
