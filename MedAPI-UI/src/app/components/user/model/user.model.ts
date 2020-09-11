export class User {
  id: string;
  name : string;
  role : number;
  permissions: Array<string>;

  constructor(id: string, name: string, role: number, permissions: Array<string>) {
    this.id = id;
    this.name = name;
    this.role = role;
    this.permissions = permissions;
  }
}
