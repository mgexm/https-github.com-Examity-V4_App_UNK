

function ValidateChangePassword(TxtResponse1, lblInfo, TxtResponse2, TxtResponse3) {
    if (document.getElementById(TxtResponse1).value == "") {
        document.getElementById(lblInfo).innerHTML = "";

        return false;
    }
    else if (document.getElementById(TxtResponse2).value == "") {
        document.getElementById(lblInfo).innerHTML = "";

        return false;
    }
    else if (document.getElementById(TxtResponse3).value == "") {
        document.getElementById(lblInfo).innerHTML = "";

        return false;
    }
    else {
        return true;
    }


}