import * as decode from 'jwt-decode';
import { JwtSecurityTokenDescriptor } from './jwt-security-token-descriptor';
// import { Sede } from '../../../shared/data-models/sede';
// import { Sociedad } from '../../../shared/data-models/sociedad';
// import { Terminal } from '../../../shared/data-models/terminal';

export class UserContext {

  private readonly tokenDescriptor: JwtSecurityTokenDescriptor;

  constructor(public readonly token: string) {
    this.tokenDescriptor = decode<JwtSecurityTokenDescriptor>(this.token);
  }

  get idUsuario(): number {
    return this.tokenDescriptor.nameid;
  }

  get nombreUsuario(): string {
    return this.tokenDescriptor.unique_name;
  }

  get idPuestoTrabajo(): number {
    return this.tokenDescriptor.worksid;
  }

//   get terminal(): Terminal {
//     const propietario = new Sociedad(this.tokenDescriptor.socid, this.tokenDescriptor.soc_name);
//     const sede = new Sede(this.tokenDescriptor.siteid, this.tokenDescriptor.site_alias.toString(),
//       this.tokenDescriptor.site_name, this.tokenDescriptor.site_wh);

//     return new Terminal(this.tokenDescriptor.termid,
//                         this.tokenDescriptor.term_name,
//                         this.tokenDescriptor.term_card,
//                         propietario, sede,
//                         this.tokenDescriptor.term_code,
//                         this.tokenDescriptor.term_harvest);
//   }
}
