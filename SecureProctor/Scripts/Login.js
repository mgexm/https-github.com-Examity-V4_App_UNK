
function ValidateUser(UserName, Password, lblError) {


    if (document.getElementById(UserName).value == "" || document.getElementById(Password).value == "") {

        document.getElementById(lblError).innerHTML = "";

        return false;
        
    }

        
    }


//function ValidateStudentRegistration(firstName, lastName, userName, fileUpload, Gender, Password, ConfirmPassword, SecQuestion1, SecAnswer1, SecQuestion2, SecAnswer2, SecQuestion3, SecAnswer3) {

//    if (document.getElementById(firstName).value == "") {
//        alert("Please enter first Name");
//        return false;
//    }
//    if (document.getElementById(lastName).value == "") {
//        alert("Please enter last Name");
//        return false;
//    }
//    if (document.getElementById(userName).value == "") {
//        alert("Please enter user Name");
//        return false;
//    }
//    
//    var x = document.getElementById(userName).value;
//    var atpos = x.indexOf("@");
//    var dotpos = x.lastIndexOf(".");
//    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
//        alert("Not a valid UserName.");
//        return false;
//    }
//    
//    var course = document.getElementById(Gender);
//    var result = course.options[course.selectedIndex].value;
//    if (result == -1) {
//        alert("Please select Gender.");
//        return false;
//    }

//    if (document.getElementById(fileUpload).value == "") {
//        alert("Please Upload file");
//        return false;
//    }

//    
//    
//    if (document.getElementById(Password).value == "") {
//        alert("Please enter Password");
//        return false;
//    }
//    if (document.getElementById(ConfirmPassword).value == "") {
//        alert("Please enter Confirm Password");
//        return false;
//    }

//    var v1 = document.getElementById(Password).value;

//    var v2 = document.getElementById(ConfirmPassword).value;

//    if (v1 != v2) {
//        alert("Password and Confirm New Password did not match.");
//       return false;
//   }
//   var SecQuestion = document.getElementById(SecQuestion1);
//   var result = SecQuestion.options[SecQuestion.selectedIndex].value;
//   if (result == -1) {
//       alert("Please select Security Question#1.");
//       return false;
//   }
//   var SecAns1 = document.getElementById(SecAnswer1).value;
//  
//   
//   if (SecAns1 == "") {

//       alert("Security Answer Can not be null");
//       return false;
//   }
//   var SecQuestion1 = document.getElementById(SecQuestion2);
//   var result = SecQuestion1.options[SecQuestion1.selectedIndex].value;
//   if (result == -1) {
//       alert("Please select Security Question#2.");
//       return false;
//   }
//   var SecAns2 = document.getElementById(SecAnswer2).value;
//   
//   if (SecAns2 == "") {

//       alert("Security Answer Can not be null");
//       return false;
//   }

//   var SecQuestion2 = document.getElementById(SecQuestion3);
//   var result = SecQuestion2.options[SecQuestion2.selectedIndex].value;
//   if (result == -1) {
//       alert("Please select Security Question#3.");
//       return false;
//   }
//   var SecAns3 = document.getElementById(SecAnswer3).value;
//   if (SecAns3 == "") {

//       alert("Security Answer Can not be null");
//       return false;
//   }
//   
    //    }


//    function ValidateStudentRegistration(phonenumber1,phonenumber2,phonenumber3,lblmsg) {

//        var pn = document.getElementById(phonenumber1).value;
//        var pn1 = document.getElementById(phonenumber2).value;
//        var pn2 = document.getElementById(phonenumber3).value;

//        if(pn == "" && pn1 == "" && pn2 =="")
//        
//        {

//            document.getElementById(lblmsg).innerHTML = "Please enter valid Phone Number";
//            return false;

//        }

//        return true;
//        }
        

function popupWindow(popupURL) {

 
    window.open(popupURL, 'View_password_Details', 'top=100,left=200,height=330,width=800,resizable=No,scrollbars = No');
}


