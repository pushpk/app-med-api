import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject } from 'rxjs';
import { LabUploadResult } from 'src/app/models/labUploadResult';

@Injectable({
  providedIn: 'root'
})
export class RecordService {
  public patientId: BehaviorSubject<any> = new BehaviorSubject('');
  public ticketNumber: BehaviorSubject<any> = new BehaviorSubject('');
  public selectedSpecialty: BehaviorSubject<string> = new BehaviorSubject('');
  public passwordHash = new BehaviorSubject<string>(undefined);

  constructor(private httpUtilService: HttpUtilService) { }

  uploadResult(formData : FormData)
  {
    return this.httpUtilService.invoke('POST', formData, 'users/lab-upload-result', null);
  }

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


  getAttentionByNoteId(noteId: number)
  {
    const self = this;
    const apiEndpoint = 'record/note';
    const params = {
      key: 'id',
      value: noteId
    }

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);

  }
}
