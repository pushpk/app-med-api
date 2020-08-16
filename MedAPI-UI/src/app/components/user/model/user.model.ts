export class User {
  id: string;
  name : string;
  permissions: Array<string>;

  constructor(
    id: string,
    name: string,
    permissions: Array<string>) {
    this.id = id;
    this.name = name;
    this.permissions = permissions;
  }
}
