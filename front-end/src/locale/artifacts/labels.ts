import { Resource } from './base/resource';

const fileName = 'labels';

export class Labels extends Resource  {
    get Si(): string {
        return this.Provider.translate(fileName, 'Si');
    }

    get No(): string {
        return this.Provider.translate(fileName, 'No');
    }
}
