import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { jsPDF } from 'jspdf';
import 'jspdf-autotable';
import { CommonService } from 'src/app/services/common.service';
import SignaturePad from 'signature_pad';
import { NoteDetail } from 'src/app/models/noteDetail.model';

@Component({
  selector: 'app-form-summary',
  templateUrl: './form-summary.component.html',
  styleUrls: ['./form-summary.component.scss'],
})
export class FormSummaryComponent implements OnInit {
  @Input() submit: any;
  @Input() note: NoteDetail;
  @Input() patient: any;
  @Input() isEditable: boolean;
  @ViewChild('sPad', { static: true }) signaturePadElement;
  @ViewChild('sPadDiv', { static: true }) signaturePadElementDiv;
  signImageDataUrl: any;

  signaturePad: any;

  constructor(private commonService: CommonService) {}

  ngOnInit(): void {
    this.note.isSignatureDraw = true;
  }

  ngAfterViewInit(): void {
    this.signaturePad = new SignaturePad(
      this.signaturePadElement.nativeElement
    );
  }
  clear() {
    this.signaturePad.clear();
  }
  saveSignature() {
    this.signImageDataUrl = this.signaturePad.toDataURL('image/png');

    fetch(this.signImageDataUrl)
      .then((res) => res.blob())
      .then((imgBlob) => {
        this.note.signatuteDraw = imgBlob;
        console.log(imgBlob);
      });
  }

  signatureOptionChange() {
    if (!this.note.isSignatureDraw) {
      this.signaturePadElementDiv.nativeElement.style.display = 'none';
    } else {
      this.signaturePadElementDiv.nativeElement.style.display = 'block';
      this.signaturePad = new SignaturePad(
        this.signaturePadElement.nativeElement
      );
    }
  }

  downloadAttention() {
    this.commonService.generatePDF(this.patient, this.note, 'Attention');
  }

  downloadPrescription() {
    this.commonService.generatePDF(this.patient, this.note, 'Prescription');
  }

  downloadInter() {
    console.log(this.patient);
    this.commonService.generatePDF(
      this.patient,
      this.note,
      'Interconsultation'
    );
  }
}
