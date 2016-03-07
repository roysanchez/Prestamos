import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {jQuery} from 'jquery';
import dataTable from 'datatables.net-bs4';
import {ClienteFactory} from './cliente';

@inject(ClienteFactory, jQuery)
class List {
    constructor(factory, $){
        this.factory = factory;
        this.$ = $;
        this.dt = dataTable(window, $);
        this.clientes = [];
    }

    activate(){
        return this.factory.Get().then(cls => this.clientes = cls);
    }

    attached() {
        this.$('.table').dataTable();
    }
}

export { List };