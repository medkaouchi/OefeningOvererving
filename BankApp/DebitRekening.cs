using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class DebitRekening:Rekening
    {
        
        public DebitRekening(double s):base(s) {   }
        public override void Overschrijven(double bedrag, Rekening r,string rn)
        {
            if(saldo-bedrag>0)
            base.Overschrijven(bedrag, r,rn);
        }
    }
}
