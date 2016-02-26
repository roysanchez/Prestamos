class Cliente {
    constructor(data){
        this.Id = data.Id;
        this.Cedula = data.Cedula;
        this.PrimerNombre = data.PrimerNombre;
        this.SegundoNombre = data.SegundoNombre;
        this.PrimerApellido = data.PrimerApellido;
        this.SegundoApellido = data.SegundoApellido;
        this.Edad = data.Edad;
    }

    get NombreCompleto(){
        let f = c => c || '';
        return `${f(this.PrimerNombre)} ${f(this.SegundoNombre)} ${f(this.PrimerApellido)} ${f(this.SegundoApellido)}`;
    }
}

export { Cliente }