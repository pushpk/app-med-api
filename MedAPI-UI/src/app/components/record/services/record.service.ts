import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecordService {

  constructor(private httpClient: HttpClient) { }

  getPatientsByDocNumber(documentNumber: any) {
    const self = this;
    const apiEndpoint = 'record/patient';
    const url = environment.apiUrl + apiEndpoint;
    return self.httpClient.get(url + '?documentNumber=' + documentNumber).toPromise().then(
      (response) => {
        return response;
      }
    ).catch((error) => {
      return error;
    });
  }
  getPatientsByTicketNumber(ticketNumber: any) {
    const self = this;
    const apiEndpoint = 'record/patient';
    const url = environment.apiUrl + apiEndpoint;
    return self.httpClient.get(url + '?id=' + ticketNumber).toPromise().then(
      (response) => {
        return response;
      }
    ).catch((error) => {
      return error;
    });
  }
}
