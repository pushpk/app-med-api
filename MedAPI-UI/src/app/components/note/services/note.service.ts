import { Injectable, EventEmitter, Output } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { ResourcesService } from '../../../services/resources.service';

@Injectable({
  providedIn: 'root',
})
export class NoteService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);
  updateComputedFieldsEvent: EventEmitter<[]> = new EventEmitter<[]>();
  isPharmacologicalEvent = new BehaviorSubject<boolean>(true);
  isPharmacological = this.isPharmacologicalEvent.asObservable();
  // isPharmacologicalChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  // diagnosisList: EventEmitter<[]> = new EventEmitter<[]>();

  constructor(
    private httpUtilService: HttpUtilService,
    private resourcesService: ResourcesService
  ) {}

  setIsPharmacological(isPharma: boolean) {
    this.isPharmacologicalEvent.next(isPharma);
  }

  // getIsPharmacological(){
  //   return this.isPharmacological;
  // }

  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath, null);
  }

  save(note: any, email: string) {
    return this.httpUtilService.invoke('POST', note, '/record/note', email);
  }
  saveSignature(formData: FormData, email: string) {
    console.log(
      '🚀 ~ file: note.service.ts ~ line 39 ~ NoteService ~ saveSignature ~ formData',
      formData.get('noteId')
    );
    return this.httpUtilService.invokePostWithFormData(
      'POST',
      formData,
      'record/saveSignatureForNote',
      email
    );
  }

  getSignature(noteId: number) {
    return this.httpUtilService.invokeGetForSign(
      'record/noteSignature/' + noteId
    );
  }

  /* diagnosis */

  queryDiagnosis(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService
      .search(query, '/admin/diagnosis')
      .then((response) => {
        return response;
      })
      .catch((error) => {
        console.log(error);
        return error;
      });
  }

  queryExams(query: string): any {
    if (!query || query.length < 2) {
      return [];
    }
    return this.resourcesService
      .search(query, '/admin/exam')
      .then((response) => {
        return response;
      })
      .catch((error) => {
        console.log(error);
        return error;
      });
  }

  //treatments
  queryTreatments(query: string): any {
    if (!query || query.length < 3) {
      return [];
    }
    return this.resourcesService
      .search(query, '/admin/medicine')
      .then((response) => {
        return response;
      })
      .catch((error) => {
        console.log(error);
        return error;
      });
  }

  queryInterconsultations(query: string): any {
    if (!query || query.length < 2) {
      return [];
    }
    return this.resourcesService
      .search(query, '/record/specialty')
      .then((response) => {
        return response;
      })
      .catch((error) => {
        console.log(error);
        return error;
      });
  }
}
