using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningOvererving
{
     class Patient
    {
        public string naam { get; set; }
        public int aantalUren { get; set; }
        public Patient() { }
        public Patient (string Naam,int AantalUren)
        {
            naam = Naam;
            aantalUren = AantalUren;
        }
        public virtual double BerekenKost()
        {
            return 50 + (20 * aantalUren);
        }
    }
}
