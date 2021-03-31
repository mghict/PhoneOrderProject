var customerid = 0;
var pagesize = 25;
var pagenumber = 1;

function AddNewAddress(id) {
    customerid = id;
    ShowDiv("#DivMap");
    HideDiv("#Divaddresslist");
    initMap();
}

function ShowMessage(message) {
    ShowAlert("", message);
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
            html += '<tr>';         
            html += '<td class="text-center">' + item.AddressTypeName + '</td>';
            html += '<td class="text-center">' + item.AddressValue + '</td>';         
            html += '</tr>';

        });
        $('.tbodyaddress').html(html);       
    }
    else {
        ShowAlert("خطا", JSON.parse(result.Item4))
    }
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
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
            SuccessInsert(result);
        },
        error: function (result) {
            ShowMessage(result)
        }
    });

}
function SuccessInsert(result) {
    if (parseInt(result.Item1) >= 0) {       
        ShowMessage("ثبت اطلاعات با موفقیت انجام شد");
        loadAddressData(pagenumber);
        Return();
    }
    else {
        ShowMessage(result.Item3);
    }
}
function Return() {
    ShowDiv("#Divaddresslist");
    HideDiv("#DivMap");
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