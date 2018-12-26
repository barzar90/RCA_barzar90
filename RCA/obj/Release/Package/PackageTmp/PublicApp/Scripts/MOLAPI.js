function ChangeCulture() {
    var t_URL;
    var t_Data;
    var t_OBJ = $("#MAHAITCurrentCultureID").text();

    debugger;

    t_URL = "../../PublicApp/API/MAHAITAPI.aspx/SetCulture";

    t_Data = '{ "CurrentCulture": "' + t_OBJ + '" }';

    $.ajax({ url: t_URL,
        type: "POST",
        contentType: "application/json",
        data: t_Data,
        dataType: "json",
        success: function (msg) {
            window.location.href = $(location).attr('href');
        },
        error: function (xhr, status) {
            alert("An error occurred: " + status);

//        error: function (xhr, status, error) {
//            alert(error);

        }
    });
}