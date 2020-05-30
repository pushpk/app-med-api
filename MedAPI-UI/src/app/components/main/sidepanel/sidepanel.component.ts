import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidepanel',
  templateUrl: './sidepanel.component.html',
  styleUrls: ['./sidepanel.component.scss']
})
export class SidepanelComponent implements OnInit {

  navMenus: any[] = [{ name: 'Inicio', pageUrl: 'records' },
    //{ name: 'Médicos', pageUrl: 'records' },
    { name: 'Afiliar paciente', pageUrl: 'patients/new' },
    { name: 'Atención General', pageUrl: 'records' },
    { name: 'Atención de Cardiología', pageUrl: 'records' }];

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToPage(url: any) {
    this.router.navigateByUrl(url);
  }

}
