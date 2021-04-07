
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
        url: '/Admin/Home/Login',
        data: model,
        beforeSend: function () {
            $("#global-loader").show();
        },
        complete: function () {
            $("#global-loader").hide();
        },
        success: function (res) {
            if (res.isSuccess == true) {

                swal.fire(
                    'موفق!',
                    'ورود موفق کاربر',
                    'success'
                ).then(function (isConfirm) {
                    location.replace('/Admin/Home/Index');
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