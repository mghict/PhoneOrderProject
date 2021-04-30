
'use strict';



function login() {

    //alert('start login()');

    var model = {
        'userName': $('#txtUserName').val(),
        'password': $('#txtPassword').val()
    };

    //alert(model);

    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Stores/Home/Login',
        data: model,
        beforeSend: function () {
            showBehsamLoading();
        },
        complete: function () {
            hideBehsamLoading();
        },
        success: function (res) {
            if (res.isSuccess == true) {

                swal.fire(
                    'موفق!',
                    'ورود موفق کاربر',
                    'success'
                ).then(function (isConfirm) {
                    location.replace('/Stores/Home/Index');
                });

            } else {
                swal.fire(
                    'هشدار!',
                    res.errors,
                    'warning'
                );
            }
        },
        error: function (request, status, error) {
            swal.fire(
                'هشدار!',
                request.responseText + '-' + status.responseText + '-' + error.responseText,
                'warning'
            );

        }
    });

    //
}