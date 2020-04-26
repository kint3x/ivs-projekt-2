using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
        /// Hlavný začiatočný bod programu
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
            /**
             * Ak je premenná <code>generate_tdd</code> nastavená na true, pri spustení programu sa generujú tdd testy
             */
            bool generate_tdd = true; //!< premenna ktorá určuje generovanie výsledkov z TDD testov
            if (generate_tdd) {
                TDD_testy testy = new TDD_testy();
                testy.Spusti_testy();
            }


        }
    }
}
