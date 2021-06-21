import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { LabUser } from 'src/app/models/labUser.model';
import { Medic } from 'src/app/models/medic.model';
import { HttpUtilService } from '../../../services/http-util.service';

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
    return this.httpUtilService.invoke('POST', patient, 'Patient', null);
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

  changePassword(oldPassword: any, newPassword: any) {
    var UserWithIdPw = {
      id: localStorage.getItem('loggedInID'),
      oldPasswordHash: oldPassword,
      passwordHash: newPassword,
    };
    return this.httpUtilService.invoke(
      'POST',
      UserWithIdPw,
      'users/change-password',
      null
    );
  }

  getMedicAccessPermissions(userId: number) {
    const self = this;
    const apiEndpoint = 'users/MedicAccessRequests';
    const params = {
      key: 'userId',
      value: userId,
    };

    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }

  changeMedicAccessForPatient(
    userId: number,
    medicId: number,
    isMedicAuthorized: boolean,
    isFutureRequestBlocked: boolean,
    isRequestSent: boolean
  ) {
    var medicPermission = {
      user_id: userId,
      medic_id: medicId,
      is_medic_authorized: isMedicAuthorized,
      is_future_request_blocked: isFutureRequestBlocked,
      is_request_sent: isRequestSent,
    };

    return this.httpUtilService.invoke(
      'POST',
      medicPermission,
      'users/MedicAccessRequestChange',
      null
    );
  }
}
