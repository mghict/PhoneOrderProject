var pagesize = 25;
var pagenumber = 1;

$(document).ready(function () {
    loadData(1);
    initMap();
});

function loadData(pagenumber) {
    var url = '/Admin/StoreData_Paging';
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
            html += '<td class="text-center">' + item.StoreCode + '</td>';
            html += '<td class="text-center">' + item.StoreName + '</td>';
            html += '<td class="text-center">' + item.StorePhone + '</td>';
            html += '<td class="text-center">' + item.StatusName + '</td>';
            html += '<td class="text-center">';
            html += '<a href="#" data-toggle="tooltip" class="btn btn-sm btn-info" title="ویرایش اطلاعات" onclick="getbyID(' + item.StoreCode + ')" data-original-title="ویرایش اطلاعات"><i class="fa fa-pen"></i></a>'
            html += '         ';
            html += '<a href="/Admin/StoreTimeSheetPage?storeid=' + item.StoreCode + '" class="btn btn-sm btn-info" data-toggle="tooltip" title="زمانبندی سفیر فروشگاه"  data-original-title="زمانبندی سفیر فروشگاه"><i class="fa fa-clock"></i></a>'
            html += '         ';
            html += '<a href="/Admin/StoreInActivePage?storeid=' + item.StoreCode + '"  class="btn btn-sm btn-info"data-toggle="tooltip" title="تعطیلات فروشگاه"  data-original-title="تعطیلات فروشگاه"><i class="fa fa-calendar"></i></a>'
            html += '         ';
            html += '<a href="/Admin/StoreAreaPage?storeid=' + item.StoreCode + '"  class="btn btn-sm btn-info"data-toggle="tooltip" title="مناطق تحت پوشش"  data-original-title="مناطق تحت پوشش"><i class="fa fa-map-marker"></i></a>'
            html += '         ';
            html += '<a class="remove-from-cart btn btn-sm btn-info" href="#" data-toggle="tooltip" title="حذف اطلاعات" onclick="Delele(' + item.StoreCode + ')" data-original-title="حذف"><i class="fa fa-trash"></i></a>'
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
$('#txtsearch').on('keypress', function (e) {
    if (e.which == 13) {
        loadData(1);
    }
})
function ShowMessage(message) {
    ShowAlert("", message);
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var formData = new FormData();
    formData.append("StoreCode", $('#StoreCode').val())
    formData.append("StoreName", $('#StoreName').val())
    formData.append("StorePhone", $('#StorePhone').val())
    formData.append("StoreAddress", $('#StoreAddress').val())
    formData.append("Status", $('#Status').val())
    formData.append("Latitude", latitude)
    formData.append("Longitude", longitude)
    $.ajax({
        type: "POST",
        url: '/Admin/StoreData_Insert',
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
    var url = '/Admin/StoreData_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#StoreCode').val(result.StoreCode);
    $('#StoreName').val(result.StoreName);
    $("#StorePhone").val(result.StorePhone);
    $("#StoreAddress").val(result.StoreAddress);
    $('#Status').val(result.Status);
    latitude = result.Latitude;
    longitude = result.Longitude;
    info = '<div id="content">';
    info += 'نام فروشگاه : ' + result.StoreName;
    info += '<br>'
    info += '</div>';
    infowindow = new google.maps.InfoWindow({
        content: info
    });
    ShowStoreOnMap();
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
    formData.append("StoreCode", $('#StoreCode').val())
    formData.append("StoreName", $('#StoreName').val())
    formData.append("StorePhone", $('#StorePhone').val())
    formData.append("StoreAddress", $('#StoreAddress').val())
    formData.append("Status", $('#Status').val())
    formData.append("Latitude", latitude)
    formData.append("Longitude", longitude)
    $.ajax({
        type: "POST",
        url: '/Admin/StoreData_Update',
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
            var url = '/Admin/StoreData_Delete'
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
    $('#StoreCode').val("");
    $('#StoreName').val("");
    $('#StorePhone').val("");
    $('#StoreAddress').val("");
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
var infowindow;
var info = "";
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
function ShowStoreOnMap() {
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
    marker.addListener('click', function () {
        infowindow.open(map, marker);
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

function initSearchMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: { lat: -34.397, lng: 150.644 },
    });
    const geocoder = new google.maps.Geocoder();
    document.getElementById("submit").addEventListener("click", () => {
        geocodeAddress(geocoder, map);
    });
}

function geocodeAddress(geocoder, resultsMap) {
    const address = document.getElementById("address").value;
    geocoder.geocode({ address: address }, (results, status) => {
        if (status === "OK") {
            resultsMap.setCenter(results[0].geometry.location);
            new google.maps.Marker({
                map: resultsMap,
                position: results[0].geometry.location,
            });
        } else {
            alert("Geocode was not successful for the following reason: " + status);
        }
    });
}



