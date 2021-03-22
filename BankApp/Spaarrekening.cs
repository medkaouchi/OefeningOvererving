using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Spaarrekening : Rekening
    {
        public Spaarrekening(double s) : base(s) { }
        public override void Overschrijven(double bedrag, Rekening r,string rn)
        {
            Console.WriteLine("Deze rekening kanniet overschrijven");
        }

    }
}
