
function MOLFileUpload() {
    $("#Loading")
.ajaxStart(function () {
    $(this).show();
})
.ajaxComplete(function () {
    $(this).hide();
});

    $.MOLFileUpload
(
{
    url: 'FileUpload.ashx',
    secureuri: false,
    fileElementId: 'FileUpload',
    dataType: 'json',
    data: { name: 'logan', id: 'id' },
    success: function (data, status) {
        if (typeof (data.error) != 'undefined') {
            if (data.error != '') {
                alert(data.error);
            } else {
                alert(data.msg);
            }
        }
    },
    error: function (data, status, e) {
        alert(e);
    }
}
)

    return false;
}


function sampleashx() {
    debugger;

    var form = $('#form2');

    alert('in');
    $.ajax({
        type: "POST",
        url: form.attr('action'),
        data: form.serialize(),
        dataType: 'json',
        success: function (msg) {
            alert(msg.results[2].name);
        },
        error: function (msg) {
            alert('Error:' + msg.d);
        }
    });
    alert('out');
    return false;
}
