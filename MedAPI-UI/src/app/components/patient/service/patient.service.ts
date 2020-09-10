import { Injectable } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject } from 'rxjs';
import { Medic } from 'src/app/models/medic.model';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);

  constructor(private httpUtilService: HttpUtilService) { }


  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  updateProvinces(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  updateDistricts(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  save(patient: any, email: string) {
    return this.httpUtilService.invoke('POST', patient, 'users/patient', email);
  }

  registerPatient(patient: any){
    return this.httpUtilService.invoke('POST', patient, 'users/RegisterPatient', null);
  }
  
  createMedic(medic : Medic)
  {
    return this.httpUtilService.invoke('POST', medic, 'users/medic', null);
  }

}