/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/vue/dist/vue.js"/>
/// <reference path="../../lib/accounting/accounting.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

//TODO Mover la parte de pickadate a un modulo independiente comun

/**
* Modulo para configurar el datepicker pickadate
* @module jquery
* @module Modernizr
* @module require
*/
define(['jquery', 'Modernizr', 'require'], function ($, Modernizr, require) {

    if (!Modernizr.inputtypes.date) {
        /**
        * Modulo para cargar los datepicker pickadate
        * @module picker
        * @module pickadate
        * @module pickerES
        */
        require(['picker', 'pickadate', 'pickerES'], function () {
            //https://github.com/amsul/pickadate.js/issues/160
            $('[type="date"]').pickadate({
                format: 'yyyy-mm-dd',
                selectYears: 15,
                selectMonths: true,
                min: new Date(1960, 0, 1),
                onClose: function () {
                    $('.datepicker').blur();
                }
            });
        });
    }
});