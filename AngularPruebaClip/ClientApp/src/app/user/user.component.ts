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


  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string,
    protected userService: UserService) {

  }

  public SendInfo() {
    this.userService.Add(this.nombreUsuarioControl.value, this.contraseniaControl.value);

    this.nombreUsuarioControl.setValue('');
    this.contraseniaControl.setValue('');

  }

}

interface Cliente {
  Id: number,
  NombreUsuario: string,
  Contraseña: string,

}


