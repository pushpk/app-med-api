import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-account-setting',
  templateUrl: './account-setting.component.html',
  styleUrls: ['./account-setting.component.scss'],
})
export class AccountSettingComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;

  // filterType: MatTableFilter;
  // filterEntity: Medic;

  medicRequests: Permissions[];
  displayedColumnsUpload: string[] = [
    'medic.user.firstName',
    'medic.rne',
    'medic.cmp',
    'action',
    'action2',
    'action3',
  ];
  currentUserId: number;

  constructor(
    private patientService: PatientService,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.currentUserId = +localStorage.getItem('loggedInID');
    this.patientService
      .getMedicAccessPermissions(this.currentUserId)
      .then((response: any) => {
        this.medicRequests = response.permissions;
      })
      .catch((error: any) => {
        console.log(error);
      });
  }

  changeMedicAccess(medicId: number, action: string) {
    var isMedicAuthorized = false;
    var isFutureRequestBlocked = false;
    var isRequestSent = true;

    switch (action) {
      case 'approve': {
        isMedicAuthorized = true;
        break;
      }
      case 'deny': {
        isMedicAuthorized = false;
        break;
      }
      case 'denyAndBlock': {
        isMedicAuthorized = false;
        isFutureRequestBlocked = true;

        break;
      }
      default: {
        //statements;
        break;
      }
    }

    this.patientService
      .changeMedicAccessForPatient(
        this.currentUserId,
        medicId,
        isMedicAuthorized,
        isFutureRequestBlocked,
        isRequestSent
      )
      .then((response: any) => {
        this.medicRequests = response.permissions;
        this.toastr.success('Success!');
      })
      .catch((error: any) => {
        this.toastr.success('Failed!');
        console.log(error);
      });
  }
}
