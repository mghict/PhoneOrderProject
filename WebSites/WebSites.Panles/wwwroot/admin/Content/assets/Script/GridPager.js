function ASPSnippetsPager(a, b)
{
    //var c = '<a style = "cursor:pointer" class="page" page = "{1}">{0}</a>';
    var c = ' <li class="paginate_button page-item" id="example_previous">';
    c += '<a href="#" aria-controls="example" data-dt-idx="{1}" tabindex="0" class="page-link">{0}</a>';
    c += '</li>';
    var d = "";
    var e, f, g; var g = 5;
    var h = Math.ceil(b.RecordCount / b.PageSize);
    if (b.PageIndex > h) { b.PageIndex = h } var i = "";
    if (h > 1) {
        f = h > g ? g : h; e = b.PageIndex > 1 && b.PageIndex + g - 1 < g ? b.PageIndex : 1; if (b.PageIndex > g % 2) { if (b.PageIndex == 2) f = 5; else f = b.PageIndex + 2 } else { f = g - b.PageIndex + 1 } if (f - (g - 1) > e) { e = f - (g - 1) } if (f > h) { f = h; e = f - g + 1 > 0 ? f - g + 1 : 1 }
        var j = (b.PageIndex - 1) * b.PageSize + 1;
        var k = j + b.PageSize - 1; if (k > b.RecordCount) { k = b.RecordCount } i = "";
        var pre = '<li class="paginate_button page-item previous disabled" id="example_previous">';
        pre +='< a href = "#" aria - controls="example" data - dt - idx="{1}" tabindex = "0" class="page-link" > قبلی</a >'    
        pre += '</li >';
        if (b.PageIndex > 1) {
            i += c.replace("{0}", pre).replace("{1}", "1");
            i += c.replace("{0}", "<").replace("{1}", b.PageIndex - 1)
        } for (var l = e; l <= f; l++) { if (l == b.PageIndex) { i += d.replace("{0}", l) } else { i += c.replace("{0}", l).replace("{1}", l) } } if (b.PageIndex < h) { i += c.replace("{0}", ">").replace("{1}", b.PageIndex + 1); i += c.replace("{0}", ">>").replace("{1}", h) }
    } a.html(i); try { a[0].disabled = false } catch (m) { }
} (function (a) { a.fn.ASPSnippets_Pager = function (b) { var c = {}; var b = a.extend(c, b); return this.each(function () { ASPSnippetsPager(a(this), b) }) } })(jQuery);








//function ASPSnippetsPager(a, b) {
//    //var c = '<a style = "cursor:pointer" class="page" page = "{1}">{0}</a>'; var d = "<span>{0}</span>";
//    //<a href="#" aria-controls="example" data-dt-idx="1" tabindex="0" class="page-link">1</a>
//    var c = '<li class="paginate_button page-item">';
//    c += '<a href="#" aria-controls="example" data-dt-idx="{1}" tabindex="{0}" class="page-link">{1}</a>';
//    c += '</li>';
//    var d = "";
//    var e, f, g; var g = 5; var h = Math.ceil(b.RecordCount / b.PageSize);
//    if (b.PageIndex > h) { b.PageIndex = h } var i = "";
//    if (h > 1) {
//        f = h > g ? g : h; e = b.PageIndex > 1 && b.PageIndex + g - 1 < g ? b.PageIndex : 1;
//        if (b.PageIndex > g % 2) { if (b.PageIndex == 2) f = 5; else f = b.PageIndex + 2 } else { f = g - b.PageIndex + 1 } if (f - (g - 1) > e) { e = f - (g - 1) } if (f > h) { f = h; e = f - g + 1 > 0 ? f - g + 1 : 1 } var j = (b.PageIndex - 1) * b.PageSize + 1; var k = j + b.PageSize - 1;
//        if (b.PageIndex > 1) {
//            i += c.replace("{0}", "<<").replace("{1}", "1");
//            i += c.replace("{0}", "<").replace("{1}", b.PageIndex - 1)
//        } for (var l = e; l <= f; l++) { if (l == b.PageIndex) { i += d.replace("{0}", l) } else { i += c.replace("{0}", l).replace("{1}", l) } } if (b.PageIndex < h) {
//            i += c.replace("{0}", ">").replace("{1}", b.PageIndex + 1);
//            i += c.replace("{0}", ">>").replace("{1}", h)
//        }
//    } a.html(i); try { a[0].disabled = false } catch (m) { }
//}
//(function (a) { a.fn.ASPSnippets_Pager = function (b) { var c = {}; var b = a.extend(c, b); return this.each(function () { ASPSnippetsPager(a(this), b) }) } })(jQuery);