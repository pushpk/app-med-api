import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { jsPDF } from 'jspdf';
import 'jspdf-autotable';
import { CommonService } from 'src/app/services/common.service';
import SignaturePad from 'signature_pad';
import { NoteDetail } from 'src/app/models/noteDetail.model';
import { ToastrService } from 'ngx-toastr';
import { NoteService } from '../services/note.service';

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
  @ViewChild('signatureShow', { static: true }) signatureShow;
  signImageDataUrl: any;

  signaturePad: any;

  constructor(
    private commonService: CommonService,
    private noteService: NoteService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.signatureShow.nativeElement.style.display = 'none';

    if (this.note.isSignatureDraw && this.note.signatuteDraw != null) {
      this.signaturePadElementDiv.nativeElement.style.display = 'none';
      this.signatureShow.nativeElement.style.display = 'block';
      this.signImageDataUrl =
        'data:image/png;base64,' + this.note.signatuteDraw;
    }

    if (!this.note.isSignatureDraw && this.note.signatuteText !== '') {
      this.signaturePadElementDiv.nativeElement.style.display = 'none';
    }
  }

  ngAfterViewInit(): void {
    this.signaturePad = new SignaturePad(
      this.signaturePadElement.nativeElement
    );
  }
  clear() {
    this.signaturePad.clear();
    this.signatureShow.nativeElement.style.display = 'none';
    this.note.signatuteDraw = null;
  }
  saveSignature() {
    this.signImageDataUrl = this.signaturePad.toDataURL('image/png');

    fetch(this.signImageDataUrl)
      .then((res) => res.blob())
      .then((imgBlob) => {
        this.note.signatuteDraw = imgBlob;
      });

    this.signatureShow.nativeElement.style.display = 'block';

    this.toastr.success('¡Firma guardada!');
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
    this.commonService.generatePDF(
      this.patient,
      this.note,
      'Attention',
      this.signImageDataUrl
    );
  }

  downloadPrescription() {
    this.commonService.generatePDF(
      this.patient,
      this.note,
      'Prescription',
      this.signImageDataUrl
    );
  }

  downloadInter() {
    this.commonService.generatePDF(
      this.patient,
      this.note,
      'Interconsultation',
      this.signImageDataUrl
    );
  }

  downloadExams() {
    this.commonService.generatePDF(
      this.patient,
      this.note,
      'Exams',
      this.signImageDataUrl
    );
  }
}
