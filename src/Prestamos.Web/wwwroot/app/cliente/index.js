import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {jQuery} from 'jquery';
import dataTable from 'datatables.net-bs4';
import {ClienteFactory} from './cliente';

@inject(HttpClient, ClienteFactory, jQuery)
class List {
    constructor(http, factory, $){
        this.http = http;
        this.factory = factory;
        this.$ = $;
        this.dt = dataTable(window, $);
        this.clientes = [];
    }

    activate() {
        var addCliente = cl => this.clientes = cl.map(c => this.factory.Make(c));
        return this.http.fetch('http://localhost:5001/api/Cliente', { mode: 'cors' })
            .then(resp => resp.json().then(addCliente));
    }

    attached() {
        this.$('.table').dataTable();
    }
}

export { List };