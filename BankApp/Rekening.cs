using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Rekening
    {
        public string  rekeningnummer { get; set; }
        public double saldo { get; set; }
        public Rekening(double s) 
        {
            Random r = new Random();
            rekeningnummer = "BE" + r.Next(0, 9) + r.Next(0, 9) + " " + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + " " + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + " " + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9) + r.Next(0, 9);
            saldo = s;
        }
        public virtual void Overschrijven(double bedrag,Rekening r,string rn)
        {
            if(r !=null)
            r.saldo += bedrag;
            saldo -= bedrag;
            Console.WriteLine($"{bedrag} euro is overschreven van {this.rekeningnummer} naar {rn}.");
            Console.ReadKey();
        }
        public virtual void Toon()
        {
            Console.WriteLine($"{rekeningnummer}: {saldo} euro.");
            Console.ReadKey();
        }
    }
}
