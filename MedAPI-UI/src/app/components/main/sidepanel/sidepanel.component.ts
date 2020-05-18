import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidepanel',
  templateUrl: './sidepanel.component.html',
  styleUrls: ['./sidepanel.component.scss']
})
export class SidepanelComponent implements OnInit {

  navMenus: any[] = [{ name: 'Inicio', pageUrl: '' },
    { name: 'Médicos', pageUrl: '' },
    { name: 'Afiliar paciente', pageUrl: '' },
    { name: 'Atención General', pageUrl: '' },
    { name: 'Atención de Cardiología', pageUrl: '' }];

  constructor() { }

  ngOnInit(): void {
  }

  navigateToPage(page: any) {

  }

}
