// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

'use strict';

function init() {
    var mapOptions = {
        zoom=10,
        center=new google.maps.LatLng(33.3378473, 48.375731),
    };

    var map = new google.maps.Map(document.getElementById('maps-div'), mapOptions);
}


function showLocation(lat,lng) {
    var mapOptions = {
        zoom=10,
        center=new google.maps.LatLng(lat ,lng),
    };

    var map = new google.maps.Map(document.getElementById('maps-div'), mapOptions);
}

google.maps.event.addDomListener(window, 'load', init);
