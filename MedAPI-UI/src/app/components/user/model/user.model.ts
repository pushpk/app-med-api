export class User {
  id: string;
  permissions: Array<string>;

  constructor(
    id: string,
    permissions: Array<string>) {
    this.id = id;
    this.permissions = permissions;
  }
}
