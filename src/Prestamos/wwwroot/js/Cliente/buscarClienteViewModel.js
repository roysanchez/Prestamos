/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>

(function (window, $, PR, Vue, accounting) {

    var demo = new Vue({
        el: '#BuscadorClientes',
        name: 'Buscador-Clientes',
        data: {
            cedula: '',
            nombres: '',
            apellidos: ''

        },
        methods: {
            SeleccionCliente: SeleccionarCliente,
            BuscarClientes: BuscarClientes
        }
    });

    function BuscarClientes(event) {
        var vm = this;
    }

    function SeleccionarCliente(event) {
        var vm = this;

    }

}(this.window, this.jQuery, this.PR, this.Vue, this.accounting));