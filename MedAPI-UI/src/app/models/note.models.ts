export class Note {
  id: number = 0;
  constructor(data?: any) {
    if (data) {
      if (data.id) {
        this.id = data.id;
      }
    }
  }
}
