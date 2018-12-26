$(document).ready(function () {
    var t_Mask;
    var t_WaterMark;
    var t_DataType;
    var t_Object;

    $("#frmNew").attr("disabled", true);
    $("#frmPrint").attr("disabled", true);

    $(":input[Instruction]").each(function (idx, item) {
        t_Object = $("#" + item.id);
        t_WaterMark = t_Object.attr("Instruction");
        if (t_WaterMark != "") {
            t_Object.watermark(t_WaterMark);
        }
    });

    $(":input[MOLR]").each(function (idx, item) {
        t_Object = $("#" + item.id);
        t_Object.attr("readonly", true);
    });

    //MOLInitialiseForm();

});

function MOLEditRow(SectionName, RowNo, FormHeight, FormWidth) {
    var t_FrmM;
    var t_FileID;

    t_FrmM = $("#FRMM").val();
    t_FileID = $("#FRMDT").val();

    DisplayWindow("EditForm.aspx?RID=" + RowNo + "&ID=" + t_FrmM + "&SEC=" + SectionName + "&FID=" + t_FileID, "Edit Form", FormHeight, FormWidth);
}


function PrintDocument() {
    var t_Tmp = $("#FRMTMP").val();
    var t_TrnID = $("#TRNID").val();
    var t_URL;

    t_URL = "../../Reports/Report.aspx?ReportName=" + t_Tmp + "&TransactionID=" + t_TrnID;

    window.open(t_URL);
}

function SaveDocument() {
    SaveForm("#FormsForm",false);
}

function SaveSection() {
    var t_Return = SaveForm("#FormsSection",true);

    if (!t_Return) {
        //parent.modalWindow.close();
    }
}

function CancelSection() {
    parent.modalWindow.close();
}

function SaveForm(frmName,HasParent) {
    var arForm = $(frmName).serializeArray();
    var t_Object;
    var t_MandatoryStatus;
    var t_HasError = false;
    var t_ErrorMessage = "";


    $('[id^="err_lbl_"]').html("");


    $(frmName + " :input[MOLDTN]").each(function (idx, item) {
        t_Object = $("#" + item.id);
        if (t_Object.val() == "") {
            t_Object.val("0");
        }

        if (!isNumber(t_Object.val())) {
            t_Object.val("0");
        }

    });


    $(frmName + " :input[MOLM]").each(function (idx, item) {

        t_Object = $("#" + item.id);
        t_MandatoryStatus = t_Object.attr("MOLM");
        if (t_MandatoryStatus != "") {

            if (t_Object.attr("MOLDTN") == "1") {
                if (parseFloat(t_Object.val()) == 0) {
                    t_HasError = true;
                    $("#err_lbl_" + item.id).html(MOLMessages[0]);
                }
            }

            if (t_Object.val() == "") {
                t_HasError = true;
                $("#err_lbl_" + item.id).html(MOLMessages[0]);
            }
        }
    });


    $(frmName + " :input[MOLCV]").each(function (idx, item) {
        t_Object = $("#" + item.id);
        t_ErrorMessage = MOLValidateField(item.id, t_Object.val());
        if (t_ErrorMessage != "") {
            t_HasError = true;
            $("#err_lbl_" + item.id).html(t_ErrorMessage);
        }
    });



    $(frmName + " :input[MOLDTD]").each(function (idx, item) {
        t_Object = $("#" + item.id);
        if (!validateDateFormat(t_Object.val())) {
            t_HasError = true;
            $("#err_lbl_" + item.id).html(MOLMessages[3]);
        }
    });

    var t_GRP = $("#FRMGRP").val();
    var t_TMP = $("#FRMTMP").val();

    var t_URL = "";

    if (frmName == "#FormsSection") {
        t_URL = "../../Handler/" + t_GRP + "/" + t_TMP + ".aspx/SaveSection";
    }
    else {
        t_URL = "../../Handler/" + t_GRP + "/" + t_TMP + ".aspx/SaveDocument";
    }

    if (!t_HasError) {
        $.ajax({ url: t_URL,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ formVars: arForm }),
            dataType: "json",
            success: function (msg) {
                DisplayMessage(msg);
                if (HasParent) {
                    parent.modalWindow.close();
                    //parent.__doPostBack("_Page", "");
                }
            },
            error: function (xhr, status) {
                alert("An error occurred: " + status);
            }
        });
    }

    return t_HasError;
}

