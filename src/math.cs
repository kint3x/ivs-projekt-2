using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

/*! \namespace mathlib
 *	\brief Namespace v ktorom je trieda math obsahujúca matematické metódy
 */

namespace mathlib
{
	/*! \class math
    \brief Trieda v ktorej sú všetky matematické metódy ktoré kalkulačka používa

    Matematická trieda obsahuje metódy: Sucet, Nasobenie, Delenie, Rozdiel, Faktorial, Mocnina, Absolutna, Sinus, Obecna_odmocnina

	*/
public class math
	{

		public const double EPSILON = 0.0000000001; /*!< Konštanta na počítanie pre iteračné výpočty */

		/**
		 * \brief Sčíte argument a s argumentom b
		 * \param a prvý argument.
		 * \param b druhý argument.
		 * \return Vráti súčet hodnôt
		 */

		public static double Sucet(double a, double b)
		{
			return a + b;
		}


		/**
		 * \brief Vynásobí argument a argumentom b
		 * \param a prvý argument.
		 * \param b druhý argument.
		 * \return Vráti súčin hodnôt
		 */

		public static double Nasobenie(double a, double b)
		{
			return a * b;
		}

		/**
		 * \brief Funkcia vydelí argument a argumentom b
		 * \param a prvý argument.
		 * \param b druhý argument.
		 * \return Vráti podiel hodnôt
		 * \exception InvalidOperationException ak sa pokúsi deliť a/0
		 */
		public static double Delenie(double a, double b)
		{
			if (b == 0)
			{
				throw new System.InvalidOperationException("DELENIE NULOU!");
			}
			return a / b;
		}

		/**
		 * \brief Odpočíta argument a od argumentu b
		 * \param a prvý argument.
		 * \param b druhý argument.
		 * \return Vráti rozdiel hodnôt
		 * \exception InvalidOperationException ak sa pokúsi deliť a/0
		 */
		public static double Rozdiel(double a, double b)
		{
			return a - b;
		}

		/**
		 * \brief Spraví faktoriál z celého čísla
		 * \param a prvý argument.
		 * \return Vráti faktoriál
		 * \exception InvalidOperationException ak je a menšie ako 0
		 * \exception InvalidOperationException ak a nie je celé číslo
		 */
		public static double Faktorial(double a)
		{
			double res = 1;
			if (a == 0) return 1;
			if (a < 0)
			{
				throw new System.InvalidOperationException("Neda sa spravit faktorial z cisla mensieho ako 0!");
			}

			if (a % 1 != 0)
			{
				throw new System.InvalidOperationException("Faktorial sa da iba na celé číslo!");
			}

			for (int i = 1; i <= a; i++)
			{
				res *= i;
			}
			return res;
		}
		/**
		 * \brief Umocní X na N-tú pomocou aproximácie a iteračných výpočov
		 * \param x mocnenec
		 * \param n exponent
		 * \return Vráti x na n-tú
		 * \exception InvalidOperationException ak n nie je celé číslo
		 * \exception InvalidOperationException ak n je záporné číslo
		 */
		public static double Mocnina(double x, double n)
		{ 
			if (n < 0)
			{
				throw new InvalidOperationException("Exponent nemôže byť záporný!");
			}

			if (n % 1 != 0)
			{
				throw new InvalidOperationException("Nemožno použiť desatinné číslo ako mocninu!");
			}

			if (n == 0)
			{
				return 1;
			}

			double mocnina = x;   // x sa nam bude zvacsovat a ale nasobit budeme stale len zakladom 
			for (int i = 2; i <= n; i++)
			{
				x *= mocnina;
			}
			return x;
		}

		/**
		 * \brief Vráti absolútnu hodnotu
		 * \param abs 
		 * \return Vráti absolútnu hodnotu
		 */
		public static double Absolutna(double abs)
		{
			if (abs >= 0) return abs;
			return -abs;
		}
		// Vrati sinus cisla, najskor si premeni radiany na stupne a potom vypocita sinus, je mozne zadat aj inu presnost

