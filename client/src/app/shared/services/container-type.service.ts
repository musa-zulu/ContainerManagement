import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ContainerType } from '../models/conainer-type';
import { ServerConfig } from './server-config';

@Injectable({
  providedIn: 'root'
})
export class ContainerTypeService {
  private readonly _apiURL = "container-types";
  constructor(private _http: HttpClient, private _serverConfig: ServerConfig) {}

  getContainerTypes(): Observable<any> {
    return this._http
      .get<ContainerType[]>(
        this._serverConfig.getBaseUrl() + this._apiURL,
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  getContainerType(containerTypeId: string): Observable<any> {
    return this._http
      .get<ContainerType>(
        this._serverConfig.getBaseUrl() + this._apiURL + "/" + containerTypeId,         
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  addContainerType(containerType: ContainerType): Promise<any> {
    return this._http
      .post(
        this._serverConfig.getBaseUrl() + this._apiURL,
        containerType,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  updateContainerType(containerType: ContainerType) {
    return this._http
      .put(
        this._serverConfig.getBaseUrl() + this._apiURL + "/",
        containerType,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  deleteContainerType(containerType: ContainerType) {
    return this._http
      .delete<ContainerType>(
        this._serverConfig.getBaseUrl() +
          this._apiURL +
          "/" +
          containerType.containerTypeId,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  private handleError(error: any) {
    return Observable.throw(error);
  }
}
