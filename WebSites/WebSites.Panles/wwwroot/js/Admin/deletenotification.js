
'use strict';

function DeleteNotification(id) {
    var postData = {
        'id': id
    };

    $.ajax(
        {
            url: '/Admin/Home/DeleteNotification',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {

                showNotification();
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}