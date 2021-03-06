import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CheckEmptyUtil } from '../shared/util/check-empty.util';

@Injectable({
  providedIn: 'root',
})
export class HttpUtilService {
  constructor(private httpClient: HttpClient) {}

  invoke(method, postBody, endPoint, currentUserEmail) {
    const url = environment.apiUrl + endPoint;
    const requestHeaders: any = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };

    if (CheckEmptyUtil.isNotEmpty(currentUserEmail)) {
      requestHeaders.email = currentUserEmail;
    }
    const headers = new HttpHeaders(requestHeaders);
    const body = CheckEmptyUtil.isNotEmptyObject(postBody) ? postBody : null;

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .request(method, url, { body, headers })
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
      Accept: 'application/json',
    };

    const headers = new HttpHeaders(requestHeaders);

    if (params) {
      url = url + '?' + params.key + '=' + params.value;
    }

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .request(method, url, { headers })
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

  invokeQueryWithTwoParams(method, params1, params2, endPoint) {
    let url = environment.apiUrl + endPoint;
    const requestHeaders: any = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    };

    const headers = new HttpHeaders(requestHeaders);

    if (params1 && params2) {
      url =
        url +
        '?' +
        params1.key +
        '=' +
        params1.value +
        '&' +
        params2.key +
        '=' +
        params2.value;
    }

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .request(method, url, { headers })
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

  invokePostWithFormData(method, postBody, endPoint, currentUserEmail) {
    const url = environment.apiUrl + endPoint;
    const requestHeaders: any = {
      Accept: 'application/json',
    };

    if (CheckEmptyUtil.isNotEmpty(currentUserEmail)) {
      requestHeaders.email = currentUserEmail;
    }
    const headers = new HttpHeaders(requestHeaders);
    const body = postBody;

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .post(url, postBody, { headers: headers })
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

  invokeGetForSign(endPoint) {
    let url = environment.apiUrl + endPoint;

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .get(url)
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

  login(postBody, endPoint, currentUserEmail) {
    const url = environment.loginUrl + endPoint;
    const requestHeaders: any = {
      'Content-Type': 'application/x-www-form-urlencoded',
      Accept: 'application/json',
    };

    if (CheckEmptyUtil.isNotEmpty(currentUserEmail)) {
      requestHeaders.email = currentUserEmail;
    }
    const headers = new HttpHeaders(requestHeaders);
    const body = CheckEmptyUtil.isNotEmptyObject(postBody) ? postBody : null;

    var bdy = this.ObjectsToParams(body);

    const promise = new Promise((resolve, reject) => {
      this.httpClient
        .post(url, bdy, { headers: headers })
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

  ObjectsToParams(obj) {
    var p = [];
    for (var key in obj) {
      p.push(key + '=' + encodeURIComponent(obj[key]));
    }
    return p.join('&');
  }
}
