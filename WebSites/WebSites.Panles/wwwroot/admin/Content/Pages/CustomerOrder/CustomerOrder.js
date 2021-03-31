var mealid = 0;
var orderlist = '';
var totalprice = 0;
var finalprice = 0;
var shippingcost = 0;
var mashmmolmaliat = 0;
var maliat = 0;
var customerid = 0;
var customername = 0;
var ordercount = 0
var addressID = 1;
var dayid = 0;
var ordertime = 0;
var mobile = "";
var lock = false;
$(document).ready(function () {
    GetCustomerInfo();
    LoadDayOrder();
    LoadFood();
    initialize();
});

function LoadNavbarData() {
    var html = '';
    if (customerid == 0) {
        html = '<li><a class="signinclass" onclick="ShowLoginModal();">ورود / عضویت</a></li>';
    }
    else {
        //html = '<li><a class="signinclass" onclick=" LoginOut()">خروج از حساب کاربری</a></li>'; 
        //html += '<li><a class="signinclass" href="#">' + customername + '</a></li>';
    }
    $("#UserAccount").children().remove();
    $("#UserAccount").append(html);
    $("#customerinfo").text(customername);
    $("#usermobile").text(mobile);

    if (customerid > 0) {
        LoadCustomerAddress();
    }
}

function GetCustomerInfo() {
    var url = '/Home/Customer_GetData';
    ExcuteQuery(url, "POST", "", "json", "false", "true", function (result) { LoadCustomerInfo(result) }, function (result) { ShowMessage(result) });
}
function LoadCustomerInfo(result) {

    customerid = result.Item1;
    customername = result.Item2;
    mobile = result.Item3;
    LoadNavbarData();

}
function LoadDayOrder() {
    var url = '/Home/GetDayOrderList';
    ExcuteQuery(url, "POST", "", "json", "false", "true", function (result) { LoadDayOrderlist(result) }, function (result) { ShowMessage(result) });
}
function LoadDayOrderlist(result) {

    var output = JSON.stringify(result);
    var outputt = JSON.parse(output);
    var html = '';
    html = "<option value=0>" + 'نزدیک ترین زمان ممکن' + "</option>";
    $.each(outputt, function (key, item) {
        html += "<option value='" + item.DayID + "'>" + item.DayName + "</option>";
    });
    $("#orderday").children().remove();
    $("#orderday").append(html);

}

function LoadTimeOrder() {
    var url = '/Home/GetTimeOrderList';
    var data = JSON.stringify({ "dayid": dayid });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadTimeOrderlist(result) }, function (result) { ShowMessage(result) });
}
function LoadTimeOrderlist(result) {

    var output = JSON.stringify(result);
    var outputt = JSON.parse(output);
    var html = '';
    html = "<option class='timeorder' value=0,0>" + 'انتخاب ساعت' + "</option>";
    $.each(outputt, function (key, item) {
        html += "<option class='digit timeorder' value='" + item.TimeString + "'>" + item.DisplayName + "</option>";
    });
    $("#ordertime").children().remove();
    $("#ordertime").append(html);

}

$('#orderday').on('change', function () {
    dayid = parseInt(this.value);
    if (ordercount > 0) {
        ShowConfirm('توجه', 'سبد خرید شما دارای غذای انتخابی می باشد، در صورت تغییر زمان درخواست، سبد شما خالی می گردد. آیا مایل به لغو سبد خرید می باشید',
            function myfunction() {
                EmptyBasket();
                if (dayid > 0) {
                    LoadTimeOrder();
                }
                else {
                    $("#ordertime").children().remove();
                }
            }, function () { });
    }
    else {
        if (dayid > 0) {
            LoadTimeOrder();
        }
        else {
            $("#ordertime").children().remove();
        }
    }
})
$('#ordertime').on('change', function () {

    var tim = this.value;
    var tmp = tim.split(',');
    if (parseInt(tmp[0]) > 0) {


        if ((mealid > 0 && mealid != parseInt(tmp[0])) && ordercount > 0) {

            ShowConfirm('توجه', 'سبد خرید شما دارای غذای انتخابی می باشد، در صورت تغییر زمان درخواست، سبد شما خالی می گردد. آیا مایل به لغو سبد خرید می باشید',
                function myfunction() {
                    EmptyBasket();
                    mealid = parseInt(tmp[0]);
                    ordertime = tmp[1];
                    LoadFood();
                }, function () { });

        }
        else {
            ordertime = tmp[1];
            mealid = parseInt(tmp[0]);
            LoadFood();
        }
    }
})

