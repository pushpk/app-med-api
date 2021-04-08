import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Medic } from 'src/app/models/medic.model';
import { CommonService } from 'src/app/services/common.service';
import { User } from '../user/model/user.model';
import { AdminService } from './services/admin.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableFilter } from 'mat-table-filter';
import { MedicUser } from 'src/app/models/medicuser.model';
import { LabUser } from 'src/app/models/labUser.model';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  filterType: MatTableFilter;
  filterEntity: Medic;
  filterEntityLab: LabUser;
  userCounts: any;

  nonApprovedMedicsData: Medic[];
  nonApprovedMedics = new MatTableDataSource<Medic>([]);
  displayedColumnsUpload: string[] = [
    'user.firstName',
    'user.lastNameFather',
    'user.lastNameMother',
    'rne',
    'cmp',
    'status',
    'action',
    'action2',
    'action3',
  ];

  nonApprovedLabData: LabUser[];
  nonApprovedLabs = new MatTableDataSource<LabUser>([]);
  displayedColumnsUploadLab: string[] = [
    'parentCompany',
    'labName',
    'RUC',
    'status',
    'action',
    'action2',
    'action3',
  ];

  constructor(
    private adminService: AdminService,
    public router: Router,
    private changeDetectorRefs: ChangeDetectorRef,
    private commonService: CommonService,
    private activatedRouter: ActivatedRoute,
    public toastr: ToastrService
  ) {}

  ngOnInit(): void {
    var usr = new MedicUser();
    var mdc = new Medic();
    mdc.user = usr;

    this.filterEntity = mdc;
    this.filterType = MatTableFilter.ANYWHERE;

    var usrLab = new MedicUser();
    var lb = new LabUser();
    lb.user = usrLab;

    this.filterEntityLab = lb;
    this.filterType = MatTableFilter.ANYWHERE;

    this.adminService
      .getNonApprovedMedics()
      .then((response: Medic[]) => {
        this.nonApprovedMedicsData = response;
        this.nonApprovedMedics.data = response;
        this.filterEntity = mdc;
        this.filterType = MatTableFilter.ANYWHERE;

        this.nonApprovedMedics.sort = this.sort;
      })
      .catch((error: any) => {
        console.log(error);
      });

    this.adminService
      .getNonApprovedLabs()
      .then((response: LabUser[]) => {
        this.nonApprovedLabData = response;
        this.nonApprovedLabs.data = response;

        this.filterEntityLab = lb;
        this.filterType = MatTableFilter.ANYWHERE;

        // this.nonApprovedMedics.sort = this.sort;
      })
      .catch((error: any) => {
        console.log(error);
      });

      this.userCounts = this.adminService.getActiveUserCounts();

    // this.adminService.getActiveUserCounts().then((response) => {
    //   this.userCounts = response;
    // });
  }

  ngAfterViewInit() {
    this.nonApprovedMedics.paginator = this.paginator;
    this.nonApprovedMedics.sort = this.sort;

    this.nonApprovedLabs.paginator = this.paginator;
    this.nonApprovedLabs.sort = this.sort;
  }

  approveeMedic(id: number) {
    this.adminService
      .approveMedic(id)
      .then((response: Medic) => {
        this.adminService
          .getNonApprovedMedics()
          .then((response: Medic[]) => {
            this.nonApprovedMedicsData = response;
            this.nonApprovedMedics.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }
  denyMedic(id: number) {
    this.adminService
      .denyMedic(id)
      .then((response: Medic) => {
        this.adminService
          .getNonApprovedMedics()
          .then((response: Medic[]) => {
            this.nonApprovedMedicsData = response;
            this.nonApprovedMedics.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }

  freezeMedic(id: number) {
    this.adminService
      .freezeMedic(id)
      .then((response: Medic) => {
        this.adminService
          .getNonApprovedMedics()
          .then((response: Medic[]) => {
            //f
            console.log(response);
            this.nonApprovedMedicsData = response;
            this.nonApprovedMedics.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }

  approveeLab(id: number) {
    this.adminService
      .approveLab(id)
      .then((response: LabUser) => {
        this.adminService
          .getNonApprovedLabs()
          .then((response: LabUser[]) => {
            this.nonApprovedLabData = response;
            this.nonApprovedLabs.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }
  denyLab(id: number) {
    this.adminService
      .denyLab(id)
      .then((response: LabUser) => {
        this.adminService
          .getNonApprovedLabs()
          .then((response: LabUser[]) => {
            this.nonApprovedLabData = response;
            this.nonApprovedLabs.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }
  freezeLab(id: number) {
    this.adminService
      .freezeLab(id)
      .then((response: LabUser) => {
        this.adminService
          .getNonApprovedLabs()
          .then((response: LabUser[]) => {
            this.nonApprovedLabData = response;
            this.nonApprovedLabs.data = response;
          })
          .catch((error: any) => {
            console.log(error);
          });
      })
      .catch((error: any) => {
        console.log(error);
      });
  }
}
