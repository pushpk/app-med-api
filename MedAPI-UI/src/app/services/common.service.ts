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

            var title = 'Receta Médica';
            // var xOffset = (doc.internal.pageSize.width / 2) - (doc.getStringUnitWidth(title) * titleFontSize / 2); 
            doc.text(title, doc.internal.pageSize.width / 2, currentY, null, 'center');
          } else if (type === 'Interconsultation') {
            var title = 'Solicitud de Interconsulta'
            // var xOffset = (doc.internal.pageSize.width / 2) - (doc.getStringUnitWidth(title) * titleFontSize / 2); 
            doc.text(title, doc.internal.pageSize.width / 2, currentY, null, 'center');
          } else if (type === 'Exams'){
            var title = 'Exámenes de Laboratorio';
            doc.text(title, doc.internal.pageSize.width / 2, currentY, null, 'center');

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

            if (note.triage.vitalFunctions.systolic && note.triage.vitalFunctions.diastolic){
              doc.text(
                note.triage.vitalFunctions.systolic.toString() + '/' + note.triage.vitalFunctions.diastolic.toString(),
                14,
                (currentY += 8)
              );
            }
            else {
              doc.text(
                '-',
                14,
                (currentY += 8)
              );
            }

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

            // console.log(doc.internal.pageSize.height);
            // console.log(currentY);
            doc.setFont('helvetica', 'bold');
            doc.text('Frecuencia cardiaca (lpm)', 14, (currentY += 15));
            doc.setFont('helvetica', null);
            if (note.triage.vitalFunctions.heartRate){
              doc.text(
                note.triage.vitalFunctions.heartRate.toString(),
                14,
                (currentY += 8)
              );
            }
            else{
              doc.text(
                '-',
                14,
                (currentY += 8)
              );
            }
          }

          if (type === 'Attention' || type === 'Interconsultation') {
            // Patient PErsonal History
            doc.setFont('helvetica', 'bold');
            doc.text('Antecedentes Personales ', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            if (patient.personalBackground.length > 0){
              doc.text(
                patient.personalBackground.map((s) => s.name).join(', '),
                14,
                (currentY += 8)
              );
            }
            else{
              doc.text(
                'Ninguno',
                14,
                (currentY += 8)
              );
            }


            // Patient Allergies
            doc.setFont('helvetica', 'bold');
            doc.text('Alergias', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            if (patient.allergies.length > 0) {
              doc.text(
                patient.allergies.map((s) => s.name).join(', '),
                14,
                (currentY += 8)
              );
            }
            else {
              doc.text(
                'Ninguna',
                14,
                (currentY += 8)
              );
            }


            // Symptom Description
            doc.setFont('helvetica', 'bold');
            doc.text('Síntomas', 14, (currentY += 15));

            doc.setFont('helvetica', null);
            var splitSymptoms = doc.splitTextToSize(note.symptoms.description, 180);
            doc.text(splitSymptoms, 14, (currentY += 8));

            // Patient Background Information from NOTE
            doc.setFont('helvetica', 'bold');
            if (currentY + doc.splitTextToSize(note.symptoms.description, 180).length * 7 + 8> doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }

            doc.text('Relato', 14, (currentY += (doc.splitTextToSize(note.symptoms.description, 180).length * 7 + 8)));

            if (note.symptoms.background) {
              doc.setFont('helvetica', null);
              var splitSymptomsBackground = doc.splitTextToSize(note.symptoms.background, 180);
              doc.text(splitSymptomsBackground, 14, (currentY += 8));
            }
            else{
              doc.setFont('helvetica', null);
              var noSymptomsBackground = '-';
              doc.text(noSymptomsBackground, 14, (currentY += 8));
            }

          }
          if (type === 'Attention') {
            //Note Examen físico
            if (note.physicalExam.text.length > 0) {
              var index = 20;
              if (currentY + doc.splitTextToSize(note.symptoms.background, 180).length * 7 + 40 > doc.internal.pageSize.height) {
                doc.addPage();
                currentY = 0;
              }
              else{
                index = note.symptoms.background.length < 1 ? 15 : doc.splitTextToSize(note.symptoms.background, 180).length * 7 + 8;
              }
              doc.setFont('helvetica', 'bold');
              doc.text('Examen físico', 14, (currentY += index));
  
              doc.setFont('helvetica', null);
              var splitPhysicalExam = doc.splitTextToSize(note.physicalExam.text, 180);
              doc.text(splitPhysicalExam, 14, (currentY += 8));

            }
            else {
              currentY += 15;
            }

            if (currentY + 75 > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 15;
            }

            //Diagnóstico
            doc.setFont('helvetica', 'bold');
            // if (note.symptoms.background.length < 1) {
            //   index = 15;
            // }
            // else{
            index = note.physicalExam.text.length > 1 ? doc.splitTextToSize(note.physicalExam.text, 180).length * 7 + 8 : note.symptoms.background.length > 1 ? doc.splitTextToSize(note.symptoms.background, 180).length * 7 + 8: 15;
            // }
            doc.text('Diagnóstico', 14, (currentY += index));

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

            if (note.diagnosis.observations.length > 0){
              doc.setFont('helvetica', 'italic');
              doc.text('Observaciones', 14, currentY);
  
              doc.setFont('helvetica', '');
              // @ts-ignore
              var splitDiagnosisObservations = doc.splitTextToSize(note.diagnosis.observations, 180);
              doc.text(splitDiagnosisObservations, 14, (currentY += 8));
            }

            if (currentY > pageHeight) {
              doc.addPage();
              currentY = 0;
            }
          }

          if (type === 'Attention' || type === 'Exams') {

            if (currentY + 75 > doc.internal.pageSize.height) {
              doc.addPage();
              currentY = 0;
            }

            doc.setFont('helvetica', 'bold');
            // @ts-ignore
            doc.text('Examenes solicitados', 14, (currentY += 15));

            var colExams = ['#', 'Nombre'];
            var rowsExam = [];


            if (note.exams.list.length === 0){
              var noExams = ['-', 'Ninguno'];
              rowsExam.push(noExams);
            }
            else {
              for (var i = 0; i < note.exams.list.length; i++) {
                var tempExams = [i + 1, this.titleCasePipe.transform(note.exams.list[i].name)];
                rowsExam.push(tempExams);
            }

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

            // @ts-ignore
            currentY = 12 + doc.lastAutoTable.finalY;

            if (note.exams.observations.length > 0){
              doc.setFont('helvetica', 'italic');
              doc.text('Observaciones', 14, currentY);

              doc.setFont('helvetica', '');
              var splitExamsObservations = doc.splitTextToSize(note.exams.observations, 180);

              // @ts-ignore
              doc.text(splitExamsObservations, 14, (currentY += 8));
            }

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
            finalY = doc.lastAutoTable ? doc.lastAutoTable.finalY + 40 : 105 + 40;
          }

          if (type === 'Interconsultation') {
            var colInterconsultation = ['#', 'Especialidad', 'Motivo'];
            var rowsInterconsultation = [];

            // console.log(note.treatments.list);
            // console.log(note.interconsultation.list);

            if (note.interconsultation.list.length === 0){
              var noInterconsultationTable = [
                '-',
                'Ninguna',
                '-',

              ];
              rowsInterconsultation.push(noInterconsultationTable);
            }
            else{
              for (var i = 0; i < note.interconsultation.list.length; i++) {
                var interconsultationTable = [
                  i + 1,
                  this.titleCasePipe.transform(note.interconsultation.list[i].specialty),
                  note.interconsultation.list[i].reason,
                ];
                rowsInterconsultation.push(interconsultationTable);
              }
            }


            index = note.symptoms.background.length < 1 ? 15 : doc.splitTextToSize(note.symptoms.background, 180).length * 7 + 8;
            // @ts-ignore
            doc.autoTable({
              styles: { theme: 'plain' },
              margin: { top: currentY + index },
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
            finalY = doc.lastAutoTable ? doc.lastAutoTable.finalY + 25 : currentY + 25;
          }

          var pageHeight = doc.internal.pageSize.height;

          if (finalY + 60 > pageHeight) {
            doc.addPage();
            finalY = 30;
          }

          const imageData = signImageDataUrl ? signImageDataUrl : 'data:image/png;base64,' + note.signatuteDraw;

          doc.setFont('helvetica', 'bold');
          if (type === 'Attention' || type === 'Exams'){
            finalY += 30;
          }
          else if (type === 'Interconsultation'){
            finalY += 8;
          }
          else {
            finalY += 10;
          }
          doc.text('Médico', 14, finalY);

          if (note.isSignatureDraw)
          {
               var img = new Image();
               img.src = imageData;
               doc.addImage(img, 'png', 14, 14 + finalY, 90, 15);
               finalY = finalY + 10;
          }
          else{
              if (note.signatuteText){
                doc.setFont('Pacifico-Regular');
                doc.text(note.signatuteText, 14, 14 + finalY);
              }
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
          doc.save(patient.lastnameFather + '_' + type + '.pdf');
        })
        .catch((error: any) => {
          console.log(error);
        });
    } catch (err) {
      console.log(err);
    }
  }
}
