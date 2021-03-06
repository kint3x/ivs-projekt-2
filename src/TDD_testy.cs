﻿using System;
using System.Text;
using System.Collections.Generic;
using mathlib;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
/**
 * \namespace TDD
 * \brief Obsahuje triedu s tdd testami
 */
namespace TDD
{
    /*! \class TDD_testy
    \brief Trieda v ktorej sú všetky TDD testy
    Trieda vykoná testy a ich výsledok uloží do súboru TDD_testy.html
	*/
    public class TDD_testy
    {
        StreamWriter file; //!< objekt pomocou ktorého sa vytvára súbor s výsledkami TDD
        /**
         * \brief Metóda ktorá spustí všetky ostatné fukncie ktoré testujú matematickú knižnicu
         * Taktiež vygenereju súbor TDD_testy.html do ktorej sa zapisujú výsledky
         */
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
                SUC_TEST();
                DEL_TEST();
                ODC_TEST();
                NAS_TEST();
                FAKT_TEST();
                MOC_TEST();
                ABS_TEST();
                SIN_TEST();
                ODM_TEST();
                obecna_odmocnina_TEST();
                file.WriteLine("</table></body></html>");
            }
        }

        /**
         * \brief Funkcia zapíše výsledok testu ak uspel s jeho ID
         * \param id_test parameter, ktorý bude vypísaný ako ID testu
         */
        private void Success_test(int id_test)
        {
            file.WriteLine("<tr>");
            file.WriteLine("<td>TEST[{0}]</td><td><b style='color:green;'>OK</b></td>",id_test);
            file.WriteLine("</tr>");
        }
        /**
         * \brief Funkcia zapíše výsledok testu ak neuspel s jeho ID a dôvodom
         * \param id_test parameter, ktorý bude vypísaný ako ID testu
         * \param result premenná do ktorej sa posiela dôvod prečo test neuspel
         */
        private void Fail_test(string result, int id_test)
        {
            file.WriteLine("<tr>");
            file.Write("<td>TEST[{0}]</td><td><b style='color:red;'>FAIL = ", id_test);
            file.WriteLine("{0}</b></td>", result);
            file.WriteLine("</tr>");
        }

        /**
         * \brief Testuje funkciu <code>math.Sucet</code>
         */
        void SUC_TEST()
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
        /**
         * \brief Testuje funkciu <code>math.Delenie</code>
         */
        void DEL_TEST()
        {
            try
            {
                if (math.Delenie(10.5, 10) == 1.05) Success_test(4);
                else Fail_test(string.Format("Expected: 1.05 Got: {0}", math.Delenie(10.5, 10)), 4);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
            try
            {

                if (math.Delenie(10.5, 0) == 1.5) Success_test(5);
                else Fail_test(string.Format("Expected: 1.5 Got: {0}", math.Delenie(10.5, 0)), 5);
            }
            catch (InvalidOperationException exception) {
                if (exception!=null)
                Success_test(5);
            }
        }
        /**
         * \brief Testuje funkciu <code>math.Rozdiel</code>
         */
        void ODC_TEST()
        {
            try
            {
                if (math.Rozdiel(20, 8) == 12) Success_test(6);
                else Fail_test(string.Format("Expected: 12 Got: {0}", math.Rozdiel(20, 8)), 6);

                if (math.Rozdiel(0, -20) == 20) Success_test(7);
                else Fail_test(string.Format("Expected: 20 Got: {0}", math.Rozdiel(0, -20)), 7);

            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }

        /**
         * \brief Testuje funkciu <code>math.Nasobenie</code>
         */
        void NAS_TEST()
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
         * \brief Testuje funkciu <code>math.Faktorial</code>
         */
        void FAKT_TEST()
        {
            try
            {
                if (math.Faktorial(6) == 720) Success_test(10);
                else Fail_test(string.Format("Expected: 720 Got: {0}", math.Faktorial(6)), 10);

                if (math.Faktorial(4) == 24) Success_test(11);
                else Fail_test(string.Format("Expected: 24 Got: {0}", math.Faktorial(4)), 11);
                
                if (math.Faktorial(0) == 1) Success_test(12);
                else Fail_test(string.Format("Expected: 1 Got: {0}", math.Faktorial(4)), 12);
            }
            catch (InvalidOperationException exception)
            {
                if(exception != null)
                { 
                    Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
                }
            }
            try
            {
                if (math.Faktorial(-1) != 0) Fail_test(string.Format("Got answer to non answerable", -1), 13);
                else Fail_test(string.Format("Got answer to non answerable",-1), 13);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                {
                    Success_test(13);
                }
            }
        }
        /**
         * \brief Testuje funkciu <code>math.Mocnina</code>
         */
        void MOC_TEST()
        {
            try
            {
                if (math.Mocnina(2, 3) == 8) Success_test(14);
                else Fail_test(string.Format("Expected: 8 Got: {0}", math.Mocnina(2, 3)), 14);

                if (math.Mocnina(8, 2) == 64) Success_test(15);
                else Fail_test(string.Format("Expected: 64 Got: {0}", math.Mocnina(8, 2)), 15);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
            try
            {
                if (math.Mocnina(8, 2.5) == 64) Fail_test(string.Format("Didnt expect return"),16);
                else Fail_test(string.Format("Didnt expect return"),16);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                    Success_test(16);
            }
        }

        /**
         * \brief Testuje funkciu <code>math.Absolutna</code>
         */
        void ABS_TEST()
        {
            try
            {
                if (math.Absolutna(40) == 40) Success_test(17);
                else Fail_test(string.Format("Expected: 35 Got: {0}", math.Absolutna(40)), 17);

                if (math.Absolutna(0) == 0) Success_test(18);
                else Fail_test(string.Format("Expected: 0 Got: {0}", math.Absolutna(0)), 18);

                if (math.Absolutna(-420) == 420) Success_test(19);
                else Fail_test(string.Format("Expected: 420 Got: {0}", math.Absolutna(-420)), 19);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }
        /**
         * \brief Testuje funkciu <code>math.Sinus</code>
         */
        void SIN_TEST()
        {
            try
            {
                if (math.Sinus(0) == 0) Success_test(17);
                else Fail_test(string.Format("Expected: 35 Got: {0}", math.Sinus(40)), 17);

                if (math.Sinus(90) == 1) Success_test(18);
                else Fail_test(string.Format("Expected: 0 Got: {0}", math.Sinus(0)), 18);

                if (math.Sinus(-90) == -1) Success_test(19);
                else Fail_test(string.Format("Expected: -1 Got: {0}", math.Sinus(-90)), 19);

                if (math.Absolutna(math.Sinus(20) - 0.3420201433) < 0.01) Success_test(20);
                else Fail_test(string.Format("Exppected: {0} < 0.01", math.Absolutna(math.Sinus(20) - 0.3420201433)), 20);
            }
            catch (InvalidOperationException exception)
            {
                Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
            }
        }

        /**
          * \brief Testuje funkciu <code>math.findSqrt</code>
          */
        void ODM_TEST()
        {
            try
            {
                if (math.findSqrt(49) == 7) Success_test(21);
                else Fail_test(string.Format("Expected: 7 Got: {0}", math.findSqrt(40)), 21);

                if (math.findSqrt(0) == 0) Success_test(22);
                else Fail_test(string.Format("Expected: 0 Got: {0}", math.findSqrt(0)), 22);

                if (math.Absolutna(math.findSqrt(2.5) - 1.58113883) < 0.01) Success_test(23);
                else Fail_test(string.Format("Expected:{0} < 0.01", math.Absolutna(math.findSqrt(2.5) - 1.58113883)), 23);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                {
                    Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
                }
            }
            try
            {
                if (math.findSqrt(-1) == 7) Fail_test(string.Format("Didnt expect return"), 24);
                else Fail_test(string.Format("Didnt expect return"), 24);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                {
                    Success_test(24);
                }
            }

        }
        /**
         * \brief Testuje funkciu <code>math.Obecna_odmocnina</code>
         */
        void obecna_odmocnina_TEST()
        {
            try
            {
                if (math.Absolutna(math.Obecna_odmocnina(49,3) - 3.65930571) < 0.001) Success_test(25);
                else Fail_test(string.Format("Expected: <0.001 Got: {0}", math.Absolutna(math.Obecna_odmocnina(49, 3) - 3.65930571)), 25);

                if (math.Absolutna(math.Obecna_odmocnina(300, 5) - 3.129134645) < 0.001) Success_test(26);
                else Fail_test(string.Format("Expected: <0.001 Got: {0}", math.Absolutna(math.Obecna_odmocnina(300, 5) - 3.129134645)), 26);

                if (math.Absolutna(math.Obecna_odmocnina(50, 30) - 1.139284879) < 0.001) Success_test(27);
                else Fail_test(string.Format("Expected:{0} < 0.01", math.Absolutna(math.Obecna_odmocnina(50, 30) - 1.139284879)), 27);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                {
                    Fail_test(string.Format("EXCEPTION = {0}", exception.Message), -1);
                }
            }
            try
            {
                if (math.Absolutna(math.Obecna_odmocnina(-1, 5))==0) Fail_test(string.Format("Didnt expect return"), 28);
                else Fail_test(string.Format("Didnt expect return"), 28);
            }
            catch (InvalidOperationException exception)
            {
                if (exception != null)
                {
                    Success_test(28);
                }
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
  
  