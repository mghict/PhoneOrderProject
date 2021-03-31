function isValidDate(s) {
    
    var bits = s.split('/');
    if (bits[2].toString().length != 4 && bits[1] < 1 && bits[1] > 12 && bits[0] > 31 && bits[0] < 1) {
        return false
    }
    return true;
}
function readytoconverttomiladi(date) {
    
    var bits = date.split('/');
    if (bits[2].toString().length != 4 && bits[1] < 1 && bits[1] > 12 && bits[0] > 31 && bits[0] < 1) {
        return false
    }
    return true;
}
$(".CloseModalImage").click(function () {
    $("#modalImage").css('display', 'none');
})
$(".CloseModalInfo").click(function () {
    $("#ModalInfo").css('display', 'none');
})
function CloseModalImage(modalname) {
    $(modalname).css('display', 'none');
}
function ShowImageModal(imagesrc) {
    $("#imgmodal").attr('src', imagesrc);
    $("#modalImage").css('display', 'block')
}
function ShowDiv(controlname) {
    $(controlname).removeAttr('hidden');
}
function HideDiv(controlname) {
    $(controlname).attr('hidden', 'hidden');
}
function UploadImage(fileuploadname, controlname) {

    $(controlname).html("");
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
    if (regex.test($(fileuploadname).val().toLowerCase())) {

        if (typeof (FileReader) != "undefined") {
            $(controlname).show();
            $(controlname).append("<img style='width: 100%;' />");
            var reader = new FileReader();
            reader.onload = function (e) {
                $(controlname + " img").attr("src", e.target.result);
            }
            reader.readAsDataURL($(fileuploadname)[0].files[0]);
        } else {
            alert("This browser does not support FileReader.");

        }
    } else {
        alert("Please upload a valid image file.");
    }


}
function GridViewPager(conrolname, pageindex, pagesize, totalcount) {
    $(conrolname).ASPSnippets_Pager({
        ActiveCssClass: "current",
        PagerCssClass: "pager",
        PageIndex: pageindex,
        PageSize: pagesize,
        RecordCount: totalcount
    });

}
function ShowConfirm(title, message, yesfunction, nofunction) {
    var $confirm = $("#confirmModal");
    $confirm.modal('show');
    $("#lblTitleConfirm").html(title);
    $("#lblMsgConfirm").html(message);
    $("#btnYesConfirm").on('click').click(function () {
        yesfunction();
        $confirm.modal("hide");
    });
    $("#btnNoConfirm").on('click').click(function () {
        nofunction();
        $confirm.modal("hide");
    });
}
function ShowAlert(title, message) {
    $(".modal-title").html(title);
    $("#modalMessage").html(message);
    $("#alertModal").modal('show');
}
function ExcuteQuery(Url, Type, Data, DataType, Cache, Async, successfunction, errorfunction) {
    $.ajax({
        type: Type,
        contentType: "application/json; charset=utf-8",
        cache: Cache,
        url: Url,
        async: Async,
        data: Data,
        dataType: DataType,
        success: successfunction,
        error: errorfunction
    });
}
function ExcuteQueryFormData(Url, Type, Data, DataType, Cache, Async, successfunction, errorfunction) {
    //var token = $('[name=__RequestVerificationToken]').val();
    //var headers = {};
    //headers["__RequestVerificationToken"] = token;
    $.ajax({

        type: Type,
        //  headers: headers,
        url: Url,
        contentType: false,
        processData: false,
        data: Data,
        dataType: DataType,
        success: successfunction,
        error: errorfunction
    });
}
$('.aplus').click(function () {
    var ControlName = $(this).attr('name');
    $.ajax(
        {
            type: "POST",
            url: "WebForm1.aspx/Result",
            data: "{ controlName:'" + ControlName + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#control').html(response.d);
            },
            error: function (msg) {
                alert(msg);
                $('#control').html(msg.d);
            }
        });
});
(function () {
    'use strict';
    var $ = jQuery;
    $.fn.extend({
        filterTable: function () {
            return this.each(function () {
                $(this).on('keyup', function (e) {
                    $('.filterTable_no_results').remove();
                    var $this = $(this),
                        search = $this.val().toLowerCase(),
                        target = $this.attr('data-filters'),
                        $target = $(target),
                        $rows = $target.find('tbody tr');

                    if (search == '') {
                        $rows.show();
                    } else {
                        $rows.each(function () {
                            var $this = $(this);
                            $this.text().toLowerCase().indexOf(search) === -1 ? $this.hide() : $this.show();
                        })
                        if ($target.find('tbody tr:visible').size() === 0) {
                            var col_count = $target.find('tr').first().find('td').size();
                            var no_results = $('<tr class="filterTable_no_results"><td colspan="' + col_count + '">No results found</td></tr>')
                            $target.find('tbody').append(no_results);
                        }
                    }
                });
            });
        }
    });
    $('[data-action="filter"]').filterTable();
})(jQuery);
$(function () {
    // attach table filter plugin to inputs
    $('[data-action="filter"]').filterTable();

    $('.container').on('click', '.panel-heading span.filter', function (e) {
        var $this = $(this),
            $panel = $this.parents('.panel');

        $panel.find('.panel-body').slideToggle();
        if ($this.css('display') != 'none') {
            $panel.find('.panel-body input').focus();
        }
    });
    $('[data-toggle="tooltip"]').tooltip();
})
$(document).ajaxStart(function () {
    $("#ajaxwaitloading").css('display', 'block');
});
$(document).ajaxComplete(function () {
    $("#ajaxwaitloading").css('display', 'none');
});
$('.money').keyup(function (event) {
    if (event.which >= 37 && event.which <= 40) return;

    $(this).val(function (index, value) {
        return value
        .replace(/\D/g, "")
        .replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    })
});
$('.digit').keyup(function() {

    this.value = this.value.replace(/[^0-9\.]/g,'');
    //if (event.which >= 37 && event.which <= 40) return;

    //$(this).val(function (index, value) {
    //    return value
    //    .replace(/\D/g, "");
    //})
});
