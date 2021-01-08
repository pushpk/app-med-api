import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { jsPDF } from 'jspdf';
import 'jspdf-autotable';
import { CommonService } from 'src/app/services/common.service';
import SignaturePad from 'signature_pad';

@Component({
  selector: 'app-form-summary',
  templateUrl: './form-summary.component.html',
  styleUrls: ['./form-summary.component.scss'],
})
export class FormSummaryComponent implements OnInit {
  @Input() submit: any;
  @Input() note: any;
  @Input() patient: any;
  @Input() isEditable: boolean;
  @ViewChild('sPad', { static: true }) signaturePadElement;
  signaturePad: any;

  constructor(private commonService: CommonService) {}

  ngOnInit(): void {}

  ngAfterViewInit(): void {
    this.signaturePad = new SignaturePad(
      this.signaturePadElement.nativeElement
    );
  }
  clear() {
    this.signaturePad.clear();
  }

  radioChange(e: any) {
    console.log(
      '🚀 ~ file: form-summary.component.ts ~ line 35 ~ FormSummaryComponent ~ radioChange ~ e',
      e
    );
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
