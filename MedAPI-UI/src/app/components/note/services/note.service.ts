import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { ResourcesService } from '../../../services/resources.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);
  updateComputedFieldsEvent: EventEmitter<[]> = new EventEmitter<[]>();
  //diagnosisList: EventEmitter<[]> = new EventEmitter<[]>();

  constructor(private httpUtilService: HttpUtilService, private resourcesService: ResourcesService) { }

  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  save(note: any, email: string) {
    return this.httpUtilService.invoke('POST', note, '/record/note', email);
  }

  /* diagnosis */

  queryDiagnosis(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService.search(query, '/admin/diagnosis').then((response) => {
      return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  }

  queryExams(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService.search(query, '/admin/exam').then((response) => {
      return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  }

  queryTreatments(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService.search(query, '/admin/medicine').then((response) => {
      return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  }

  queryInterconsultations(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService.search(query, '/record/specialty').then((response) => {
      return response;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  }
}
