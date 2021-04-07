
'use strict';



function showNotification() {
    $.ajax(
        {
            url: '/CallCenter/Home/ShowNotification',
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
            url: '/CallCenter/login/logout',
            type: 'get',
            data: {},
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                window.location.replace("/CallCenter/Login/Login");
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function ShowProfile() {

    $.ajax(
        {
            url: '/CallCenter/Login/ShowUserProfile',
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