// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function Add(id, handler) {
    $.ajax({
        type: "POST",
        url: "/Doctor/" + id + "?handler=" + handler,
        beforeSend: XHRCheck,
        data: { Id: id },
        success: function (message) {
            $('#message').html(message);
        }
    });
}

function XHRCheck(xhr) {
    xhr.setRequestHeader("XSRF-TOKEN",
        $('input:hidden[name="__RequestVerificationToken"]').val());
}