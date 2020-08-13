export class JwtSecurityTokenDescriptor {

    constructor(
      public readonly siteid: number,
      public readonly site_alias: number,
      public readonly site_name: string,
      public readonly site_wh: boolean,
      public readonly socid: number,
      public readonly soc_name: string,
      public readonly termid: number,
      public readonly term_name: string,
      public readonly term_card: boolean,
      public readonly unique_name: string,
      public readonly nameid: number,
      public readonly nbf: number,
      public readonly exp: number,
      public readonly iat: number,
      public readonly iss: string,
      public readonly term_code: string,
      public readonly term_harvest: boolean,
      public readonly worksid: number
    ) { }
  }
  