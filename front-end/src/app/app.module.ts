import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, APP_INITIALIZER } from '@angular/core';
import { NgbModule, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';
// import { ModalModule } from './core/components/modal/modal.module';
import { RouterModule } from '@angular/router';
// import { HotkeyModule } from 'angular2-hotkeys';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import { CoreSharedModule } from './core/core-shared.module';
// import { CoreSharedModule } from './core/core-shared.module';
// import { BcrRoutes } from './shared/data-models/routes';
import { PopupModule } from './core/services/popupService/popup.module';
import { JasperoConfirmationsModule } from '@jaspero/ng-confirmations';
// import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { PopupService } from './core/services/popupService/popup.service';
import { NgxPermissionsModule, NgxPermissionsService } from 'ngx-permissions';
// import { TreeModule } from 'angular-tree-component';
import { environment } from '../environments/environment';
// import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgProgressModule } from '@ngx-progressbar/core';
// import { NgProgressRouterModule } from '@ngx-progressbar/router';
import { ToastrModule } from 'ngx-toastr';
import { AngularMaterialModule } from './shared/angular-material/angular-material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LaboratorioProcesosComponent } from './monitoreo/laboratorio-procesos/laboratorio-procesos.component';
import { ToolbarComponent } from './home/toolbar/toolbar/toolbar.component';
import { HomeComponent } from './home/home.component';
import { LaboratorioProcesosIndicadorComponent } from './monitoreo/laboratorio-procesos/laboratorio-procesos-indicador/laboratorio-procesos-indicador.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    LoginComponent,
    LaboratorioProcesosComponent,
    ToolbarComponent,
    HomeComponent,
    LaboratorioProcesosIndicadorComponent,
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  imports: [
    BrowserModule,
    // ModalModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    PopupModule,
    // NgxDatatableModule,
    // HotkeyModule.forRoot(),
    JasperoConfirmationsModule.forRoot(),
    NgbModule,
    FormsModule,
    // RouterModule.forRoot(BcrRoutes),
    ReactiveFormsModule,
    // CoreSharedModule,
    // SharedModule,
    NgxPermissionsModule.forRoot(),
    // TreeModule.forRoot(),
    // FontAwesomeModule,
    // NgbTimepickerModule,
    NgProgressModule.withConfig({
      spinner: false,
      color: '#4d9d45'
    }),
    // NgProgressRouterModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    AngularMaterialModule,
    FlexLayoutModule,
  ],
  providers: [
    PopupService,
    {
      provide: APP_INITIALIZER,
      useFactory: (ngxPermissionsService: NgxPermissionsService) => () => {
        const permisos = ngxPermissionsService.getPermissions();
        if (Object.keys(permisos).length === 0) {
          const jsonPermissions = localStorage.getItem(environment.permissionsKey);
          if (jsonPermissions) {
            const perms = JSON.parse(jsonPermissions);
            ngxPermissionsService.loadPermissions(perms);
          }
        }
        return Promise.resolve(true);
      },
      deps: [NgxPermissionsService],
      multi: true
    }
  ]
})
export class AppModule { }
