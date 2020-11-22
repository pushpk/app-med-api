import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RecordService } from '../../record/services/record.service';

@Component({
  selector: 'app-sidepanel',
  templateUrl: './sidepanel.component.html',
  styleUrls: ['./sidepanel.component.scss']
})
export class SidepanelComponent implements OnInit {

  // navMenus: any[] = [{ name: 'Inicio', pageUrl: 'records' },
  //   //{ name: 'Médicos', pageUrl: 'records' },
  //   { name: 'Afiliar paciente', pageUrl: 'patients/new' },
  //   { name: 'Atención General', pageUrl: 'records' },
  //   { name: 'Atención de Cardiología', pageUrl: 'records' }];
  navMenus: any[] = [{ name: 'Inicio', pageUrl: 'records' },
    //{ name: 'Médicos', pageUrl: 'records' },
    { name: 'Afiliar paciente', pageUrl: 'patients/new' },
    { name: 'Atención', pageUrl: 'records' }];
  isUserAdmin: boolean;

  constructor(private router: Router, private recordService: RecordService) { }

  ngOnInit(): void {
    this.isUserAdmin = localStorage.getItem('role') !== 'patient';
  }


  navigateToPage(url: any) {
    localStorage.setItem('speciality', '');
    this.recordService.selectedSpecialty.next('');
    localStorage.setItem('patient', '');
    this.router.navigateByUrl(url);
  }

}
