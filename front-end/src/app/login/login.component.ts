import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../core/services/session/login.service';
import { AuthService } from '../core/services/session/auth.service';
import { NavigationService } from '../core/services/navigationService/navigation.service';
import { SecurityService } from '../core/services/session/security.service';
import { NgxPermissionsService } from 'ngx-permissions' ;
import { MenuIdentifiers } from '../shared/enums/enums.enum';
import { Resources } from '../../locale/artifacts/resources';
import { FormComponentService } from '../core/services/formComponent/formComponent.service';
import { Collection } from '../core/models/collection';
import { environment } from '../../environments/environment';
import { MatIconModule } from '@angular/material/icon';
import { PopupService } from '../core/services/popupService/popup.service';
import { NgProgressRef, NgProgress } from '@ngx-progressbar/core';
import { ParametrosService } from '../shared/parametros-service/parametros.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formUsuarioContrasenia: FormGroup;
  ambiente = '';
  version = '';
  muestraContrasenia = true;
  progressRef: NgProgressRef;

  private fcsUsuarioContrasenia: FormComponentService;

  constructor(private readonly formBuilder: FormBuilder,
              private readonly loginService: LoginService,
              private readonly authenticationService: AuthService,
              private readonly navigationService: NavigationService,
              private readonly securityService: SecurityService,
              private readonly permissionsService: NgxPermissionsService,
              private readonly popupService: PopupService,
              private readonly progress: NgProgress,
              private readonly parametrosService: ParametrosService) {
                this.fcsUsuarioContrasenia = new FormComponentService(this.popupService);
              }

  ngOnInit() {
    this.crearForm();
    this.progressRef = this.progress.ref('loginProgress');

    this.version = this.parametrosService.version;
  }

  private crearForm(): void {

    this.formUsuarioContrasenia = this.formBuilder.group({
      usuario: [ {value: '', disabled: false}, Validators.required],
      contrasenia: [{ value: '', disabled: false }, Validators.required]
    });

    this.fcsUsuarioContrasenia.initialize(this.formUsuarioContrasenia);
  }

  ingresar(): void {
    this.progressRef.start();

    const usuario = this.fcsUsuarioContrasenia.getValue('usuario');
    const contrasenia = this.fcsUsuarioContrasenia.getValue('contrasenia');

    this.loginService.login(usuario, contrasenia).subscribe(token => {

      if (token != null) {
        this.authenticationService.setSession(token);

        localStorage.setItem(environment.currentUserKey, usuario);

        this.securityService.getPermissions().subscribe(permissions => {

          if ((permissions && permissions.length === 0) || !permissions) {
            this.popupService.error(Resources.Messages.FaltaConfigurarLosPermisosDeAccesoALasOpcionesDeMenuEnLaPcIngresada);
          }

          localStorage.setItem(environment.permissionsKey, JSON.stringify(permissions));

          this.permissionsService.loadPermissions(permissions);
          this.navigationService.navigate(MenuIdentifiers.Login, MenuIdentifiers.Home);
        });
      }

      this.progressRef.complete();
    });
  }

}
