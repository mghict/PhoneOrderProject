
'use strict';

function showBehsamLoading() {

    $('.ajax-loader').fadeIn();

}

function hideBehsamLoading() {

    $('.ajax-loader').fadeOut();

}

$(document).ready(function () {

    $('.ajax-loader').hide();

    $(document).ajaxStart(function () {
        $('.ajax-loader').show();
    })

    $(document).ajaxComplete(function () {
        $('.ajax-loader').hide();
    })

    $(document).ajaxError(function (e, xhr) {
        $('.ajax-loader').hide();

        if (xhr.status == 401 || xhr.status == 403) {
            swal.fire(
                'هشدار!',
                'شما به عملیات مورد نظر دسترسی ندارید',
                'warning'
            );
        }

    });

});
