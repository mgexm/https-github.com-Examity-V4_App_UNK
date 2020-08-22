using System;
using System.Text;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BMail 
    {
        public void BSendEmail(BEMail objBEMail)
        {
            new DMail().DSendMail(objBEMail);
        }
    }
}
