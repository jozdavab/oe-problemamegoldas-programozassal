using System.Text;

namespace LAB04_20241003_Teachers
{
    /*
     * Speciális és vezérlő karakterek szerepe. Fontosabb karakterlánc-műveletek (IndexOf, Replace, Split, Substring, Trim),
     * formázott karakterláncok és karakterlánc-interpoláció alkalmazása. Formázott szöveges adatok feldolgozása.   
     */
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Stringek

            string str1 = "It's";
            string str2 = "Wednesday";
            string str3 = "my dudes";
            string str4 = str1 + " " + str2 + " " + str3;

            //Olvasásnál tömbként indexelhetőek a string változók karakterei
            Console.WriteLine(str1[2]);

            //String szétválasztása rész stringekké, ' ' jel alapján
            string[] splitted = str4.Split(' ');
            Console.WriteLine(splitted[2]); // Kettes indexű rész string kiíratása

            //Karakter beolvasása a konzolról
            char example = Console.ReadKey().KeyChar;
            //Beépített segédfüggvény szám és karakter különböztetéséhez.
            Console.WriteLine("Is letter or digit: " + char.IsLetterOrDigit(example));

            //Részsorozat keresése - IndexOf
            int row;
            string exampleString = "These are different characters in a string";
            row = exampleString.IndexOf("characters");
            Console.WriteLine(row);
            row = exampleString.IndexOf("in");
            Console.WriteLine(row);
            row = exampleString.IndexOf("ez nincs benne");
            Console.WriteLine(row);

            //String rész stringjének kinyerése.
            string ss1, ss2;
            ss1 = "Hello, World";
            ss2 = ss1.Substring(7, 5); // Kezdő index: 0
            Console.WriteLine(ss2);

            //String részeinek kicserélése.
            ss1 = ss1.Replace(ss2, "user!"); //ss1 ben felülírjuk ss2 által mutatott szöveg részt, "user!" el
            Console.WriteLine(ss1);

            #endregion

            #region StringBuilder

            string simpleString = "";
            for (int i = 0; i < 2; i++)
            {
                simpleString += ":) ";  // String immutable tulajdonság miatt, mindig új string kreálódik.
            }
            Console.WriteLine(simpleString);

