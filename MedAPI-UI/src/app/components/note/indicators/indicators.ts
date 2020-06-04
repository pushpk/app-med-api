interface Indicator {
  // get():number;
}

export class CardiovascularFraminghamIndicator implements Indicator {

  /** cardiovascular desease
   * @param {string} sex patient sex
   * @param age patient age
   * @param SBP systolic preassure
   * @param smoke cigarrettes / day
   * @param TRTBP Treatment for Blood Pressure
   * @param BMI Body Mass Index
   * @param DIAB Patient suffers diabetes
   * @return {number} cardiovascular desease
   */
  get(sex: string,
    age: number,
    SBP: number,
    smoke: boolean,
    TRTBP: boolean,
    BMI: number,
    DIAB: boolean): number {

    age = (age < 30) ? 30 : age;
    age = (age > 70) ? 70 : age;

    var beta: number = 0;

    switch (true) {
      case (sex === 'M' && TRTBP):

        beta += 3.11296 * Math.log(age);
        beta += 1.92672 * Math.log(SBP);
        beta += 0.79277 * Math.log(BMI);
        beta += (smoke) ? 0.70953 : 0;
        beta += (DIAB) ? 0.5316 : 0;

        return 1 - Math.pow(0.88432, Math.exp(beta - 23.9388));

      case (sex === 'M' && !TRTBP):

        beta += 3.11296 * Math.log(age);
        beta += 1.85508 * Math.log(SBP);
        beta += 0.79277 * Math.log(BMI);
        beta += (smoke) ? 0.70953 : 0;
        beta += (DIAB) ? 0.5316 : 0;

        return 1 - Math.pow(0.88432, Math.exp(beta - 23.9388));

      case (sex === 'F' && TRTBP):

        beta += 2.72107 * Math.log(age);
        beta += 2.88267 * Math.log(SBP);
        beta += 0.51125 * Math.log(BMI);
        beta += (smoke) ? 0.61868 : 0;
        beta += (DIAB) ? 0.77763 : 0;

        return 1 - Math.pow(0.94833, Math.exp(beta - 26.0145));

      case (sex === 'F' && !TRTBP):

        beta += 2.72107 * Math.log(age);
        beta += 2.81291 * Math.log(SBP);
        beta += 0.51125 * Math.log(BMI);
        beta += (smoke) ? 0.61868 : 0;
        beta += (DIAB) ? 0.77763 : 0;

        return 1 - Math.pow(0.94833, Math.exp(beta - 26.0145));

    }
  }

}

export class HypertensionIndicator implements Indicator {

  get(sex: string,
    age: number,
    SBP: number,
    DBP: number,
    smoke: boolean,
    PARHT: number,
    BMI: number,
    HT: boolean): number {
    if (HT) {
      return 1;
    }
    age = (age < 20) ? 20 : age;
    age = (age > 70) ? 70 : age;

    var beta: number = 22.949536;

    beta -= 0.156412 * age;
    beta += (sex === 'F') ? -0.202933 : 0;
    beta += -0.033881 * BMI;
    beta += -0.059330 * SBP;
    beta += -0.128468 * DBP;
    beta += (smoke) ? -0.190731 : 0;
    beta -= 0.166121 * PARHT;
    beta += 0.001624 * age * DBP;

    return 1 - Math.exp(-Math.exp((Math.log(4) - beta) / 0.876925));
  }
}

export class DiabetesIndicator implements Indicator {

  get(sex: string,
    age: number,
    WC: number,
    PHYACT: boolean,
    FV: boolean,
    HIGHGL: boolean,
    TRTBP: boolean,
    BMI: number,
    PARDB: boolean,
    DB: boolean): number {
    if (DB) {
      return 1;
    }
    var points: number = 0;

    switch (true) {
      case (age > 64):
        points += 4;
        break;

      case (age > 54):
        points += 3;
        break;

      case (age > 44):
        points += 2;
        break;
    }

    switch (true) {
      case (BMI > 30):
        points += 2;
        break;

      case (BMI > 25):
        points += 1;
        break;
    }

    switch (true) {
      case ((sex === 'M' && 94 < WC && WC <= 102) || (sex === 'F' && 80 < WC && WC <= 88)):
        points += 3;
        break;
      case ((sex === 'M' && WC > 102) || (sex === 'F' && WC > 88)):
        points += 4;
    }

    points += (PHYACT) ? 0 : 2;
    points += (FV) ? 0 : 2;
    points += (HIGHGL) ? 5 : 0;
    points += (TRTBP) ? 2 : 0;
    points += (PARDB) ? 5 : 0;

    switch (true) {
      case (points >= 21):
        return 0.50;

      case (points >= 15):
        return 0.33;

      default:
        return 0.17 * points / 15;
    }
  }
}

export class FractureIndicator implements Indicator {

  get(age: number,
    weight: number,
    falls: number,
    PF: number): number {

    age = (age < 50) ? 50 : age;
    age = (age > 100) ? 100 : age;

    var frisk: number = 0.427;

    frisk += 0.014 * age;
    frisk += -0.027 * weight;
    frisk += 1.978 * falls;
    frisk += 1.081 * PF;

    var result: number = 0.04354 + 0.08362 * frisk - 0.002655 * Math.pow(frisk, 2);

    var lowerLimit = 0.004;
    return (result > lowerLimit) ? result : lowerLimit;
  }
}

