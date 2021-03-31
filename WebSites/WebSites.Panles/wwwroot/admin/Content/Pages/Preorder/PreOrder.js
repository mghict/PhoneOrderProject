var pagesize = 15;
var pagenumber = 1;
var storeid = 323.199
var lock = false;
var orderlist = '';
var totalprice = 0;
var finalprice = 0;
var totaldiscount = 0;
var shippingcost = 0;
var mashmmolmaliat = 0;
var maliat = 0;
var customerid = 3;
var customername = 0;
var ordercount = 0
var orderitemlist = '';
var orderdate = '';
var ordertime = '';
var addressID = 7;

$(document).ready(function () {
    LoadCategory();
    LoadProduct(1);
    initFaktor();
});
function testalert() {
    ShowMessage("این بخش در حال تکمیل می باشد");
}
$('#txtcustomercode').on('keypress', function (e) {
    if (e.which == 13) {
        SearchCustomerByCode();
    }
})
$('#txtcustomerphone').on('keypress', function (e) {
    if (e.which == 13) {
        SearchCustomerByPhone();
    }
})
function SearchCustomer() {
    if ($('#txtcustomercode').val().length > 1) {
        SearchCustomerByCode();
    }
    else if ($('#txtcustomerphone').val().length > 6) {
        SearchCustomerByPhone();
    }
}
function SearchCustomerByCode() {
    var url = '/Admin/CustomerData_GetByCode';
    var data = JSON.stringify({ "code": $('#txtcustomercode').val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessSearchCustomerByCode(result) }, function (result) { ShowMessage(result) });
    return false;
}
function SuccessSearchCustomerByCode(result) {
    if (result.Item1 > 0) {
        customerid = result.Item2.ID;
        LoadCustomerProfile(customerid);
        ShowDiv("#DivCustomerInfo");

    }
    else {
        HideDiv("#DivCustomerInfo");

    }
}

function SearchCustomerByPhone() {
    var url = '/Admin/CustomerData_GetByPhone';
    var data = JSON.stringify({ "phone": $('#txtcustomerphone').val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessSearchCustomerByPhone(result) }, function (result) { ShowMessage(result) });
    return false;
}
function SuccessSearchCustomerByPhone(result) {
    if (result.Item1 > 0) {
        customerid = result.Item2.ID;
        LoadCustomerProfile(customerid);
        ShowDiv("#DivCustomerInfo");

    }
    else {
        HideDiv("#DivCustomerInfo");

    }
}

function LoadCategory() {
    var url = '/Admin/CategoryData';
    var data = JSON.stringify({ "status": 1 });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadDropdownCategory(result) }, function (result) { ShowMessage(result) });
}
function LoadDropdownCategory(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';

        $.each(outputt, function (key, item) {
            html += '<a href="#">';
            html += ' <div class="list-group-item list-group-item-action">';
            html += ' <div class="media mt-0">';
            html += '<img class="avatar-lg rounded-circle ml-3 my-auto" src="/Files/Images/img_21040753_dfa8bac7c43f457f83079ca109cb1809.png" alt="">';
            html += '<div class="media-body">'
            html += ' <div class="d-flex align-items-center">';
            html += '<div class="mt-0">';
            html += ' <h5 class="mb-1 tx-15">' + item.CategoryName + '</h5>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            html += ' </div>';
            html += '</div>';
            html += '</a>';
        });
        $(".Divcategortlist").children().remove();
        $(".Divcategortlist").append(html);
    }
}
function LoadCustomerProfile(id) {
    var url = '/Admin/Customer_Profile';
    var data = JSON.stringify({ "customerid": id });
    ExcuteQuery(url, "POST", data, "html", "false", "true", function (result) { SuccessLoadCustomerProfile(result) }, function (result) { ShowMessage(result) });
}
function SuccessLoadCustomerProfile(result) {

    $("#customerprofile").html(result);

}



function LoadProduct(pagenumber) {
    var url = '/Admin/ProductListByStore_Paging';
    var data = JSON.stringify({ "storeid": storeid, "filter": $("#txtsearch").val(), "pagenumber": pagenumber, "pagesize": pagesize });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadProductList(result) }, function (result) { ShowMessage(result) });
}

