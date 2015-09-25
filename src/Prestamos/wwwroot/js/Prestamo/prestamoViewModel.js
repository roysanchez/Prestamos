/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>
/// <reference path="../../lib/accounting/accounting.js"/>

(function (window, $, PR, Vue, accounting) {

    //https://github.com/amsul/pickadate.js/issues/160
    if (!Modernizr.inputtypes.date) {
        $('[type="date"]').pickadate({
            onClose: function () {
                $('.datepicker').blur();
            }
        });
    }

    var model = PR.PrestamoViewModel;

    var demo = new Vue({
        el: '#crearPrestamoForm',
        name: 'Creacion-Prestamos',
        data: {
            monto: model.monto,
            textoMonto: "",
            tasa: model.tasa,
            textoTasa: "",
            mora: model.mora,
            textoMora: "",
            cuotas: model.cuotas,
            textoCuotas: "",
            cedula : model.deudorCedula
        },
        methods: {
            BuscarCliente: BuscarClientePorCedula
        }
    });

    demo.$watch(
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
        var cedula = this.cedula;
        var url = PR.PrestamoViewModel.urlBuscarCliente;

        var posting = $.post(url, { cedula: cedula });
        posting.done(function (cliente) {
            console.debug("cliente", cliente);
        });
    }

}(this.window, this.jQuery, this.PR, this.Vue, this.accounting));