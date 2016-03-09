import {inject} from 'aurelia-framework';
import { ClienteFactory } from './cliente';

@inject(ClienteFactory)
class Create {
    constructor(factory){
        this.factory = factory;
        this.cliente = factory.Make();
    }

    crear(){
        this.cliente.validation.validate().then(c => {
            this.factory.Create(this.cliente);
        }).catch(() => {});;
    }
}

export { Create }