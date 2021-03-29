import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-account-setting',
  templateUrl: './account-setting.component.html',
  styleUrls: ['./account-setting.component.scss'],
})
export class AccountSettingComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;

  // filterType: MatTableFilter;
  // filterEntity: Medic;

  medicRequests: Permissions[];
  medicRequestsDataSource = new MatTableDataSource<Permissions>([]);

  displayedColumnsUpload: string[] = [
    'name',
    'cmp',
    'rne',
    'action',
    'action2',
    'action3',
  ];
  currentUserId: number;
  role: string;

  constructor(
    private patientService: PatientService,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.role = localStorage.getItem('role');
    this.currentUserId = +localStorage.getItem('loggedInID');
    this.patientService
      .getMedicAccessPermissions(this.currentUserId)
      .then((response: any) => {
        this.medicRequests = response.permissions;
        this.medicRequestsDataSource.data = response.permissions;
      })
      .catch((error: any) => {
        console.log(error);
      });
  }

  ngAfterViewInit() {
    this.medicRequestsDataSource.paginator = this.paginator;
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
        this.toastr.success('Respuesta enviada');
      })
      .catch((error: any) => {
        this.toastr.error('Ocurrió un error');
        console.log(error);
      });
  }
}
