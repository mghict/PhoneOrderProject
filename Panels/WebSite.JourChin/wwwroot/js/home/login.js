'use strict';



function login() {

    //alert($('#txtUserName').val());
    $('#btnLogin').prop("disabled", true);

    var model = {
        'userName': $('#txtUserName').val(),
        'password': $('#txtPassword').val()
    };

    //alert(model);

    $.ajax({
        dataType: 'json',
        type: 'POST',
        url: '/Home/Login',
        data: model,
        beforeSend: function () {
            showBehsamLoading();
        },
        complete: function () {
            hideBehsamLoading();
            $('#btnLogin').prop("disabled", false);
        },
        success: function (res) {
            if (res.isSuccess == true) {

                location.replace('/Home/Index');

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

            $('#btnLogin').prop("disabled", false);

        }
    });

    //
}