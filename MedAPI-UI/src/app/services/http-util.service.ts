import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CheckEmptyUtil } from '../shared/util/check-empty.util';

@Injectable({
  providedIn: 'root'
})
export class HttpUtilService {

  constructor(private httpClient: HttpClient) { }

  invoke(method, postBody, endPoint) {
    const url = environment.apiUrl + endPoint;
    const requestHeaders: any = {
      'Content-Type': 'application/json',
      Accept: 'application/json'
    };

    const headers = new HttpHeaders(requestHeaders);
    const body = CheckEmptyUtil.isNotEmptyObject(postBody) ? postBody : null;

    const promise = new Promise((resolve, reject) => {
      this.httpClient.request(method, url, { body, headers })
        .toPromise()
        .then((response: any) => {
          return resolve(response);
        })
        .catch((error) => {
          return reject(error);
        });
    });
    return promise;
  }


  invokeQuery(method, params, endPoint) {
    let url = environment.apiUrl + endPoint;
    const requestHeaders: any = {
      'Content-Type': 'application/json',
      Accept: 'application/json'
    };

    const headers = new HttpHeaders(requestHeaders);
    url = url + '?' + params.key + '=' + params.value;

    const promise = new Promise((resolve, reject) => {
      this.httpClient.request(method, url, { headers })
        .toPromise()
        .then((response: any) => {
          return resolve(response);
        })
        .catch((error) => {
          return reject(error);
        });
    });
    return promise;
  }

}
