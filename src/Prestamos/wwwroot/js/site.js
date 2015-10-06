requirejs.config({
});

//define('jQuery', [], function () {
//    return $;
//});

requirejs(['jQuery'], function (a) {
    console.debug("entro");
    var x = $("body");
    console.debug(x);
});