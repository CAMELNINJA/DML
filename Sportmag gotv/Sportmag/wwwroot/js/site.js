// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function Search() {
    let inpVal = $('#search').html();
    $.ajax({
        type: "POST",
        url: "/Index",
        data: { name: inpVal },
        beforeSend: XHRCheck,
        success: function (data) {
            $('html').html(data);
            //window.history.pushState("object or string", "Title", url);
        }
    });
}

function XHRCheck(xhr){
    xhr.setRequestHeader("XSRF-TOKEN",
        $('input:hidden[name="__RequestVerificationToken"]').val());
}