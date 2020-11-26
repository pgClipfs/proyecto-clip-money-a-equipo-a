import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import {FormControl} from '@angular/forms'
import { UserService } from '../service/user.service';


@Component({
  selector: 'user-app',
  templateUrl: "./user.component.html",
  styleUrls: ["./user.component.css"]
})

export class UserComponent {
  public lstMessages: string[];

  nombreUsuarioControl = new FormControl('');
  contraseniaControl = new FormControl('');
  nombreControl = new FormControl('');
  apellidoControl = new FormControl('');
  dniControl = new FormControl('');
  domicilioControl = new FormControl('');
  correoElectronicoControl = new FormControl('');
  telefonoControl = new FormControl('');
  cuilControl = new FormControl('');



  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected userService: UserService) {

  }

  public SendInfo() {
    this.userService.Add(this.nombreUsuarioControl.value, this.contraseniaControl.value, this.nombreControl.value, this.apellidoControl.value,
    this.dniControl.value, this.domicilioControl.value, this.correoElectronicoControl.value, this.telefonoControl.value, this.cuilControl.value);

    this.nombreUsuarioControl.setValue('');
    this.contraseniaControl.setValue('');
    this.nombreControl.setValue('');
    this.apellidoControl.setValue('');
    this.dniControl.setValue('');
    this.correoElectronicoControl.setValue('');
    this.telefonoControl.setValue('');
    this.cuilControl.setValue('');
    this.domicilioControl.setValue('');

    

  }

}

interface Cliente {
  Id: number,
  NombreUsuario: string,
  Contraseña: string,
  Nombre: string,
  Apellido: string,
  DNI: string,
  Domicilio: string,
  Telefono: string,
  Cuil: string,
  CorreoElectronico: string
  
}


