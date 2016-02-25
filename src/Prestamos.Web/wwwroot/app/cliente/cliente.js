class Cliente {
    constructor(){
        this.Cedula = '';
        this.PrimerNombre = '';
        this.SegundoNombre = '';
        this.PrimerApellido = '';
        this.SegundoApellido = '';
    }

    get NombreCompleto(){
        return `${this.NombreCompleto} ${this.SegundoNombre} ${this.PrimerApellido} ${this.SegundoApellido}`;
    }
}

export { Cliente }