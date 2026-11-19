using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
        private static CompanyInfo theInstance = null;
        public string Vat { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public int ClubDiscount { get; set; }

        private CompanyInfo(string vat, string cvr, string name, int clubDiscount)
        {
            Vat = vat;
            Cvr = cvr;
            Name = name;
            ClubDiscount = clubDiscount;
        }

        public static CompanyInfo getInstance()
        {
            if (theInstance == null)
            {
                theInstance = new CompanyInfo("vat stuff","123456789", "big mamma", 10);
            }
            return theInstance;
        }
        public override string ToString()
        {
            return $"company: {Name}. our members get {ClubDiscount}% off. cvr: {Cvr}";
        }
    }
}
