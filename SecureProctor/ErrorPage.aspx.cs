using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureProctor
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random waitTime = new Random();
            int seconds = waitTime.Next(3 * 1000, 11 * 1000);

            //Put the thread to sleep
            System.Threading.Thread.Sleep(seconds);
        }
    }
}