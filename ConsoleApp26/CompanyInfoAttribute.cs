using System;

namespace ConsoleApp26
{
    internal class CompanyInfoAttribute : Attribute
    {
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
    }
}