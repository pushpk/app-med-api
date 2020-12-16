import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MustMatch } from 'src/app/shared/directive/MustMatch.Validator';
import { PatientService } from '../../patient/service/patient.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup;

  constructor(private fb: FormBuilder, private patientService: PatientService, public router: Router,  private activatedRouter: ActivatedRoute, public toastr: ToastrService) { }

  id:string = '';
  code:string = '';

  ngOnInit(): void {

    this.resetPasswordForm = this.fb.group({

          password: ['', [Validators.required]],
          confirmPassword: ['', Validators.required],


  },  {validator: MustMatch('password', 'confirmPassword')});


  this.activatedRouter.queryParams.subscribe(params => {
    this.id = params['id'];
    this.code = params['code'];
  });

  }

  resetPassword(){

    const self = this;
    let pwd = self.resetPasswordForm.get('password').value;

    this.patientService.resetPassword(this.id,encodeURIComponent(this.code),pwd).then((response: any) => {
      this.toastr.success('Restablecimiento de contraseña exitosa.');
      this.router.navigateByUrl('/login');

    }).catch((error: any) => {
      this.toastr.error('¡Algo salió mal! Póngase en contacto con el servicio de asistencia..');
      this.router.navigateByUrl('/login');
   });
  }

  get f() { return this.resetPasswordForm.controls; }

  passwordConfirming(c: AbstractControl): { invalid: boolean, passwordConfirming : boolean } {
    var self = this;
    if (c.get('password').value !== c.get('confirmPassword').value) {
      console.log(c);
        return {invalid: true, passwordConfirming : true};
    }
}

}
