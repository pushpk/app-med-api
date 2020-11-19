import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { LabUploadResult } from 'src/app/models/labUploadResult';
import { environment } from 'src/environments/environment';
import { Symptoms } from 'src/app/models/symptoms.model';

@Injectable({
  providedIn: 'root'
})
export class RecordService {
  public patientId: BehaviorSubject<any> = new BehaviorSubject('');
  public ticketNumber: BehaviorSubject<any> = new BehaviorSubject('');
  public selectedSpecialty: BehaviorSubject<string> = new BehaviorSubject('');
  public passwordHash = new BehaviorSubject<string>(undefined);

  constructor(private httpUtilService: HttpUtilService, private httpClient: HttpClient) { }

  uploadResult(fileToUpload: File, labUploadResult: LabUploadResult)
  {
    const formData: FormData = new FormData();
    formData.append('uploadFile', fileToUpload, fileToUpload.name);
    formData.append('comments', labUploadResult.comments);
    formData.append('userId', labUploadResult.user_id.toString());

    if(labUploadResult.labId == 0)
    {
      formData.append('labId', null);
      formData.append('medicId', labUploadResult.medicId.toString());

    }
    else{
      formData.append('labId', labUploadResult.labId.toString());
      formData.append('medicId', null);
    }



    return this.httpClient.post(environment.apiUrl + 'users/lab-upload-result', formData);
    // return this.httpUtilService.invoke('POST', formData, , null);
  }

  getUploadResultByLabID(labId : number){
    const self = this;
    const apiEndpoint = 'users/lab-uploads-by-lab';
    const params = {
      key: 'labId',
      value: labId
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }


  getUploadResultByPatientID(patientId: number){
    const self = this;
    const apiEndpoint = 'users/lab-uploads-by-patient';
    const params = {
      key: 'patientId',
      value: patientId
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }


  getSymptoms(){
      const self = this;
      const apiEndpoint = 'users/GetPatientSymptoms';

    return self.httpUtilService.invokeQuery('GET', null, apiEndpoint);
  }

  getSymptomsForPatient(docNumber : string ){  
    const self = this;
    const apiEndpoint = 'users/GetSymptomsByPatientID';

    const params = {
      key: 'documentNumber',
      value: docNumber
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
}

  saveSymptoms(docNum: string, symptoms: Symptoms[], customSymptoms: any)
  {

    var symptomsPatient = {

      documentNumber : docNum,
      symptoms: symptoms,
      Custom_Symptom : customSymptoms
    };

    return this.httpUtilService.invoke('POST', symptomsPatient, '/users/SavePatientSymptoms', null);
  }


  getUploadResultFile(id: number): Observable<Blob> {
      const apiEndpoint = environment.apiUrl + 'users/GetTestResultFile';
      const formData: FormData = new FormData();
      formData.append('id', id.toString());

      return this.httpClient.post(apiEndpoint, formData, {responseType: 'blob'});  
  }

  getPatientsByDocNumber(documentNumber: any) {
    const self = this;
    const apiEndpoint = 'record/patient';
    const params = {
      key: 'documentNumber',
      value: documentNumber
    };
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
