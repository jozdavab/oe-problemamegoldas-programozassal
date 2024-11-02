using System.Globalization;
using System.Text;

namespace LAB01_20240912_Teachers
{
    /*
     * Utasítások és kulcsszavak. Változók használata C#-ban. Típuskonverzió (Parse, ToString),
     * típuskényszerítés. Fontosabb összehasonlító és logikai operátorok. Elágazások használata
     */
    public class Program
    {
        private static void Main(string[] args)
        {
            // region - endregion blokkok miatt áttekinthetőbb a kód. Oldalt a kis +- jelekkel lehet kinyitni és becsukni őket.
            #region Deklarálás | Inicializálás | Műveletek | Egészek

            int num1;                       // Változó deklarálása. Elől a típusa szerepel (int), hátul a neve, amivel hivatkozhatunk rá (num1);
            num1 = 1;                       // Változó inicializálása.
            Console.WriteLine(num1);        // Változó értékének kiírása a konzolra (1). "cw tab tab"

            int num2 = 2;                   // Deklarálás és inicializálás összevonható

            int num3, num4, num5;           // Több változó deklarálása egyszerre
            int num6 = 6, num7 = 7;         // Több változó deklarálása és inicializálása egyszerre

            num3 = num2 + num1;             // Értékadás változónak művelettel.
            Console.WriteLine(num3);        // Változó értékének kiírása a konzolra (3)

            int c = 2014;
            //Inkrementálás 4 különböző módon
            c = c + 1;                      // Változó inkrementálása
            c += 1;                         // Változó inkrementálása
            c++;                            // Változó értékének kiolvasása, majd változó inkrementálása
            ++c;                            // Változó inkrementálása, majd változó értékének kiolvasása
            Console.WriteLine(c);           // Változó értékének kiírása a konzolra (2018)

            //Fontos különbség!
            Console.WriteLine(c++);         // Változó értékének kiírása (2018), majd változó inkrementálása 
            Console.WriteLine(++c);         // Változó inkrementálása, majd változó értékének kiírása (2020)

            Console.WriteLine(c + 1);       // Művelet (kifejezés) eredményének kiírása konzolra (2020 + 1).
            Console.WriteLine(c);           // Mivel előbb az értéket nem tároltuk, C változatlan (2020).

            #endregion

            #region Logikai változók | Logikai műveletek

            bool b1 = true;                 // Logikai típus deklarálása és inicializálása igaz értékkel.
            Console.WriteLine(b1);          // Változó értékének kiírása a konzolra (true);    
            b1 = !b1;                       // Változó negálása, átbillentése.
            Console.WriteLine(b1);          // Változó értékének kiírása a konzolra (false);

            bool result1 = false || true;                       // VAGY logikai művelet. (true)
            Console.WriteLine(result1);
            bool result2 = false && true;                       // ÉS logikai művelet.   (false)
            Console.WriteLine(result2);
            bool result3 = result1 || (!!!!!false && result2);  // Rövidzár kiértékelés!  (true)
            Console.WriteLine(result3);

            #endregion

            #region Szöveg típus | Karakterek | Típuskonverzió | Formázás

            string elso = "Ez a mondat";                // A szöveg típusú érték "" között szerepel.
            string masodik = "véget ér";
            //char c = '!';                             // Fordítási hiba, c már deklarálva van.
            char jel = '!';                             // A karakter típusú érték '' között szerepel.
            string mondat = elso + masodik + jel;       // Karakterláncok összefűzése.
            Console.WriteLine(mondat);
            Console.WriteLine(elso + " " + masodik + jel);

            Console.Write("Add meg a neved:\t");        // Escape karakterek: https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions
            string userInput = Console.ReadLine();      // Szöveget olvas a konzolról Enter lenyomásáig
            Console.WriteLine("Hello " + userInput);

            Console.Write("Add meg a születési dátumod:\t");
            int userInputNum = int.Parse(Console.ReadLine());   // Típus konverzió! Szöveget kértünk be, számként tárolunk
            int age = 2024 - userInputNum;

            //3 alternatív módszer kiíratáshoz
            Console.WriteLine("Szia " + userInput + "! Te " + age + " éves vagy 2024-ben.");
            Console.WriteLine("Szia {0}! Te {1} éves vagy 2024-ben.", userInput, age);
            Console.WriteLine($"Szia {userInput}! Te {age} éves vagy 2024-ben.");

            #endregion

            #region Tizedesek | Típusveszteség | Maradékos osztás | Math

            double d1 = 1.01;
            int i1 = (int)d1;       // Explicit kasztolás. Nagyobb típus a kisebbe. Értékvesztés történhet!
            double d2 = i1;         // Implicit kasztolás. Kisebb típus a nagyobba.
            Console.WriteLine(d1);  // Változó értékének kiírása a konzolra (1.01)
            Console.WriteLine(i1);  // Változó értékének kiírása a konzolra (1)
            Console.WriteLine(d2);  // Változó értékének kiírása a konzolra (1)

            //Fahrenheit Calculator. [°F] = [°C] * 9 / 5 + 32
            Console.Write("Hőfok °C:\t");
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = celsius * 9 / 5 + 32;
            double fahrenheitBad = celsius * (9 / 5) + 32;    // 9/5 nél int/int osztás van, aminek az eredménye is int, ezért más eredményt kapnánk.
            Console.WriteLine($"Hőfok F: {fahrenheit} °F");
            Console.WriteLine($"Hőfok F (rossz): {fahrenheitBad} °F");

            //Modulo and Math
            Console.Write("Adj meg egy számot:\t");
            int number = int.Parse(Console.ReadLine());

            int modNumber = number % 2;                     // Maradékos osztás
            Console.WriteLine($"A számod % 2 = {modNumber}");

            //Négyzetszám eldöntő program
            int sqrt = (int)Math.Sqrt(number);              // Értékvesztés konverzió miatt. Math.sqrt double-t ad vissza, de egésszé lesz kasztolva
            bool isSquareNumber = sqrt * sqrt == number;    // Ha visszakapjuk az eredeti számot, akkor nem történt érték vesztés, ergo négyzetszám volt.
            Console.WriteLine("A szám négyzetszám-e: " + isSquareNumber);   // Stringet és boolt is össze lehet fűzni a + jellel.

            #endregion

            Console.Clear();

            #region 1.feladat

            /*
             * Hozzunk létre egy új parancssoros projektet, majd írjunk programot, amely megjeleníti a Hello, World!
             * szöveget a képernyőn. Az alkalmazás az Enter billentyű leütésekor érjen véget.       
             */

            Console.WriteLine("Hello, world!");

            #endregion

            #region 2.feladat

            /*
             * Bővítsük ki az előbbi programot: helyezzünk el néhányat az alábbi utasításokból a szöveg megjelenítését
             * végző utasítás elé vagy után. Az utasítások a kurzor és a parancssori ablak jellemzőit módosítják.
             *      • Console.Clear()
             *      • Console.WindowHeight
             *      • Console.WindowWidth
             *      • Console.BackgroundColor
             *      • Console.ForegroundColor
             *      • Console.SetCursorPosition()
             *      • Console.CursorVisible
             */

            Console.Clear();
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(5, 10);
            Console.CursorVisible = true;
            Console.WriteLine("Hello, world again!");

            Console.ResetColor();

            #endregion

            #region 3.feladat

            /*
             * Készítsünk programot, amely elkéri a felhasználó nevét, majd név szerint köszönti őt
             */

            Console.Clear();
            Console.Write("Add meg a neved:\t");
            string name = Console.ReadLine();

            Console.WriteLine("Hello " + name + "!");
            Console.WriteLine("Hello {0}!", name);
            Console.WriteLine($"Hello {name}!");

            #endregion

            #region 4.feladat

            /*
             * Készítsünk programot, amely elkéri a felhasználó születési évét, ez alapján pedig kiszámítja és kiírja az
             * életkorát. A program írja ki azt is, hány éves lesz a felhasználó a következő évben.          
             */

            Console.Write("Add meg a születési éved:\t"); // Év adott hónapjától függően az eredmény rossz is lehet, ha csak a születési évet kérjük be...
            int birthYear = int.Parse(Console.ReadLine());
            int calculatedAge = DateTime.Now.Year - birthYear;  //DateTime.Now visszaadja az aktuális pillanatot, aminek lekérdezhető az ÉV adattagja (is).      
            Console.WriteLine($"Ön {calculatedAge} éves, jövőre pedig {calculatedAge + 1} éves!");

            #endregion

            #region 5.feladat

            /*
             * Készítsünk programot, amely elkéri a felhasználó testmagasságát (h, méterben) és testtömegét 
             * (m, kilogrammban), majd kiszámítja és kiírja a felhasználó testtömegindexét (BMI).
             */

            Console.Write("Add meg a magasságod méterben:\t");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Add meg a súlyod kilogramban:\t");
            int weight = int.Parse(Console.ReadLine());

            double BMI = Math.Round(height / Math.Pow(weight, 2), 1);   // Kerekítés és hatványozás a Math osztály segítségével.
            Console.WriteLine($"A BMI-d: {BMI}");

            #endregion

            #region 6.feladat

            /*
             * Kérjünk el a felhasználótól egy másodpercben megadott időtartamot, majd írjuk ki azt perc:másodperc formátumban.
             */

            Console.Write("Az időtartam másodpercben: ");
            int seconds = int.Parse(Console.ReadLine());

            Console.WriteLine($"Az időtartam formázva: {seconds / 60}:{seconds % 60}");

            #endregion

            #region 7.feladat

            /*
             * Kérjük el a felhasználótól a jelszavát, majd kérjük el még egyszer megerősítésképp. Ha egyezik a két megadott
             * jelszó, nyugtázzuk egy zöld színnel kiírt üzenettel, ellenkező esetben jelenítsünk meg egy piros színű hibaüzenetet.
             */

            Console.Write("Add meg a jelszavad: ");
            string pass = Console.ReadLine();
            Console.Write("Add meg újra a jelszavad: ");
            string rePass = Console.ReadLine();

            if (pass == rePass)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sikeres bejelentkezés");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sikertelen bejelentkezés");
            }
            Console.ResetColor();

