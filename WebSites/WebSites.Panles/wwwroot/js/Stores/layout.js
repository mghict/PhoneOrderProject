
'use strict';



function ShowProfile(){

    $.ajax(
        {
            url: '/Stores/Home/ShowUserProfile',
            type: 'post',
            data: {},
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $('#divUserProfile').html(result);
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function showNotification() {
    $.ajax(
        {
            url: '/Stores/Home/ShowNotification',
            type: 'post',
            data: {},
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $('#divShowNotification').html(result);
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function logout() {
    $.ajax(
        {
            url: '/Stores/Home/logout',
            type: 'get',
            data: {},
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                window.location.replace("/Stores/Home/Login");
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}