function NewDocument() {
    window.location.href = $(location).attr('href');
}

function DisplayMessage(msg) {

    var t_Error = false;
    var i = 0;

    for(i = 0;i<msg.d.length;i++)
    {
        if (msg.d[i].Action == "ERR") {
            t_Error = true;

            $("#err_lbl_" + msg.d[i].FieldName).html(msg.d[i].Message);
        }
        else if (msg.d[i].Action == "ASV") {
            $("#" + msg.d[i].FieldName).val(msg.d[i].Message);
        }
        else if (msg.d[i].Action == "RO") {
            $("#" + msg.d[i].FieldName).attr('readonly', true);
        }
        else if (msg.d[i].Action == "RW") {
            $("#" + msg.d[i].FieldName).attr('readonly', false);
        }
        else if (msg.d[i].Action == "SECDATA") {
            $("#" + msg.d[i].FieldName, parent.document).html(msg.d[i].Message);
        }
        else if (msg.d[i].Action == "ASVTP") {
            $("#" + msg.d[i].FieldName, parent.document).val(msg.d[i].Message);
        }
        else if (msg.d[i].Action == "TRNID") {
            $("#" + msg.d[i].FieldName, parent.document).val(msg.d[i].Message);
            alert('TRansaction Saved : ' + $("#" + msg.d[i].FieldName, parent.document).val());
        }
        else if (msg.d[i].Action == "DSF") {
            t_Error = true;
        }
        else if (msg.d[i].Action == "DSS") {
        }
        else if (msg.d[i].Action == "EXCEPTION") {
            alert(msg.d[i].Message);
        }
    }

    if (!t_Error) {

        $("#FormsForm :input").attr("disabled", true);
        $("#frmNew").attr("disabled", false);
        $("#frmPrint").attr("disabled", false);
    }
}

