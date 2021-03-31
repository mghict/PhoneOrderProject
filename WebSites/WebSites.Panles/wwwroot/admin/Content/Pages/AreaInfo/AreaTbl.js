var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);
    LoadArea();
    initialize();
});

function loadData(pagenumber) {
    var url = '/Admin/AreaData';
    var data = JSON.stringify({ "status": 10, "pagenumber": pagenumber, "pagesize": pagesize });
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
            html += '<td class="text-center">' + item.AreaTypeName + '</td>';
            html += '<td class="text-center">' + item.AreaParentName + '</td>';          
            html += '<td class="text-center">' + item.StatusName + '</td>';
            html += '<td class="text-center">';
            html += '<a href="#" data-toggle="tooltip" title="ویرایش اطلاعات" onclick="getbyID(' + item.ID + ')" data-original-title="ویرایش اطلاعات"><i class="fa fa-pen"></i></a>'
            html += '         ';
            if (item.AreaType == 0) {
                html += '<a href="/Admin/AreaGeoPage?areaId=' + item.ID + '" data-toggle="tooltip" title="نقاط جغرافیایی"><img src="/Content/assets/images/map.png" alt="نقاط جغرافیایی" /></a>';
                html += '         ';
            }
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
        html += "<option value=0>گروه اصلی</option>";
        $.each(outputt, function (key, item) {
            html += "<option value='" + item.ID + "'>" + item.AreaName + "</option>";
        });
        $("#parentAreaSelect").children().remove();
        $("#parentAreaSelect").append(html);
    }
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();
    formData.append("AreaName", $('#AreaName').val())
    formData.append("Status", $('#Status').val())
    formData.append("ParentID", $('#parentAreaSelect').val())
    formData.append("AreaType", $('#AreaTypeSelect').val())
    formData.append("CenterLatitude", latitude)
    formData.append("Centerlongitude", longitude)
    $.ajax({
        type: "POST",
        url: '/Admin/AreaData_Insert',
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
    var url = '/Admin/AreaData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#AreaName').val(result.AreaName);
    $("#parentAreaSelect").val(result.ParentID);
    $("#AreaTypeSelect").val(result.AreaType);
    $('#Status').val(result.Status);
    latitude = result.CenterLatitude;
    longitude = result.Centerlongitude;
    ShowOnMap();
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
    formData.append("AreaName", $('#AreaName').val())
    formData.append("Status", $('#Status').val())
    formData.append("ParentID", $('#parentAreaSelect').val())
    formData.append("AreaType", $('#AreaTypeSelect').val())
    formData.append("CenterLatitude", latitude)
    formData.append("Centerlongitude", longitude)
    $.ajax({
        type: "POST",
        url: '/Admin/AreaData_Update',
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
            var url = '/Admin/AreaData_Delete'
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
    $('#AreaName').val("");
    $('#parentAreaSelect').val(0);
    $('#AreaTypeSelect').val(0);
    $('#Status').val(1);

}
function validate() {
    var isValid = true;
    return isValid;
}

var map
var marker;
var latitude = 35.740868;
var longitude = 51.409954;
function initialize() {
    var latlng = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        zoom: 18,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('register__map'), mapOptions);
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map,
        draggable: true

    });
    marker.addListener('drag', handleEvent);
}
function ShowOnMap() {
    var latlng = new google.maps.LatLng(latitude, longitude);
    var mapOptions = {
        zoom: 18,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    marker = new google.maps.Marker({
        position: new google.maps.LatLng(latitude, longitude),
        map: map,
        draggable: true

    });

}
function handleEvent(event) {
    latitude = event.latLng.lat();
    longitude = event.latLng.lng();
}
