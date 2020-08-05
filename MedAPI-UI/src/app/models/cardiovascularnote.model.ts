import { CardiovascularnoteSkin } from './cardiovascularnoteSkin.model';
import { CardiovascularnotePulse } from './CardiovascularnotePulse.model';
import { CardiovascularnoteRespiratorySystem } from './cardiovascularnoteRespiratorySystem.model';
import { CardiovascularSystem } from './cardiovascularSystem.model';
import { CardiovascularnoteMurmur } from './cardiovascularnoteMurmur.model';
import { CardiovascularnoteGastrointestinalSemiology } from './cardiovascularnoteGastrointestinalSemiology.model';

export class Cardiovascularnote {
  skin: CardiovascularnoteSkin = new CardiovascularnoteSkin();
  pulses: CardiovascularnotePulse = new CardiovascularnotePulse();
  respiratorySystem: CardiovascularnoteRespiratorySystem = new CardiovascularnoteRespiratorySystem();
  cardiovascularSystem: CardiovascularSystem = new CardiovascularSystem();
  murmurs: CardiovascularnoteMurmur = new CardiovascularnoteMurmur();
  gastrointestinalSemiology: CardiovascularnoteGastrointestinalSemiology = new CardiovascularnoteGastrointestinalSemiology();
  fourthNoise = false;
  neckRadiation = false;
  systolicPhase = false;
  thirdNoise = false;
}