function EmptyBasket() {
    $("#basketlist").children().empty();
    totalprice = 0;
    ordercount = 0;
    finalprice = 0;
    mashmmolmaliat = 0;
    shippingcost = 0;
    $("#totalcount").text(0);
    LoadFaktorAmount();
    lock = false;
}


function LoadCustomerAddress() {
    var url = '/Home/CustomerAddressList';
    var data = JSON.stringify({ "status": 1, "customerID": customerid });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadCustomerAddresslist(result) }, function (result) { ShowMessage(result) });
}
function LoadCustomerAddresslist(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';
        var id = '';
        $.each(outputt, function (key, item) {
            id = 'Addresses' + item.ID;
            html += " <input  name='SelectAddresses[sladdress]' id='" + id + "' type='radio'>";
            html += " <label for='" + id + "' style='font-size:14px;'>" + item.Address + "</label>";
            html += '<br>'
        });
        $("#addresses").children().remove();
        $("#addresses").append(html);
    }


}

function LoadFood() {
    var url = '/Home/GetFoodList';
    var data = JSON.stringify({ "mealid": mealid, "dayid": dayid });
    ExcuteQuery(url, "POST", data, "html", "false", "true", function (result) { LoadFoodlist(result) }, function (result) { ShowMessage(result) });
}
function LoadFoodlist(result) {

    $("#foodlist").html(result);

}

function ShowMessage(message) {
    ShowAlert("", message);
}

function AddFactor(id, price, productname, ismaliat) {

    if (lock) {
        return;
    }
    if (IsExistProduct(id)) {
        IncreassCount(id, price, ismaliat);

    }
    else {
        AddToOrderList(id, price, productname, ismaliat);
    }
}

function AddToOrderList(id, price, productname, ismaliat) {

    if (lock) {
        return;
    }

    html = '';
    html += '<div class="basket-item row idn-basket-hover" id=d' + id + ' " style="display: block;">';
    html += ' <a onclick="RemoveFromFaktor(' + id + ',' + ismaliat + ');"  class="del"  title="حذف از سبد خرید"> <span id="remove-item-basket" class="idn-remove"></span></a>';
    html += '<div class="basket-item-title col-xs-12">' + productname + ' </div>';
    html += ' <div class="basket-item-price col-md-7 col-xs-5" style="font-size: 10px;">';
    html += '<span class="kk-apply-comma  kk-comma-done">' + price + '</span>';
    html += ' <span style="display: none;" class="kk-apply-comma final-item-price  kk-comma-done" id=unitprice' + id + '>' + price + '</span> تومان  </div>';
    html += '  <div class="basket-item-action col-md-5 col-xs-7">';
    html += ' <a onclick="IncreassCount(' + id + ',' + price + ',' + ismaliat + ');" class="inc action-btn" id="decbtn-3534268"><i class="zfi zf-android-add"></i></a>';
    html += ' <span class="quantity" qnt="1" value=' + id + '   ><span class="kk-fa-digit kk-fa-digit-done qnt " ">1</span></span>';
    html += '  <a onclick="DecreassCount(' + id + ',' + price + ',' + ismaliat + ');" class="dec action-btn" id="incbtn-3534268"><i class="zfi zf-android-remove"></i></a>';
    html += '</div></div>';

    $("#basketlist").append(html);
    ordercount = ordercount + 1;
    $("#totalcount").text(ordercount);
    totalprice = totalprice + price;
    if (ismaliat == 1) {
        mashmmolmaliat = mashmmolmaliat + price;
    }
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
function IncreassCount(id, price, ismaliat) {

    if (lock) {
        return;
    }
    if ($("#basketlist").find('d' + id)) {
        var cnt = (parseInt($("#d" + id + "").find('span .qnt').text()));
        $("#d" + id + "").find('span .qnt').text(cnt + 1);
        ordercount = ordercount + 1;
        $("#totalcount").text(ordercount);
        totalprice = totalprice + price;
        if (ismaliat == 1) {
            mashmmolmaliat = mashmmolmaliat + price;
        }
        LoadFaktorAmount();
    }
}
function DecreassCount(id, price, ismaliat) {

    if (lock) {
        return;
    }
    if ($("#basketlist").find('d' + id)) {
        var cnt = (parseInt($("#d" + id + "").find('span .qnt').text()));
        if (cnt == 1) {
            RemoveFromFaktor(id, ismaliat);
        }
        else {
            $("#d" + id + "").find('span .qnt').text(cnt - 1);
            ordercount = ordercount - 1;
            $("#totalcount").text(ordercount);
            totalprice = totalprice - price;
            if (ismaliat == 1) {
                mashmmolmaliat = mashmmolmaliat - price;
            }
        }
        LoadFaktorAmount();
    }
}
function RemoveFromFaktor(id, ismaliat) {
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
        if (ismaliat) {
            mashmmolmaliat = mashmmolmaliat - (cnt * uprice);
        }
        LoadFaktorAmount();
    }
}
function LoadFaktorAmount() {
    $("#totalprice").text(totalprice);
    $("#shippingcost").text(shippingcost);
    $("#finalprice").text((totalprice + shippingcost));
    //$("#totalmaliat").text(mashmmolmaliat * maliat / 100);

}

