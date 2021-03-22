using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningOvererving
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient("Kamal", 3);
            Console.WriteLine(patient.BerekenKost()); 
            VerzekerdePatient persoon = new VerzekerdePatient("Mohamed", 3);
            Console.WriteLine(persoon.BerekenKost());
            Console.ReadLine();
        }
    }
}
