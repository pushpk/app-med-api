import { Component, OnInit, ViewChild } from '@angular/core';
import { RecordService } from './services/record.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { CheckEmptyUtil } from '../../shared/util/check-empty.util';

export enum TicketStatus {
  REGISTERED = 0,
  STARTED = 1,
  FINISHED = 2
}

export interface PastAttentions {
  id: number;
  description: any;
  specialty: any;
  date: string;
  action: string;
}


@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.scss']
})
export class RecordComponent implements OnInit {
  notes: any[];
  patient: any;
  ticket: any;
  ticketNumber: string;
  documentNumber: string;

  askTicket: boolean;
  waitingTicket: boolean;
  askDocumentNumber: boolean;
  askPatientRegistration: boolean;
  showRecord: boolean;

  displayedColumns: string[] = ['id', 'description', 'specialty', 'date', 'action'];
  dataSource: any;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  selectedSpeciality: any = '';

  specialities = [{ value: 'GENERAL', name: 'Medicina General', id: 1 },
  { value: 'CARDIOLOGY', name: 'Cardiología', id: 2 },
  { value: 'PEDIATRY', name: 'Pediatría', id: 3 },
  { value: 'TRAUMATOLOGY', name: 'Traumatología', id: 4 }];

  constructor(private recordService: RecordService, public router: Router) { }

  ngOnInit(): void {
    this.askTicket = false;
    this.waitingTicket = false;
    this.askDocumentNumber = true; // false;
    this.askPatientRegistration = false;
    this.showRecord = false;

    this.ticketNumber = '';
    //this.ticket.status   = TicketStatus.REGISTERED;
    this.documentNumber = '';

    this.patient = {};
  }

  searchTicket() {
    this.askTicket = true;
    this.askDocumentNumber = false;
    this.askPatientRegistration = false;
    this.showRecord = false;

    if (!this.ticketNumber) {
      return;
    }

    let self = this;

    self.waitingTicket = true;
    this.recordService.getPatientsByTicketNumber(this.ticketNumber).then((response: any) => {
      localStorage.setItem('patient', response.patient);
      localStorage.setItem('notes', response.notes);
      self.patient = response.patient;
      self.patient.notes = response.notes;
      self.ticket = response.ticket;
      self.ticket.status = TicketStatus[<string>response.ticket.status];
      //self.recordService.patientId= self.patient
      if (typeof self.patient.notes !== 'undefined' && self.patient.notes !== null) {
        console.log(JSON.stringify(self.patient.notes),'notes');
        this.dataSource = new MatTableDataSource<PastAttentions>(self.patient.notes);
        this.dataSource.paginator = this.paginator;
      }
      self.showRecord = true;
      self.waitingTicket = false;
    }).catch(() => {
      self.askDocumentNumber = true;
      self.waitingTicket = false;
    });
  }

  searchDocumentNumber() {
    this.askTicket = false; // true;
    this.askDocumentNumber = true;
    this.askPatientRegistration = false;
    this.showRecord = false;
    this.ticketNumber = '000-000000';

    if (!this.documentNumber) {
      return;
    }

    let self = this;

    self.waitingTicket = true;
    this.recordService.getPatientsByDocNumber(this.documentNumber).then((response: any) => {
      localStorage.setItem('patient', JSON.stringify(response.patient));
      if (CheckEmptyUtil.isNotEmptyObject(response.notes)) {
        localStorage.setItem('notes', JSON.stringify(response.notes));
      }
      self.patient = response.patient;
      self.patient.notes = response.notes;
      console.log(self.patient)
      if (typeof self.patient.notes !== 'undefined' && self.patient.notes !== null) {
        console.log(JSON.stringify(self.patient.notes));
        this.dataSource = new MatTableDataSource<PastAttentions>(self.patient.notes);
        this.dataSource.paginator = this.paginator;
      }
      self.ticket = {
        ticket: self.ticketNumber,
        status: TicketStatus.REGISTERED
      };

      self.showRecord = true;
      self.waitingTicket = false;
    }).catch(() => {
      self.askPatientRegistration = true;
      self.waitingTicket = false;
    });
  }

  onSpecialityChange(event: any) {
    if (CheckEmptyUtil.isNotEmptyObject(event)) {
      this.selectedSpeciality = event.value.toLowerCase();
      localStorage.setItem('speciality', this.selectedSpeciality);
      this.recordService.selectedSpecialty.next(this.selectedSpeciality);
    } else {
      localStorage.setItem('speciality', '');
      this.selectedSpeciality = '';
      this.recordService.selectedSpecialty.next('');
    }
  }

  navigateToNotes() {
    let routerPath = '/records/notes/new';
    switch (this.selectedSpeciality) {
      case 'general':
        routerPath = routerPath + '/general';
        break;
      case 'cardiology':
        routerPath = routerPath + '/cardiology';
        break;
      case 'pediatry':
        routerPath = routerPath + '/pediatry';
        break;
      case 'traumatology':
        routerPath = routerPath + '/traumatology';
        break;
      default:
        routerPath = '/records/notes/new';
        localStorage.setItem('speciality', '');
        break;
    }
    this.router.navigateByUrl(routerPath);
  }
  navigateToPatient() {
    let routerPath = '/patients/new';
    if (CheckEmptyUtil.isNotEmpty(this.patient.Id)) {
      routerPath = '/patients/' + this.patient.Id;
    }
    this.router.navigateByUrl(routerPath);
  }

}
