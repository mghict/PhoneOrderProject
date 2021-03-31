var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);
    LoadStoreArea();
});

function loadData(pagenumber) {
    var url = '/Admin/StoreAreaData_Paging';
    var data = JSON.stringify({ "status": 10,"storeid": $("#StoreID").val(), "filter": $("#txtsearch").val(), "pagenumber": pagenumber, "pagesize": pagesize });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadGridView(result) }, function (result) { ShowMessage(result) });
}

function LoadGridView(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';
        var index = (pagenumber - 1) * pagesize;
        var step = 0;
        $.each(outputt, function (key, item) {
            index = index + 1;
            html += '<tr>';
            html += '<td class="text-center">' + index + '</td>';           
            html += '<td class="text-center">' + item.AreaName + '</td>';
            html += '<td class="text-center">' + item.DrivingTime + '</td>';
            html += '<td class="text-center">' + item.ShippingPrice + '</td>';
            html += '<td class="text-center">' + item.Priority + '</td>';
            html += '<td class="text-center">' + item.StatusName + '</td>';
            html += '<td class="text-center">';
            html += '<a href="#" data-toggle="tooltip" title="ویرایش اطلاعات" onclick="getbyID(' + item.ID + ')" data-original-title="ویرایش اطلاعات"><i class="fa fa-pen"></i></a>'
            html += '         ';
            html += '<a class="remove-from-cart" href="#" data-toggle="tooltip" title="حذف اطلاعات" onclick="Delele(' + item.ID + ')" data-original-title="حذف"><i class="fa fa-trash"></i></a>'
            html += '</td>';
            html += '</tr>';

        });
        $('.tbody').html(html);
        GridViewPager('.Pager', pagenumber, pagesize, JSON.parse(result.Item3));
    }
    else {
        ShowAlert("خطا", JSON.parse(result.Item4))
    }
}

$('#txtsearch').on('keypress', function (e) {
    if (e.which == 13) {
        loadData(1);
    }
})
$(".Pager").delegate('.pageitem', 'click', function (event) {
    loadData(parseInt($(this).attr('page')));
    pagenumber = parseInt($(this).attr('page'));
});
function ShowMessage(message) {
    ShowAlert("", message);
}
function LoadArea() {
    var url = '/Admin/AreaData';
    var data = JSON.stringify({ "status": 1 });
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { LoadDropdownArea(result) }, function (result) { ShowMessage(result) });
}
function LoadDropdownArea(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item2);
        var outputt = JSON.parse(output);
        var html = '';      
        $.each(outputt, function (key, item) {
            html += "<option value='" + item.ID + "'>" + item.AreaName + "</option>";
        });
        $("#AreaSelect").children().remove();
        $("#AreaSelect").append(html);
    }
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();    
    formData.append("StoreID", $('#StoreID').val())
    formData.append("AreaID", $('#AreaSelect').val())
    formData.append("ShippingPrice", $('#ShippingPrice').val())
    formData.append("Status", $('#Status').val())
    formData.append("DrivingTime", $('#DrivingTime').val())
    formData.append("Priority", $('#Priority').val())
    $.ajax({
        type: "POST",
        url: '/Admin/StoreAreaData_Insert',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessInsert(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });

}
function SuccessInsert(result) {
    if (parseInt(result.Item1) >= 0) {
        ClearForm();
        ShowMessage("ثبت اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
        Return();
    }
    else {
        ShowMessage(result.Item3);
    }
}
function getbyID(iD) {
    var url = '/Admin/StoreAreaData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#AreaSelect').val(result.AreaID);
    $("#ShippingPrice").val(result.ShippingPrice);
    $("#DrivingTime").val(result.DrivingTime);
    $("#Priority").val(result.Priority);
    $('#Status').val(result.Status);
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");
    $('#btnUpdate').show();
    $('#btnAdd').hide();
}
function Return() {
    ShowDiv("#DivInfo");
    HideDiv("#DivDetail");
}
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();
    formData.append("ID", $('#ID').val())
    formData.append("AreaID", $('#AreaSelect').val())
    formData.append("ShippingPrice", $('#ShippingPrice').val())
    formData.append("Status", $('#Status').val())
    formData.append("DrivingTime", $('#DrivingTime').val())
    formData.append("Priority", $('#Priority').val())
    $.ajax({
        type: "POST",
        url: '/Admin/StoreAreaData_Update',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessInsert(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });
}
function SuccessUpdate(result) {
    if (parseInt(result.Item1) >= 0) {
        ClearForm();
        ShowMessage("ویرایش اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
        Return();
    }
    else {
        ShowMessage(result.Item3);
    }

}
function Delele(ID) {
    ShowConfirm('توجه', 'آیا مایل به حذف رکورد می باشید ؟',
        function myfunction() {
            var url = '/Admin/StoreAreaData_Delete'
            var data = JSON.stringify({ "id": ID });
            ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessDelete(result) }, function (result) { ShowMessage(result) })
        }, function () { });


}
function SuccessDelete(result) {
    if (result) {
        ShowMessage("حذف اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
    }
    else {
        ShowMessage("بروز خطا در انجام عملیات");
    }
}
function NewRecord() {

    LoadArea();
    ClearForm();
    $('#btnAdd').show();
    $('#btnUpdate').hide();
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");
}
function ClearForm() {
    $('#ID').val("");
    $('#AreaSelect').val(0);
    $('#DrivingTime').val("");
    $('#ShippingPrice').val("");
    $('#Status').val(1);
    $('#Priority').val(1);
}
function validate() {
    var isValid = true;
    return isValid;
}