import {computedFrom, inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client'
import {Validation} from 'aurelia-validation';


class Cliente {
    constructor(validation, data){
        if(!data) data = {};

        this.Id = data.Id;
        this.Cedula = data.Cedula;
        this.PrimerNombre = data.PrimerNombre;
        this.SegundoNombre = data.SegundoNombre;
        this.PrimerApellido = data.PrimerApellido;
        this.SegundoApellido = data.SegundoApellido;
        this.Edad = data.Edad;

        this.validation = validation.on(this)
            .ensure('Cedula')
            .isNotEmpty()
            .withMessage('La cédula es obligatoria')
            .containsOnlyDigits()
            .hasLengthBetween(11,11)
            //TODO Validar la cedula
            .ensure('PrimerNombre')
            .withMessage('El nombre es obligatorio')
            .isNotEmpty()
            .ensure('PrimerApellido')
            .isNotEmpty()
            .withMessage('El apellido es obligatorio');
    }

    @computedFrom('PrimerNombre', 'SegundoNombre', 'PrimerApellido', 'SegundoApellido')
    get NombreCompleto(){
        let f = c => c || '';
        return `${f(this.PrimerNombre)} ${f(this.SegundoNombre)} ${f(this.PrimerApellido)} ${f(this.SegundoApellido)}`;
    }
}

@inject(HttpClient, Validation)
class ClienteFactory {
    baseUrl = 'http://localhost:5001/api/Cliente';

    constructor(http, validation){
        this.http = http;
        this.validation = validation;
    }

    Make(data){
        return new Cliente(this.validation, data);
    }

    Get(){
        let addClient = cl => cl.map(c => this.Make(c));
        return this.http.fetch(this.baseUrl, { mode: 'cors' })
                        .then(resp => resp.json())
                        .then(addClient);
    }

    GetById(id){
        return this.http.fetch(`${this.baseUrl}/${id}`, { mode: 'cors' })
                        .then(resp => resp.json())
                        .then(cl => this.Make(cl));
    }
}

export { Cliente, ClienteFactory }