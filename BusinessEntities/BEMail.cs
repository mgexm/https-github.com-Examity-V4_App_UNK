using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class BEMail
    {
        public int IntUserID { get; set; }
        public Int64 IntTransID { get; set; }
        public string StrTemplateName { get; set; }
        public string StrUserName { get; set; }
        public string StrPassword { get; set; }

    }
}
