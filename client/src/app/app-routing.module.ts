import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContainerTypesComponent } from './components/container-types/container-types.component';
import { ContainersComponent } from './components/containers/containers.component';

const routes: Routes = [
  {path: '', redirectTo: '/containers', pathMatch: 'full'},
  {path: 'containers', component: ContainersComponent},
  {path: 'containerTypes', component: ContainerTypesComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