export class CardiovascularAgeIndicator implements Indicator {

  get(sex: string,
    age: number,
    SBP: number,
    smoke: boolean,
    TRTBP: boolean,
    HDL: number,
    TCH: number,
    DIAB: boolean): number {

    age = (age < 30) ? 30 : age;
    age = (age > 70) ? 70 : age;

    var beta: number = 0;
    var risk: number = 0;
    var consti: number = 0;
    var numerator: number = 0;

    switch (true) {
      case (sex === 'M' && TRTBP):

        beta += 3.06117 * Math.log(age);
        beta += 1.99881 * Math.log(SBP);
        beta += 1.1237 * Math.log(TCH);
        beta += -0.93263 * Math.log(HDL);
        beta += (smoke) ? 0.65451 : 0;
        beta += (DIAB) ? 0.57367 : 0;

        risk = 1 - Math.pow(0.88936, Math.exp(beta - 23.9802));

        consti = 0;
        consti += 1.99881 * Math.log(SBP);
        consti += 1.1237 * Math.log(TCH);
        consti += -0.93263 * Math.log(HDL);
        consti += (smoke) ? 0.65451 : 0;
        consti += (DIAB) ? 0.57367 : 0;

        numerator = Math.exp((-(consti - 23.9802) / 3.06117));

        return (numerator / 0.4964878537) * Math.pow((-Math.log(1 - risk)), 0.3266724814);

      case (sex === 'M' && !TRTBP):
        beta += 3.06117 * Math.log(age);
        beta += 1.93303 * Math.log(SBP);
        beta += 1.1237 * Math.log(TCH);
        beta += -0.93263 * Math.log(HDL);
        beta += (smoke) ? 0.65451 : 0;
        beta += (DIAB) ? 0.57367 : 0;

        risk = 1 - Math.pow(0.88936, Math.exp(beta - 23.9802));

        consti = 0;
        consti += 1.93303 * Math.log(SBP);
        consti += 1.1237 * Math.log(TCH);
        consti += -0.93263 * Math.log(HDL);
        consti += (smoke) ? 0.65451 : 0;
        consti += (DIAB) ? 0.57367 : 0;

        numerator = Math.exp((-(consti - 23.9802) / 3.06117));

        return (numerator / 0.4964878537) * Math.pow((-Math.log(1 - risk)), 0.3266724814);

      case (sex === 'F' && TRTBP):
        beta += 2.32888 * Math.log(age);
        beta += 2.82263 * Math.log(SBP);
        beta += 1.20904 * Math.log(TCH);
        beta += -0.70833 * Math.log(HDL);
        beta += (smoke) ? 0.52873 : 0;
        beta += (DIAB) ? 0.69154 : 0;

        risk = 1 - Math.pow(0.95012, Math.exp(beta - 26.1931));

        consti = 0;
        consti += 2.82263 * Math.log(SBP);
        consti += 1.20904 * Math.log(TCH);
        consti += -0.70833 * Math.log(HDL);
        consti += (smoke) ? 0.52873 : 0;
        consti += (DIAB) ? 0.69154 : 0;

        numerator = Math.exp((-(consti - 26.1931) / 2.32888));

        return (numerator / 0.2790306551) * Math.pow((-Math.log(1 - risk)), 0.4293909519);
      case (sex === 'F' && !TRTBP):
        beta += 2.32888 * Math.log(age);
        beta += 2.76157 * Math.log(SBP);
        beta += 1.20904 * Math.log(TCH);
        beta += -0.70833 * Math.log(HDL);
        beta += (smoke) ? 0.52873 : 0;
        beta += (DIAB) ? 0.69154 : 0;

        risk = 1 - Math.pow(0.95012, Math.exp(beta - 26.1931));

        consti = 0;
        consti += 2.76157 * Math.log(SBP);
        consti += 1.20904 * Math.log(TCH);
        consti += -0.70833 * Math.log(HDL);
        consti += (smoke) ? 0.52873 : 0;
        consti += (DIAB) ? 0.69154 : 0;

        numerator = Math.exp((-(consti - 26.1931) / 2.32888));

        return (numerator / 0.2790306551) * Math.pow((-Math.log(1 - risk)), 0.4293909519);
    }
  }

}

export class CardiovascularRiskReynoldsIndicator implements Indicator {

  get(age: number,
    SBP: number,
    smoke: boolean,
    HSCRP: number,
    HDL: number,
    TCH: number,
    DIAB: boolean,
    PARCD: boolean): number {

    age = (age < 30) ? 30 : age;
    age = (age > 70) ? 70 : age;

    var beta: number = 0;

    beta += 0.0799 * age;
    beta += 3.137 * Math.log(SBP);
    beta += 0.180 * Math.log(HSCRP);
    beta += 1.382 * Math.log(TCH);
    beta += -1.172 * Math.log(HDL);
    beta += (smoke) ? 0.818 : 0;
    beta += (DIAB) ? 0.134 : 0;
    beta += (PARCD) ? 0.438 : 0;

    return 1 - Math.pow(0.98634, Math.exp(beta - 22.325));
  }
}
