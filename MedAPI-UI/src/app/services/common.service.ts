import { Injectable, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BehaviorSubject } from 'rxjs';
import { TitleCasePipe } from '@angular/common';
import { jsPDF } from 'jspdf';

// import 'jspdf-autotable';

import { Patient } from '../models/patient.model';
import { NoteDetail } from '../models/noteDetail.model';
import { DatePipe } from '@angular/common';
import { HttpUtilService } from './http-util.service';
import { MedicUser } from '../models/medicuser.model';
import { Medic } from '../models/medic.model';
import { AbstractControl, ValidatorFn } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import * as fontRef from '../../assets/Pacifico-Regular-bold.js';

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
    private httpUtilService: HttpUtilService,
    private titleCasePipe: TitleCasePipe,
    private sanitizer: DomSanitizer
  ) {}

  blobToDataURL = (blob) => {
    return new Promise((fulfill, reject) => {
      let reader = new FileReader();
      reader.onerror = reject;
      reader.onload = (e) => fulfill(reader.result);
      reader.readAsDataURL(blob);
    });
  };

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
  public generatePDF(patient: Patient, note: NoteDetail, type: string, signImageDataUrl : any) {
    try {
      //Attention
      //Prescription
      //Interconsultation

      fontRef;

      var medic;
      var titleFontSize = 20;
      var contentFontSize = 14;


      const medicId = note.medicId === null ? +localStorage.getItem('loggedInID') : +note.medicId;
      this.getMedicForThisNote(medicId)
        .then((response: Medic) => {
          this.medicForNote = response;

          var doc = new jsPDF();

          var logo = new Image();
          logo.src = 'assets/images/logo.png';
          doc.addImage(logo, 'png', 15, 15, 50, 15);
          // doc.addImage(logo.png);

          doc.setFontSize(titleFontSize);
          var currentY = 40;
          if (type === 'Prescription') {
            var title = 'Receta Medica';
            // var xOffset = (doc.internal.pageSize.width / 2) - (doc.getStringUnitWidth(title) * titleFontSize / 2);
            doc.text(
              title,
              doc.internal.pageSize.width / 2,
              currentY,
              null,
              'center'
            );
          } else if (type === 'Interconsultation') {
            var title = 'Solicitud de Interconsulta';
            // var xOffset = (doc.internal.pageSize.width / 2) - (doc.getStringUnitWidth(title) * titleFontSize / 2);
            doc.text(
              title,
              doc.internal.pageSize.width / 2,
              currentY,
              null,
              'center'
            );
          } else {
            var title = 'Atención Médica';
            // var xOffset = (doc.internal.pageSize.width / 2) - (doc.getStringUnitWidth(title) * titleFontSize / 2);
            doc.text(
              title,
              doc.internal.pageSize.width / 2,
              currentY,
              null,
              'center'
            );
          }

          doc.setFontSize(contentFontSize);

          doc.text(
            'Fecha: ' +
              this.datepipe.transform(note.registrationDate, 'dd/MM/yyyy'),
            doc.internal.pageSize.width / 2,
            currentY + 7,
            null,
            'center'
          );

          //Right Side of the page
          //Patient Sex
          doc.setFont('helvetica', 'bold');
          doc.text('Sexo', 146, 63);

          doc.setFont('helvetica', null);
          doc.text(patient.sex, 146, 71);

          // Patient Date of Birth
          doc.setFont('helvetica', 'bold');
          doc.text('Fecha de Nacimiento', 146, 83);

          doc.setFont('helvetica', null);
          doc.text(
            // patient.age.toString(),
            this.datepipe.transform(patient.birthday, 'dd-MM-yyyy'),
            146,
            91
          );

          //Name
          doc.setFont('helvetica', 'bold');
          doc.text('Paciente', 14, (currentY += 23));

          doc.setFont('helvetica', null);
          doc.text(
            patient.name +
              ' ' +
              patient.lastnameFather +
              ' ' +
              patient.lastnameMother,
            14,
            (currentY += 8)
          );

          // Patient Doc Number
          doc.setFont('helvetica', 'bold');
          doc.text('DNI', 14, (currentY += 15));

          doc.setFont('helvetica', null);
          doc.text(patient.documentNumber, 14, (currentY += 8));

          var finalY = 0;

          if (type === 'Attention') {
            doc.setFont('helvetica', 'bold');
            doc.text('Presión arterial (mmHg)', 14, (currentY += 15));
            doc.setFont('helvetica', null);
            doc.text(
              note.triage.vitalFunctions.systolic.toString() +
                '/' +
                note.triage.vitalFunctions.diastolic.toString(),
              14,
              (currentY += 8)
            );

            // doc.setFont('helvetica', 'bold');
            // doc.text(
            //   'Presión arterial diastólica (mmHg)',
            //   14,
            //   (currentY += 15)
            // );
            // doc.setFont('helvetica', null);
            // doc.text(
            //   note.triage.vitalFunctions.diastolic.toString(),
            //   14,
            //   (currentY += 8)
            // );

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
            doc.text('Síntomas', 14, (currentY += 15));

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
                this.titleCasePipe.transform(note.diagnosis.list[i].title),
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
                fontSize: contentFontSize,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: contentFontSize,
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
              var tempExams = [
                i + 1,
                this.titleCasePipe.transform(note.exams.list[i].name),
              ];
              rowsExam.push(tempExams);
            }

            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              startY: (currentY += 8),
              body: rowsExam,
              columns: colExams,
              theme: 'grid',
              headStyles: {
                fontSize: contentFontSize,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: contentFontSize,
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

            // console.log(note.treatments.list);
            // console.log(note.interconsultation.list);

            for (var i = 0; i < note.treatments.list.length; i++) {
              var temp = [
                i + 1,
                note.treatments.list[i].name,
                note.treatments.list[i].indications,
              ];
              rowsTreatments.push(temp);
            }
            if (note.treatments.other && note.treatments.other.length > 0) {
              var otherTreatment = [
                note.treatments.list.length + 1,
                'No farmacéutico',
                note.treatments.other,
              ];
              rowsTreatments.push(otherTreatment);
            }
            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: 120 },
              body: rowsTreatments,
              columns: colTreatments,
              theme: 'grid',
              headStyles: {
                fontSize: contentFontSize,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: contentFontSize,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
            });

            // @ts-ignore
            finalY = doc.lastAutoTable? doc.lastAutoTable.finalY + 40: 105 + 40;
          }

          if (type === 'Interconsultation') {
            var colInterconsultation = ['#', 'Especialidad', 'Motivo'];
            var rowsInterconsultation = [];

            // console.log(note.treatments.list);
            // console.log(note.interconsultation.list);

            for (var i = 0; i < note.interconsultation.list.length; i++) {
              var interconsultationTable = [
                i + 1,
                this.titleCasePipe.transform(
                  note.interconsultation.list[i].specialty
                ),
                this.titleCasePipe.transform(
                  note.interconsultation.list[i].reason
                ),
              ];
              rowsInterconsultation.push(interconsultationTable);
            }

            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: currentY + 15 },
              body: rowsInterconsultation,
              columns: colInterconsultation,
              theme: 'grid',
              headStyles: {
                fontSize: contentFontSize,
                fontStyle: 'bold',
                fillColor: 'white',
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
              bodyStyles: {
                fontSize: contentFontSize,
                textColor: 'black',
                lineColor: 'black',
                lineWidth: 0.5,
              },
            });

            // @ts-ignore
            finalY = doc.lastAutoTable? doc.lastAutoTable.finalY + 25: currentY + 25;
          }

          var pageHeight = doc.internal.pageSize.height;

          if (finalY > pageHeight) {
            doc.addPage();
            finalY = 0;
          }

         const imageData = signImageDataUrl ? signImageDataUrl : 'data:image/png;base64,' + note.signatuteDraw;

          doc.setFont('helvetica', 'bold');
          doc.text('Médico', 14, 12 + finalY);

          if(note.isSignatureDraw)
          {
               var img = new Image();
               img.src = imageData;
               doc.addImage(img, 'png', 14, 14 + finalY, 90, 15);
               finalY = finalY + 10;
          }
          else{
               doc.setFont('Pacifico-Regular');
               doc.text(note.signatuteText, 14, 14 + finalY);
          }

          var medicData = JSON.parse(localStorage.getItem('userData'));
          var medicName =
            this.medicForNote.user.firstName +
            ' ' +
            this.medicForNote.user.lastNameFather +
            ' ' +
            this.medicForNote.user.lastNameMother;
          doc.setFont('helvetica', '');
          doc.text(medicName, 14, 28 + finalY);

          doc.setFontSize(contentFontSize);

          doc.setFont('helvetica', '');
          doc.text(
            'CMP:' + this.medicForNote.cmp + ' RNE:' + this.medicForNote.rne,
            14,
            34 + finalY
          );

          doc.text(
            'Fecha:' +
              this.datepipe.transform(note.registrationDate, 'dd/MM/yyyy'),
            14,
            40 + finalY
          );

          doc.setFontSize(contentFontSize);
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
