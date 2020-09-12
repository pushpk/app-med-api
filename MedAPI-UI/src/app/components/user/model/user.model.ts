export class User {
  id: string;
  name : string;
  role : number;
  docNumber : string;
  permissions: Array<string>;

  constructor(id: string, name: string, role: number, docNumber : string, permissions: Array<string>) {
    this.id = id;
    this.name = name;
    this.role = role;
    this.docNumber = docNumber;
    this.permissions = permissions;
  }
}
