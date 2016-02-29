import {inject} from 'aurelia-framework';
import { ClienteFactory } from './cliente';

@inject(ClienteFactory)
class Create {
    constructor(factory){
        this.cliente = factory.Make();
    }

    crear(){
        alert(this.cliente.Cedula);
    }
}

export { Create }