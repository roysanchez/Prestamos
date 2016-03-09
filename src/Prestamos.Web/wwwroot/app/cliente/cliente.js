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
        this.FechaNacimiento = data.FechaNacimiento;
        
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
        return `${f(this.PrimerNombre)} ${f(this.SegundoNombre)} ${f(this.PrimerApellido)} ${f(this.SegundoApellido)}`.trim();
    }

    toJson(){
        return JSON.stringify({
            Id: this.Id,
            Cedula: this.Cedula,
            PrimerNombre: this.PrimerNombre,
            SegundoNombre: this.SegundoNombre,
            PrimerApellido: this.PrimerApellido,
            SegundoApellido: this.SegundoApellido,
            FechaNacimiento: this.FechaNacimiento
        });
    }
}

@inject(HttpClient, Validation)
class ClienteFactory {
    constructor(http, validation){
        this.http = http.configure(config => {
            config
                .useStandardConfiguration()
                .withBaseUrl('http://localhost:5001/api/Cliente')
                .withDefaults({
                    headers: {
                        'content-type': 'application/json'
                    },
                    mode: 'cors'
                });
        });
        this.validation = validation;
    }

    Make(data){
        return new Cliente(this.validation, data);
    }

    Get(){
        let addClient = cl => cl.map(c => this.Make(c));
        return this.http.fetch('')
                        .then(resp => resp.json())
                        .then(addClient);
    }

    GetById(id){
        return this.http.fetch(`/${id}`)
                        .then(resp => resp.json())
                        .then(cl => this.Make(cl));
    }

    Create(cliente){
        return this.http.fetch('', { method: 'post', body: cliente.toJson() })
                        .then(resp => console.debug(resp));
    }
}

export { Cliente, ClienteFactory }