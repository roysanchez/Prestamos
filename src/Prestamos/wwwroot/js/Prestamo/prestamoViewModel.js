/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/knockout/dist/knockout.debug.js"/>

var PR = PR || {};

(function (window, ko, accounting) {

    PR.PrestamoViewModel = function (model, monedas) {
        model = model || {};

        var self = this;
        self.Moneda = ko.observable(model.Monto != null ? model.Monto.Moneda : null);
        self.Monto = ko.observable(model.Monto != null ? model.Monto.Monto : null);
        self.TextoMonto = ko.computed(function () {
            return accounting.formatMoney(self.Monto(), monedas[self.Moneda()] + "$", 2);
        });

        self.Tasa = ko.observable(model.Porciento);
        self.TextoTasa = ko.computed(function () {
            return accounting.formatMoney(self.Tasa(), '%', 2);
        });

        self.Mora = ko.observable(model.PorcMora);
        self.TextoMora = ko.computed(function () {
            return accounting.formatMoney(self.Mora(), '%', 2);
        });

        self.Cuotas = ko.observable(model.CantCuotas);
        self.TextoCuotas = ko.computed(function () {
            return accounting.formatNumber(self.Cuotas());
        });
    };

}(this.window, this.ko, this.accounting));