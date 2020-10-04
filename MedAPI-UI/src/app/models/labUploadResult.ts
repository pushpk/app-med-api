import { MedicUser } from './medicuser.model';

export class LabUploadResult  {
  
    
    file : File;
    comments : string = '';
    fileName : string = '';
    user_Id : number = 0;
    dateUploaded : Date = new Date();
    labId : number = 0;
    medicId : number = 0;
    
    
  }