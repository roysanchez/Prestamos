/// <reference path="../../lib/jquery/dist/jquery.js"/>
/// <reference path="../../lib/pickadate/lib/picker.js"/>
/// <reference path="../../lib/pickadate/lib/picker.date.js"/>

(function (window, $) {

    //https://github.com/amsul/pickadate.js/issues/160
    if (!Modernizr.inputtypes.date) {
        $('[type="date"]').pickadate({
            onClose: function () {
                $('.datepicker').blur();
            }
        });
    }

}(this.window, this.jQuery));