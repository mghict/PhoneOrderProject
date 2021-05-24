'use strict';

function showUserProfile() {

    $('#userProfile').html('');

    $.ajax(
        {
            url: '/Home/ShowUserProfile',
            type: 'post',
            data: {},
            success: function (result, status, err) {
                $('#userProfile').html(result);
            },
            error: function (request, status, error) {
                console.log(request);
            },
        });
}