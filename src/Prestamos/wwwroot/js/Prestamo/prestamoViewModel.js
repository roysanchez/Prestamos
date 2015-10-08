/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>
/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

//TODO Mover la parte de pickadate a un modulo independiente comun

/**
* Modulo para configurar la vista de prestamos
* @module jquery
* @module module
* @module vuejs
* @module accounting
* @module Modernizr
* @module require
*/
define(['jquery', 'module', 'vuejs', 'accounting', 'Modernizr', 'require'],
    function ($, module, Vue, accounting, Modernizr, require) {
        var model = module.config();

        if (!Modernizr.inputtypes.date) {
            /**
            * Modulo para cargar los datepicker pickadate
            * @module picker
            * @module pickadate
            * @module pickerES
            */
            require(['picker', 'pickadate', 'pickerES'], function () {
                $('[type="date"]').pickadate({
                    onClose: function () {
                        $('.datepicker').blur();
                    }
                });
            });
        }


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