using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using mathlib;
using TDD;

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

            Console.WriteLine("TDD TESTY:");
            TDD_testy testy = new TDD_testy();
            testy.Spusti_testy();


            // DOCASNE TESTY END
        }
    }
}
