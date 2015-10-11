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
* @module Modernizr
* @module require
*/
define(['jquery', 'module', 'Modernizr', 'require'], function ($, module, Modernizr, require) {
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
                format: 'yyyy-mm-dd',
                onClose: function () {
                    $('.datepicker').blur();
                }
            });
        });
    }

});