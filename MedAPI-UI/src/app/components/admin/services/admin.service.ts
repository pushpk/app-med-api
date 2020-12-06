import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { LabUploadResult } from 'src/app/models/labUploadResult';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  public patientId: BehaviorSubject<any> = new BehaviorSubject('');
  public ticketNumber: BehaviorSubject<any> = new BehaviorSubject('');
  public selectedSpecialty: BehaviorSubject<string> = new BehaviorSubject('');
  public passwordHash = new BehaviorSubject<string>(undefined);

  constructor(
    private httpUtilService: HttpUtilService,
    private httpClient: HttpClient
  ) {}

  getNonApprovedMedics() {
    const self = this;
    const apiEndpoint = 'users/not-approved-medics';

    return self.httpUtilService.invokeQuery('GET', null, apiEndpoint);
  }

  getNonApprovedLabs() {
    const self = this;
    const apiEndpoint = 'users/not-approved-labs';

    return self.httpUtilService.invokeQuery('GET', null, apiEndpoint);
  }

  approveMedic(id: number) {
    const self = this;
    const apiEndpoint = 'users/approve-medic';
    const params = {
      key: 'id',
      value: id,
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  denyMedic(id: number) {
    const self = this;
    const apiEndpoint = 'users/deny-medic';
    const params = {
      key: 'id',
      value: id,
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  freezeMedic(id: number) {
    const self = this;
    const apiEndpoint = 'users/freeze-medic';
    const params = {
      key: 'id',
      value: id,
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  approveLab(id: number) {
    const self = this;
    const apiEndpoint = 'users/approve-lab';
    const params = {
      key: 'id',
      value: id,
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  denyLab(id: number) {
    const self = this;
    const apiEndpoint = 'users/deny-lab';
    const params = {
      key: 'id',
      value: id,
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  freezeLab(id: number) {
    const self = this;
    const apiEndpoint = 'users/freeze-lab';
    const params = {
      key: 'id',
      value: id,
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }
}
