import { Injectable } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject } from 'rxjs';
import { Medic } from 'src/app/models/medic.model';
import { LabUser } from 'src/app/models/labUser.model';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);

  constructor(private httpUtilService: HttpUtilService) {}

  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  updateProvinces(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  updateDistricts(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  save(patient: any, userId: number) {
    return this.httpUtilService.invoke(
      'POST',
      patient,
      'users/patient',
      userId
    );
  }

  registerPatient(patient: any) {
    return this.httpUtilService.invoke(
      'POST',
      patient,
      'users/RegisterPatient',
      null
    );
  }

  createMedic(medic: Medic) {
    return this.httpUtilService.invoke('POST', medic, 'users/medic', null);
  }

  createLab(lab: LabUser) {
    return this.httpUtilService.invoke('POST', lab, 'users/lab', null);
  }

  confirmEmail(id, code) {
    const self = this;
    const apiEndpoint = 'users/confirm-email';
    const params1 = {
      key: 'id',
      value: id,
    };
    const params2 = {
      key: 'code',
      value: code,
    };
    return self.httpUtilService.invokeQueryWithTwoParams(
      'GET',
      params1,
      params2,
      apiEndpoint
    );
  }

  forgotPassword(username: any) {
    const self = this;
    const apiEndpoint = 'users/forgot-password';
    const params = {
      key: 'email',
      value: username,
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  sendConfirmation(username: any) {
    const self = this;
    const apiEndpoint = 'users/send-confirmation-again';
    const params = {
      key: 'email',
      value: username,
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  resetPassword(id: any, code: any, password: any) {
    var UserWithIdPw = {
      id: id,
      passwordHash: password,
      token: code,
    };
    return this.httpUtilService.invoke(
      'POST',
      UserWithIdPw,
      'users/reset-password',
      null
    );
  }
}
