import {inject} from 'aurelia-framework';
import {ClienteFactory} from './cliente' 

@inject(ClienteFactory)
class List {
    constructor(factory){
        this.factory = factory;
    }

    activate(){
        return this.factory.Get().then(cls => this.clientes = cls);
    }
}

export { List };