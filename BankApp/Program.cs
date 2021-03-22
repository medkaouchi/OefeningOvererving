using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rekening> rekeningen = new List<Rekening>();
            do
            {
                string[] rekeningennummers = new string[rekeningen.Count];
                for (int i = 0; i < rekeningennummers.Length; i++)
                {
                    rekeningennummers[i] = rekeningen[i].rekeningnummer;
                }
                switch (SelectMenu("Je bestaande rekeningen", "Nieuw rekening openen", "Bestaande rekening verwijderen", "Overschrijven"))
                {
                    case 1:
                        if(rekeningen.Count!=0)
                        rekeningen[SelectMenu(rekeningennummers) - 1].Toon();
                        break;
                    case 2:
                        switch (SelectMenu("Debit rekening", "Krediet rekening", "Spaar rekening"))
                        {
                            case 1:
                                Console.Write("Saldo: ");
                                double s = Convert.ToDouble(Console.ReadLine());
                                if (s >= 0)
                                    rekeningen.Add(new DebitRekening(s));
                                else
                                {
                                    Console.WriteLine("Error!");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                Console.Write("CVC: ");
                                int cvc = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Saldo: ");
                                double s1 = Convert.ToDouble(Console.ReadLine());
                                if (s1 >= 0)
                                    rekeningen.Add(new CreditRekening(s1,cvc));
                                else
                                {
                                    Console.WriteLine("Error!");
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                Console.Write("Saldo: ");
                                double s3 = Convert.ToDouble(Console.ReadLine());
                                if (s3 >= 0)
                                    rekeningen.Add(new Spaarrekening(s3));
                                else
                                {
                                    Console.WriteLine("Error!");
                                    Console.ReadKey();
                                }
                                break;
                        }
                        break;
                    case 3:
                        if (rekeningen.Count != 0)
                        {
                            int index = SelectMenu(rekeningennummers) - 1;
                            if (rekeningen[index].saldo == 0)
                                rekeningen.RemoveAt(index);
                        }
                        break;
                    case 4:
                        if (rekeningen.Count != 0)
                        {
                            int ind = SelectMenu(rekeningennummers) - 1;
                            if (rekeningen[ind].GetType().Equals(typeof(Spaarrekening)))
                            {
                                Console.WriteLine("Deze rekening kanniet overschrijven");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("Bedrag: ");
                                double bedrag = Convert.ToDouble(Console.ReadLine());
                                if(bedrag>0)
                                if ((rekeningen[ind].GetType().Equals(typeof(DebitRekening)) && rekeningen[ind].saldo < bedrag))
                                {
                                    Console.WriteLine("Bedrag is te hoog!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Write("Rekening nummer: ");
                                    string rn = Console.ReadLine();
                                    rekeningen[ind].Overschrijven(bedrag, RekeningExist(rn, rekeningen),rn);
                                }
                                else
                                {
                                    Console.WriteLine("Error!");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;
                }
            } while (true);
        }
        static Rekening RekeningExist(string rn,List<Rekening> list)
        {
            Rekening rekening = null;
            foreach (var item in list)
            {
                if (item.rekeningnummer == rn)
                    rekening= item;
            }
            return rekening;
        }
        static int SelectMenu(params string[] menu)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();

            int selection = 1;
            bool selected = false;
            ConsoleColor selectionForeground = Console.BackgroundColor;
            ConsoleColor selectionBackground = Console.ForegroundColor;

            while (!selected)
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    if (selection == i + 1)
                    {
                        Console.ForegroundColor = selectionForeground;
                        Console.BackgroundColor = selectionBackground;
                    }
                    Console.WriteLine((i + 1) + ": " + menu[i]);
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selection--;
                        break;
                    case ConsoleKey.DownArrow:
                        selection++;
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                }

                selection = Math.Min(Math.Max(selection, 1), menu.Length);
                Console.SetCursorPosition(0, 0);
            }

            Console.Clear();
            Console.CursorVisible = true;

            return selection;
        }
    }
}
