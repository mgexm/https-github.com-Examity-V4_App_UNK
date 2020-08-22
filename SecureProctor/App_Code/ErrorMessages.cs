using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for ErrorMessages
/// </summary>
public class ErrorMessages
{
    public static string GetErrorMessage(int ErrorId)
    {
        /****************************************************************************/
        /*            CERTIFICATE ERROR SERIES IS        :  1000 .......            */
        /*            DATABSE ERROR SERIES IS            :  2000 .......            */
        /*            USER VALIDATING ERROR SERIES IS    :  3000 .......            */
        /*            APPLICATION ERROR SERIES IS        :  4000 .......            */
        /****************************************************************************/

        string strErrorMsg = string.Empty;
        switch (ErrorId)
        {
            case 1001: strErrorMsg = "Saml Response was not found.";
                break;
            case 1002: strErrorMsg = "Signature verification failed.";
                break;
            case 1003: strErrorMsg = "Invalid Saml Response.";
                break;
            case 1004: strErrorMsg = "UserId is not found in Saml Response.";
                break;
            case 2001: strErrorMsg = "Database server was not found";
                break;
            case 3001: strErrorMsg = "UserId is not found in Database";
                break;
        }
        return strErrorMsg;
    }
}