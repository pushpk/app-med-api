import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ResourcesService {
  http: any;
  constructor($http, public apiEndPoint: any) {
    this.http = $http;
  }

  search(query: string) {
    let api_host = environment.apiUrl;
    return this.http.get(api_host + this.apiEndPoint, { params: { query: query.toLowerCase() } }).toPromise()
      .then(function (response: { data: any }) {
        return response.data;
      })
      .catch((error: any) => {
        return error;
      });
  }
}
