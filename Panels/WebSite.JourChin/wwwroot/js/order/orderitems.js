'use strict';

function OrderItemComplate(orderId, itemId, name, count) {

    let message = 'محصول: ' + name + '\n' + 'تعداد: ' + count + '\n' + 'آیا از تایید اطلاعات مطمئن هستید؟';

    swal.fire({
        title: 'تایید',
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله، تایید شود',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            var postData = {
                'orderId': orderId,
                'itemId': itemId
            };

            $.ajax({
                //contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: "POST",
                url: "/Orders/AcceptItem",
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
                            data.message,
                            'warning'
                        );
                    }
                },
                error: function (request, status, error) {
                    hideBehsamLoading();
                }

            });

        }
    });
}

function OrderItemFirstState(orderId, itemId) {

    let message = 'آیا از برگشت اطلاعات به حالت اولیه مطمئن هستید؟';

    swal.fire({
        title: 'تایید',
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله، انجام شود',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            var postData = {
                'orderId': orderId,
                'itemId': itemId
            };

            $.ajax({
                //contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: "POST",
                url: "/Orders/FirstStateItem",
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
                            data.message,
                            'warning'
                        );
                    }
                },
                error: function (request, status, error) {
                    hideBehsamLoading();
                }

            });

        }
    });
}

function OrderItemReject(orderId, itemId, orderCode, name, count) {

    let message = 'محصول: ' + name + '\n' + 'تعداد: ' + count + '\n' + 'آیا از اتمام موجودی کالا مطمئن هستید؟';

    swal.fire({
        title: 'تایید',
        text: message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله، تمام شده است',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            location.replace('/Orders/RejectItem?orderId=' + orderId + '&itemId=' + itemId + '&orderCode=' + orderCode);
        }
    });
}

function OrderComplate(orderCode) {

    swal.fire({
        title: 'تایید',
        text: 'از تایید تکمیل سفارش مطمئن هستید؟',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            var postData = {
                'orderCode': orderCode
            };

            $.ajax({
                //contentType: 'application/x-www-form-urlencoded',
                dataType: 'json',
                type: "POST",
                url: "/Orders/ComplateOrder",
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
                            location.replace('/Orders/CurrentOrder');
                        });
                    }
                    else {
                        swal.fire(
                            'هشدار!',
                            data.message,
                            'warning'
                        );
                    }
                },
                error: function (request, status, error) {
                    hideBehsamLoading();
                }

            });

        }
    });
}