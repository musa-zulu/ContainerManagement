import { Component, OnInit, ViewChild } from "@angular/core";
import { MatDialog, MatTable, MatTableDataSource } from "@angular/material";
import { ContainerType } from "src/app/shared/models/conainer-type";
import { AlertService } from "src/app/shared/services/alert.service";
import { ContainerTypeService } from "src/app/shared/services/container-type.service";
import { AddEditContainerTypeDialogBoxComponent } from "./add-edit-container-type-dialog-box/add-edit-container-type-dialog-box.component";

@Component({
  selector: "app-container-types",
  templateUrl: "./container-types.component.html",
  styleUrls: ["./container-types.component.css"],
})
export class ContainerTypesComponent implements OnInit {
  containerTypes: ContainerType[];
  containerType: ContainerType = new ContainerType();
  pageLength: number = 0;

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  filteredContainerTypes: ContainerType[] = [];
  displayedColumns: string[] = ["type", "action"];
  tableDataResource = new MatTableDataSource<ContainerType>();

  constructor(
    private _containerTypeService: ContainerTypeService,
    public dialog: MatDialog,
    protected _alertService: AlertService
  ) {}

  ngOnInit() {
    this.getContainerTypes();
  }

  getContainerTypes() {
    this._containerTypeService
      .getContainerTypes()
      .subscribe((containerTypes) => {
        this.containerTypes = containerTypes;
        console.log();
        this.pageLength = this.containerTypes.length;
        this.onPageChanged(null);
      });
  }

  openDialog(action: any, containerType) {
    containerType.action = action;
    let width = "400px";
    let height = "300px";
    if (action === "Delete") {
      width = "350px";
      height = "350px";
    }
    const dialogRef = this.dialog.open(AddEditContainerTypeDialogBoxComponent, {
      width: width,
      height: height,
      data: containerType,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.event !== "Cancel") {
        if (action === "Add") {
          this.addContainerType(result.data);
        } else if (action === "Update") {
          this.updateContainerType(result.data);
        } else if (action === "Delete") {
          this.deleteContainerType(result.data);
        }
      }
    });
  }

  addContainerType(containerType: ContainerType) {
    this._containerTypeService
      .addContainerType(containerType)
      .then(() => {
        this._alertService.success("Container Type was saved successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not saved, please try again");
      });
    this.refreshTable();
  }

  updateContainerType(containerType: ContainerType) {
    this._containerTypeService
      .updateContainerType(containerType)
      .then(() => {
        this._alertService.success("Container Type was updated successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not updated, please try again");
      });
    this.refreshTable();
  }

  deleteContainerType(containerType: ContainerType) {
    this._containerTypeService
      .deleteContainerType(containerType)
      .then(() => {
        this._alertService.success("Container Type was deleted successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not deleted, please try again");
      });
    this.refreshTable();
  }

  refreshTable() {
    this.getContainerTypes();
  }

  private initializeTable(containerTypes: ContainerType[]) {
    this.tableDataResource = new MatTableDataSource<ContainerType>(containerTypes);
  }

  filter(query: any) {
    let searchTerm = query.target.value.toLocaleLowerCase();
    const filteredContainerTypes = searchTerm
      ? this.containerTypes.filter((p) => p.type.toLowerCase().includes(searchTerm))
      : this.containerTypes;

    this.initializeTable(filteredContainerTypes);
  }

  onPageChanged(e: { pageIndex: number; pageSize: number }): void {
    let containerTypes = [];
    if (e == null) {
      let firstCut = 0;
      let secondCut = firstCut + 10;
      containerTypes = this.containerTypes.slice(firstCut, secondCut);
    } else {
      let firstCut = e.pageIndex * e.pageSize;
      let secondCut = firstCut + e.pageSize;
      containerTypes = this.containerTypes.slice(firstCut, secondCut);
    }
    this.initializeTable(containerTypes);
  }
}
