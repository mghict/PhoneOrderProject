"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
connection.on("sendToUser", (messageHead, messageBody, messageType) => {
   let options = {
        progressBar: true,
        showMethod: "slideDown",
        hideMethod: "slideUp",
        showDuration: 300,
        hideDuration: 300,
        newestOnTop: true,
        positionClass: "toast-bottom-right",
        closeButton: true,
        timeOut: 0,
        extendedTimeOut: 0,
    };

    if (messageType === 1) {
        toastr.info(messageBody, messageHead, options);
    }
    else if (messageType === 2) {
        toastr.success(messageBody, messageHead, options);
    }
    else if (messageType === 3) {
        toastr.warning(messageBody, messageHead, options);
    }
    else if (messageType === 4) {
        toastr.error(messageBody, messageHead, options);
    }
    else {
        toastr.info(messageBody, messageHead,options);
    }
    
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});