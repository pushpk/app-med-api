import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Medic } from 'src/app/models/medic.model';
import { CommonService } from 'src/app/services/common.service';
import { User } from '../user/model/user.model';
import { AdminService } from './services/admin.service';
import {MatPaginator} from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableFilter } from 'mat-table-filter';
import { MedicUser } from 'src/app/models/medicuser.model';


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  filterType: MatTableFilter;
  filterEntity: Medic;

  
  nonApprovedMedicsData : Medic[];
  nonApprovedMedics =  new MatTableDataSource<Medic>([]);
  displayedColumnsUpload: string[] = ['user.firstName', 'user.lastNameFather', 'user.lastNameMother', 'rne', 'cmp', 'action', 'action2'];

  constructor(private adminService: AdminService, public router: Router, private changeDetectorRefs: ChangeDetectorRef, 
    private commonService : CommonService, private activatedRouter: ActivatedRoute, public toastr: ToastrService) { }


  ngOnInit(): void {

    var usr = new MedicUser();
    var mdc = new Medic();
    mdc.user = usr;
    
    this.filterEntity = mdc;

    this.filterType = MatTableFilter.ANYWHERE;

    this.adminService.getNonApprovedMedics().then((response : Medic[]) => {
      //f
      console.log(response);
      this.nonApprovedMedicsData = response;
      this.nonApprovedMedics.data = response;
      this.filterEntity = mdc;
      this.filterType = MatTableFilter.ANYWHERE;
      
      
      this.nonApprovedMedics.sort = this.sort;



    }).catch((error : any) => {
       console.log(error);
    });

  }

  ngAfterViewInit() {
    this.nonApprovedMedics.paginator = this.paginator;
    this.nonApprovedMedics.sort = this.sort;

  }

  approveeMedic(id: number){

    this.adminService.approveMedic(id).then((response : Medic) => {
      
      this.adminService.getNonApprovedMedics().then((response : Medic[]) => {
        //f
        console.log(response);
        this.nonApprovedMedicsData = response;
        this.nonApprovedMedics.data = response;
      }).catch((error : any) => {
         console.log(error);
      });
      
    }).catch((error : any) => {
       console.log(error);
    });
    
  }

  freezeMedic(id: number){

    this.adminService.freezeMedic(id).then((response : Medic) => {
      
      this.adminService.getNonApprovedMedics().then((response : Medic[]) => {
        //f
        console.log(response);
        this.nonApprovedMedicsData = response;
        this.nonApprovedMedics.data = response;
      }).catch((error : any) => {
         console.log(error);
      });
      
    }).catch((error : any) => {
       console.log(error);
    });
  }

}
