using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWCFServices.Model
{
    public class SProduct
    {
        public int SPID { get; set; }
        public string SName { get; set; }
        public string SPNO { get; set; }
        public bool SMF { get; set; }
        public bool SFGF { get; set; }
        public string SColor { get; set; }
        public Int16 SSSL { get; set; }
        public Int16 SROP { get; set; }
        public decimal SSC { get; set; }
        public decimal SLP { get; set; }        
        public string SSize { get; set; }
        public string SSUMC { get; set; }
        public string SWUMC { get; set; }
        public decimal SWeight { get; set; }
        public int SDTM { get; set; }
        public string SPL { get; set;}
        public string SClass { get; set; }
        public string SStyle { get; set; }
        public int SPSID { get; set; }
        public int SPMID { get; set; }
        public DateTime SSSD { get; set; }
        public DateTime SSED { get; set; }
        public DateTime SDD { get; set; }
        public Guid SRG { get; set; }
        public DateTime SMD { get; set; }
    }
}