            // optimális String összefűzéshez StringBuildert használnunk.
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                stringBuilder.Append(":) ");
            }
            Console.WriteLine(stringBuilder.ToString());

            #endregion

            #region 1.feladat

            /*
             * Írjunk programot, amely meghatározza egy szövegben a betűk, a számjegyek és a magánhangzók számát kategóriánként.
             */

            Console.Write("Adj meg egy szöveget melyben megszámolom a betűket/számokat/magánhangzókat:\t");
            string targetWord = Console.ReadLine();

            int letterCnt = 0, digitCnt = 0, vovelCnt = 0;
            char[] vovels = { 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < targetWord.Length; i++)
            {
                if (char.IsLetter(targetWord[i]))
                {
                    letterCnt++;
                    for (int j = 0; j < vovels.Length; j++)
                    {
                        if (vovels[j] == char.ToLower(targetWord[i]))
                        {
                            vovelCnt++;
                            break;
                        }
                    }
                }
                else if (char.IsDigit(targetWord[i]))
                {
                    digitCnt++;
                }
            }

            Console.WriteLine($"\nLetters:{letterCnt}, digits:{digitCnt}, vovels:{vovelCnt}");

            #endregion

            #region 2.feladat

            /*
             * Írjunk programot, amely meghatározza, hogy egy szöveg palindrom szöveg - e, vagyis hogy előre olvasva ugyanazt adja-e, mint visszafelé.
             */

            Console.Write("Adj meg egy szót amelyről eldöntöm, hogy palindrom-e:\t");
            string inputWord = Console.ReadLine();

            string palindrom = inputWord.ToLower().Replace(" ", ""); // Segédváltozó, hogy a kis-nagy betű eltérések és a szóközök ne zavarjanak be a vizsgálatba.
            int k = 0;
            while (k < palindrom.Length / 2 && palindrom[k] == palindrom[palindrom.Length - 1 - k])
            {
                k++;
            }
            if (k < palindrom.Length / 2)
            {
                Console.WriteLine($"{inputWord} nem palindrom!");
            }
            else
            {
                Console.WriteLine($"{inputWord} palindrom!");
            }

            #endregion

            #region 3.feladat

            /*
             * Írjunk programot, amely sztenderd formátumra hozza egy jármű rendszámát. A jelenlegi sztenderd formátum
             * kétszer két nagybetű, közöttük egy szóköz, majd egy kötőjel és három szám.
             */

            Console.Write("Adj meg egy formázatlan rendszámot:\t");
            string plateNum = Console.ReadLine();
            string finalPlate = "";

            k = 0;
            while (k < plateNum.Length && finalPlate.Length != 9)
            {
                if ((char.IsLetter(plateNum[k]) && finalPlate.Length < 6) || (char.IsDigit(plateNum[k]) && finalPlate.Length > 5))
                {
                    finalPlate += char.ToUpper(plateNum[k]);
                }
                if (finalPlate.Length == 2)
                {
                    finalPlate += " ";
                }
                else if (finalPlate.Length == 5)
                {
                    finalPlate += "-";
                }
                k++;
            }
            if (finalPlate.Length == 9)
            {
                Console.WriteLine($"Siker, {plateNum} formázás után sztenderd {finalPlate} alakba került!");
            }
            else
            {
                Console.WriteLine($"{plateNum} nem hozható sztenderd formátumra.");
            }

            #endregion

            #region 4.feladat

            /*
             * Írjunk programot, amely képes adott számú, különböző, az előző feladatban megadott formátumú véletlen rendszámot generálni.
             */

            Random rnd = new Random();

            Console.Write("Hány rendszámot akarsz generálni:\t");
            int platesCnt = int.Parse(Console.ReadLine());
            string[] plates = new string[platesCnt];
            Console.WriteLine("A generált rendszámok:");
            for (int i = 0; i < plates.Length; i++)
            {
                plates[i] =
                    "" +
                    (char)rnd.Next(65, 91) +
                    (char)rnd.Next(65, 91) +
                    " " +
                    (char)rnd.Next(65, 91) +
                    (char)rnd.Next(65, 91) +
                    "-" +
                    rnd.Next(0, 10) +
                    rnd.Next(0, 10) +
                    rnd.Next(0, 10);

                //(char)rnd.Next(65, 91) helyett írhatnánk (char)rnd.Next('A', 'Z' + 1) et is.
                Console.WriteLine(plates[i] + ",");
            }

            #endregion

            #region 5.feladat

            /*
             * Írjunk programot, amely helyesség szempontjából ellenőrzi a felhasználó által megadott email címet.Az
             * email cím helyes, ha az alábbiak mindegyike teljesül.
             *      a) pontosan egy @ karaktert tartalmaz
             *      b) tartalmaz legalább egy betű karaktert a @ előtt
             *      c) tartalmaz legalább egy.karaktert a @ után
             *      d) a @ és az utolsó.karakter között kell legyen legalább egy betű vagy szám karakter
             *      e) ha tartalmaz . karaktert a @ előtt is, akkor a . előtt és után is betű vagy szám karakter kell álljon
             *      f) az utolsó . karakter után legalább két betűt kell tartalmazzon
             */

            Console.Write("Add meg az e-mail címed:\t");
            string email = Console.ReadLine();

            string[] parts = email.Split('@');
            if (parts.Length == 2)
            {
                k = 0;
                while (k < parts[0].Length && !char.IsLetter(parts[0][k]))
                {
                    k++;
                }
                if (k < parts[0].Length)
                {
                    if (parts[1].Contains('.'))
                    {
                        int lastDotPlace = parts[1].LastIndexOf('.');
                        k = 0;
                        while (k < lastDotPlace & !char.IsLetterOrDigit(parts[1][k]))
                        {
                            k++;
                        }
                        if (k < lastDotPlace)
                        {
                            k = lastDotPlace;
                            int counter = 0;
                            while (k < parts[1].Length && counter < 2)
                            {
                                if (char.IsLetterOrDigit(parts[1][k]))
                                {
                                    counter++;
                                }
                                k++;
                            }
                            if (counter > 1)
                            {
                                bool valid = true;
                                if (parts[0].Contains("."))
                                {
                                    for (int i = 1; i < parts[0].Length; i++)
                                    {
                                        if (parts[0][i] == '.')
                                        {
                                            if (i == 0 || i == parts[0].Length - 1 || !char.IsLetterOrDigit(parts[0][i - 1]) || !char.IsLetterOrDigit(parts[0][i + 1]))
                                            {
                                                valid = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (valid)
                                {
                                    Console.WriteLine("Az email érvényes.");
                                }
                                else
                                {
                                    Console.WriteLine("Az email érvénytelen, mivel a @ előtti részben lévő . előtt és után nem betű vagy szám karakter kell áll");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Az email érvénytelen, mivel nem tartalmaz az utolsó . karakter után legalább két betűt");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Az email érvénytelen, mivel nincs a @ és az utolsó . karakter között legalább egy betű vagy szám karakter");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Az email érvénytelen, mivel nem tartalmaz legalább egy . karaktert a @ után");
                    }
                }
                else
                {
                    Console.WriteLine("Az email érvénytelen, mivel nem tartalmaz legalább egy betű karaktert a @ előtt");
                }
            }
            else
            {
                Console.WriteLine("Az email érvénytelen, mivel nem pontosan egy @ karaktert tartalmaz!");
            }

            #endregion

            #region 6.feladat

            /*
             * Készítsünk programot Neptun-kódhoz hasonló szöveg generálására. Egy Neptun-kód pontosan hat karakterből
             * áll, véletlenszerű betűkből és számokból, de az első karakter mindig betű. Számoljuk meg, hogy hányadik
             * véletlenszerűen generált Neptun-kód egyezik meg a saját azonosítónkkal.
             */

            string targetNeptun = "JML37D";
            string rndNeptun;
            int cnt = 0;
            do
            {
                cnt++;
                rndNeptun = "" + (char)rnd.Next('A', 'Z' + 1);
                for (int i = 0; i < 5; i++)
                {
                    if (rnd.Next(0, 2) == 0)
                    {
                        rndNeptun += (char)rnd.Next('A', 'Z' + 1);
                    }
                    else
                    {
                        rndNeptun += rnd.Next(0, 10);
                    }
                }
            } while (targetNeptun != rndNeptun);

            Console.WriteLine($"A(z) {cnt}. próbálkozásra legeneráltuk a saját azonosítónkat.");

            #endregion

            #region 7.feladat

            /*
             * Írjunk programot, amely egy adott szöveget SpongeCase formátumúra alakít. Az átalakítás során a szöveg
             * karakterei véletlenszerűen legyenek kis- és nagybetűk
             */

            Console.Write("Adj meg egy tetszőleges szöveget:\t");
            string textInput = Console.ReadLine();
            string spongeCase = "";

            for (int i = 0; i < textInput.Length; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    spongeCase += char.ToLower(textInput[i]);
                }
                else
                {
                    spongeCase += char.ToUpper(textInput[i]);
                }
            }
            Console.WriteLine("Sponge case: " + spongeCase);

            #endregion

            #region 8.feladat

            /*
             * Írjunk programot, amely egyetlen formázott s karakterlánc tartalmát egy táblázatba (kétdimenziós tömbbe)
             * rendezi. Az s karakterláncban az egyes sorokat sortörés ('\n') karakterek, az egyes oszlopokat pontosvesszők
             * (';') választják el.
             */

            Console.Write("Adj meg egy formázott karakterláncot:\t");
            string formattedInput = Console.ReadLine();
            string[] splits = formattedInput.Split("\\n");
            string[,] matrix = new string[splits.Length, splits[0].Split(";").Length]; // Feltételezve az azonos hosszúságú sorokat!
            for (int i = 0; i < splits.Length; i++)
            {
                string[] innerSplit = splits[i].Split(";");
                for (int j = 0; j < innerSplit.Length; j++)
                {
                    matrix[i, j] = innerSplit[j];
                }
            }

            #endregion

            #region 9.feladat

            /*
             * Készítsünk programot, amely egy szöveg formájában adott zárójel-sorozatról eldönti, hogy az szabályos-e.
             * Egy ilyen sorozatot szabályosnak nevezünk, ha benne a zárójelek párosíthatóak úgy, hogy minden párban legyen
             * egy összetartozó kezdő- és egy végzárójel.
             */

            #endregion

            #region 10.feladat

            /*
             * Készítsünk egyszerű szövegszerkesztő programot az alábbiak szerint. A szöveget tároljuk egy kétdimenziós
             * karaktertömbben, amelynek mérete előre megadott (pl. 50 karakter széles és 20 karakter magas). A program
             * frissítse és jelenítse meg a tömb tartalmát minden billentyűlenyomás után. Legyen lehetőség a kurzorbillentyűk
             * segítségével navigálni a szövegben, továbbá szöveg beírására, amely ilyenkor felülírja a korábban ott lévő szöveget.
             */

            #endregion

            #region 11.feladat

            /*
             * Base64 kódolás egy 64 karakteres ábécén (kódtáblán) alapuló kódolási forma, melynek használatával
             * tetszőleges adatot szöveges formátumúvá alakíthatunk. Írjunk programot, amel egy egyszerűsített, tetszőleges
             * (Unicode) karakterekből álló szöveget képes 64 előre megadott karakter segítségével kódolni. A szótár álljon az
             * alábbi karakterekből:
             *      • az angol ábécé nagybetűi (A-Z)
             *      • az angol ábécé kisbetűi (a-z)
             *      • számjegyek (0-9)
             *      • további két speciális karakter: + és /
             * A kódolás során a kódolandó adathalmazt bontsuk fel 3 bájtos egységekre, az így kapott 24 bitet pedig daraboljuk
             * 6 bites szegmensekre. Egy-egy 6 bites szegmens értéke a kódtábla indexeként használható, vagyis minden három
             * kódolatlan karakter négy kódolttá alakul.
             */

            #endregion

            Console.ReadKey();
        }
    }
}