/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>
/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

/**
* Modulo para configurar la vista de prestamos
* @module jquery
* @module module
* @module vuejs
* @module accounting
* @module Comun/pickadateConfig
*/
define(['jquery', 'module', 'vuejs', 'accounting', 'Cliente/buscarClienteViewModel', 'Comun/pickadateConfig'], function (jq, module, Vue, accounting, buscador) {
    var model = module.config();

    var vm = new Vue({
        el: '#app',
        name: 'Creacion-Prestamos',
        data: {
            deudorId: model.deudorId,
            monto: model.monto,
            textoMonto: '',
            tasa: model.tasa,
            textoTasa: '',
            mora: model.mora,
            textoMora: '',
            cuotas: model.cuotas,
            textoCuotas: '',
            cedula: model.deudorCedula,
            nombre: model.deudorNombre
        },
        methods: {
            BuscarCliente: BuscarClientePorCedula
        },
        components: {
            buscadorCliente: buscador
        }
    });

    vm.$watch(
        function () {
            return [this.monto, this.tasa, this.mora, this.cuotas];
        },
        function (nuevo, viejo) {
            var valores = accounting.formatColumn(nuevo, { format: "%s %v" });
            this.textoMonto = valores[0];
            this.textoTasa = valores[1].replace('$', '%');
            this.textoMora = valores[2].replace('$', '%');
            this.textoCuotas = valores[3].replace('$', ' ');
        },
        {
            immediate: true
        }
    );

    function BuscarClientePorCedula(event) {
        var vm = this;
        if (vm.cedula !== "") {
            //TODO Verificar si hacer un servicio que busque solo los datos que se necesitan aquí
            jq.post(vm.url, { cedula: vm.cedula })
                .done(function (cliente) {
                    console.debug("cliente", cliente);
                    vm.deudorId = cliente.Id;
                    vm.nombre = cliente.NombreTitular;
                });
        } else {
            jq(model.elModal).modal();
        }
    }

    vm.$on('cliente-seleccionado', function (cliente) {
        var vm = this;
        vm.deudorId = cliente.id;
        vm.cedula = cliente.cedula;
        vm.nombre = cliente.nombre;
        jq(model.elModal).modal('hide');
    });

    return vm;
});