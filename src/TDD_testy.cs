using System;
using System.Text;
using System.Collections.Generic;
using mathlib;
using System.IO;

namespace TDD
{

    public class TDD_testy {
        StreamWriter file;
        //FUNKCIA SPUSTI VSETKY TESTY
        public void Spusti_testy()
        {
            if (File.Exists("TDD_testy.html"))
            {
                File.Delete("TDD_testy.html");
            }
            using (file = new StreamWriter("TDD_testy.html", true))
            {
                file.WriteLine("<html><head><title>VYSLEDKY TESTOV</title><style><style>table{font-family: arial, sans-serif;border-collapse: collapse;width: 100%;}td, th {border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head><body><table><tr><th> TEST </th><th> VYSLEDOK </th></tr>");
                file.WriteLine("<b>---- SUM TESTY ----</b><br>");
                // sem pôjdu funkcie s testami postupne ako ich budeš robiť
                SUM_TEST();
                DIV_TEST();
                SUB_TEST();
                MUL_TEST();

                file.WriteLine("</table></body></html>");
            }
        }

        // VYPIS STATUSU TESTOV
        private void Success_test(int id_test)
        {
            file.WriteLine("<tr>");
            file.WriteLine("<td>TEST[{0}]</td><td><b style='color:green;'>OK</b></td>",id_test);
            file.WriteLine("</tr>");
        }

        private void Fail_test(string result, int id_test)
        {
            file.WriteLine("<tr>");
            file.Write("<td>TEST[{0}]</td><td><b style='color:red;'>FAIL = ", id_test);
            file.WriteLine("{0}</b></td>", result);
            file.WriteLine("</tr>");
        }

        // TESTY 
        void SUM_TEST()
        { 
            try
            {
                // DO PODMIENKY VLOZIT FUNKCIU A OCAKAVANY VYSLEDOK, do Success_test("SEM IDE CISLO TESTU");
                if (math.Sucet(10, 10) == 20) Success_test(1);
                else Fail_test(string.Format("Expected: 20 Got: {0}", math.Sucet(10, 10)), 1);

                if (math.Sucet(-5, 20) == 15) Success_test(2);
                else Fail_test(string.Format("Expected: 15 Got: {0}", math.Sucet(-5, 20)), 2);

                if (math.Sucet(-10, 20) == 10) Success_test(3);
                else Fail_test(string.Format("Expected: 10 Got: {0}", math.Sucet(-10, 20)), 3);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null) // ak exception existuje nech ju vypise
                {
                    // exception bude mat test_ID -1 
                    Fail_test(string.Format("EXCEPTION = {0}",exception.Message), -1);
                }
            }
        }
        void DIV_TEST()
        {
            try
            {
                if (math.Delenie(10.5, 10) == 1.05) Success_test(4);
                else Fail_test(string.Format("Expected: 1.05 Got: {0}", math.Delenie(10.5, 10)), 4);

                if (math.Delenie(10.5, 0) == 1.5) Success_test(5);
                else Fail_test(string.Format("Expected: 1.5 Got: {0}", math.Delenie(10.5, 0)), 5);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }

        void SUB_TEST()
        {
            try
            {
                if (math.Rozdiel(20, 8) == 12) Success_test(6);
                else Fail_test(string.Format("Expected: 12 Got: {0}", math.Rozdiel(20, 8)), 6);

                if (math.Rozdiel(0, -20) == -20) Success_test(7);
                else Fail_test(string.Format("Expected: -20 Got: {0}", math.Rozdiel(20, 8)), 6);

            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }

        void MUL_TEST()
        {
            try
            {
                if (math.Nasobenie(5, 7) == 35) Success_test(8);
                else Fail_test(string.Format("Expected: 35 Got: {0}", math.Nasobenie(5, 7)), 8);

                if (math.Nasobenie(-9, 6) == -54) Success_test(9);
                else Fail_test(string.Format("Expected: -54 Got: {0}", math.Nasobenie(-9, 6)), 9);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }






        /**
         *  SABLONA AKO VYTVARAT FUNKCIE > POTOM KAZDU NOVU FUNKCIU (TEST) treba zaradit hore do vyznaceneho miesta vo funkcii Spusti_testy()
         *  void NAZOV_TEST()
         *  {
         *  try
         *  { // sem pojdu testy
         *      if(math.NAZOV_TESTOVANEJ_FUNKCIE_Z_MATH.CS(ARGUMENTY) == OCAKAVANY VYSLEDOK) Success_test(PORADIE TESTU);
         *      else Fail_test(string.Format("Expected: OCAKAVANY_VYSLEDOK Got: {0}", math.NAZOV_TESTOVANEJ_FUNKCIE), PORADIE_TESTU);
         *    // DALSI TESTE PRE INE ARGUMENTY ....
         *  }
         *  catch (InvalidOperationException exception)
         *  {
         *      Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
         *  }
         */
    }
} 
  
  