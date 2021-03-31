var pagesize = 25;
var pagenumber = 1;
var storeid = 323.199;
$(document).ready(function () {
    loadData(1);   
});

function loadData(pagenumber) {
    var url = '/Admin/StoreOrderData_Paging';
    var data = JSON.stringify({ "status": 0, "storeid": storeid, "filter": $("#txtsearch").val(), "pagenumber": pagenumber, "pagesize": pagesize });
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
            html += '<td class="text-center">' + item.OrderCode + '</td>';
            html += '<td class="text-center">' + item.OrderDateShamsi + '</td>';
            html += '<td class="text-center">' + item.OrderTimeString + '</td>';
            html += '<td class="text-center">' + item.CustomerName + '</td>';
            html += '<td class="text-center">' + item.OrderStateName + '</td>';
            html += '<td class="text-center">';
            html += '<a href="#" data-toggle="tooltip" class="btn btn-sm btn-info" title="مشاهده اطلاعات" onclick="getbyID(' + item.ID + ')" data-original-title="مشاهده اطلاعات"><i class="fa fa-pen"></i></a>'
            html += '         ';                    
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

function getbyID(iD) {
    var url = '/Admin/StoreOrderDetails';
    var data = JSON.stringify({"status" : 10 , "orderid": iD })
    ExcuteQuery(url, "POST", data, "json", "false", "true", function (result) { ShowDetails(result) }, function (result) { ShowMessage(result) });
    return false;
}
function ShowDetails(result) {
    if (result.Item1 > 0) {
        var output = JSON.stringify(result.Item3);
        var outputt = JSON.parse(output);
        var html = '';
        var index = (pagenumber - 1) * pagesize;
       $.each(outputt, function (key, item) {
            index = index + 1;
            html += '<tr>';
            html += '<td class="text-center">' + index + '</td>';
            html += '<td class="text-center">' + item.ProductName + '</td>';
            html += '<td class="text-center">' + item.Quantity + '</td>';
            html += '<td class="text-center">' + item.UnitPrice + '</td>';
            html += '<td class="text-center">' + item.TaxPrice + '</td>';
            html += '<td class="text-center">' + item.DiscountPrice + '</td>';
            html += '<td class="text-center">' + ((item.UnitPrice * item.Quantity)+(((item.UnitPrice * item.Quantity) * item.TaxPrice)/100) - item.DiscountPrice)  + '</td>';
            html += '</tr>';

        });
        $('.tbodyOrderItem').html(html);       
    }
    else {
        ShowAlert("خطا", JSON.parse(result.Item4))
    }
    ShowDiv("#DivDetail");
    HideDiv("#DivInfo");   
}

function Return() {
    ShowDiv("#DivInfo");
    HideDiv("#DivDetail");
}