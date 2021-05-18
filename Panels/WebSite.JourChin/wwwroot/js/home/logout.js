'use strict';

function logout() {
    $.ajax(
        {
            url: '/Home/logout',
            type: 'post',
            data: {},
            success: function (result, status, err) {
                window.location.replace("/Home/Login");
            },
            error: function (request, status, error) {
                console.log(request);
            },
        });
}