var mappathNotEqual = "";
var mappathEqual = "";
var flag = true;
var editable = false;
$(document).ready(function () {
    loadAreaXmlData();
});

function loadAreaXmlData() {
    var url = '/Admin/AreaGeo_GetLatLan';
    var data = JSON.stringify({ "areaId": $('#areaId').val() });
    ExcuteQuery(url, "POST", data, "json", false, true, function (result) { GenerateAreaXmlData(result) }, function (result) { ShowMessage(result) });
}
function GenerateAreaXmlData(result) {
    if (result.Item1 > 0) {
        var temp = [];
        var output = JSON.stringify(result.Item2);
        temp = JSON.parse(output);
        mappathNotEqual = temp[0];
        mappathEqual = temp[1];
        if (mappathEqual.length > 5) {
            editable = true;
        }
        initMap();
    }
    else {
        ShowAlert("خطا", JSON.parse(result.Item4))
    }
}

function ShowMessage(message) {
    ShowAlert("", message);
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var areadata = "";
    polyganpath.getPath().forEach(function (latLng) { areadata = areadata + (latLng.toString()) + ';'; })
    var formData = new FormData();
    formData.append("areaId", $('#areaId').val());
    formData.append("arealist", areadata);
    formData.append("editable", editable);
    var url = '/Admin/AreaGeo_Insert';
    $.ajax({
        type: "POST",
        url: url,
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
    if (result) {
        ShowMessage("ثبت اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
        Return();
    }
    else {
        ShowMessage("بروز خطا در انجام عملیات");
    }
}
function getbyID(iD) {
    var url = '/Admin/AreaGeo_GetByID';
    var data = JSON.stringify({ "id": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    $('#ID').val(result.ID);
    $('#name').val(result.name);
    $('#time').val(result.timeShamsi);
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
    formData.append("ID", $('#ID').val());
    formData.append("name", $('#name').val());
    formData.append("time", $('#time').val());
    var url = '/Admin/AreaGeo_Update';
    $.ajax({
        type: "POST",
        url: url,
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
    if (result = "true") {
        ShowMessage("ویرایش اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
        Return();
    }
    else {
        ShowMessage("بروز خطا در انجام عملیات");
    }

}
function Delele(ID) {
    ShowConfirm('توجه', 'آیا مایل به حذف رکورد می باشید ؟',
        function myfunction() {
            var url = '/Admin/AreaGeo_Delete'
            var data = JSON.stringify({ "id": ID });
            ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { SuccessDelete(result) }, function (result) { ShowMessage(result) })
        }, function () { });


}
function SuccessDelete(result) {
    if (result = "true") {
        ShowMessage("حذف اطلاعات با موفقیت انجام شد");
        loadData(pagenumber);
    }
    else {
        ShowMessage("بروز خطا در انجام عملیات");
    }
}
function clearTextBox() {
    $('#ID').val("");
    $('#name').val("");
    $('#time').val("");
    $('#btnAdd').show();
    $('#btnUpdate').hide();
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");
    flag = false;
    areas = [];
    polyganpath = null;
    initMap();
}
function validate() {
    var isValid = true;
    if (areas.length < 3) {
        isValid = false;
    }
    return isValid;
}
//-------------Map-------------
var marker;
var areas = [];
var polyganpath = null;
var polyganpath2 = null;
function initMap() {
    polyganpath = new google.maps.Polygon();
    var Hyderabad = new google.maps.LatLng(35.720331, 51.406613);
    var mapOptions = {
        zoom: 11,
        center: Hyderabad,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById('map'), mapOptions);
    var arr = new Array();
    var polygons = [];
    var bounds = new google.maps.LatLngBounds();
    var xmlString = mappathNotEqual;
    if (xmlString.length < 5) {
        xmlString = '<subdivisions><subdivisions>'
    }
    var xml = xmlParse(xmlString);
    var subdivision = xml.getElementsByTagName("subdivision");
    for (var i = 0; i < subdivision.length; i++) {
        arr = [];
        var coordinates = xml.documentElement.getElementsByTagName("subdivision")[i].getElementsByTagName("coord");
        for (var j = 0; j < coordinates.length; j++) {
            arr.push(new google.maps.LatLng(
                parseFloat(coordinates[j].getAttribute("lat")),
                parseFloat(coordinates[j].getAttribute("lng"))
            ));

            bounds.extend(arr[arr.length - 1])
        }
        polygons.push(new google.maps.Polygon({
            paths: arr,
            strokeColor: '#C39BD3',
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: '#F7DC6F',
            fillOpacity: 0.35

        }));
        polygons[polygons.length - 1].setMap(map);
    }
    if (!bounds.isEmpty) { map.fitBounds(bounds); }
    //-------------------------------------------------------------

    xmlString = mappathEqual;
    if (xmlString.length < 5) {
        xmlString = '<subdivisions><subdivisions>'
    }
    xml = xmlParse(xmlString);
    subdivision = xml.getElementsByTagName("subdivision");
    var latlang;
    for (var i = 0; i < subdivision.length; i++) {
        var coordinates = xml.documentElement.getElementsByTagName("subdivision")[i].getElementsByTagName("coord");
        for (var j = 0; j < coordinates.length; j++) {
            latlang = new google.maps.LatLng(parseFloat(coordinates[j].getAttribute("lat")), parseFloat(coordinates[j].getAttribute("lng")));
            marker = new google.maps.Marker({
                position: latlang,
                map: map,
                draggable: true
            });
            google.maps.event.addListener(marker, 'drag', function (event) {


                var tp = [];
                var s = areas.length;
                for (var i = 0; i < s; i++) {
                    tp.push(areas[i].getPosition());
                }
                polyganpath.setOptions({
                    path: tp,
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.8,
                    strokeWeight: 3,
                    fillColor: '#FF0000',
                    fillOpacity: 0.35,


                });

                polyganpath.setMap(map);
            });
            areas.push(marker);
            var tp = [];
            var s = areas.length;
            for (var i = 0; i < s; i++) {
                var lat = areas[i].getPosition().lat();
                var lng = areas[i].getPosition().lng();
                tp.push(areas[i].getPosition());
            }
            polyganpath.setOptions({
                path: tp,
                strokeColor: '#FF0000',
                strokeOpacity: 0.8,
                strokeWeight: 3,
                fillColor: '#FF0000',
                fillOpacity: 0.35,

            });

            polyganpath.setMap(map);
        }
    }


    //------------------------------------------------------------

    google.maps.event.addListener(map, 'rightclick', function (event) {

        if (areas.length > 0) {
            console.log(areas.length);
            var m = areas.pop();
            m.setMap(null);

            var tp = [];
            var s = areas.length;

            for (var i = 0; i < s; i++) {
                tp.push(areas[i].getPosition());
            }


            polyganpath.setOptions({
                path: tp,
                strokeColor: '#FF0000',
                strokeOpacity: 0.8,
                strokeWeight: 3,
                fillColor: '#FF0000',
                fillOpacity: 0.35,

            });
            polyganpath.setMap(map);
        }
    });

    google.maps.event.addListener(map, 'click', function (event) {

        marker = new google.maps.Marker({
            position: event.latLng,
            map: map,
            draggable: true
        });



        google.maps.event.addListener(marker, 'drag', function (event) {


            var tp = [];
            var s = areas.length;
            for (var i = 0; i < s; i++) {
                tp.push(areas[i].getPosition());
            }
            polyganpath.setOptions({
                path: tp,
                strokeColor: '#FF0000',
                strokeOpacity: 0.8,
                strokeWeight: 3,
                fillColor: '#FF0000',
                fillOpacity: 0.35,


            });

            polyganpath.setMap(map);
        });
        areas.push(marker);
        var tp = [];
        var s = areas.length;
        for (var i = 0; i < s; i++) {
            var lat = areas[i].getPosition().lat();
            var lng = areas[i].getPosition().lng();
            tp.push(areas[i].getPosition());
        }
        polyganpath.setOptions({
            path: tp,
            strokeColor: '#FF0000',
            strokeOpacity: 0.8,
            strokeWeight: 3,
            fillColor: '#FF0000',
            fillOpacity: 0.35,

        });

        polyganpath.setMap(map);

    });

}
function xmlParse(str) {
    if (typeof ActiveXObject != 'undefined' && typeof GetObject != 'undefined') {
        var doc = new ActiveXObject('Microsoft.XMLDOM');
        doc.loadXML(str);
        return doc;
    }

    if (typeof DOMParser != 'undefined') {
        return (new DOMParser()).parseFromString(str, 'text/xml');
    }
    return createElement('div', null);
}