export interface JWT {
  jwt: string;
}

export interface JwtPayload {
  id: number;
  exp: number;
  iat: number;
}
