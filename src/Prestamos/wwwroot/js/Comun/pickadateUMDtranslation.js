//TODO Verificar si ya la libreria oficial soporta UMD
/**
* Modulo que arregla el error de que el objeto defaults no existe, lo saque de un bug no me acuerdo cual
* @module jquery
* @module picker
* @module pickadate
*/
define(['jquery', 'picker', 'pickadate'], function (jq) {
    jq.fn.pickatime = { defaults: {} };

    jq.extend(jq.fn.pickadate.defaults, {
        monthsFull: ['enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 'julio', 'agosto', 'septiembre', 'octubre', 'noviembre', 'diciembre'],
        monthsShort: ['ene', 'feb', 'mar', 'abr', 'may', 'jun', 'jul', 'ago', 'sep', 'oct', 'nov', 'dic'],
        weekdaysFull: ['domingo', 'lunes', 'martes', 'miércoles', 'jueves', 'viernes', 'sábado'],
        weekdaysShort: ['dom', 'lun', 'mar', 'mié', 'jue', 'vie', 'sáb'],
        today: 'hoy',
        clear: 'borrar',
        close: 'cerrar',
        firstDay: 1,
        format: 'dddd d !de mmmm !de yyyy',
        formatSubmit: 'yyyy/mm/dd'
    });

    jq.extend(jq.fn.pickatime.defaults, {
        clear: 'borrar'
    });

});