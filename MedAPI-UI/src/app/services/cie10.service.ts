import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResourcesService } from './resources.service';

@Injectable({
  providedIn: 'root'
})
export class CIE10Service extends ResourcesService {
  constructor(public http: HttpClient) {

    super(http, '/admin/diagnosis');
  }
}