function LoadProductList(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';

        $.each(outputt, function (key, item) {
            html += '<div class="col-md-6 col-lg-6 col-xl-4  col-sm-6">';
            html += '<div class="card">';
            html += '<div class="card-body">';
            html += '<div class="pro-img-box">';
            html += ' <div class="d-flex product-sale">'
            html += ' <div class="badge bg-pink"></div>';
            html += ' <i class="mdi mdi-heart-outline ml-auto wishlist"></i>';
            html += ' </div>';
            html += ' <img class="w-100" src="/Files/Images/Product.jpg" alt="">';
            html += ' <a href="#" class="adtocart" onclick="AddFactor(' + item.ID + ',' + item.UnitPrice + ',' + item.TaxPrice + ",'" + item.DisplayName + "'" + ')" >';
            html += ' <i class="las la-shopping-cart "></i>';
            html += ' </a>';
            html += ' </div>';
            html += ' <div class="text-center pt-3">';
            html += ' <h3 class="h6 mb-2 mt-4 font-weight-bold text-uppercase">' + item.DisplayName + '</h3>';
            html += ' <h4 class="h5 mb-0 mt-2 text-center font-weight-bold text-danger">' + item.UnitPrice + ' ریال </h4>';
            html += '</div>';
            html += ' </div>';
            html += ' </div>';
            html += ' </div>';
            html += ' </div>';
        });
        $(".DivProductList").children().remove();
        $(".DivProductList").append(html);
        GridViewPager('.Pager', pagenumber, pagesize, JSON.parse(result.Item3));
    }
}

function AddFactor(id, price, taxprice, productname) {

    if (lock) {
        return;
    }
    if (IsExistProduct(id)) {
        IncreassCount(id, price, taxprice);

    }
    else {
        AddToOrderList(id, price, productname, taxprice);
    }
}

function AddToOrderList(id, price, productname, taxprice) {

    if (lock) {
        return;
    }

    var html = '';
    html += '<li class="list-group-item d-flex align-items-center" id=d' + id + ' ">';
    html += '<img alt="" class="ml-3 rounded-circle avatar-md" src="/Files/Images/Product.jpg">';
    html += ' <div>';
    html += ' <h6 class="tx-15 mb-1 tx-inverse tx-semibold mg-b-0 productname "  value="' + productname + '" >' + productname + '</h6>';
    html += '<span class="d-block tx-13 text-muted  productprice " id=unitprice' + id + '  value=' + price + '    >' + price + ' ریال</span>';
    html += '<span hidden="hidden" class="producttax" value=' + taxprice + ' ></sapn>'
    html += '</div>';
    html += '<div class="d-flex float-right mr-auto">';
    html += '  <a href="#" onclick="IncreassCount(' + id + ',' + price + ',' + taxprice + ');" class="btn btn-outline-light btn-icon ml-2">';
    html += ' <div class=""><i class="bx bx-plus"></i></div>';
    html += '</a>';
    html += '<span class="itemcnt ml-2 mr-2  quantity "  qnt="1" value=' + id + '  ><span class="qnt">1</span></span>';
    html += ' <a href="#" onclick="DecreassCount(' + id + ',' + price + ',' + taxprice + ');" class="btn btn-outline-light btn-icon">';
    html += '  <div class=""><i class="bx bx-minus"></i></div>';
    html += '</a>';
    html += ' <a href="#" onclick="RemoveFromFaktor(' + id + ',' + taxprice + ');" class="btn btn-outline-light btn-icon">';
    html += '  <div class=""><i class="bx bx-trash"></i></div>';
    html += '</a>';
    html += ' </div>';
    html += '  </li>';
    $("#basketlist").append(html);
    ordercount = ordercount + 1;
    $("#totalcount").text(ordercount);
    totalprice = totalprice + price;
    mashmmolmaliat = mashmmolmaliat + (price * taxprice) / 100;

    LoadFaktorAmount();
}

