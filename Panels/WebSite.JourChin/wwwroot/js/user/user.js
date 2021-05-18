'use strict';



function sendRequest() {

    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/User/SendRequest',
        data: {},
        beforeSend: function () {
            showBehsamLoading();
        },
        complete: function () {
            hideBehsamLoading();
        },
        success: function (res) {
            if (res.isSuccess == true) {

                location.replace('/Home/Index');

            } else {

                swal.fire({
                    title: 'هشدار!',
                    text: res.message,
                    icon: 'warning',
                    showCancelButton: false,
                    confirmButtonColor: '#8a0c1f',
                    //cancelButtonColor: '#8a8581',
                    confirmButtonText: 'بستن',
                    //cancelButtonText: 'خیر'
                });
            }
        },
        error: function (request, status, error) {

            swal.fire(
                'هشدار!',
                request.responseText + '-' + status.responseText + '-' + error.responseText,
                'warning'
            );

            $('#btnLogin').prop("disabled", false);

        }
    });

    //
}