using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Xml;
using System.IO;
using System.Text;
using BusinessEntities;
using BLL;

namespace SecureProctor.Proctor
{
    public partial class BlockedDates : BaseClass 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = BaseClass.EnumPageTitles.APPNAME + BaseClass.EnumPageTitles.HOME;
                ((LinkButton)this.Page.Master.FindControl("lnkHome")).CssClass = "main_menu_active";
                trTime.Visible = false;
                chkAllDay.Checked = true;
            }
        }

        protected void gvSlots_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBProctor.BGetBlockedDates(objBEProctor);

                if (objBEProctor.DtResult.Rows.Count > 0)
                    gvSlots.DataSource = objBEProctor.DtResult;
                else
                    gvSlots.DataSource = new string[] { };
            }
            catch
            {
            }
        }

        protected void gvSlots_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == "DeleteSlot")
                {
                    BEProctor objBEProctor = new BEProctor();
                    BProctor objBProctor = new BProctor();
                    objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                    objBEProctor.intID = Convert.ToInt32(e.CommandArgument.ToString());
                    objBProctor.BDeleteBlockedDates(objBEProctor);
                    if (objBEProctor.IntResult == 1)
                        gvSlots.Rebind();
                }
            }
            catch
            {
            }
        }

        protected void btnAddDate_Click(object sender, EventArgs e)
        {
            try
            {
                BEProctor objBEProctor = new BEProctor();
                BProctor objBProctor = new BProctor();
                objBEProctor.strSlotDate = Convert.ToDateTime(CalendarExtender1.SelectedDate.ToString()).ToString("MM/dd/yyyy").Replace("-", "/");
                if (chkAllDay.Checked == true)
                {
                    objBEProctor.strSlotTime = null;
                    objBEProctor.intAllDay = 1;
                }
                else
                {
                    //objBEProctor.strSlotTime = Convert.ToDateTime(RadTimePicker1.DbSelectedDate).ToString("hh:mm tt").ToString();
                    objBEProctor.strSlotTime = RadTimePicker1.SelectedTime.ToString();
                    objBEProctor.intAllDay = 0;
                }
                objBEProctor.IntUserID = Convert.ToInt32(Session[BaseClass.EnumPageSessions.USERID].ToString());
                objBProctor.BSaveBlockedDates(objBEProctor);
                if (objBEProctor.IntResult == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('Date added successfully');", true);
                    CalendarExtender1.SelectedDate = null;
                    RadTimePicker1.SelectedTime = null;
                    gvSlots.Rebind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('Date already exists');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotSaved", "alert('Please enter the valid Date and Time');", true);
            }
        }
        protected void chkAllDay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDay.Checked == true)
                trTime.Visible = false;
            else
                trTime.Visible = true;
        }


    }
}