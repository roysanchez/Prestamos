//TODO Agregar las configuraciones de jquery-validate y de pickadate, ya que se van a utilizar en todas las pantallas
//de editar
var require = {
    baseUrl: '/js',
    paths: {
        lib: '../lib',
        libext: '../libext',
        jquery: '../lib/jquery/dist/jquery',
        picker: '../lib/pickadate/lib/picker',
        pickadate: '../lib/pickadate/lib/picker.date',
        'jquery.validate': '../lib/jquery-validation/dist/jquery.validate',
        'jquery.validate.unobtrusive': '../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive',
        'jquery.validation.unobtrusive.bootstrap': '../libext/jquery-validation-unobtrusive-bootstrap/jquery.validation.unobtrusive.bootstrap'
    },
    map:{
        '*':{
            'Modernizr': 'libext/modernizr/modernizr-input',
            'pickerES': 'lib/pickadate/lib/translations/es_ES'
        }
    },
    shim: {
        'libext/modernizr/modernizr-input': {
            exports: 'Modernizr',
            init: function () {
                var ret = this.Modernizr;
                this.Modernizr = undefined;
                return ret;
            }
        },
        'lib/pickadate/lib/translations/es_ES': {
            deps: ['picker', 'pickadate', 'Comun/PickaDateTranslationFix'],
            exports: 'jQuery.fn.pickadate.defaults'
        }
    },
    enforceDefine: true
};