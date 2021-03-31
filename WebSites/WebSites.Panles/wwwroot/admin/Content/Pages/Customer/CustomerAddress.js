var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);
    initMap();
});

function loadData(pagenumber) {
    var url = '/Admin/CustomerAddressData_Paging';
    var data = JSON.stringify({ "status": 10, "customerid": $('#CustomerID').val(), "pagenumber": pagenumber, "pagesize": pagesize });
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
            html += '<td class="text-center">' + item.AddressTypeName + '</td>';
            html += '<td class="text-center">' + item.AddressValue + '</td>';
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
    formData.append("CustomerID", $('#CustomerID').val())
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
    var url = '/Admin/CustomerAddressData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#AddressType').val(result.AddressType);
    $("#AddressValue").val(result.AddressValue);
    $('#Status').val(result.Status);
    latitude = result.Latitude;
    longitude = result.Longitude;  
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
    formData.append("CustomerID", $('#CustomerID').val())
    formData.append("AddressType", $('#AddressType').val())
    formData.append("AddressValue", $('#AddressValue').val())
    formData.append("Latitude", latitude)
    formData.append("Longitude", longitude)
    formData.append("Status", $('#Status').val())
    $.ajax({
        type: "POST",
        url: '/Admin/CustomerAddressData_Update',
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
            var url = '/Admin/CustomerAddressData_Delete'
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
    $('#AddressValue').val("");
    $('#AddressType').val(1);
    $('#Status').val(1);
    latitude = 35.740868;
    longitude = 51.409954;
}
function validate() {
    var isValid = true;
    return isValid;
}


let map
let marker;
let markers = [];
let latitude = 35.740868;
let longitude = 51.409954;
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
    marker.setMap(map);
}
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
