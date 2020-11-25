import { Component, OnInit } from "@angular/core";
import { APiauthService } from "../service/apiauth.service";


@Component({
  
  templateUrl: 'login.component.html',
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {

  public nombreUsuario: string;
  public contrasenia: string;



  constructor(public apiauth: APiauthService) {

  }

  ngOnInit() {

  }

  login() {
    this.apiauth.login(this.nombreUsuario, this.contrasenia).subscribe(response => {
      console.log(response);
    })

  }


}
