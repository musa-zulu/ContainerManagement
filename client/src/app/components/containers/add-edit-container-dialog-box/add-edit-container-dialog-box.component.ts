import { Component, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Container } from 'src/app/shared/models/container';
import { ContainerTypeService } from 'src/app/shared/services/container-type.service';

@Component({
  selector: 'app-add-edit-container-dialog-box',
  templateUrl: './add-edit-container-dialog-box.component.html',
  styleUrls: ['./add-edit-container-dialog-box.component.css']
})
export class AddEditContainerDialogBoxComponent {

  action: string;
  localData: any;
  containerTypes$;
  container: Container = new Container();

  constructor(
    private _containerTypeService: ContainerTypeService,
    public dialogRef: MatDialogRef<AddEditContainerDialogBoxComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Container) {
    console.log(data);
    this.localData = {...data};
    this.action = this.localData.action;

    this._containerTypeService.getContainerTypes().subscribe((containerTypes) => {
      this.containerTypes$ = containerTypes;
      console.log();
    });
  }

  doAction() {
    this.dialogRef.close({event: this.action, data: this.localData});
  }

  closeDialog() {
    this.dialogRef.close({event: 'Cancel'});
  }
}
