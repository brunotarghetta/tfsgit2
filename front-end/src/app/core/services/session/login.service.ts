import { Injectable } from '@angular/core';
import { ApiService } from '../restClient/api.service';
import { JwtSecurityToken } from './jwt-security-token';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class LoginService {

  constructor(
    private readonly apiService: ApiService) { }

  login(usuario: string, contrasenia: string): Observable<JwtSecurityToken> {

    const url = 'login';
    const command = { nombreUsuario: usuario, contrasenia: contrasenia };

    return this.apiService.post<JwtSecurityToken>(url, command);
  }
}
