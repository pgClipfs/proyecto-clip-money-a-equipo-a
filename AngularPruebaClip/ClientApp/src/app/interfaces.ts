

export interface Cliente {
  Id: number,
  NombreUsuario: string,
  Contraseña: string;
  Nombre: string,
  Apellido: string,
  DNI: string,
  Domicilio: string,
  Telefono: string,
  Cuil: string,
  CorreoElectronico: string
}


export interface MyResponse {
  Success: Number,
  Data: any,
  Message: string
}
