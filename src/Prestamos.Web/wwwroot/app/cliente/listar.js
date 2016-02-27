import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client'
import {Cliente} from './cliente' 

@inject(HttpClient)
class List {
    constructor(http){
        this.http = http;
        this.clientes = [];
    }

    activate(){
        var addCliente = cl => this.clientes = cl.map(c => new Cliente(c));
        return this.http.fetch('http://localhost:5001/api/Cliente', { mode: 'cors' })
            .then(resp => resp.json().then(addCliente));
    }
}

export { List };