function ShowLoginModal() {
    var $confirm = $("#loginModal");
    $confirm.modal('show');
    $("#btnNoConfirmm").on('click').click(function () {
        $confirm.modal("hide");
    });
}
function VerifyPhoneNumber() {
    if ($("#mobile").val().length != 11) {
        ShowMessage("شماره همراه نامعتبر می باشد");
        return;
    }
    var url = '/Home/VerifyPhoneNumber';
    var data = JSON.stringify({ "mobile": $("#mobile").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessVerifyPhoneNumber(result) }, function (result) { ShowMessage(result) });
}
function SuccessVerifyPhoneNumber(result) {
    if (result) {
        ShowDiv(".loginstep3");
        HideDiv(".loginstep1");
        $("#mobile3").val($("#mobile").val());
    }
    else {
        ShowDiv(".loginstep2");
        HideDiv(".loginstep1");
        $("#mobile2").val($("#mobile").val());
    }
}

function VerifySignCode() {
    if ($("#signcode").val().length < 4) {
        ShowMessage("شماره همراه نامعتبر می باشد");
        return;
    }
    var url = '/Home/VerifySignCode';
    var data = JSON.stringify({ "mobile": $("#mobile2").val(), "code": $("#signcode").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessVerifySignCode(result) }, function (result) { ShowMessage(result) });
}
function SuccessVerifySignCode(result) {
    if (result) {
        ShowDiv(".loginstep3");
        HideDiv(".loginstep2");
        $("#mobile3").val($("#mobile").val());
    }
    else {
        alert('invalid');
        //ShowDiv(".loginstep2");
        //HideDiv(".loginstep1");
        //$("#mobile2").val($("#mobile").val());
    }
}

function VerifySignCode() {
    if ($("#signcode").val().length < 4) {
        ShowMessage("شماره همراه نامعتبر می باشد");
        return;
    }
    var url = '/Home/VerifySignCode';
    var data = JSON.stringify({ "mobile": $("#mobile2").val(), "code": $("#signcode").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessVerifySignCode(result) }, function (result) { ShowMessage(result) });
}
function SuccessVerifySignCode(result) {
    if (result) {
        ShowDiv(".loginstep6");
        HideDiv(".loginstep2");
        $("#mobile3").val($("#mobile").val());
    }
    else {
        alert('invalid');
        //ShowDiv(".loginstep2");
        //HideDiv(".loginstep1");
        //$("#mobile2").val($("#mobile").val());
    }
}

function RegisterUser() {
    if ($("#signcode").val().length < 4) {
        ShowMessage("شماره همراه نامعتبر می باشد");
        return;
    }
    if ($("#userpass").val().length < 4) {
        ShowMessage("رمز عبور نامعتبر می باشد");
        return;
    }
    var url = '/Home/CustomerRegister';
    //var data = JSON.stringify({ "mobile": $("#mobile").val(), "title": $("#usertitle").val(), "type": $("#usertype option:selected").val(), "pass": $("#userpass").val() });
    var data = JSON.stringify({ "mobile": $("#mobile").val(), "title": $("#usertitle").val(), "type": 1, "pass": $("#userpass").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessRegisterUser(result) }, function (result) { ShowMessage(result) });
}

function SuccessRegisterUser(result) {
    if (result) {
        alert('welcome');
    }
    else {
        alert('invalid');
        //ShowDiv(".loginstep2");
        //HideDiv(".loginstep1");
        //$("#mobile2").val($("#mobile").val());
    }
}

function LoginUser() {

    var url = '/Home/CustomerLogin';
    var data = JSON.stringify({ "mobile": $("#mobile3").val(), "code": $("#userpasslogin").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessLoginUser(result) }, function (result) { ShowMessage(result) });
}
function SuccessLoginUser(result) {
    if (result.Item1 > 0) {
        customerid = parseInt(result.Item1);
        customername = result.Item2;
        mobile = result.Item3;
        LoadNavbarData();
        var $confirm = $("#loginModal");
        $confirm.modal("hide");
    }
    else {
        ShowMessage("رمز عبور اشتباه می باشد");
    }
}


