// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

'use strict';



function showBehsamLoading() {
    
    $('.page-loader').fadeIn();
    
}


function hideBehsamLoading() {
    
    $('.page-loader').fadeOut();

}





$(document).ready(function () {
    $('.page-loader').hide();

    $(document).ajaxStart(function () {
        $('.page-loader').show();
    })

    $(document).ajaxComplete(function () {
        $('.page-loader').hide();
    })

});


