// //stackoverflow.com/questions/18754020/bootstrap-3-with-jquery-validation-plugin
// override jquery validate plugin defaults
/**
* Modulo para marcar los errores con bootstrap
* @module jquery
* @module jquery.validate.unobtrusive
* @exports $.validator.unobtrusive
*/
define(['jquery', 'jquery.validate.unobtrusive'], function ($) {
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    return $.validator.unobtrusive;
});