import { Component, OnInit, Input, } from '@angular/core';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-form-triage',
  templateUrl: './form-triage.component.html',
  styleUrls: ['./form-triage.component.scss']
})
export class FormTriageComponent implements OnInit {
  resources: any;
  @Input() note: any;

  constructor(public noteService: NoteService) {
  }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

  updateComputedFields() {

  }
  showIndicatorDialog(o: any) { }
}
