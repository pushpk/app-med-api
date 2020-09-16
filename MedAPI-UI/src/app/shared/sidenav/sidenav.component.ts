import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { CommonService } from '../../services/common.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  screenWidth: number;
  @ViewChild('drawer', { static: false }) drawer: MatSidenav;

  constructor(public commonService: CommonService) {
  }

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
    window.onresize = () => {
      // set screenWidth on screen size change
      this.screenWidth = window.innerWidth;
    }

    setTimeout(() => {
      this.commonService.sideBar = this.drawer;

      this.commonService.slideEmitter.subscribe((open: boolean = false) => {
        if (open) {
          this.drawer.close();
        } else {
          if (this.drawer.opened) {
            this.drawer.close();
          } else {
            this.drawer.open();
          }
        }
      });

      this.commonService.slideEmitter.emit(true);

      if (this.commonService.isSidebarOpened === null) {
        this.commonService.isSidebarOpened = 'false';
      }

      const isSidebarOpened = this.commonService.isSidebarOpened.replace(/['"]+/g, '');
      if (isSidebarOpened === 'true') {
        this.drawer.open();
      }
    });
  }
}
