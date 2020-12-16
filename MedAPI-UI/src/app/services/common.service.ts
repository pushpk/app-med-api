import { Injectable, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BehaviorSubject } from 'rxjs';

import { jsPDF } from 'jspdf';

// import 'jspdf-autotable';

import { Patient } from '../models/patient.model';
import { NoteDetail } from '../models/noteDetail.model';
import { DatePipe } from '@angular/common';
import { HttpUtilService } from './http-util.service';
import { MedicUser } from '../models/medicuser.model';
import { Medic } from '../models/medic.model';
import { AbstractControl, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  public sideBar: MatSidenav;

  public currentUrl = new BehaviorSubject<string>(undefined);
  slideEmitter: EventEmitter<any> = new EventEmitter<boolean>(false);
  medicForNote: Medic;

  constructor(
    public datepipe: DatePipe,
    private httpUtilService: HttpUtilService
  ) {}

  patternValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } => {
      if (!control.value) {
        return null;
      }
      const regex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$');
      const valid = regex.test(control.value);
      return valid ? null : { invalidPassword: true };
    };
  }

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

  getMedicForThisNote(medicId: number) {
    const self = this;
    const apiEndpoint = 'users/get-medic';
    const params = {
      key: 'id',
      value: medicId,
    };
    return self.httpUtilService.invokeQuery('GET', params, apiEndpoint);
  }
  public generatePDF(patient: Patient, note: NoteDetail, type: string) {
    try {
      //Attention
      //Prescription
      //Interconsultation

      var medic;
      this.getMedicForThisNote(note.medicId)
        .then((response: Medic) => {
          this.medicForNote = response;

          var doc = new jsPDF();

          doc.setFontSize(35);
          var currentY = 15;
          if (type === 'Prescription') {
            doc.text('Receta medica', 14, currentY);
          } else if (type === 'Interconsultation') {
            doc.text('Solicitud de interconsulta', 14, currentY);
          } else {
            doc.text('Atención medica', 14, currentY);
          }

          doc.setFontSize(20);

          //Right Side of the page
          //Patient Sex
          doc.setFont('helvetica', 'bold');
          doc.text('Sexo', 156, 30);

          doc.setFont('helvetica', null);
          doc.text(patient.sex, 156, 38);

          // Patient Date of Birth
          doc.setFont('helvetica', 'bold');
          doc.text('Fecha', 156, 50);

          doc.setFont('helvetica', null);
          doc.text(
            this.datepipe.transform(patient.birthday, 'yyyy-MM-dd'),
            156,
            58
          );

          //Name
          doc.setFont('helvetica', 'bold');
          doc.text('Paciente', 14, (currentY += 15));

          doc.setFont('helvetica', null);
          doc.text(patient.name, 14, (currentY += 8));

          // Patient Doc Number
          doc.setFont('helvetica', 'bold');
          doc.text('DNI', 14, (currentY += 15));

          doc.setFont('helvetica', null);
          doc.text(patient.documentNumber, 14, (currentY += 8));

          var finalY = 0;

          if (type === 'Attention') {
            doc.setFont('helvetica', 'bold');
            doc.text('Presión arterial sistólica (mmHg)', 14, (currentY += 15));
            doc.setFont('helvetica', null);
            doc.text(
              note.triage.vitalFunctions.systolic.toString(),
              14,
              (currentY += 8)
            );

            doc.setFont('helvetica', 'bold');
            doc.text(
              'Presión arterial diastólica (mmHg)',
              14,
              (currentY += 15)
            );
            doc.setFont('helvetica', null);
            doc.text(
              note.triage.vitalFunctions.diastolic.toString(),
              14,
              (currentY += 8)
            );

            console.log(doc.internal.pageSize.height);
            console.log(currentY);

            doc.setFont('helvetica', 'bold');
            doc.text('Frecuencia cardiaca (lpm)', 14, (currentY += 15));
            doc.setFont('helvetica', null);
            doc.text(
              note.triage.vitalFunctions.heartRate.toString(),
              14,
              (currentY += 8)
            );
          }

          if (type === 'Attention' || type === 'Interconsultation') {
            // Patient PErsonal History
            doc.setFont('helvetica', 'bold');
            doc.text('Antecedentes Personales ', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            doc.text(
              patient.personalBackground.map((s) => s.name).join(','),
              14,
              (currentY += 8)
            );

            // Patient Allergies
            doc.setFont('helvetica', 'bold');
            doc.text('Alergias', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            doc.text(
              patient.allergies.map((s) => s.name).join(','),
              14,
              (currentY += 8)
            );

            // Symptom Description
            doc.setFont('helvetica', 'bold');
            doc.text('Síntomas Descripción', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            doc.text(note.symptoms.description, 14, (currentY += 8));

            // Patient Background Information from NOTE
            doc.setFont('helvetica', 'bold');
            doc.text('Relato', 14, (currentY += 15));

            if (note.symptoms.background) {
              doc.setFont('helvetica', null);
              doc.text(note.symptoms.background, 14, (currentY += 8));
            }

            if (currentY > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }
          }
          if (type === 'Attention') {
            //Note Examen físico
            doc.setFont('helvetica', 'bold');
            doc.text('Examen físico', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            doc.text(note.physicalExam.text, 14, (currentY += 8));

            if (currentY + 75 > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }

            //Diagnóstico
            doc.setFont('helvetica', 'bold');
            doc.text('Diagnóstico', 14, (currentY += 15));

            var col = ['#', 'CIE-10', 'Descripción', 'Tipo'];
            var rows = [];

            for (var i = 0; i < note.diagnosis.list.length; i++) {
              var temp = [
                i + 1,
                note.diagnosis.list[i].code,
                note.diagnosis.list[i].title,
                note.diagnosis.list[i].type === 'PRESUMPTIVE'
                  ? 'Presumptivo'
                  : note.diagnosis.list[i].type === 'DEFINATIVE'
                  ? 'Definitivo'
                  : '',
              ];
              rows.push(temp);
            }
            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: (currentY += 8) },
              body: rows,
              columns: col,
              theme: 'grid',
              headStyles: {
                fontSize: 18,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: 18,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              didDrawPage: function (data) {
                // console.log(data);
                // diagossisHeight = data.table.finalY
              },
            });
            if (currentY > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }

            // @ts-ignore
            currentY = 12 + doc.lastAutoTable.finalY;

            doc.setFont('helvetica', 'bold');

            doc.text('Observaciones', 14, currentY);

            doc.setFont('helvetica', '');
            // @ts-ignore
            doc.text(note.diagnosis.observations, 14, (currentY += 8));

            if (currentY > pageHeight) {
              doc.addPage();
              currentY = 0;
            }

            doc.setFont('helvetica', 'bold');
            // @ts-ignore
            doc.text('Examenes solicitados', 14, (currentY += 15));

            var colExams = ['#', 'Nombre'];
            var rowsExam = [];

            for (var i = 0; i < note.exams.list.length; i++) {
              var temp = [i + 1, note.exams.list[i].name];
              rowsExam.push(temp);
            }

            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              startY: (currentY += 8),
              body: rowsExam,
              columns: colExams,
              theme: 'grid',
              headStyles: {
                fontSize: 18,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: 18,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
            });

            if (currentY > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }

            // doc.setFont('helvetica', 'bold');
            // doc.text('Observaciones', 14, (currentY += 15));

            // doc.setFont('helvetica', '');
            // doc.text(note.exams.observations, 14, (currentY += 8));

            // @ts-ignore
            finalY = doc.lastAutoTable ? doc.lastAutoTable.finalY + 30 : 180;
          }

          if (type === 'Prescription') {
            var colTreatments = ['#', 'Descripción', 'Indicaciones'];
            var rowsTreatments = [];

            console.log(note.treatments.list);
            console.log(note.interconsultation.list);

            for (var i = 0; i < note.treatments.list.length; i++) {
              var temp = [
                i + 1,
                note.treatments.list[i].name,
                note.treatments.list[i].indications,
              ];
              rowsTreatments.push(temp);
            }

            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: 70 },
              body: rowsTreatments,
              columns: colTreatments,
              theme: 'grid',
              headStyles: {
                fontSize: 18,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: 18,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
            });

            // @ts-ignore
            finalY = doc.lastAutoTable ? doc.lastAutoTable.finalY : 65;
          }

          if (type === 'Interconsultation') {
            var colInterconsultation = ['#', 'Especialidad', 'Motivo'];
            var rowsInterconsultation = [];

            console.log(note.treatments.list);
            console.log(note.interconsultation.list);

            for (var i = 0; i < note.interconsultation.list.length; i++) {
              var temp = [
                i + 1,
                note.interconsultation.list[i].specialty,
                note.interconsultation.list[i].reason,
              ];
              rowsInterconsultation.push(temp);
            }

            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: currentY + 15 },
              body: rowsInterconsultation,
              columns: colInterconsultation,
              theme: 'grid',
              headStyles: {
                fontSize: 18,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: 18,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
            });

            // @ts-ignore
            finalY = doc.lastAutoTable ? doc.lastAutoTable.finalY : currentY;
          }

          var pageHeight = doc.internal.pageSize.height;

          if (finalY > pageHeight) {
            doc.addPage();
            finalY = 0;
          }

          doc.setFont('helvetica', 'bold');
          doc.text('Médico', 14, 12 + finalY);

          var medicData = JSON.parse(localStorage.getItem('userData'));
          var medicName =
            this.medicForNote.user.firstName +
            ' ' +
            this.medicForNote.user.lastNameFather +
            '' +
            this.medicForNote.user.lastNameMother;
          doc.setFont('helvetica', '');
          doc.text(medicName, 14, 18 + finalY);

          doc.setFontSize(15);

          doc.setFont('helvetica', '');
          doc.text(
            'CMP:' + this.medicForNote.cmp + ' RNE:' + this.medicForNote.rne,
            14,
            24 + finalY
          );

          doc.setFontSize(35);
          doc.save(patient.name + '_' + type + '.pdf');
        })
        .catch((error: any) => {
          console.log(error);
        });
    } catch (err) {
      console.log(err);
    }
  }
}
