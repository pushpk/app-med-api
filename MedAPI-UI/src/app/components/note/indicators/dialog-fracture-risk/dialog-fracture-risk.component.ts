import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-dialog-fracture-risk',
  templateUrl: './dialog-fracture-risk.component.html',
  styleUrls: ['./dialog-fracture-risk.component.scss']
})
export class DialogFractureRiskComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<DialogFractureRiskComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private noteService: NoteService) {
    console.log(data, 'data');
  }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close();
  }

  answer(): void {
    this.dialogRef.close({
      accept: true,
      note: this.data.note,
      patient: this.data.patient
    });
  }

  updateComputedFields() {
    this.noteService.updateComputedFieldsEvent.emit(this.data.note);
  }

}
