import { MedicUser } from './medicuser.model';

export class Medic {
  user: MedicUser;
  speciality: string = '';
  cmp: string = '';
  rne: string = '';
  IsApproved: boolean;
  IsFreezed: boolean;
  IsDenied: boolean;
}
export class Permissions {
  medicId: number;
  patientId: number;
  isMedicAuthorized: boolean;
  isFutureRequestBlocked: boolean;
  medic: Medic;
}
