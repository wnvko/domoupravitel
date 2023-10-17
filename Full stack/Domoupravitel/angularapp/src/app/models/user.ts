import { Role } from "./enums/role";

export interface User {
  id: number;
  userName: string;
  password: string;
  role: Role;
}
