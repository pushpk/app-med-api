import { Injectable } from '@angular/core';
import { User } from './model/user.model';
import { HttpUtilService } from '../../services/http-util.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: User;
  constructor(
    private httpUtilService: HttpUtilService,
    private toastr: ToastrService
  ) {}

  login(params: any) {
    const self = this;
    const apiEndpoint = 'users/login';
    return self.httpUtilService
      .invoke('POST', params, apiEndpoint, null)
      .then(
        (response: {
          id: string;
          name: string;
          role: number;
          docNumber: string;
          permissions: string[];
          IsApproved: boolean;
          IsFreezed: boolean;
        }) => {
          // console.log(response);
          self.user = new User(
            response.id,
            response.name,
            response.role,
            response.docNumber,
            response.permissions,
            response.IsApproved,
            response.IsFreezed
          );
          return self.user;
        }
      )
      .catch((error) => {
        // if (error['status'] === 401) {
        //   this.toastr.toastrConfig.extendedTimeOut = 0;
        //   this.toastr.toastrConfig.timeOut = 0;
        //   this.toastr.error(error.error);
        // } else {
        this.toastr.error(error.error);
        //}
      });
  }

  logout() {
    const self = this;
    const apiEndpoint = 'logout';
    return self.httpUtilService
      .invoke('POST', null, apiEndpoint, null)
      .then((response) => {
        return response;
      });
  }
}
