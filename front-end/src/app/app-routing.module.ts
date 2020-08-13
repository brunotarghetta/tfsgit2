import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MenuIdentifiers } from './shared/enums/enums.enum';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { LaboratorioProcesosComponent } from './monitoreo/laboratorio-procesos/laboratorio-procesos.component';


const routes: Routes = [
     {
        path: 'login',
        component: LoginComponent,
        data: {
            title: 'BCR - Login',
            identifier: MenuIdentifiers.Login,
            hide: true
        }
    },
    {
       path: '',
       component: HomeComponent,
       children: [
          {
            path: 'LaboratorioProcesos',
            component: LaboratorioProcesosComponent
        }
        ]
     },
     {
        path: '**',
        component: LoginComponent
     },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
