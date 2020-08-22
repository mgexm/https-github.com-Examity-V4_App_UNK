function IsHtml5Compliant() {

    var Html5Compliant = "No";
    if (
            (navigator.userAgent.indexOf("Opera") != -1 || navigator.userAgent.indexOf('OPR') != -1 || navigator.userAgent.indexOf("Chrome") != -1 || navigator.userAgent.indexOf("Firefox") != -1
            || navigator.userAgent.indexOf("Edge") != -1) 
       )
        {
            Html5Compliant = "Yes";
        }
        else if ((navigator.userAgent.indexOf("Safari") != -1 || navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) //IF IE > 10
        {
            Html5Compliant = "No";// browserType ='IE';
        }

    return Html5Compliant;


    //else if (navigator.userAgent.indexOf("Chrome") != -1) {
    //    browserType ='Chrome';
    //}
    //else if (navigator.userAgent.indexOf("Safari") != -1) {
    //    browserType ='Safari';
    //}
    //else if (navigator.userAgent.indexOf("Firefox") != -1) {
    //    browserType = 'Firefox';
    //}
   
    //else if (navigator.userAgent.indexOf("Edge") != -1) {
    //    browserType = 'Chrome';
    //}
   
}
function onFailure(err) {
    alert("The following error occured: " + err.name);
}