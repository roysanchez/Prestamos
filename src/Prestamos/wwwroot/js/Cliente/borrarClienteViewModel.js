/**
* Modulo para configurar la vista de borrar el cliente
* @module module
* @module vuejs
*/
define(['module', 'vuejs'], function (module, Vue) {
    var model = module.config();

    var vmBorrar = new Vue({
        el: model.formaBorrar,
        name: 'Borrar-Cliente',
        data: {
        },
        methods: {
            borrarCliente: function (event) {
                if (!window.confirm(model.mensajeBorrar)) {
                    event.preventDefault();
                }
            }
        }
    });

});