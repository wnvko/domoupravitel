export interface JWT {
  token: string;
}

export interface JwtPayload {
  aud: string;
  exp: number;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name': string;
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier': string;
  iat: Date;
  iss: string;
  jti: string;
  sub: string;
}
