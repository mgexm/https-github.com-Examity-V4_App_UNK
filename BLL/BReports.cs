using System;
using BusinessEntities;
using DAL;


namespace BLL
{
    public class BReports:BCommon
    {
        
      
        public void BGETLAUNCHTIMEREPORT(BEReports objBEReports)
        {
            DReports objDReports = new DReports();
            objDReports.DGETLAUNCHTIMEREPORT(objBEReports);
        }
    }
}
