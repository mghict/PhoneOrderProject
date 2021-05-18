'use strict';

function filter() {

    let isCheckedName = $('#chkName').prop('checked');
    let isCheckedBrand = $('#chkBrand').prop('checked');
    let isCheckedCat = $('#chkCat').prop('checked');

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
        'productName': txtNameVal,
        'brandName': txtBrandVal,
        'sameCategory': isCheckedCat
    }

    $.ajax({
        //dataType: 'json',
        type: 'post',
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

        },
        async: false
    });
}