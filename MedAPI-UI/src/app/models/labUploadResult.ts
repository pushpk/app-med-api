import { MedicUser } from './medicuser.model';

export class LabUploadResult  {
  
    id: number  = 0;
    file: File;
    comments: string = '';
    fileName: string = '';
    user_id: number = 0;
    patient_docNumber : number = 0;
    uploadedBy: string = '';
    dateUploaded: Date = new Date();
    labId: number = 0;
    medicId: number = 0;
    
    
  }