import { Component, OnInit, ViewChild } from '@angular/core';
import { RecordService } from './services/record.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

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
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  specialities = [{ value: 'GENERAL', name: 'Medicina General' },
  { value: 'CARDIOLOGY', name: 'Cardiología' },
  { value: 'PEDIATRY', name: 'Pediatría' },
  { value: 'TRAUMATOLOGY', name: 'Traumatología' }];

  constructor(private recordService: RecordService) { }

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
      console.log(response);
      self.patient = response.patient;
      self.patient.notes = response.notes;
      self.ticket = response.ticket;
      self.ticket.status = TicketStatus[<string>response.ticket.status];

      if (typeof self.patient.notes !== 'undefined' && self.patient.notes !== null) {
        console.log(JSON.stringify(self.patient.notes));
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
    this.recordService.getPatientsByDocNumber(this.documentNumber).then((response:any) => {
      console.log(response);
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

}
