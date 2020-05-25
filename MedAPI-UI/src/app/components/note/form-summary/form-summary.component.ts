import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-form-summary',
  templateUrl: './form-summary.component.html',
  styleUrls: ['./form-summary.component.scss']
})
export class FormSummaryComponent implements OnInit {
  @Input() submit: any;
  @Input() note: any;

  constructor() { }

  ngOnInit(): void {
  }

}
