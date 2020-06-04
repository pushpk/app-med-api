import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ResourcesService {

  constructor(private http: HttpClient) {
  }

  search(query: string, apiEndPoint) {
    let api_host = environment.apiUrl;
    return this.http
      .get(api_host + apiEndPoint, { params: { query: query.toLowerCase() } })
      .toPromise()
      .then((response: any) => {
        return response;
      })
      .catch((error) => {
        return error;
      });
  }
}
