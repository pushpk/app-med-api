import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { NoteService } from '../../services/note.service';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { map, startWith } from 'rxjs/operators';
import { CardiovascularSymptoms } from '../../../../models/cardiovascularSymptoms.model';

@Component({
  selector: 'app-cardio-form-symptoms',
  templateUrl: './cardio-form-symptoms.component.html',
  styleUrls: ['./cardio-form-symptoms.component.scss']
})
export class CardioFormSymptomsComponent implements OnInit {
  resources: any;
  @Input() note: any;
  @Input() patient: any;
  @Input() isEditable: boolean;
  public visible = true;
  public selectable = true;
  public removable = true;
  public addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];
  symptomsCtrl = new FormControl();
  filteredSymptoms: Observable<string[]>;
  //selectedSymptoms: any[] = [];
  @ViewChild('symptomInput') symptomInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  constructor(public noteService: NoteService) {
  }

  ngOnInit(): void {
    this.noteService.resources.subscribe((o) => {
      this.resources = o;
      this.filteredSymptoms = this.symptomsCtrl.valueChanges.pipe(
        startWith(null),
        map((data: string | null) => data ? this._filter(data) : this.resources.cardiovascularSymptom));
    });
  }
  add(event: MatChipInputEvent): void {
    if (!this.isEditable){
      return;
    }
    const input = event.input;
    const value = event.value;

    if ((value || '').trim()) {
      this.note.cardiovascularSymptoms.push(event);
    }

    if (input) {
      input.value = '';
    }

    this.symptomsCtrl.setValue(null);
  }

  remove(o): void {
    if (!this.isEditable){
      return;
    }
    const index = this.note.cardiovascularSymptoms.indexOf(o);

    if (index >= 0) {
      this.note.cardiovascularSymptoms.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    if (!this.isEditable){
      return;
    }
    if (this.note.cardiovascularSymptoms.indexOf(event.option.value) === -1) {
      this.note.cardiovascularSymptoms.push(event.option.value);
    }
    this.symptomInput.nativeElement.value = '';
    this.symptomsCtrl.setValue(null);
  }

  private _filter(value: any): string[] {
    const filterValue = value.name.toLowerCase();
    return this.resources.cardiovascularSymptom.filter(x => x.name.toLowerCase().indexOf(filterValue) === 0);
  }

  addSymptoms(data) {
    if (!this.isEditable){
      return;
    }
    if (this.note.cardiovascularSymptoms.indexOf(data) === -1) {
      let symptoms: CardiovascularSymptoms = {
        id: data.$id,
        cardiovascularSymptoms: data.name,
        cardiovascularNoteId: this.note.id
      }
      this.note.cardiovascularSymptoms.push(symptoms);
    }
  }
}
