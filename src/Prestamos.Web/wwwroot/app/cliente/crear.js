import {inject} from 'aurelia-framework';
import { ClienteFactory } from './cliente';

@inject(ClienteFactory)
class Create {
    constructor(factory){
        this.cliente = factory.Make();
    }

    crear(){
        this.cliente.validation.validate().then(c => {
            alert(this.cliente.Cedula);
        }).catch(() => {});;
    }
}

export { Create }