import { BiologicalFunctions } from './biologicalFunctions.model';
import { VitalFunctions } from './vitalFunctions.model';
import { TriageOthers } from './triageOthers.model';

export class Triage {
  triageId = 0;
  biologicalFunctions = new BiologicalFunctions();
  vitalFunctions = new VitalFunctions();
  others = new TriageOthers();
}