function LoginOut() {

    var url = '/Home/Signout';
    ExcuteQuery(url, "POST", "", "json", "false", "true", function (result) { SuccessLoginOut(result) }, function (result) { ShowMessage(result) });
}
function SuccessLoginOut(result) {
    customerid = 0;
    customername = "";
    LoadNavbarData();
}

function ResetPassword() {

    var url = '/Home/Customer_ResetPassword';
    var data = JSON.stringify({ "mobile": $("#mobile").val() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessResetPassworder(result) }, function (result) { ShowMessage(result) });
}
function SuccessResetPassworder(result) {
    if (result) {
        ShowMessage("رمز عبور برای شما ارسال گردید");
    }
}

function PrePardakht() {

    if (customerid == 0) {
        ShowLoginModal();
        return;
    }
    else if (ordercount == 0) {
        ShowMessage("سبد خرید شما خالی می باشد");
        return;
    }
    else {
        ShowDiv("#Divorder");
        HideDiv("#Divmenue");

        $('#btnedit').show();
        $('#btnpardakht').show();
        $('#btnverify').hide();
        $('#basketdiv').find('input, textarea, select , a').attr('disabled', 'true');
        lock = true;

    }

}
function EditFaktor() {
    HideDiv("#Divorder");
    ShowDiv("#Divmenue");

    $('#btnedit').hide();
    $('#btnpardakht').hide();
    $('#btnverify').show();

    $('#basketdiv').find('input, textarea, select , a').removeAttr('disabled');
    lock = false;
}

function FinalPardakht() {

    $("#basketlist").find('.quantity').each(function () {
        orderlist = '';
        orderlist += $(this).attr('value') + ',' + $(this).text() + ';'
    });
    var formData = new FormData();
    formData.append("OrderList", orderlist)
    formData.append("CustomerID", customerid)
    formData.append("TotalPrice", totalprice);
    //   formData.append("FinalPrice", finalprice);
    formData.append("FinalPrice", 1000);
    formData.append("Description", $("#order_comment").val());
    formData.append("Shippingcost", shippingcost);
    formData.append("Mashmmolmaliat", mashmmolmaliat);
    formData.append("OrderCount", ordercount);
    formData.append("AddressID", addressID);
    formData.append("ResturantID", 1);
    $.ajax({
        type: "POST",
        url: '/Home/FoodOrder_Proccess',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessFinalPardakht(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });
}

function SuccessFinalPardakht(result) {

    alert(result.Item2);
    if (result.Item1 > 0) {
        var h = screen.height;
        var w = screen.width;
        //window.open(result, "_blank", "toolbar=no ,location=0,status=no,titlebar=no,menubar=no,width="+w +",height=" +h);
        var id = (new Date()).getTime();
        var myWindow = window.open(result.Item2 + '?printerFriendly=true', id, "toolbar=no ,location=0,status=no,titlebar=no,menubar=no,width=" + w + ",height=" + h);
        $.post("/ajax/friendlyPrintPage", true)
            .done(function (htmlContent) {
                myWindow.document.write(htmlContent);
                myWindow.focus();
            });
    }
    else {
        ShowMessage(result.Item3);
    }






}

function ShowAddressModal() {
    var $confirm = $("#address-modal");
    $confirm.modal('show');
    //$(".ModalAddressclose").on('click').click(function () {
    //    $confirm.modal("hide");
    //});
}

function PreAddressData() {
    ShowDiv("#DivAddressLocation");
    HideDiv("#DivAddressData");
}
var marker;
function initialize() {

    var latitude = 35.740868;
    var longitude = 51.409954;

    var latlng = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        zoom: 18,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById('register__map'), mapOptions);
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map
    });

    google.maps.event.addListener(map, 'mouseout', function (event) {

        marker = new google.maps.Marker({
            position: event.latLng,
            draggable: true
        });


    });
    google.maps.event.addListener(map, 'click', function (event) {

        marker = new google.maps.Marker({
            position: event.latLng,
            draggable: true
        });


    });

}

function AcceptPosition() {

    if ($("#txtAddress").val().length < 15) {
        ShowMessage("آدرس پستی خود را وارد نمایید");
        return;
    }
    var url = '/Home/CustomerAddress_Insert';
    var data = JSON.stringify({ "customerid": customerid, "address": $("#txtAddress").val(), "position": marker.getPosition().lat() + ',' + marker.getPosition().lng() });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessAcceptPosition(result) }, function (result) { ShowMessage(result) });
}
function SuccessAcceptPosition(result) {
    if (result) {
        LoadCustomerAddress();
    }
}