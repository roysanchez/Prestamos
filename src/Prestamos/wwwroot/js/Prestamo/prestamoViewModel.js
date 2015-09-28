/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>
/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

(function (window, $, PR, Vue, accounting) {

    ////https://github.com/amsul/pickadate.js/issues/160
    //if (!Modernizr.inputtypes.date) {
    //    $('[type="date"]').pickadate({
    //        onClose: function () {
    //            $('.datepicker').blur();
    //        }
    //    });
    //}

    var model = PR.PrestamoViewModel;

    var demo = new Vue({
        el: '#crearPrestamoForm',
        name: 'Creacion-Prestamos',
        data: {
            deudorId: model.deudorId,
            monto: model.monto,
            textoMonto: "",
            tasa: model.tasa,
            textoTasa: "",
            mora: model.mora,
            textoMora: "",
            cuotas: model.cuotas,
            textoCuotas: "",
            cedula: model.deudorCedula,
            nombre: model.deudorNombre
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
        var vm = this;
        var data = event.target.dataset;

        if (vm.cedula !== "") {
            $.post(data.url, { cedula: vm.cedula })
                .done(function (cliente) {
                    console.debug("cliente", cliente);
                    vm.deudorId = cliente.Id;
                    vm.nombre = cliente.NombreTitular;
                });
        } else {
            $('#' + data.modal).modal();
        }

        
    }

}(this.window, this.jQuery, this.PR, this.Vue, this.accounting));