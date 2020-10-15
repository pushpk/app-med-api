export class User {
  id: string;
  name : string;
  role : number;
  docNumber : string;
  permissions: Array<string>;
  IsApproved  : boolean;
   IsFreezed : boolean;

  constructor(id: string, name: string, role: number, docNumber : string, permissions: Array<string>, IsApproved  : boolean, IsFreezed : boolean) {
    this.id = id;
    this.name = name;
    this.role = role;
    this.docNumber = docNumber;
    this.permissions = permissions;
    this.IsApproved = IsApproved;
    this.IsFreezed = IsFreezed;
  }
}
