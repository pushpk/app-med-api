import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NoteService } from '../../services/note.service';

@Component({
  selector: 'app-dialog-cardiovascular-risk-framingham',
  templateUrl: './dialog-cardiovascular-risk-framingham.component.html',
  styleUrls: ['./dialog-cardiovascular-risk-framingham.component.scss']
})
export class DialogCardiovascularRiskFraminghamComponent implements OnInit {
  public patient: any = {
    sex: 'M',
    cigarettes: 0,
    personalBackground: ['DIABETES_MELITUS_'],
    medicines: ['ANTIHIPERTENSIVOS'],
    age: 20
  }
  constructor(public dialogRef: MatDialogRef<DialogCardiovascularRiskFraminghamComponent>,
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
      note: this.data.note
    });
  }

  updateComputedFields() {
    this.noteService.updateComputedFieldsEvent.emit(this.data.note);
  }
}
