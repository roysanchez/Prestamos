/// <reference path="../../lib/jquery/dist/jquery.js"/>

/**
* Modulo jquery privado, es el que sera utilizado por la aplicación
* @module jquery
*/
define(['jquery'], function (jq) {
    return jq.noConflict(true);
});