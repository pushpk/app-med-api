import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from 'src/app/services/common.service';
import { AdminService } from './services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  constructor(private adminService: AdminService, public router: Router, private changeDetectorRefs: ChangeDetectorRef, 
    private commonService : CommonService, private activatedRouter: ActivatedRoute, public toastr: ToastrService) { }

  ngOnInit(): void {
  }

}
