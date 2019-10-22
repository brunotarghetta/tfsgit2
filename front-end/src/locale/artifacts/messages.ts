import { Resource } from './base/resource';

const fileName = 'messages';

export class Messages extends Resource {
    get DeseaContinuar(): string {
        return this.Provider.translate(fileName, 'DeseaContinuar');
    }

    get DeseaConfirmarEstaAccion(): string {
        return this.Provider.translate(fileName, 'DeseaConfirmarEstaAccion');
    }

    get VerificarLosDatosIngresados(): string {
        return this.Provider.translate(fileName, 'VerificarLosDatosIngresados');
    }

    get ErrorValidacion(): string {
        return this.Provider.translate(fileName, 'ErrorValidacion');
    }

    get FaltaConfigurarLosPermisosDeAccesoALasOpcionesDeMenuEnLaPcIngresada(): string {
        return this.Provider.translate(fileName, 'FaltaConfigurarLosPermisosDeAccesoALasOpcionesDeMenuEnLaPcIngresada');
    }
}
