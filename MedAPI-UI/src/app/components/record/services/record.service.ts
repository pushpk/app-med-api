import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../../services/http-util.service';

@Injectable({
  providedIn: 'root'
})
export class RecordService {

  constructor(private httpUtilService: HttpUtilService) { }

  getPatientsByDocNumber(documentNumber: any) {
    const self = this;
    const apiEndpoint = 'record/patient';
    const params = {
      key: 'documentNumber',
      value: documentNumber
    }
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  getPatientsByTicketNumber(ticketNumber: any) {
    const self = this;
    const apiEndpoint = 'record/patient';
    const params = {
      key: 'id',
      value: ticketNumber
    }
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }
}
