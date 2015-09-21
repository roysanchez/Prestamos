/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/knockout/dist/knockout.js"/>

var PR = PR || {};

(function (window, ko, accounting) {

    PR.PrestamoViewModel = function (model, monedas) {
        model = model || {};

        var self = this;
        self.Moneda = ko.observable(model.Monto != null ? model.Monto.Moneda : null);
        self.Monto = ko.observable(model.Monto != null ? model.Monto.Monto : null);
        self.Tasa = ko.observable(model.Porciento);
        self.Mora = ko.observable(model.PorcMora);
        self.Cuotas = ko.observable(model.CantCuotas);
        self.Labels = ko.observableArray([self.Moneda, self.Monto, self.Tasa, self.Mora, self.Cuotas]);

        self.Labels.subscribe(function () {
            console.log("entro");
        });

        self.TextoMonto = ko.computed(function () {
            self.Labels.valueHasMutated();
            return accounting.formatMoney(self.Monto(), monedas[self.Moneda()] + "$", 2);
        });

        
        self.TextoTasa = ko.computed(function () {
            return accounting.formatMoney(self.Tasa(), '%', 2);
        });

        
        self.TextoMora = ko.computed(function () {
            return accounting.formatMoney(self.Mora(), '%', 2); 
        });

        
        self.TextoCuotas = ko.computed(function () {
            return accounting.formatNumber(self.Cuotas());
        });
    };

}(this.window, this.ko, this.accounting));