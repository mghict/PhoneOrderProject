var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);
    LoadCategory();
});

function loadData(pagenumber) {
    var url = '/Admin/ProductData_Paging';
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
            if (item.ImageUrl != null) {
                html += '<td class="text-center"><img class="imggrid" src="/Files/Images/' + item.ImageUrl + '"/> </td>';
            }
            else {
                html += '<td class="text-center"><img class="imggrid" src="/Content/assets/images/noimage.jpg"/> </td>';
            }           
            html += '<td class="text-center">' + item.ProductCode + '</td>';
            html += '<td class="text-center">' + item.ProductName + '</td>';
            html += '<td class="text-center">' + item.CategoryName + '</td>';
            html += '<td class="text-center">' + item.BrandName + '</td>';
            html += '<td class="text-center">' + item.UnitPrice + '</td>';
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
        html += "<option value=0>گروه اصلی</option>";
        $.each(outputt, function (key, item) {
            html += "<option value='" + item.ID + "'>" + item.CategoryName + "</option>";
        });
        $("#CategorySelect").children().remove();
        $("#CategorySelect").append(html);
    }
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();
    var totalFiles = document.getElementById("FileUpload").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("FileUpload").files[i];

        formData.append("FileUpload", file);
    }
    formData.append("ProductCode", $('#ProductCode').val())
    formData.append("ProductName", $('#ProductName').val())
    formData.append("DisplayName", $('#DisplayName').val())
    formData.append("Status", $('#Status').val())
    formData.append("BrandName", $('#BrandName').val())
    formData.append("UnitPrice", $('#UnitPrice').val())
    formData.append("TaxPrice", $('#TaxPrice').val())
    formData.append("CategotyID", $('#CategorySelect').val())
    $.ajax({
        type: "POST",
        url: '/Admin/ProductData_Insert',
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
    var url = '/Admin/ProductData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#ProductName').val(result.ProductName);
    $("#ProductCode").val(result.ProductCode);
    $("#DisplayName").val(result.DisplayName);
    $("#BrandName").val(result.BrandName);
    $("#UnitPrice").val(result.UnitPrice);
    $("#TaxPrice").val(result.TaxPrice);
    $("#CategorySelect").val(result.CategotyID);
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
    var totalFiles = document.getElementById("FileUpload").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("FileUpload").files[i];

        formData.append("FileUpload", file);
    }
    formData.append("ID", $('#ID').val())
    formData.append("ProductCode", $('#ProductCode').val())
    formData.append("ProductName", $('#ProductName').val())
    formData.append("DisplayName", $('#DisplayName').val())
    formData.append("Status", $('#Status').val())
    formData.append("BrandName", $('#BrandName').val())
    formData.append("UnitPrice", $('#UnitPrice').val())
    formData.append("TaxPrice", $('#TaxPrice').val())
    formData.append("CategotyID", $('#CategorySelect').val())
    $.ajax({
        type: "POST",
        url: '/Admin/ProductData_Update',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (result) {
            SuccessUpdate(result);
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
            var url = '/Admin/ProductData_Delete'
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

    LoadCategory();
    ClearForm();
    $('#btnAdd').show();
    $('#btnUpdate').hide();
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");
}
function ClearForm() {
    $('#ID').val("");
    $('#ProductName').val("");
    $('#DisplayName').val("");
    $('#ProductCode').val("");
    $('#BrandName').val("");
    $('#UnitPrice').val("");
    $('#TaxPrice').val("");
    $('#ProductCode').val("");
    $('#CategorySelect').val(0);
    $('#Status').val(1);
   
}
function validate() {
    var isValid = true;
    return isValid;
}