import { Component, OnInit, Input } from '@angular/core';
import { NoteService } from '../services/note.service';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

export interface State {
  flag: string;
  name: string;
  population: string;
}

@Component({
  selector: 'app-form-symptoms',
  templateUrl: './form-symptoms.component.html',
  styleUrls: ['./form-symptoms.component.scss']
})
export class FormSymptomsComponent implements OnInit {
  resources: any;
  @Input() note: any;
  myControl = new FormControl();
  options: string[] = ['One', 'Two', 'Three'];

  constructor(public noteService: NoteService) {
  }

  ngOnInit(): void {
    console.log(this.note, 'note');
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
    });
  }

}
