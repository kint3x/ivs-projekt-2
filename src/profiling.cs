using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathlib;

namespace profiling
{
    class profiling
    {
       static void main()
        {
            string hod;
            double cislo, pocet=0, suma=0, suma2=0, priemer, Npriemer, zatvorka, celok, s;

            while ((hod = Console.ReadLine()) != null)
            {
                cislo = Convert.ToInt32(hod);
                pocet++;
                suma = math.Sucet(suma, cislo);
                suma2 = math.Sucet(math.Mocnina(suma2, 2), math.Mocnina(cislo, 2));
            }

            priemer = math.Delenie(suma, pocet);

            Npriemer = math.Nasobenie(pocet, math.Mocnina(priemer, 2));
            zatvorka = math.Rozdiel(suma2, Npriemer);
            celok = math.Nasobenie(math.Delenie(1, (pocet - 1)), zatvorka);
            s = math.findSqrt(celok);
        }
    }
}
