import {inject} from 'aurelia-framework';
import {ClienteFactory} from './cliente';

@inject(ClienteFactory)
class Editar {
    constructor(factory){
        this.factory = factory;
    }
    //TODO; Cargar los datos del servicio de consulta
    activate(params) {
        this.id = params.id;
    }
}

export {Editar};