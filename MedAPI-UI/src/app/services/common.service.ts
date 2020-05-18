import { Injectable, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BehaviorSubject } from 'rxjs';
import { Router, NavigationEnd } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  public sideBarBool = false;
  public sideBar: MatSidenav;

  public appDrawer: any;
  public currentUrl = new BehaviorSubject<string>(undefined);
  slideEmitter: EventEmitter<any> = new EventEmitter<boolean>(false);

  constructor(private router: Router) {
  }

  //public closeNav() {
  //  this.appDrawer.close();
  //}

  //public openNav() {
  //  this.appDrawer.open();
  //}

  get isSidebarOpened(): string {
    if (localStorage.getItem('openSide')) {
      return localStorage.getItem('openSide');
    } else {
      return '';
    }
  }

  set isSidebarOpened(item: string) {
    localStorage.setItem('openSide', item);
  }
}
