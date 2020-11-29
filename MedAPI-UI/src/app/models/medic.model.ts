import { MedicUser } from './medicuser.model';

export class Medic  {
  
    user : MedicUser
    speciality : string  = '';
    cmp : string = '';
    rne : string = '';
    IsApproved : boolean;
    IsFreezed : boolean;
    IsDenied : boolean;
     
    
  }