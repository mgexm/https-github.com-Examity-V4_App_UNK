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
    public partial class SaveExamArchive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String RecTransID=Request.Form["RecTransID"].ToString();
            String RecArchiveId = Request.Form["RecArchiveId"];
            BECommon objBECommon = new BECommon();
            objBECommon.strArchiveId = RecArchiveId;
            objBECommon.strTransID = RecTransID;
            BCommon objBCommon = new BCommon();
            objBCommon.BOpenTokSaveArchiveID(objBECommon);
            
        }
    }
}