import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatTable, MatTableDataSource } from '@angular/material';
import { Container } from 'src/app/shared/models/container';
import { AlertService } from 'src/app/shared/services/alert.service';
import { ContainerService } from 'src/app/shared/services/container.service';
import { AddEditContainerDialogBoxComponent } from './add-edit-container-dialog-box/add-edit-container-dialog-box.component';

@Component({
  selector: 'app-containers',
  templateUrl: './containers.component.html',
  styleUrls: ['./containers.component.css']
})
export class ContainersComponent implements OnInit {
  containers: Container[];
  Container: Container = new Container();
  pageLength: number = 0;

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  filteredContainer: Container[] = [];
  displayedColumns: string[] = ["containerNo", "containerType", "color", "action"];
  tableDataResource = new MatTableDataSource<Container>();

  constructor(
    private _containerService: ContainerService,
    public dialog: MatDialog,
    protected _alertService: AlertService
  ) {}

  ngOnInit() {
    this.getContainers();
  }

  getContainers() {
    this._containerService
      .getContainers()
      .subscribe((containers) => {
        this.containers = containers;
        console.log();
        this.pageLength = this.containers.length;
        this.onPageChanged(null);
      });
  }

  openDialog(action: any, container) {
    container.action = action;
    let width = "400px";
    let height = "500px";
    if (action === "Delete") {
      width = "350px";
      height = "350px";
    }
    const dialogRef = this.dialog.open(AddEditContainerDialogBoxComponent, {
      width: width,
      height: height,
      data: container,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result.event !== "Cancel") {
        if (action === "Add") {
          this.addContainer(result.data);
        } else if (action === "Update") {
          this.updateContainer(result.data);
        } else if (action === "Delete") {
          this.deleteContainer(result.data);
        }
      }
    });
  }

  addContainer(container: Container) {
    this._containerService
      .addContainer(container)
      .then(() => {
        this.refreshTable();
        this._alertService.success("Container was saved successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not saved, please try again");
      });    
  }

  updateContainer(container: Container) {
    this._containerService
      .updateContainer(container)
      .then(() => {
        this.refreshTable();
        this._alertService.success("Container was updated successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not updated, please try again");
      });    
  }

  deleteContainer(container: Container) {
    this._containerService
      .deleteContainer(container)
      .then(() => {
        this.refreshTable();
        this._alertService.success("Container was deleted successfully !!");
      })
      .catch(() => {
        this._alertService.error("Data was not deleted, please try again");
      });
  }

  refreshTable() {
    this.getContainers();
  }

  private initializeTable(containers: Container[]) {
    this.tableDataResource = new MatTableDataSource<Container>(containers);
  }

  filter(query: any) {
    let searchTerm = query.target.value.toLocaleLowerCase();
    const filteredContainers = searchTerm
      ? this.containers.filter((p) => p.containerType.type.toLowerCase().includes(searchTerm) 
      || p.color.toLowerCase().includes(searchTerm)
      || p.containerNo.toLowerCase().includes(searchTerm))
      : this.containers;

    this.initializeTable(filteredContainers);
  }

  onPageChanged(e: { pageIndex: number; pageSize: number }): void {
    let containers = [];
    if (e == null) {
      let firstCut = 0;
      let secondCut = firstCut + 10;
      containers = this.containers.slice(firstCut, secondCut);
    } else {
      let firstCut = e.pageIndex * e.pageSize;
      let secondCut = firstCut + e.pageSize;
      containers = this.containers.slice(firstCut, secondCut);
    }
    this.initializeTable(containers);
  }
}
