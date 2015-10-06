/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>

(function (window, $, PR, Vue) {

    var vm = new Vue({
        el: '#BuscadorClientes',
        name: 'Buscador-Clientes',
        data: {
            cedula: '',
            nombres: '',
            apellidos: '',
            clientes: [],
            url: '/Cliente/BuscarClientes',
            indBusca: false

        },
        methods: {
            SeleccionCliente: SeleccionarCliente,
            BuscarClientes: BuscarClientes
        }
    });

    function BuscarClientes(event) {
        var model = this;

        model.indBusca = true;
        $.post(model.url, { cedula: model.cedula })
            .done(function (data) {
                model.clientes = data;
                model.indBusca = false;
            });
    }

    function SeleccionarCliente(event) {
        //var vm = this;
        var x = 2;

    }

}(this.window, this.jQuery, this.PR, this.Vue));