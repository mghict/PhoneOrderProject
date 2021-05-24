'use strict';

function filter(page,pagesize) {
    alert('ok');

    let isCheckedName = $('#chkName').prop('checked');
    let isCheckedBrand = $('#chkBrand').prop('checked');
    let isCheckedCat = $('#chkCat').prop('checked');

    let itemId = $('#txtItemIdReserve').val();
    let txtNameVal = $('#txtName').val();
    let txtBrandVal = $('#txtBrand').val();

    if (isCheckedName == true && (txtNameVal == null || txtNameVal == '')) {
        swal.fire(
            'هشدار!',
            'نام کالا را وارد کنید',
            'warning'
        );
        return;
    }
    else if (isCheckedName == false) {
        txtNameVal = '';
    }

    if (isCheckedBrand == true && (txtBrandVal == null || txtBrandVal == '')) {
        swal.fire(
            'هشدار!',
            'نام برند را وارد کنید',
            'warning'
        );
        return;
    }
    else if (isCheckedBrand == false) {
        txtBrandVal = '';
    }

    var postData = {
        'itemId': itemId,
        'page': page,
        'pagesize': pagesize,
        'productName': txtNameVal,
        'brandName': txtBrandVal,
        'sameCategory': isCheckedCat,
        
    }

    $.ajax({
        //dataType: 'json',
        type: 'GET',
        url: '/Orders/FilterProducts',
        data: postData,
        beforeSend: function () {
            $('#divFilterProduct').html('');
            showBehsamLoading();
        },
        complete: function () {
            hideBehsamLoading();
        },
        success: function (res) {
            $('#divFilterProduct').html(res);
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(status);
            console.log(error);

        }
    });

}

function fillReversProductList(itemId) {

    $('#slideProductListContent').html('');

    var postData = {
        'itemId': itemId
    };

    $.ajax({
        //dataType: 'json',
        type: 'GET',
        url: '/Orders/RejectListItem',
        data: postData,
        beforeSend: function () {

            showBehsamLoading();
        },
        complete: function () {

            hideBehsamLoading();
        },
        success: function (res) {

            $('#slideProductListContent').html(res);
            //$('#divItemReserve').show();
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(status);
            console.log(error);

        }
    });
}

function additionToList(id) {

    let orderItemId = $('#txtItemIdReserve').val();
    var postData = {
        'orderItemId': orderItemId,
        'productId': id
    };

    $.ajax({
        //dataType: 'json',
        type: 'POST',
        url: '/Orders/AddToRejectList',
        data: postData,
        beforeSend: function () {

            showBehsamLoading();
        },
        complete: function () {

            hideBehsamLoading();
        },
        success: function (res) {

            if (res.isSuccess == true) {
                fillReversProductList(orderItemId);
            }
            else {
                swal.fire(
                    'هشدار!',
                    res.message,
                    'warning'
                );
            }
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(status);
            console.log(error);

        }
    });
}

function deleteFromList(id) {
    var postData = {
        'id': id
    };

    $.ajax({
        //dataType: 'json',
        type: 'POST',
        url: '/Orders/DeleteFromRejectList',
        data: postData,
        beforeSend: function () {

            showBehsamLoading();
        },
        complete: function () {

            hideBehsamLoading();
        },
        success: function (res) {

            if (res.isSuccess == true) {
                $('#txt' + id).hide();
            }
            else {
                swal.fire(
                    'هشدار!',
                    res.message,
                    'warning'
                );
            }
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(status);
            console.log(error);

        }
    });
}

function findBarcode() {
    let barcode = $('#searchkey').val();

    if (barcode == null || barcode == '') {
        return;
    }

    $('#findResult').html('');

    var postData = {
        'barcode': barcode
    };

    $.ajax({
        //dataType: 'json',
        type: 'POST',
        url: '/Orders/FindProduct',
        data: postData,
        beforeSend: function () {

            showBehsamLoading();
        },
        complete: function () {

            hideBehsamLoading();
        },
        success: function (res) {
            $('#findResult').html(res);
        },
        error: function (request, status, error) {
            console.log(request);
            console.log(status);
            console.log(error);

        }
    });
}

$(document).ready(function () {
    let itemId = $('#txtItemIdReserve').val();
    fillReversProductList(itemId);
});