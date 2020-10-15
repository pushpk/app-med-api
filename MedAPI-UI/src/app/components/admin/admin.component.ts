import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Medic } from 'src/app/models/medic.model';
import { CommonService } from 'src/app/services/common.service';
import { User } from '../user/model/user.model';
import { AdminService } from './services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  nonApprovedMedicsData : Medic[];
  nonApprovedMedics =  new MatTableDataSource<Medic>([]);
  displayedColumnsUpload: string[] = ['user.firstName','user.lastNameMother','user.lastNameFather', 'rne','cmp','action', 'action2'];

  constructor(private adminService: AdminService, public router: Router, private changeDetectorRefs: ChangeDetectorRef, 
    private commonService : CommonService, private activatedRouter: ActivatedRoute, public toastr: ToastrService) { }

  ngOnInit(): void {

    
    this.adminService.getNonApprovedMedics().then((response : Medic[]) => {
      //f
      console.log(response);
      this.nonApprovedMedicsData = response;
      this.nonApprovedMedics.data = response;
    }).catch((error : any) => {
       console.log(error);
    });

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
