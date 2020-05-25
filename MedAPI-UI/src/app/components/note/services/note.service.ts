import { Injectable } from '@angular/core';
import { HttpUtilService } from '../../../services/http-util.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoteService {
  resources: BehaviorSubject<[]> = new BehaviorSubject([]);

  constructor(private httpUtilService: HttpUtilService) { }

  getResources(resourcesPath: any) {
    return this.httpUtilService.invoke('GET', null, resourcesPath);
  }

  save(note: any) {
    return this.httpUtilService.invoke('POST', note, '');
  }
}
