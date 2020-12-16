import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-dialog-close-attention',
  templateUrl: './dialog-close-attention.component.html',
  styleUrls: ['./dialog-close-attention.component.scss']
})
export class DialogCloseAttentionComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogCloseAttentionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.dialogRef.close({
      accept: false,
    });
  }

  answer() {
    this.dialogRef.close({
      accept: true,
    });
  }
}