function IsExistProduct(id) {
    var flag = false;
    var elem = '#d' + id;
    if ($(elem).length) {
        flag = true;
    }
    return flag;
}
function IncreassCount(id, price, taxprice) {

    if (lock) {
        return;
    }
    if ($("#basketlist").find('d' + id)) {
        var cnt = (parseInt($("#d" + id + "").find('span .qnt').text()));
        $("#d" + id + "").find('span .qnt').text(cnt + 1);
        ordercount = ordercount + 1;
        $("#totalcount").text(ordercount);
        totalprice = totalprice + price;
        mashmmolmaliat = mashmmolmaliat + (price * taxprice) / 100;
        LoadFaktorAmount();
    }
}
function DecreassCount(id, price, taxprice) {

    if (lock) {
        return;
    }
    if ($("#basketlist").find('d' + id)) {
        var cnt = (parseInt($("#d" + id + "").find('span .qnt').text()));
        if (cnt == 1) {
            RemoveFromFaktor(id, taxprice);
        }
        else {
            $("#d" + id + "").find('span .qnt').text(cnt - 1);
            ordercount = ordercount - 1;
            $("#totalcount").text(ordercount);
            totalprice = totalprice - price;
            mashmmolmaliat = mashmmolmaliat - (price * taxprice) / 100;
        }
        LoadFaktorAmount();
    }
}
function RemoveFromFaktor(id, taxprice) {
    if (lock) {
        return;
    }
    if ($("#basketlist").find('d' + id)) {
        var cnt = (parseInt($("#d" + id + "").find('span .qnt').text()));
        var uprice = (parseInt($("#unitprice" + id + "").text()));
        $("#d" + id + "").remove();
        ordercount = parseInt($("#totalcount").text()) - cnt;
        $("#totalcount").text(ordercount);
        totalprice = totalprice - (cnt * uprice);
        mashmmolmaliat = mashmmolmaliat - ((cnt * uprice) * taxprice) / 100;
        LoadFaktorAmount();
    }
}
function LoadFaktorAmount() {
    $("#totalprice").text(totalprice);
    $("#shippingcost").text(shippingcost);
    $("#finalprice").text((totalprice + shippingcost + mashmmolmaliat));
    $("#totalmaliat").text(mashmmolmaliat);
    $("#totaldiscount").text(0);
    if (ordercount > 0) {
        ShowDiv("#DivProccessButton");
    }
    else {
        HideDiv("#DivProccessButton");
    }
}
function EmptyBasket() {
    $("#basketlist").html("");
    totalprice = 0;
    ordercount = 0;
    finalprice = 0;
    mashmmolmaliat = 0;
    shippingcost = 0;
    $("#totalcount").text(0);
    LoadFaktorAmount();
    lock = false;
    HideDiv("#DivFinalOrder");
    HideDiv("#DivPreOrder");
    HideDiv("#DivCustomerInfo");
    ShowDiv("#DivSearch");

}
function EditFaktorStep() {
    HideDiv("#DivFinalOrder");
    ShowDiv("#DivPreOrder");
    lock = false;
}
function PreFinalStep() {
    ShowDiv("#DivFinalOrder");
    HideDiv("#DivPreOrder");
    lock = true;
    LoadFinalOrder();

}

function FinalPreOrderInsert() {

    $("#basketlist").find('.quantity').each(function () {
        orderlist += $(this).attr('value') + ',' + $(this).text() + ';'
    });
    var formData = new FormData();
    formData.append("OrderList", orderlist)
    formData.append("CustomerID", customerid)
    formData.append("TotalPrice", totalprice);
    formData.append("FinalPrice", finalprice);
    formData.append("TotalDiscount", totaldiscount);
    formData.append("Shippingcost", shippingcost);
    formData.append("Mashmmolmaliat", mashmmolmaliat);
    formData.append("OrderCount", ordercount);
    formData.append("AddressID", addressID);
    formData.append("StoreID", storeid);
    var url = '/Admin/CustomerPreOrder_Insert';
    $.ajax({
        type: "POST",
        url: '/Admin/CustomerPreOrder_Insert',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessFinalPreOrderInsert(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });
}
function SuccessFinalPreOrderInsert(result) {
    if (parseInt(result.Item1) > 0) {
        ShowMessage("ثبت درخواست با موفقیت انجام شد");
        EmptyBasket();
    }
    else {
        ShowMessage(result.Item3);
    }
}

function initFaktor() {

}
function LoadFinalOrder() {
    var html = "";
    $('#basketlist li').each(function () {
        var pname = $(this).find(".productname").attr('value');
        var pprice = parseFloat($(this).find(".productprice").attr('value'));
        var ptax = parseFloat($(this).find(".producttax").attr('value'));
        var pcnt = parseInt($(this).find(".qnt").text());
        html += '<tr>';
        html += '<td>';
        html += '  <div class="media">';
        html += '  <div class="card-aside-img">';
        html += ' <img src="/Files/Images/Product.jpg" alt="img" class="h-60 w-60">';
        html += ' </div>';
        html += ' <div class="media-body">';
        html += '<div class="card-item-desc mt-0">';
        html += ' <h6 class="font-weight-semibold mt-0 text-uppercase faktoritem">' + pname + '</h6>';
        html += '  </div>';
        html += '</div>';
        html += '</div>';
        html += ' </td>';
        html += '  <td class="text-center text-lg text-medium">' + pcnt + '</td>';
        html += '  <td class="text-center text-lg text-medium">' + pprice + ' ریال</td>';
        html += ' <td class="text-center text-lg text-medium">' + ((pcnt * pprice) * ptax) / 100 + ' ریال</td>';
        html += '  <td class="text-center text-lg text-medium">0</td>';
        html += ' <td class="text-center text-lg text-medium">' + ((pcnt * pprice) - (((pcnt * pprice) * ptax) / 100)) + ' ریال</td>';
        html += ' </tr>';
    });
    $(".tbodyfinalorder").children().remove();
    $(".tbodyfinalorder").append(html);


}
$(".Pager").delegate('.pageitem', 'click', function (event) {
    LoadProduct(parseInt($(this).attr('page')));
    pagenumber = parseInt($(this).attr('page'));
});
function ShowMessage(message) {
    ShowAlert("", message);
}
$('#txtsearch').on('keypress', function (e) {
    if (e.which == 13) {
        LoadProduct(1);
    }
})



function AddNewAddress() {
    ShowDiv("#DivMap");
    HideDiv("#Divaddresslist");
    initMap();
}

function loadAddressData(pagenumber) {
    var url = '/Admin/CustomerAddressData_Paging';
    var data = JSON.stringify({ "status": 10, "customerid": customerid, "pagenumber": pagenumber, "pagesize": pagesize });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadGridViewAddress(result) }, function (result) { ShowMessage(result) });
}

