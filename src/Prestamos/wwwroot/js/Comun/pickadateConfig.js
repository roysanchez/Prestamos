/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../libext/modernizr/modernizr-input.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

/**
* Modulo para configurar el datepicker pickadate
* @module jquery
* @module Modernizr
* @module require
*/
define(['jquery', 'Modernizr', 'require'], function (jq, Modernizr, require) {

    if (!Modernizr.inputtypes.date) {
        /**
        * Modulo para cargar los datepicker pickadate
        * @module picker
        * @module pickadate
        * @module pickerES
        */
        require(['picker', 'pickadate', 'pickerES'], function () {
            //https://github.com/amsul/pickadate.js/issues/160
            jq('[type="date"]').pickadate({
                format: 'yyyy-mm-dd',
                selectYears: 15,
                selectMonths: true,
                min: new Date(1960, 0, 1),
                onClose: function () {
                    jq('.datepicker').blur();
                }
            });
        });
    }
});