'use strict';

function DeleteInActiveIndex(Id) {
    swal.fire({
        title: 'حذف',
        text: "آیا از حذف اطلاعات مطمئن هستید؟",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله، حذف شود',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            var postData = {
                'id': Id,
            };

            $.ajax({
                //contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: "POST",
                url: "/Admin/InActive/Delete",
                data: postData,
                beforeSend: function () {
                    showBehsamLoading();
                },
                complete: function () {
                    hideBehsamLoading();
                },
                success: function (data) {
                    if (data.isSuccess == true) {
                        swal.fire(
                            'موفق!',
                            'با موفقیت انجام شد',
                            'success'
                        ).then(function (isConfirm) {
                            location.reload();
                        });
                    }
                    else {
                        swal.fire(
                            'هشدار!',
                            errors,
                            'warning'
                        );
                        location.reload();
                    }
                },
                error: function (request, status, error) {
                    hideBehsamLoading();
                    console.log(request);
                    console.log(status);
                    console.log(error);
                }

            });

        }
    });
}