'use strict';

function ShowSubCat(id) {
    var postData = {
        'catId': id,
    };
    var elem = '#lst' + id;

    $.ajax(
        {
            url: '/CallCenter/Order/GetSubCategory',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $(elem).html(result);
                $(elem).fadeIn();
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function ShowProduct(id,pageNum,pageSize) {

    var storeId = $("#txtStoreId").val();
    var search = $("#txtSearch").val();
    
    if (storeId == null || storeId.trim() == "") {
        return;
    }

    var postData = {
        'catId': id,
        'storeId': storeId,
        'pageNumber': pageNum,
        'pageSize': pageSize,
        'searchKey': search
    };

    $.ajax(
        {
            url: '/CallCenter/Order/ShowProduct',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $('#CategoryId').val(id);
                $('#ProductList').html(result);
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function delProductCount(id) {


    var elem = '#' + id;
    let count = $(elem).val();
    if (count == null || count == "" || count < 1) {
        count = 1;
    }
    else {
        count--;
        if (count < 1) {
            count = 1;
        }
    }

    $(elem).val(count);
    $(elem).focus();
}

function addProductCount(id) {

    var elem = '#' + id;
    let count = $(elem).val();
    if (count == null || count == "" || count < 1) {
        count = 1;
    }
    else {
        count++;
    }

    $(elem).val(count);
    $(elem).focus();
}

function showCart() {

    let storeId = $('#txtStoreId').val();
    let customerId = $('#CustomerId').val();

    var postData = {
        'storeId': storeId,
        'customerId': customerId
    };

    $.ajax(
        {
            url: '/CallCenter/Order/ShowCart',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $('#bodyShowCart').html(result);
                showCartDetails();
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function showCartDetails() {

    let storeId = $('#txtStoreId').val();
    let customerId = $('#txtCustomerId').val();

    var postData = {
        'storeId': storeId,
        'customerId': customerId
    };

    $.ajax(
        {
            url: '/CallCenter/Order/ShowCartCount',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                $('#headerShowCart').text(result.count);
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function addCart(pid, count, uPrice, name,tax) {

    let storeId = $('#txtStoreId').val();
    let customerId = $('#CustomerId').val();
    let addId = $('#AddressId').val();
    let sTime = $('#StartTime').val();
    let eTime = $('#EndTime').val();
    let ship = $('#txtShipping').val();

    var postData = {
        'storeId': storeId,
        'customerId': customerId,
        'productId': pid,
        'count': count,
        'addressId': addId,
        'startTime': sTime,
        'endTime': eTime, 
        'unitPrice': uPrice,
        'productName': name,
        'tax': tax,
        'shipping':ship
    };

    $.ajax(
        {
            url: '/CallCenter/Order/AddToCart',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                if (result.isSuccess) {
                    addCartUpdateDetails(pid, result.count);
                    toastr.success(result.message,"پیغام");
                    //toastr["success"](result.message);
                }
                else {
                    toastr.error(result.message);
                }
                
            },
            error: function (request, status, error) {
                
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function addCartUpdateDetails(pid,count) {
    
    //var i = $('#headerShowCart').text();
    //i += count;

    $('#headerShowCart').text(count);

    $('#productImg-' + pid).removeClass('text-light');
    $('#productImg-' + pid).removeClass('text-success');

    $('#productImg-' + pid).addClass('text-success');
}

function delCart(storeId, customerId, pid, count) {

    var postData = {
        'storeId': storeId,
        'customerId': customerId,
        'productId': pid
    };

    $.ajax(
        {
            url: '/CallCenter/Order/DeleteFromCart',
            type: 'post',
            data: postData,
            beforeSend: function () {
                showBehsamLoading();
            },
            success: function (result, status, err) {
                
                if (result.isSuccess) {
                    toastr.success(result.message);
                    delCartUpdateDetails(pid, count);
                    
                }
                else {
                    toastr.error(result.message);
                    
                }
            },
            error: function (request, status, error) {
                console.log(request);
            },
            complete: function () {
                hideBehsamLoading();
            }
        });
}

function delCartUpdateDetails(pid, count) {
    
    var i = $('#headerShowCart').text();
    i -= count;

    if (i <= 0) {
        i = 0;
    }

    $('#headerShowCart').text(i);

    $('#productImg-' + pid).removeClass('text-light');
    $('#productImg-' + pid).removeClass('text-success');

    $('#productImg-' + pid).addClass('text-light');
}

function ShowInvoice() {

    let storeId = $('#txtStoreId').val();
    let customerId = $('#CustomerId').val();

    window.location.replace("/CallCenter/Order/Invoice?storeId=" + storeId +"&customerId="+customerId)
}

