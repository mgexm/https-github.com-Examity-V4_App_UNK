using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BusinessEntities;

namespace SecureProctor.Student
{
    public partial class GotoMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                BECommon objBECommon = new BECommon();
                BCommon objBCommon = new BCommon();

                objBECommon.TransID = txtTransactionID.Text;

                objBECommon.GotoMeetingID = txtGotoMeeting.Text;

                objBCommon.BUpdateGotoMeeting(objBECommon);

                if (objBECommon.IntstatusFlag == 0)
                {

                    lblSuccess.Text = "GoTOMeeting ID updated successfully.";

                }

                if (objBECommon.IntstatusFlag == 1)
                {
                    lblSuccess.Text = "Transaction ID doesn't exists";

                }

            }

            catch (Exception Ex)
            {


                lblSuccess.Text = "Transaction ID doesn't exists";

            }

        }
    }
}