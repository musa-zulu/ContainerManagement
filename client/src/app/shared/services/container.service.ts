import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Container } from '../models/container';
import { ServerConfig } from './server-config';


@Injectable({
  providedIn: 'root'
})
export class ContainerService {
  private readonly _apiURL = "containers";
  constructor(private _http: HttpClient, private _serverConfig: ServerConfig) {}

  getContainers(): Observable<any> {
    return this._http
      .get<Container[]>(
        this._serverConfig.getBaseUrl() + this._apiURL,
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  getContainer(containerId: string): Observable<any> {
    return this._http
      .get<Container>(
        this._serverConfig.getBaseUrl() + this._apiURL + "/" + containerId,         
        this._serverConfig.getRequestOptions()
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  addContainer(container: Container): Promise<any> {
    return this._http
      .post(
        this._serverConfig.getBaseUrl() + this._apiURL,
        container,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  updateContainer(container: Container) {
    return this._http
      .put(
        this._serverConfig.getBaseUrl() + this._apiURL + "/",
        container,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  deleteContainer(container: Container) {
    return this._http
      .delete<Container>(
        this._serverConfig.getBaseUrl() +
          this._apiURL +
          "/" +
          container.containerId,
        this._serverConfig.getRequestOptions()
      )
      .toPromise();
  }

  private handleError(error: any) {
    return Observable.throw(error);
  }
}
