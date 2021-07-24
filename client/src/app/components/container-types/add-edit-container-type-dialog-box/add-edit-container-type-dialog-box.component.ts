import { Inject, Optional } from '@angular/core';
import { Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ContainerType } from 'src/app/shared/models/conainer-type';

@Component({
  selector: 'app-add-edit-container-type-dialog-box',
  templateUrl: './add-edit-container-type-dialog-box.component.html',
  styleUrls: ['./add-edit-container-type-dialog-box.component.css']
})
export class AddEditContainerTypeDialogBoxComponent {

  action: string;
  localData: any;
  containerType: ContainerType = new ContainerType();

  constructor(    
    public dialogRef: MatDialogRef<AddEditContainerTypeDialogBoxComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: ContainerType
  ) {
    this.localData = { ...data };
    this.action = this.localData.action;
  }
 
  doAction() {
    this.dialogRef.close({ event: this.action, data: this.localData });
  }

  closeDialog() {
    this.dialogRef.close({ event: "Cancel" });
  }
}
