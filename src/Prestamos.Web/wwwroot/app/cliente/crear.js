import { Cliente } from './cliente'

class Create {
    constructor(){
        this.cliente = new Cliente();
    }

    crear(){
        alert(this.cliente.Cedula);
    }
}

export { Create }