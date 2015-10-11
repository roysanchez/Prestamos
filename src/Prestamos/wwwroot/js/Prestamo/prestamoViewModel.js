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
define(['jquery', 'module', 'vuejs', 'accounting', 'Comun/pickadateConfig'],
    function ($, module, Vue, accounting) {
        var model = module.config();

        var vm = new Vue({
            el: '#crearPrestamoForm',
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
            var data = event.target.dataset;

            if (vm.cedula !== "") {
                $.post(data.url, { cedula: vm.cedula })
                    .done(function (cliente) {
                        console.debug("cliente", cliente);
                        vm.deudorId = cliente.Id;
                        vm.nombre = cliente.NombreTitular;
                    });
            } else {
                var modal = $('#' + data.modal);
                modal.modal();
            }
        }

    });