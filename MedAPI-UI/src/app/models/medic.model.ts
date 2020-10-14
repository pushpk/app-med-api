import { MedicUser } from './medicuser.model';

export class Medic  {
  
    user : MedicUser
    speciality : string  = '';
    CMP : string = '';
    RNE : string = '';
    IsApproved : boolean;
    IsFreezed : boolean;
    
  }