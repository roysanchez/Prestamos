import * as $ from 'globaljquery';

function jQuery(){
    delete window.jQuery;
    return $.noConflict();
}

export {jQuery}