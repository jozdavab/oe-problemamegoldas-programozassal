namespace LAB02_20240919_Teachers
{
    /*
     Feltételes ciklusok használata. Összetett logikai kifejezések, rövidzár-kiértékelés. 
     Számláló ciklus használata. Véletlenszám-generálás.
     */
    public class Program
    {
        private static void Main(string[] args)
        {
            // region - endregion blokkok miatt áttekinthetőbb a kód. Oldalt a kis +- jelekkel lehet kinyitni és becsukni őket.

            #region 1.feladat

            /*
             * Készítsünk programot, amely elkér a felhasználótól egy N pozitív egész számot, majd kiírja az egész számokat
             * 0 és N között. Módosítsuk úgy a programot, hogy az csak a páros számokat írja ki.
             */

            Console.Write("Adj meg egy pozitív egész számot:\t");                   // https://learn.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
            int n = int.Parse(Console.ReadLine());                                  // Az int.Parse() hibát dob, ha nem számot ír be a felhasználó, de első félévben nem elvárt a hibakezelés.
            for (int i = 0; i < n; i++)                                             // Felépülés: Inicializátor (int i=0); Feltétel (i<n); Iterátor (i++);
            {// Ciklusmag eleje.
                if (i % 2 == 0)                                                     // Csak páros számok gyűjtése, maradékos osztás segítségével. 
                {
                    Console.WriteLine(i + " ");
                }
            }// Ciklusmag vége.

            #endregion

            #region 2.feladat

            /*
             * Tároljuk egy változóban a felhasználó jelszavát. Addig kérjük el tőle a jelszót a parancssorról, amíg az nem
             * egyezik az eltárolttal. Módosítsuk úgy a programot, hogy a felhasználó három sikertelen próbálkozás után kapjon
             * hibaüzenetet.
             */

            string password = "abc123";
            string passGuess;
            do //Hátultesztelő ciklus. Végrehajtja a ciklusmagban szereplő utasításokat, majd megnézi hogy teljesül e a ciklusbanmaradási feltétel. Majd ismétel amíg a feltétel igaz.
            {
                Console.Write("Kérlek add meg a jelszavad:\t");
                passGuess = Console.ReadLine();
            } while (password != passGuess);// Ciklusfeltétel. Amíg a kifejezés igaz, a ciklusmag ismétlődik.
            Console.WriteLine("Sikeres bejelentkezés!");

            int tryCount = 0;
            do
            {
                Console.Write("Kérlek add meg a jelszavad:\t");
                passGuess = Console.ReadLine();
                tryCount++;
            } while (password != passGuess && tryCount < 3);
            if (password != passGuess)
            {
                Console.WriteLine("Sikertelen bejelentkezés, túl sok próbálkozás!");
            }
            else
            {
                Console.WriteLine("Sikeres bejelentkezés!");
            }

            #endregion

            #region 3.feladat

            /*
             * Írjunk programot, amely addig generál véletlen számokat 1 és 1000 között, amíg az meg nem egyezik a
             * program kezdetén a felhasználó által megadott számmal.Számoljuk meg, hány próbálkozás kellett a találathoz.
             */

            Random rnd = new Random();                      // Randomgenerátor példányosítása. Ne legyen a ciklusban, mert akkor többször létrejön a példány.
            Console.WriteLine("Adjon meg egy célszámot ]1,1000] intervallumban.");
            int target = int.Parse(Console.ReadLine());
            int guessCnt = 0;
            //Elöltesztelő ciklus. Ha a ciklusfeltétel igaz, végrehajtja a ciklusmagban szereplő utasításokat. Majd ismétel amíg a feltétel igaz.
            while (rnd.Next(1, 1000) != target)             //rnd.Next(alsóH,felsőH) visszaad egy véletlenszámot. Felsőhatár exkluzív, alsóhatár inkluzív.
            {
                guessCnt++;
            }
            Console.WriteLine("Ennyi próbálkozásból találta ki a gép: " + guessCnt);

            #endregion

            #region 4.feladat

            /*
             * Társasjátékoknál gyakori, hogy az kezd, aki először hatos dob. Készítsünk egy alkalmazást, amely eldönti,
             * hogy N játékos közül ki kezdjen. Minden játékosnál az Enter leütésére dobjunk egy véletlen számot 1 és 6 között,
             * majd ha az nem hatos, ugorjunk a következő játékosra. Ha körbeértünk, a folyamat induljon újra, egészen addig,
             * amíg valaki hatost nem dob.
             */

            int playerCnt = 5;  // N
            int dice = 0;
            int turnNumber = 0;
            while (dice != 6)
            {
                Console.WriteLine($"Üdvözöllek {turnNumber % playerCnt}. játékos, dobj az ENTER lenyomásával"); // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated

                // Ehelyett opcionálisan egy szimpla Console.ReadLine() is elég lett volna, hisz az mindenképp ENTER leütésével ér véget.
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("\nAz entert kell lenyomni...");
                }

                dice = rnd.Next(1, 7);
                Console.WriteLine("Ezt dobtad:" + dice);
                if (dice == 6)
                {
                    Console.WriteLine("Yay, te kezdesz.");
                }
                turnNumber++;
            }

            #endregion

            #region 5.feladat

            /*
             * Írjunk programot, amelynek kezdetén adott egy pozitív egész szám, a „gondolt szám”. A felhasználónak ki
             * kell találnia, hogy mi a gondolt szám. Ehhez a felhasználó megadhat számokat, melyekről a program megmondja,
             * hogy a gondolt számnál nagyobbak vagy kisebbek-e. A program akkor ér véget, ha a felhasználó kitalálta a gondolt
             * számot. A program jelenítse meg a felhasználó próbálkozásainak számát is.
             */

            int min = 0, max = 100;
            int secretNum = rnd.Next(min, max + 1);
            int guess;
            int tryCnt = 0;
            do
            {
                Console.Write($"Tippelj {min} és {max} között:\t");
                guess = int.Parse(Console.ReadLine());
                Console.Clear();
                if (guess < secretNum)
                {
                    Console.WriteLine($"{guess} túl alacsony, próbáld újra");
                    min = guess;
                }
                else if (guess > secretNum)
                {
                    Console.WriteLine($"{guess} túl magas, próbáld újra");
                    max = guess;
                }
                tryCnt++;
            } while (guess != secretNum);
            Console.WriteLine($"Kitaláltad a számot a {tryCnt}. próbálkozásoddal.");

            #endregion

            #region 6.feladat

            /*
             * Kérjünk el a felhasználótól egy N pozitív egész számot, majd írjuk ki az alábbiakat:
             * • N páros vagy páratlan
             * • N valódi pozitív osztóinak száma (1-et és N-et nem kell beleszámolnunk)
             * • N prímszám vagy összetett szám
             */

            Console.Write("Adj meg egy pozitív egész számot:\t");
            int givenNumber = int.Parse(Console.ReadLine());
            if (givenNumber % 2 == 0)  // Paritásvizsgálat. A moduló maradékos osztást fog végrahajtani és a maradékot visszaadni. Ha nincs maradék, a szám páros.
            {
                Console.WriteLine($"{givenNumber} páros.");
            }
            else
            {
                Console.WriteLine($"{givenNumber} páratlan.");
            }

            int dividerCnt = 0;
            for (int i = 2; i < givenNumber; i++) //Számlálós ciklus 2 és givenNumber közötti darab alkalommal fut le.
            {
                if (givenNumber % i == 0)
                {
                    dividerCnt++;
                }
            }
            Console.WriteLine($"N valódi pozitív osztóinak száma: {dividerCnt}");
            Console.WriteLine($"N prímszám-e: {dividerCnt < 1}");                   //Logikai kifejezés eredménye is kiíratható
            Console.WriteLine($"N összetett szám-e: {dividerCnt > 1}");

            #endregion

            #region 7.feladat

            /*
             * Kérjünk el egy pozitív egész számot, majd írjuk ki a faktoriálisát.
             */

            Console.Write("Adjon meg egy pozitív egész számot:\t");
            int factTarget = int.Parse(Console.ReadLine());
            int fact = 1;
            for (int i = 1; i < factTarget + 1; i++)
            {
                fact *= i;       //Rövidebb szintaxis, fact = fact * i helyett;
            }
            Console.WriteLine("A szám faktoriálisa: " + fact);

            #endregion

            #region 8.feladat

            /*
             * Készítsük programot, amely kiírja a képernyőre a szorzótáblát az alábbihoz hasonlóan.
             */

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++) //Ciklusba ágyazott ciklus. Figyeljünk oda az eltérő ciklusváltozó használatára.
                {
                    Console.Write(i * j + "\t");
                }
                Console.WriteLine();
            }

            #endregion  

            #region 9.feladat

            /*
             * Készítsünk időzítő alkalmazást, amely elkér egy másodpercben megadott időtartamot, majd kiírja azt a
             * képernyőre perc:másodperc formátumban, és visszaszámlálást indít. Minden eltelt másodperc után törölje a
             * képernyőt, és írja ki a még hátralévő időt. A visszaszámlálást végét jelezze a képernyő pirosra váltásával és
             * sípolással. A késleltetéshez használjuk a System.Threading.Thread.Sleep(1000); utasítást.
             */

            Console.Write("Adj meg egy időtartamot másodpercben:\t");
            int totalSec = int.Parse(Console.ReadLine());
            int minutes;
            int seconds;
            while (totalSec > 0)
            {
                Console.Clear();
                minutes = totalSec / 60;
                seconds = totalSec % 60;
                Console.WriteLine(minutes + ":" + seconds);
                System.Threading.Thread.Sleep(1000);
                totalSec -= 1; // totalSec = totalsec - 1
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.Beep(440, 1000);

            #endregion

            #region 10.feladat

            /*
             * Készítsünk tízes számrendszerből kettes számrendszerbe átváltó alkalmazást. A bemenet legyen egy 32
             * bites előjel nélküli egész (uint), kimenetként pedig jelenítsük meg az érték kettes számrendszerbeli alakját 8
             * bites blokkokban, big endian formátumban.
             */

            const int BITS = 32;
            Console.Write("Tízes számrendszerbeli szám:");
            uint decimalNum = uint.Parse(Console.ReadLine());
            uint remainder = decimalNum;
            Console.Write("{0} (10) = ", decimalNum);
            for (int e = BITS - 1; e >= 0; e--)                 // Csökkenő módon is felépíthető egy számlálósciklus.
            {
                uint currentPower = (uint)Math.Pow(2, e);       // Hatványozáshoz használható a Math könyvtár segédfüggvénye.
                uint digit = remainder / currentPower;
                remainder = remainder - digit * currentPower;
                Console.Write("{0}", digit);
                if (e % 8 == 0)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("(2)");

            #endregion

            #region 11.feladat

            /*
             * Készítsünk egyszerű félkarú rabló játékot. A játék elején a játékos 100 kredittel rendelkezik, a tét alapesetben
             * 1 kredit. A Spacebar billentyű lenyomásakor a játék három véletlen számjegyet pörget. Két egyforma szám esetén
             * a tét 10-szeresét, három egyforma esetén a tét 50-szeresét nyeri a felhasználó. Pörgetés előtt a tétet a Fel és Le
             * kurzorbillentyűkkel lehet módosítani. A játék véget ér Escape nyomáskor, vagy ha a játékosnak elfogy a kreditje.
             */

            int credits = 10;
            int stake = 1;
            ConsoleKey pressed;
            do
            {
                Console.Clear();
                Console.WriteLine("Kredit: " + credits);
                Console.WriteLine("Jelenlegi tét: " + stake);
                pressed = Console.ReadKey().Key;
                if (pressed == ConsoleKey.UpArrow)
                {
                    if (stake < credits)
                    {
                        stake++;
                    }
                }
                else if (pressed == ConsoleKey.DownArrow)
                {
                    if (stake > 0)
                    {
                        stake--;
                    }
                }
                else if (pressed == ConsoleKey.Spacebar)
                {
                    if (stake <= credits)
                    {
                        credits -= stake;
                        int firstDigit = rnd.Next(10);
                        int secondDigit = rnd.Next(10);
                        int thirdDigit = rnd.Next(10);
                        Console.WriteLine(firstDigit + " " + secondDigit + " " + thirdDigit);
                        if (firstDigit == secondDigit && secondDigit == thirdDigit)
                        {
                            credits += 50 * stake;
                        }
                        else if (firstDigit == secondDigit || firstDigit == thirdDigit || secondDigit == thirdDigit)
                        {
                            credits += 10 * stake;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not enough credits!");
                    }
                    Console.ReadKey();
                }
            }
            while (pressed != ConsoleKey.Escape && 0 < credits);

            #endregion

            #region 12. feladat

            /*
             * Egészítsük ki az előző félkarú rabló játékot ASCII art grafikai elemekkel: a számok helyett karakterekből
             * kialakított színes figurák (pl. pikk, kőr, treff, káró) jelenjenek meg pörgetéskor.
             */

            #endregion

            #region 13. feladat

            /*
             * Egy új kriptovaluta árfolyamának alakulását szimuláljuk. Jelölje az aktuális árfolyamot P (valós szám). A
             * kriptovaluta árfolyamát a következő órában a [feladatsorban szereplő] képlettel modellezzük, ahol r egy adott 
             * paraméter, epszilon pedig egy véletlen valós szám a [-alfa; alfa] intervallumból. Írjuk ki a képernyőre az 
             * árfolyam alakulását különböző r és alfa értékekkel a felhasználó által megadott számú órára.
             */

            const double RATE = 1.1;
            const double EPS = 20.0;
            double price = 50.0;
            Console.Write("Hány órás előrejelzést kérsz:\t");
            int hours = int.Parse(Console.ReadLine());
            for (int t = 1; t <= hours; t++)
            {
                price = RATE * price + EPS * (rnd.NextDouble() - 0.5);
                Console.WriteLine("Az árfolyam {0} időpontban: {1}", t, price);
            }

            #endregion

            Console.ReadKey();
        }
    }
}