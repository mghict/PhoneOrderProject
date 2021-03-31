var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);    
});

function loadData(pagenumber) {
    var url = '/Admin/CustomerData_Paging';
    var data = JSON.stringify({ "status": 10, "filter": $("#txtsearch").val(), "pagenumber": pagenumber, "pagesize": pagesize });
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
            html += '<td class="text-center">' + item.CustomerCode + '</td>';
            html += '<td class="text-center">' + item.CustomerName + '</td>';
            html += '<td class="text-center">' + item.CustomerGroupName + '</td>';
            html += '<td class="text-center">' + item.CustomerTypeName + '</td>';
            html += '<td class="text-center">' + item.RegisterTypeName + '</td>';
            html += '<td class="text-center">' + item.StatusName + '</td>';
            html += '<td class="text-center">';
            html += '<a href="#" data-toggle="tooltip" title="ویرایش اطلاعات" onclick="getbyID(' + item.ID + ')" data-original-title="ویرایش اطلاعات"><i class="fa fa-pen"></i></a>'
            html += '         ';
            html += '<a href="/Admin/CustomerPhonePage?customerid=' + item.ID + '" data-toggle="tooltip" title="اطلاعات تلفن" data-original-title=" اطلاعات تلفن"><i class="fa fa-phone"></i></a>'
            html += '         ';
            html += '<a href="/Admin/CustomerAddressPage?customerid=' + item.ID + '" data-toggle="tooltip" title="اطلاعات آدرس"  data-original-title=" اطلاعات آدرس"><i class="fa fa-address-book"></i></a>'
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

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();  
    formData.append("CustomerName", $('#CustomerName').val())
    formData.append("Status", $('#Status').val())
    formData.append("CustomerGroupID", $('#CustomerGroupID').val())
    formData.append("CustomerTypeID", $('#CustomerTypeID').val())  
    $.ajax({
        type: "POST",
        url: '/Admin/CustomerData_Insert',
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
    var url = '/Admin/CustomerData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#CustomerName').val(result.CustomerName);
    $("#CustomerTypeID").val(result.CustomerTypeID);
    $("#CustomerGroupID").val(result.CustomerGroupID);
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
    formData.append("CustomerName", $('#CustomerName').val())
    formData.append("Status", $('#Status').val())
    formData.append("CustomerGroupID", $('#CustomerGroupID').val())
    formData.append("CustomerTypeID", $('#CustomerTypeID').val())  
    $.ajax({
        type: "POST",
        url: '/Admin/CustomerData_Update',
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
            var url = '/Admin/CustomerData_Delete'
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
    
    ClearForm();
    $('#btnAdd').show();
    $('#btnUpdate').hide();
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");
}
function ClearForm() {
    $('#ID').val("");
    $('#CustomerName').val("");
    $('#CustomerGroupID').val(1);
    $('#Status').val(1);
    $('#CustomerTypeID').val(1);
}
function validate() {
    var isValid = true;
    return isValid;
}


//--------Customer Phone--------------------