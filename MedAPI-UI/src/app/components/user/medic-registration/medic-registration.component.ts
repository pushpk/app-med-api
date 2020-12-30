import { Component, OnInit } from '@angular/core';
import { Medic } from 'src/app/models/medic.model';
import { PatientService } from '../../patient/service/patient.service';
import { MedicUser } from 'src/app/models/medicuser.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { MustMatchDirective } from 'src/app/shared/directive/mustMatch.directive';
import { MatDialog } from '@angular/material/dialog';
import { DialogTermsAndConditionsComponent } from 'src/app/shared/termsAndConditions/dialog-terms-and-conditions.component';

@Component({
  selector: 'app-medic-registration',
  templateUrl: './medic-registration.component.html',
  styleUrls: ['./medic-registration.component.scss'],
})
export class MedicRegistrationComponent implements OnInit {
  [x: string]: any;
  specialities: string[];
  resources: any;
  medic: Medic = new Medic();
  acceptTermsAndConditions = false;
  showRequiredError = false;

  constructor(
    public router: Router,
    private patientService: PatientService,
    public toastr: ToastrService,
    public dialog: MatDialog,

  ) {
    this.medic.user = new MedicUser();
    this.medic.user.roleId = 2;
  }

  ngOnInit(): void {
    let resourcesPath: string = 'users/resources';

    this.patientService
      .getResources(resourcesPath)
      .then((response: any) => {
        this.patientService.resources.next(response);
      })
      .catch((error) => {
        console.log(error);
      });

    this.patientService.resources.subscribe((o) => {
      this.resources = o;
    });

    this.specialities = [
      'ALEGOLOGIA',
      'ANALISIS CLINICOS',
      'ANATOMIA PATOLOGICA',
      'ANESTESIOLOGIA',
      'BIOQUIMICA CLINICA',
      'CARDIOLOGIA',
      'CIRUGIA CARDIOVASCULAR',
      'CIRUGIA GENERAL',
      'CIRUGIA ORAL Y MAXILOFACIAL',
      'CIRUGIA ORTOPEDICA Y TRAUMATOLOGIA',
      'CIRUGIA PEDIATRICA',
      'CIRUGIA PLASTICA',
      'CIRUGIA TORACICA',
      'CIRUGIA VASCULAR',
      'DERMATOLOGIA',
      'ENDOCRINOLOGIA',
      'ESTOMATOLOGIA',
      'FARMACOLOGIA CLINICA',
      'GASTROENTEROLOGIA',
      'GENETICA MEDICA',
      'GERIATRIA',
      'GINECOLOGIA Y OBSTETRICIA',
      'HEMATOLOGIA',
      'HIDROLOGIA MEDICA',
      'INFECTOLOGIA',
      'INMUNOLOGIA',
      'MEDICINA AEROESPACIAL',
      'MEDICINA DEL DEPORTE',
      'MEDICINA DEL TRABAJO',
      'MEDICINA DE URGENCIAS',
      'MEDICINA FAMILIAR',
      'MEDICINA FISICA Y REHABILITACION',
      'MEDICINA GENERAL',
      'MEDICINA INTENSIVA',
      'MEDICINA INTERNA',
      'MEDICINA LEGAL Y FORENSE',
      'MEDICINA NUCLEAR',
      'MEDICINA PREVENTIVA',
      'MICROBIOLOGIA Y PARASITOLOGIA',
      'NEFROLOGIA',
      'NEUMOLOGIA',
      'NEUROCIRUGIA',
      'NEUROFISIOLOGIA CLINICA',
      'NEUROLOGIA',
      'NUTRIOLOGIA',
      'ODONTOLOGIA',
      'OFTALMOLOGIA',
      'ONCOLOGIA MEDICA',
      'ONCOLOGIA RADIOTERAPICA',
      'OTORRINOLARINGOLOGIA',
      'PEDIATRIA',
      'PROCTOLOGIA',
      'PSIQUIATRIA',
      'QUIRUGICAS',
      'RADIOLOGIA',
      'REHABILITACION',
      'REUMATOLOGIA',
      'TOXICOLOGIA',
      'TRAUMATOLOGIA',
      'UROLOGIA',
    ];
  }

  submitRequest() {
    // console.log(this.medic);
    this.patientService
      .createMedic(this.medic)
      .then((response: any) => {
        // console.log(response);

        this.toastr.success('Médico registrado con éxito.');
        this.router.navigateByUrl('/login');
      })
      .catch((error) => {
        if (error.status === 409) {
          this.toastr.error(
            'Ya existe un médico con el mismo correo electrónico o número de documento o CMP en el sistema'
          );
        } else {
          console.log(error);
          this.toastr.error('Se produjo un error al crear la cuenta.');
        }
      });
  }

  updateProvinces() {
    let resourcesPath: string =
      'department/' + this.medic.user.departmentId + '/provinces';

    this.patientService
      .updateProvinces(resourcesPath)
      .then((response: any) => {
        // console.log(response, 'response');
        this.resources.provinces = response;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  updateDistricts() {
    let resourcesPath: string =
      'province/' + this.medic.user.provinceId + '/districts';

    this.patientService
      .updateDistricts(resourcesPath)
      .then((response: any) => {
        // console.log(response, 'response');
        this.resources.districts = response;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  numberOnly(ele: any) {
    var regex = /[^0-9]/gi;
    ele.value = ele.value.replace(regex, '');
  }

  openTermsAndConditions(){
    let dialogRef = this.dialog.open(DialogTermsAndConditionsComponent, {
      panelClass: 'custom-dialog',
      data: {
      },
      autoFocus: false,
      maxHeight: '90vh',
      maxWidth: '120vw'

    });
    dialogRef.afterClosed().subscribe((response: any) => {
      console.log(response)
      if (response == undefined){
        this.acceptTermsAndConditions = false;
        this.showRequiredError = true;
      }
      else if (response.accept == true) {
        this.acceptTermsAndConditions = true;
        this.showRequiredError = false;
      } else {
        this.acceptTermsAndConditions = false;
        this.showRequiredError = true;
      }

    });

  }
}