		/**
		 * \brief Vráti sínus čísla na základe rozvoja do Taylorovho radu v okolí bodu 0
		 * \param radians prijíma číslo ktoré si neskôr premení na radiány
		 * \param epsilon voliteľná konštanta ktorá je štandardne definovaná EPSILON
		 * \return Vráti sínus zadaného čísla
		 */

		public static double Sinus(double radians, double epsilon = EPSILON)
		{
			if (radians == 90) return 1;
			if (radians == -90) return -1;
			if (radians % 180 == 0) return 0;

			radians = radians * 3.141592654 / 180;
			int i = 1, moc = 3;
			double vysledok = radians, povodny = 0;
			while (true)
			{
				/** <code>if (i % 2 != 0)</code>
				* ak je zlomok párny tak sa pričíta, ak nepárny tak odčíta od vysledku 
				*/
				if (i % 2 != 0)
				{ 
					vysledok -= (Mocnina(radians, moc) / Faktorial(moc));
				}
				else
				{
					vysledok += (Mocnina(radians, moc) / Faktorial(moc));
				}
				moc += 2; /*!< v rade sa mocniny a faktorial zvysuju o 2 */
				i++; /*!< i uchovava poradie zlomku */

				/** <code>if (Absolutna(povodny - vysledok) > epsilon)</code>
				 * ak je absolutna hodnota povodneho vysledku a aktualneho vysledku vacsia ako epsilon, pokracuje a aktualny vysledok ulozi uz ako povodny <code>povodny = vysledok;</code>
				 */
				if (Absolutna(povodny - vysledok) > epsilon)
				{ 
					povodny = vysledok;
				}
				else return vysledok; /** ak nie tak sme v presnosti epsilon a vratime vysledok */
			}

		}
		/**
		 * \brief Iterativna metoda na nájdenie odmconiny Babylonian method
		 * \param S argument ktorý bude odmocnený
		 * \return Vráti odmocninu z čísla
		 * \exception InvalidOperationException ak je S záporné číslo
		 */
		public static double findSqrt(double S)
		{

			double epsilon = 0.00001;
			if (S < 0)
			{
				throw new System.InvalidOperationException("Odmocnina zo zaporneho cisla? Really?");
			}
			else if (S == 0) return 0;

			double x = S / 2;
			double xPrev = 0;
			do
			{
				xPrev = x;
				x = (xPrev + S / xPrev) / 2; 
			} while (Absolutna(x - xPrev) > epsilon);
		
			return(x);
		}

		/**
		 * \brief Iteratívna metóda na nájdenie Ntej odmocniny z A
		 * \param A Odmocňované číslo
		 * \param N odmocniteľ
		 * \return Vráti Ntú odmocninu z čísla A
		 * \exception InvalidOperationException ak je S záporné číslo
		 * \exception InvalidOperationException ak je N celé číslo
		 * \exception InvalidOperationException ak je N menšie ako 2
		 */
		public static double Obecna_odmocnina(double A, double N)
		{
			if (N % 1 != 0)
			{
				throw new InvalidOperationException("Odmocniteľ musí byť celé číslo");
			}
			if(N < 2)
			{
				throw new InvalidOperationException("Odmocniteľ nemôže byť menší ako 2");
			}
			if (A < 0)
			{
				throw new InvalidOperationException("Odmocnina zo zaporneho cisla? Really?");
			}
			Random rand = new Random();
			/** 
			 * <code>double xPre = rand.Next(10)</code> initial guess, od 0-9 ktorý je aproximovaný
			 */
			double xPre = rand.Next(10); ;

			
			double eps = EPSILON;

			/**
			 * <code>double delX = 2147483647;</code> inicializuje delX na INT_MAX od ktorého aproximuje
			 */
			double delX = 2147483647;

			
			double xK = 0.0;

			/**
			 * <code>while (delX > eps)</code> hľadá odmocninu pokiaľ je odchýľka menšia ako epsilon
			 */
			while (delX > eps)
			{
				xK = ((N - 1.0) * xPre +
				(double)A / Math.Pow(xPre, N - 1)) / (double)N;
				delX = Math.Abs(xK - xPre);
				xPre = xK;
			}

			return xK;
		}

	}
}