function LoadGridViewAddress(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';
        var index = (pagenumber - 1) * pagesize;
        var step = 0;
        $.each(outputt, function (key, item) {
            html += '<a href="#">';
            html += '   <div class="list-group-item list-group-item-action">';
            html += '<div class="media mt-0">        ';
            html += ' <div class="media-body">';
            html += '  <div class="d-flex align-items-center">';
            html += ' <div class="mt-0"> ';
            html += ' <h5 class="mb-1 tx-15">' + item.AddressValue + '</h5>';
            html += ' </div> ';
            html += '  </div> ';
            html += ' </div> ';
            html += '  </div> ';
            html += '  </div> ';
            html += '  </a> ';

        });
        $('.tbodyaddress').html(html);
    }
    else {
        ShowAlert("خطا", JSON.parse(result.Item4))
    }
}
function SetCustomerAddress(id) {
    addressID = id;
    ShowDiv("#DivPreOrder");
    HideDiv("#DivCustomerInfo");
    HideDiv("#DivSearch");
}
function InsertNewAddress() {

    var formData = new FormData();
    formData.append("CustomerID", customerid)
    formData.append("AddressType", $('#AddressType').val())
    formData.append("AddressValue", $('#AddressValue').val())
    formData.append("Latitude", latitude)
    formData.append("Longitude", longitude)
    formData.append("Status", $('#Status').val())
    $.ajax({
        type: "POST",
        url: '/Admin/CustomerAddressData_Insert',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessInsertAddress(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });

}
function SuccessInsertAddress(result) {
    if (parseInt(result.Item1) >= 0) {
        loadAddressData(pagenumber);
        ReturnAddress();
    }
    else {
        ShowMessage(result.Item3);
    }
}
function ReturnAddress() {
    ShowDiv("#Divaddresslist");
    HideDiv("#DivMap");
}
function ReturnOrder() {
    EmptyBasket();
}


let map
let marker;
let markers = [];
let latitude = 35.740868;
let longitude = 51.409954;
function ShowOnMap() {
    var latlng = new google.maps.LatLng(latitude, longitude);
    addMarker(latlng);
}

function initMap() {
    var latlng = new google.maps.LatLng(latitude, longitude);
    map = new google.maps.Map(document.getElementById("register__map"), {
        zoom: 18,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });
    map.addListener("click", (event) => {
        addMarker(event.latLng);
    });

    addMarker(latlng);

}
function addMarker(location) {
    deleteMarkers();
    latitude = location.lat();
    longitude = location.lng();
    const marker = new google.maps.Marker({
        position: location,
        map: map,
        draggable: true
    });
    markers.push(marker);
    map.panTo(location);
}
function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}
function clearMarkers() {
    setMapOnAll(null);
}
function showMarkers() {
    setMapOnAll(map);
}
function deleteMarkers() {
    clearMarkers();
    markers = [];
}