function isNumberKey(Control, evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    var value = Control.value;
    //alert(value);

    if (value != "") {
        if (charCode == 46) {
            if (value.indexOf(".") == -1) {
                return true;
            }
            else {
                return false;
            }
        }
    }

    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function validateDateFormat(dtStr) {
    var year;
    var day;
    var month;
    var leap = 0;
    var valid = true;
    var oth_valid = true;
    var feb = false;
    var validDate = true;
    var Ret = true;

    if (dtStr != "" && dtStr != null) {
        year = dtStr.substr(6, 4);
        month = dtStr.substr(3, 2);
        day = dtStr.substr(0, 2);

        if (year == "0000" || year < 1900 || month == "00" || day == "00" || dtStr.length < 10) {
            validDate = false;
        }

        if (validDate == true) {
            leap = year % 4;

            if (month == "02") {
                feb = true;
            }


            if (leap == 0 && month == "02") {
                if (day > 29) {
                    valid = false;
                    feb = true;
                }
            }

            else if (month == "02" && day > 28) {
                valid = false;
                feb = true;
            }

            if (feb == false) {
                if (month == "03" || month == "01" || month == "05" || month == "07" || month == "08" || month == "10" || month == "12") {
                    if (day > 31) {
                        oth_valid = false;
                    }
                }

                else if (month == "04" || month == 06 || month == "09" || month == "11") {
                    if (day > 30) {
                        oth_valid = false;
                    }
                }

                else {
                    oth_valid = false;
                }

            }
        }
    }

    if (valid == false || oth_valid == false || validDate == false) {
        Ret = false;
    }
    return Ret;
}

function RightClick()
{ return false; }
function KEYDOWN()
{ return false; }
function KEYDOWN1() {
    if (event.keyCode == 8 || event.keyCode == 46)
        return true
    else
        return false;
} //end of KEYDOWN function

function MOLValidateDOB(Value) {
    var t_Return = "";

    var Now = new Date()
    var DOB = Value.split('/');

    var Born = new Date(DOB[2], DOB[1]*1 - 1, DOB[0]);

    debugger;

    if ((Now - Born) < 0) {
        t_Return = MOLMessages[4];
    }

    return t_Return
}

function MOLCalculateAge(DOB) {
    var t_Return = 0

    if (DOB != '') {
        var now = new Date();

        var dob = DOB.split('/');
        var born = new Date(dob[2], dob[1] * 1 - 1, dob[0]);

        t_Return = now.getRealYear() - born.getRealYear();

    }

    return t_Return;
}

Date.prototype.getRealYear = function () {
    if (this.getFullYear)
        return this.getFullYear();
    else
        return this.getYear() + 1900;
};

function MOLGetUID(UID, SectionTable, FullName, FullName_LL, DOB, Address, Street, Building, Locality, Landmark, district, Taluka, Village, PinCode, IMG, Age, Gender, Mobile) {
    var t_URL;
    var t_Data;

    t_URL = "../STD/MOLServerAPI.aspx/GetUID";

    t_Data = '{ "UID": "' + UID + '" }';

    $.ajax({ url: t_URL,
        type: "POST",
        contentType: "application/json",
        data: t_Data,
        dataType: "json",
        success: function (msg) {
            AssignUIDValues(msg, SectionTable, FullName, FullName_LL, DOB, Address, Street, Building, Locality, Landmark, district, Taluka, Village, PinCode, IMG, Age, Gender, Mobile);
        },
        error: function (xhr, status) {
            alert("An error occurred: " + status);
        }
    });
}

function AssignUIDValues(msg, SectionTable, FullName, FullName_LL, DOB, Address, Street, Building, Locality, Landmark, District, Taluka, Village, PinCode, IMG, Age, Gender, Mobile) {

    var t_HasUID = false;
    var i = 0;
    var t_Age;

    $("#" + SectionTable + "__" + FullName).val("");
    $("#" + SectionTable + "__" + FullName_LL).val("");
    $("#" + SectionTable + "__" + DOB).val("");
    $("#" + SectionTable + "__" + Address).val("");
    $("#" + SectionTable + "__" + Street).val("");
    $("#" + SectionTable + "__" + Building).val("");
    $("#" + SectionTable + "__" + Locality).val("");
    $("#" + SectionTable + "__" + Landmark).val("");
    $("#" + SectionTable + "__" + District).val("");
    $("#" + SectionTable + "__" + Taluka).val("");
    $("#" + SectionTable + "__" + Village).val("");
    $("#" + SectionTable + "__" + PinCode).val("");
    $("#" + SectionTable + "__" + Age).val("");
    $("#" + SectionTable + "__" + Gender).attr("selected","M");
    $("#" + SectionTable + "__" + Mobile).val("");

    for (i = 0; i < msg.d.length; i++) {
        if (msg.d[i].Action == "HASUID") {
            t_HasUID = true;
        }
        else if (msg.d[i].Action == "ASV") {
            $("#" + msg.d[i].FieldName).val(msg.d[i].Message);

            if (msg.d[i].FieldName == "UID__FullName") {
                $("#" + SectionTable + "__" + FullName).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__FullName_LL") {
                $("#" + SectionTable + "__" + FullName_LL).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__DOB") {
                $("#" + SectionTable + "__" + DOB).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Address") {
                $("#" + SectionTable + "__" + Address).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Street") {
                $("#" + SectionTable + "__" + Street).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Building") {
                $("#" + SectionTable + "__" + Building).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Locality") {
                $("#" + SectionTable + "__" + Locality).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Landmark") {
                $("#" + SectionTable + "__" + Landmark).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__District") {
                $("#" + SectionTable + "__" + District).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Taluka") {
                $("#" + SectionTable + "__" + Taluka).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Village") {
                $("#" + SectionTable + "__" + Village).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Pincode") {
                $("#" + SectionTable + "__" + PinCode).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Gender") {
     
                $("#" + SectionTable + "__" + Gender).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__Mobile") {
                $("#" + SectionTable + "__" + Mobile).val(msg.d[i].Message);
            }
            else if (msg.d[i].FieldName == "UID__IMG") {
                $("#" + SectionTable + "__" + IMG).val(msg.d[i].Message);
                $("#" + SectionTable + "__" + IMG + "__IMG").attr("src", "../../App/STD/GetFile.ashx?ID=" + msg.d[i].Message);
            } 
        }
        else if (msg.d[i].Action == "EXCEPTION") {
            alert(msg.d[i].Message);
        }
    }


    if ($("#" + SectionTable + "__" + DOB).val() != "") {
        t_Age = MOLCalculateAge($("#" + SectionTable + "__" + DOB).val());
        $("#" + SectionTable + "__" + Age).val(t_Age);
        $("#" + SectionTable + "__" + Age).attr('readonly', true);
    }
    else {
        $("#" + SectionTable + "__" + Age).val("0");
        $("#" + SectionTable + "__" + Age).attr('readonly', false);
    }
}