            #endregion

            #region 8.feladat

            /*
             * Alakítsuk át úgy az előző programot, hogy a jelszó beírásakor a karakterek helyett csak *-ok jelenjenek meg.
             * Legyen lehetőség tévesen bevitt karakter törlésére is a Backspace billentyűvel.
             */

            // A feladatmegoldás későbbi órán tanult elemeket is tartalmaz!
            ConsoleKey key;
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Adj meg egy titkos jelszót!");
            do
            {
                for (int i = 0; i < sb.Length; i++)
                {
                    Console.Write('*');
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
                else if (key != ConsoleKey.Enter)
                {
                    sb.Append(keyInfo.KeyChar);
                }
                Console.Clear();
            } while (key != ConsoleKey.Enter);
            Console.WriteLine("Ezt adtad meg jelszónak: " + sb.ToString());

            #endregion

            #region 9.feladat

            /*
             * Kérjünk el a felhasználótól kettő számot és egy műveleti jelet, majd írjuk ki a képernyőre az adott művelet
             * eredményét a két szám között elvégezve.
             */

            Console.Write("Adj meg egy számot: ");
            double number1 = double.Parse(Console.ReadLine(), NumberStyles.None);   // Tizedesszámok formátuma régiónként eltérő lehet! (. vagy ,)
            Console.Write("Adj meg még egy számot: ");
            double number2 = double.Parse(Console.ReadLine(), NumberStyles.None);
            Console.Write("Adj meg egy operandust: (+ - * / %");
            char op = Console.ReadKey().KeyChar;

            double res = 0;
            switch (op)
            {
                case '+': res = number1 + number2; break;
                case '-': res = number1 - number2; break;
                case '*': res = number1 * number2; break;
                case '/': res = number1 / number2; break;       // Potenciális zéróosztás lehetséges!
                case '%': res = number1 % number2; break;
            }
            Console.WriteLine($"\n\n{number1}{op}{number2}={res}");

            #endregion

            #region 10.feladat

            /*
             * Alakítsuk át úgy az előző programot, hogy az képes legyen helyesen formázott matematikai kifejezések
             * kiértékelésére. Első lépésként valósítsuk meg, hogy a beolvasott szöveg alapján bármely kétoperandusú műveletet
             * (összeadás, kivonás, szorzás, osztás) el tudja végezni a program.
             * A fordított lengyel jelölés (Reverse Polish Notation) használatával valósítsuk meg, hogy bármely helyesen záróje-
             * lezett, a fenti műveleteket tartalmazó kifejezést ki tudjon értékelni a program.
             */

            // A feladatmegoldás későbbi órán tanult elemeket is tartalmaz!
            Console.Write("Adjon meg egy matematikai kifejezést fordított lengyel jelöléssel:");
            string[] tokens = Console.ReadLine().Split(" ");
            Stack<double> stack = new Stack<double>();
            foreach (string token in tokens)
            {
                if (token == "+" || token == "-" || token == "*" || token == "/")
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
                else
                {
                    stack.Push(double.Parse(token));
                }
            }
            Console.WriteLine("Az eredmény: " + stack.Pop());

            #endregion

            #region 11.feladat

            /*
             * Kérjünk egy a felhasználótól egy 0 és 9 közötti értéket, majd írjuk ki a számot szövegesen. Ha a tartományon
             * kívüli értéket ad meg, tájékoztassuk hibaüzenettel.
             */

            int min = 0; int max = 9;
            Console.WriteLine($"Adj megy egy {min}-{max} közötti értéket!");
            int val = int.Parse(Console.ReadLine());
            if (val < 0 || val > 9)
            {
                Console.WriteLine("Hibás érték!");
            }
            else
            {
                switch (val)
                {
                    case 0: Console.WriteLine("nulla"); break;
                    case 1: Console.WriteLine("egy");   break;
                    case 2: Console.WriteLine("kettő"); break;
                    case 3: Console.WriteLine("három"); break;
                    case 4: Console.WriteLine("négy");  break;
                    case 5: Console.WriteLine("öt");    break;
                    case 6: Console.WriteLine("hat");   break;
                    case 7: Console.WriteLine("hét");   break;
                    case 8: Console.WriteLine("nyolc"); break;
                    case 9: Console.WriteLine("kilenc");break;
                }
            }

            #endregion

            #region 12.feladat

            /*
             * Kérjünk egy a felhasználótól egy betűt, majd írjuk ki, hogy magánhangzót vagy mássalhangzót adott-e meg.
             */

            Console.Write("Adj meg egy betűt: ");
            char ch = Console.ReadKey().KeyChar;
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                Console.WriteLine($"{ch} magánhangzó!");
            }
            else
            {
                Console.WriteLine($"{ch} mássalhangzó!");
            }

            #endregion

            #region 13.feladat

            /*
             * Adott egy V térfogatú tartály, amit két csővezetéken keresztül töltünk fel fel. Ismerjük a vezetékekben a
             * térfogatáramot (az egy óra alatt átfolyó térfogatot). A két vezetéket egyszerre nyitjuk meg, majd T óráig folyni
             * hagyjuk. Adjuk meg, hogy az időtartam végén mennyire telt meg a tartály
             */

            Console.Write("V: ");
            double V = double.Parse(Console.ReadLine());
            Console.Write("R1: ");
            double R1 = double.Parse(Console.ReadLine());
            Console.Write("R2: ");
            double R2 = double.Parse(Console.ReadLine());
            Console.Write("T: ");
            double T = double.Parse(Console.ReadLine());

            double load = (R1 + R2) * T;
            if (load <= V)
            {
                Console.WriteLine($"A tartály {Math.Round(load / V * 100)}%-ban lesz tele.");
            }
            else
            {
                Console.WriteLine($"A targyál {load - V} m3-rel lesz túltöltve.");
            }

            #endregion
        }
    }
}