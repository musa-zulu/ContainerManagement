import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatDialogModule, MatFormFieldModule, MatInputModule, MatPaginatorModule, MatSortModule, MatTableModule } from '@angular/material';
import { CustomFormsModule } from 'ng2-validation';
import { CommonModule } from '@angular/common';
import { ContainersComponent } from './components/containers/containers.component';
import { AddEditContainerDialogBoxComponent } from './components/containers/add-edit-container-dialog-box/add-edit-container-dialog-box.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AlertComponent } from './shared/components/alert/alert.component';
import { AlertService } from './shared/services/alert.service';
import { ContainerService } from './shared/services/container.service';
import { ContainerTypesComponent } from './components/container-types/container-types.component';
import { ContainerTypeService } from './shared/services/container-type.service';
import { AddEditContainerTypeDialogBoxComponent } from './components/container-types/add-edit-container-type-dialog-box/add-edit-container-type-dialog-box.component';

@NgModule({
  declarations: [
    AppComponent,
    ContainersComponent,
    AddEditContainerDialogBoxComponent,
    NavBarComponent,
    AlertComponent,
    ContainerTypesComponent,
    AddEditContainerTypeDialogBoxComponent
  ],
  imports: [
    FormsModule,
    CustomFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgbModule,
    AngularFontAwesomeModule,
    MatTableModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    CommonModule,
    MatPaginatorModule,    
    MatSortModule
  ],
  entryComponents: [AddEditContainerDialogBoxComponent, AddEditContainerTypeDialogBoxComponent],
  providers: [AlertService, ContainerService, ContainerTypeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
