
'use strict';

$(document).ready(function () {


    var doc = $(document);

    toastr.options = {
        progressBar: true,
        showMethod: "slideDown",
        hideMethod: "slideUp",
        showDuration: 300,
        hideDuration: 300,
        newestOnTop: true,
        positionClass: "toast-top-left",
        closeButton: true,
        timeOut: 0,
        extendedTimeOut: 0,
    };

    //doc.on('click', '.toastr-examples a.btn-success', function () {
    //    toastr.success('با موفقیت انجام شد');
    //});

    //doc.on('click', '.toastr-examples a.btn-danger', function () {
    //    toastr.error('خطایی رخ داد');
    //});

    //doc.on('click', '.toastr-examples a.btn-info', function () {
    //    toastr.info('این یک پیام اطلاعات است');
    //});

    //doc.on('click', '.toastr-examples a.btn-warning', function () {
    //    toastr.warning('شما در حال حاضر مجاز نیستید');
    //});
});