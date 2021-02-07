import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserAuthService {
  public keyName: string = environment.userInfo_LocalStoreKey;

  constructor() {}

  public save(userData: Object) {
    localStorage.setItem(this.keyName, JSON.stringify(userData));
  }

  public saveLoginData(userData: Object) {
    localStorage.setItem(this.keyName, JSON.stringify(userData));
  }

  public load() {
    try {
      let storedData: string = localStorage.getItem(this.keyName);
      if (!storedData) {
        throw Error('no user data found');
      }
      return JSON.parse(storedData);
    } catch (e) {}
    return null;
  }

  public clear() {
    localStorage.removeItem(this.keyName);
    localStorage.removeItem('patient');
    localStorage.removeItem('notes');
    localStorage.removeItem('speciality');
    localStorage.removeItem('selectNotes');
    localStorage.removeItem('email');
    localStorage.clear();
  }

  public isAuthenticated() {
    let data: string = this.load();
    let loggedIn: boolean = false;
    if (data !== null) {
      try {
        // if (!data['token']) {
        //  return false;
        // }
        loggedIn = this.getUser() != null;
      } catch (e) {
        console.error(e);
      }
    }
    return loggedIn;
  }

  getUser(): any {
    try {
      return JSON.parse(localStorage.getItem(this.keyName));
    } catch (e) {}
    return null;
  }

  getUserId(): any {
    try {
      return JSON.parse(localStorage.getItem('loggedInID'));
    } catch (e) {}
    return null;
  }

  public getToken(): string {
    return this.load().token;
  }
}
