import { Component, OnInit, Inject, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-dialog-bmi',
  templateUrl: './dialog-bmi.component.html',
  styleUrls: ['./dialog-bmi.component.scss']
})
export class DialogBmiComponent implements OnInit {
  
  constructor(public dialogRef: MatDialogRef<DialogBmiComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private noteService: NoteService) {
    console.log(data, 'data');
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  updateComputedFields() {
    this.noteService.updateComputedFieldsEvent.emit(this.data.note);
  }

  answer(): void {
    this.dialogRef.close({
      accept: true,
      note: this.data.note
    });
  }
}
