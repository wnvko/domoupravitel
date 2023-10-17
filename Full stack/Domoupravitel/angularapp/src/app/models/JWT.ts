import { Role } from "./enums/role";

export interface JWT {
  token: string;
}

export interface JwtPayload {
  aud: string;
  exp: number;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name': string;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier': string;
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': Role;
  iat: Date;
  iss: string;
  jti: string;
  sub: string;
}
