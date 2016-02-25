import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client'
import {Cliente} from './cliente' 

@inject(HttpClient)
class List {
    constructor(http){
        this.http = http;
    }

    activate(){
        this.http.fetch('http://localhost:5001/api/Cliente').then(function(a){
            alert(a);
        });
    }
}

export { List };