'use strict';

$(document).ready(function () {
    let lat = $('#txtLat').val();
    let lng = $('#txtLng').val();
    let mapZoom = $('#txtZoom').val();

    if (lat == null || lat == "" || lat === null) {
        lat = 32.6859773
    }
    if (lng == null || lng == "") {
        lng = 56.366282;
    }
    if (mapZoom == null || mapZoom == "") {
        mapZoom = 5;
    }

    console.log(lat + ' , ' + lng + ' : ' + mapZoom);

    var myMap = new ol.Map({
        target: 'map',
        key: 'web.f4Vpn6cXKQtmWUZYkQQrZjWSuCuDg91LpV7vneDX',
        maptype: 'neshan',
        poi: true,
        traffic: true,
        view: new ol.View({
            center: ol.proj.fromLonLat([lng, lat]),
            zoom: mapZoom
        })
    });

    var markerEl = document.getElementById('geo-marker'),
        marker = new ol.Overlay({
            position: [0, 0],
            positioning: 'top-center',
            offset: [0, 0],
            element: markerEl,
            stopEvent: false
        });

    $(markerEl).hide();

    myMap.setMapType('neshan');

    myMap.on('click', function (evt) {

        //$(markerEl).show();
        //myMap.addOverlay(marker);

        var coord = evt.coordinate;
        //var coordx = evt.coordinate[0];
        //var coordy = evt.coordinate[1];
        //marker.setPosition(coord);
        //console.log(coordx);
        //var ss = 12;


        //var lonlat = ol.proj.transform(evt.coordinate, 'EPSG:3857', 'EPSG:4326');
        //var lon = lonlat[0];
        //var lat = lonlat[1];

        //alert(lonlat);

        //alert(lat + '-' + lon)




        //var model = {
        //    'geomerty': lat+','+lon
        //};


        //$.ajax({
        //    dataType: 'json',
        //    type: 'Get',
        //    url: '/locations/Sample',
        //    data: model,
        //    beforeSend: function () {
        //        //loader show
        //        console.info('before send ...!!!');
        //    },
        //    complete: function () {
        //        //doing a set of codes if ajax complate(success or error)
        //        //such as : loader hide

        //        console.info('complate ...!!!');
        //    },
        //    success: function (res) {
        //        //if run ajax success
        //        alert(res);
        //    },
        //    error: function (request, status, error) {
        //        //if run ajax with error
        //        console.error(request + '-' + status + '-' + error);
        //    }
        //});

    });

});