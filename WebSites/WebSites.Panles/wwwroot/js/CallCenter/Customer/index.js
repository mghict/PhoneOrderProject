function Delete(Id) {
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
                'customerId': Id,
            };

            $.ajax({
                //contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: "POST",
                url: "/CallCenter/Customer/Delete",
                data: postData,
                beforeSend: function () {
                    showBehsamLoading();
                },
                complete: function () {
                    hideBehsamLoading();
                },
                success: function (data) {
                    hideBehsamLoading();
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