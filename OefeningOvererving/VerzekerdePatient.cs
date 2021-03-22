using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningOvererving
{
    class VerzekerdePatient : Patient
    {
        public VerzekerdePatient(string naam, int aantaluren) : base(naam, aantaluren)
        {

        }
        public override double BerekenKost()
        {
            return base.BerekenKost()*0.9;
        }
    }
}
