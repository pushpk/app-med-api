import { Injectable } from '@angular/core';
import { User } from './model/user.model';
import { HttpUtilService } from '../../services/http-util.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user: User;
  constructor(private httpUtilService: HttpUtilService) {
  }

  login(params: any) {
    const self = this;
    const apiEndpoint = 'users/login';
    return self.httpUtilService.invoke('POST', params, apiEndpoint, null).then(
      (response: { id: string; name : string, role: number, docNumber : string,  permissions: string[] }) => {
        console.log(response);
        self.user = new User(response.id, response.name, response.role, response.docNumber, response.permissions);
        return self.user;
      }
    );
  }

  logout() {
    const self = this;
    const apiEndpoint = 'logout';
    return self.httpUtilService.invoke('POST', null, apiEndpoint, null).then(
      (response) => {
        return response;
      }
    );
  }
}
