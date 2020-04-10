using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using mathlib;


namespace src
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // DOCASNE TESTY
            Console.WriteLine("SUCET 5+5: {0}\n", math.Sucet(5, 5));
            Console.WriteLine("ABS -10.33: {0} \n ABS 15.58: {1}\n", math.Absolutna(-10.33), math.Absolutna(15.58));
            Console.WriteLine("SIN 50: {0}\n", math.Sinus(50, 0.0000001));
            Console.WriteLine("MOCNINA 2na3: {0}\n", math.Mocnina(2, 3));
            Console.WriteLine("DRUHA ODMOCNINA Z 9: {0}\n", math.findSqrt(9));
            // DOCASNE TESTY END
        }
    }
}
