import { Injectable, EventEmitter } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BehaviorSubject } from 'rxjs';

import { jsPDF } from "jspdf";

// import 'jspdf-autotable';


import { Patient } from '../models/patient.model';
import { NoteDetail } from '../models/noteDetail.model';
import { DatePipe } from '@angular/common'


@Injectable({
  providedIn: 'root'
})
export class CommonService {

 


  public sideBar: MatSidenav;

  public currentUrl = new BehaviorSubject<string>(undefined);
  slideEmitter: EventEmitter<any> = new EventEmitter<boolean>(false);

  constructor(public datepipe: DatePipe) {
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

  public generatePDF(patient: Patient, note : NoteDetail, type : string){
    try {

      //Attention
      //Prescription
      //Interconsultation


      var doc = new jsPDF();
     
      doc.setFontSize(35);

      if(type === "Prescription"){
        doc.text("Receta medica", 14, 15);
      }
      else if(type === "Interconsultation"){
        doc.text("Solicitud de interconsulta", 14, 15);
      }
      else{
        doc.text("Atención medica", 14, 15);
      }



      doc.setFontSize(20);

      //Name
      doc.setFont("helvetica", "bold");
      doc.text("Paciente", 14, 30);

      doc.setFont("helvetica", null);
      doc.text(patient.name, 14, 38);

      // Patient Doc Number
      doc.setFont("helvetica", "bold");
      doc.text("DNI", 14, 50);

      doc.setFont("helvetica", null);
      doc.text(patient.documentNumber, 14, 58);

      var  finalY = 0;

      if(type === "Attention")
      {
      // Patient Background Information
      doc.setFont("helvetica", "bold");
      doc.text("Relato", 14, 70);
  
      if(note.symptoms.background)
      {
        doc.setFont("helvetica", null);
        doc.text(note.symptoms.background, 14, 78);
      }

      //Note Examen físico
      doc.setFont("helvetica", "bold");
      doc.text("Examen físico", 14, 95);

      doc.setFont("helvetica", null);
      doc.text(note.physicalExam.text, 14, 103);

      //Diagnóstico
      doc.setFont("helvetica", "bold");
      doc.text("Diagnóstico", 14, 130);

      var col = ["#", "CIE-10", "Descripción", "Tipo"];
      var rows = [];

      for (var i = 0; i < note.diagnosis.list.length; i++) {

        var temp = [i + 1, note.diagnosis.list[i].code, note.diagnosis.list[i].title, note.diagnosis.list[i].type];
        rows.push(temp);

      }
// @ts-ignore
      doc.autoTable({
        styles: { theme: 'plain' },
        margin: { top: 135 },
        body: rows,
        columns: col,
        theme: 'grid',
        headStyles: { fontSize: 18, fontStyle: 'bold', fillColor: 'white', textColor: 'black', lineColor: 'black', lineWidth: 0.5 },
        bodyStyles: { fontSize: 18, textColor: 'black', lineColor: 'black', lineWidth: 0.5 },
        didDrawPage: function (data) {

          //console.log(data);
          // diagossisHeight = data.table.finalY

        }

      });

      

      doc.setFont("helvetica", "bold");
      // @ts-ignore
      doc.text("Examenes solicitados", 14, 12 + doc.lastAutoTable.finalY); // The y position on the page


      //  doc.setFont("helvetica",null);
      //  doc.text("", 14, 190);

      var colExams = ["#", "Nombre", "Especificación"];
      var rowsExam = [];


      for (var i = 0; i < note.exams.list.length; i++) {

        var temp = [i + 1, note.exams.list[i].name, "-"];
        rowsExam.push(temp);

      }

// @ts-ignore
      doc.autoTable({
        styles: { theme: 'plain' },
        margin: { top: 190 },
        // @ts-ignore
        startY: doc.lastAutoTable.finalY + 17,
        body: rowsExam,
        columns: colExams,
        theme: 'grid',
        headStyles: { fontSize: 18, fontStyle: 'bold', fillColor: 'white', textColor: 'black', lineColor: 'black', lineWidth: 0.5 },
        bodyStyles: { fontSize: 18, textColor: 'black', lineColor: 'black', lineWidth: 0.5 }

      });

// @ts-ignore
      finalY = doc.lastAutoTable ?  doc.lastAutoTable.finalY : 140;
    }


    if(type === "Prescription"){

     
      var colTreatments = ["#", "Descripción", "Indicaciones"];
      var rowsTreatments  = [];

      console.log(note.treatments.list);
      console.log(note.interconsultation.list);

      for (var i = 0; i < note.treatments.list.length; i++) {

        var temp = [i + 1, note.treatments.list[i].name, note.treatments.list[i].indications];
        rowsTreatments.push(temp);

      }

// @ts-ignore
      doc.autoTable({
        styles: { theme: 'plain' },
        margin: { top: 70 },
        body: rowsTreatments,
        columns: colTreatments,
        theme: 'grid',
        headStyles: { fontSize: 18, fontStyle: 'bold', fillColor: 'white', textColor: 'black', lineColor: 'black', lineWidth: 0.5 },
        bodyStyles: { fontSize: 18, textColor: 'black', lineColor: 'black', lineWidth: 0.5 }

      });

    // @ts-ignore
      finalY = doc.lastAutoTable ?  doc.lastAutoTable.finalY : 65;

    }

    if(type === "Interconsultation"){

      var colInterconsultation = ["#", "Especialidad", "Motivo"];
      var rowsInterconsultation = [];

      console.log(note.treatments.list);
      console.log(note.interconsultation.list);

      for (var i = 0; i < note.interconsultation.list.length; i++) {

        var temp = [i + 1, note.interconsultation.list[i].specialty, note.interconsultation.list[i].reason];
        rowsInterconsultation.push(temp);

      }

  // @ts-ignore
      doc.autoTable({
        styles: { theme: 'plain' },
        margin: { top: 70 },
        body: rowsInterconsultation,
        columns: colInterconsultation,
        theme: 'grid',
        headStyles: { fontSize: 18, fontStyle: 'bold', fillColor: 'white', textColor: 'black', lineColor: 'black', lineWidth: 0.5 },
        bodyStyles: { fontSize: 18, textColor: 'black', lineColor: 'black', lineWidth: 0.5 }

      });

    // @ts-ignore
      finalY = doc.lastAutoTable ?  doc.lastAutoTable.finalY : 65;
    }

  
      doc.setFont("helvetica", "bold");
      doc.text("Médico", 14, 12 + finalY); 
      var medicData = JSON.parse(localStorage.getItem("userData"));
      var medicName = medicData["name"];

      doc.setFont("helvetica", "");
      doc.text(medicName, 14, 22 + finalY);

      //Patient Sex
      doc.setFont("helvetica", "bold");
      doc.text("Sexo", 156, 30);

      doc.setFont("helvetica", null);
      doc.text(patient.sex, 156, 38);

      // Patient Date of Birth
      doc.setFont("helvetica", "bold");
      doc.text("Fecha", 156, 50);


      doc.setFont("helvetica", null);
      doc.text(this.datepipe.transform(patient.birthday, 'yyyy-MM-dd'), 156, 58);

      doc.save('Test.pdf');
    }
    catch (err) {
      console.log(err);
    }

  }

  
}
