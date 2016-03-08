//Es necesario comentar este jquery en config.js de jspm debido a https://github.com/jspm/jspm-cli/issues/1388
import * as $ from 'globaljquery';

function jQuery(){
    delete window.jQuery;
    return $.noConflict();
}

export {jQuery}