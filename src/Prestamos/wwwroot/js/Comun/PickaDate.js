(function (window, $) {

    //https://github.com/amsul/pickadate.js/issues/160
    if (!Modernizr.inputtypes.date) {
        $('[type="date"]').pickadate({
            format: 'dd-mm-yyyy',
            selectYears: 15,
            selectMonths: true,
            min: new Date(1960, 0, 1),
            onClose: function () {
                $('.datepicker').blur();
            }
        });
    }

}(this.window, this.jQuery));