import { Component, OnInit, Input } from '@angular/core';
import { jsPDF } from "jspdf";
import 'jspdf-autotable';
import { CommonService } from 'src/app/services/common.service';


@Component({
  selector: 'app-form-summary',
  templateUrl: './form-summary.component.html',
  styleUrls: ['./form-summary.component.scss']
})
export class FormSummaryComponent implements OnInit {
  @Input() submit: any;
  @Input() note: any;
  @Input() patient: any;

  constructor(private commonService: CommonService) { }

  ngOnInit(): void {
  }

  
  downloadAttention(){

    this.commonService.generateAttentionPDF(this.patient, this.note);
  }

  downloadPrescription(){}

  downloadInter(){}
}
