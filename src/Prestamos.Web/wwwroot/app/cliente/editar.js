import {inject} from 'aurelia-framework';
import {ClienteFactory} from './cliente';

@inject(ClienteFactory)
class Editar {
    constructor(factory){
        this.factory = factory;
    }
    //TODO; Cargar los datos del servicio de consulta
    activate(params) {
        return this.factory.GetById(params.id)
                           .then(c => this.cliente = c);
    }
}

export {Editar};