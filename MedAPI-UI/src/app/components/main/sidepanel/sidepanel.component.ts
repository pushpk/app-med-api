import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecordService } from '../../record/services/record.service';

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

  constructor(private router: Router, private recordService: RecordService) { }

  ngOnInit(): void {
  }

  navigateToPage(url: any) {
    localStorage.setItem('speciality', '');
    this.recordService.selectedSpecialty.next('');
    this.router.navigateByUrl(url);
  }

}
