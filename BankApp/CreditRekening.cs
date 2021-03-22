using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class CreditRekening : Rekening
    {
        public int tekens { get; set; }
        public CreditRekening(double s,int t) : base(s) { tekens = t; }
        public override void Overschrijven(double bedrag, Rekening r,string rn)
        {
            Console.Write("CVC (3 tekens op de achterkant van de kaart): ");
            if(tekens==Convert.ToInt32(Console.ReadLine()))
            base.Overschrijven(bedrag, r,rn);
        }

    }
}
