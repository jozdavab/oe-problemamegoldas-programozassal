namespace LAB03_20240926_Teachers
{
    /*
     * Alapvető műveletek tömbökkel (változó deklaráció, tömb elkészítése, feltöltése értékekkel,
     * értékek lekérdezése és módosítása). Listák használata. Tömb és lista bejárása a foreach
     * ciklussal. Hibakereső mód lehetőségei, töréspontok használata, változók értékének követése
     * lépésenként.
     */
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Tömb-gyakorlás

            int variable = 10;
            int[] exampleArray = new int[10];               //10 méretű intekből álló tömb. Minden helyen az int alapértéke (0) van benne.
            exampleArray[0] = variable;                     //0 val indexeljük az első elemet. Értékül adjuk az első elemnek a variable változó által tárolt 10 es értéket.

            Console.WriteLine(exampleArray);                //Így NEM tudjuk kiíratni a tömb elemeit

            //For ciklus. Tömb bejáráshoz ideális
            for (int i = 0; i < exampleArray.Length; i++)   //I ciklusváltozó 0 ról indul, tömbhosszig megy el, egyesével lép.
            {
                exampleArray[i] = i;                        //Tömb i. elemének feltöltése, i értékkel.
                Console.Write(exampleArray[i] + " ");
            }

            int[] reversedExampleArray = new int[exampleArray.Length];
            int nexPlace = 0;

            Console.WriteLine("\nTömb bejárás fordított irányban:");
            for (int i = exampleArray.Length - 1; i >= 0; i--)
            {
                Console.Write(exampleArray[i] + " ");
                reversedExampleArray[nexPlace++] = exampleArray[i]; // reversed tömb feltöltése az előző tömb elemeivel.
            }

            string[] exampleStringArray = { "A", "B", "stb.." };    // Tömb inicializálható alapértékekkel is.
            bool[] exampleBoolArray;                                // Nem szükséges a tömböt deklaráláskor inicializálni is.
            if (true)                                               // Dinamikusan, feltétel alapján eldönthetem a tömböm méretét.
            {
                exampleBoolArray = new bool[2];
            }
            else
            {
                exampleBoolArray = new bool[3];
            }

            int[,] exampleMatrix = new int[2, 3];                   // 2 dimenziós mátrix létrehozása 
            int exampleMatrixLength = exampleMatrix.Length;         // A mátrix 2x3 méretű tehát elemszáma 6 lesz.

            // Egymásba ágyazott számlálós ciklusok szükségesek a bejárásához.
            Console.WriteLine("\nMátrix kiíratása:");
            for (int i = 0; i < exampleMatrix.GetLength(0); i++)    // Az elemszám helyett a sor és az oszlop hosszát kell lekérdeznünk. GetLength(0) -> 2
            {
                for (int j = 0; j < exampleMatrix.GetLength(1); j++)// GetLength(1) -> 3
                {
                    Console.Write(exampleMatrix[i, j] + " ");
                }
                Console.WriteLine();                                //Sortörés a sorok után
            }

            #endregion

            #region Lista-gyakorlás

            List<int> exampleList = new List<int>();        // Lista deklaráció és inicializáció. Vegyük észre, hogy az elemszámot nem kellett kikötnünk.
            List<int> otherList = [1, 2, 3, 4];             // Lista is inicializálható kezdőértékek megadásával.

            // Lista bejárása for ciklussal.
            Console.WriteLine("\nLista kiíratása for ciklussal:");
            for (int i = 0; i < otherList.Count; i++)      // A listának lengthje nincs, de countja van (aktuális elemszám).
            {
                Console.Write(otherList[i]);               // Tömbhöz hasonló módon indexelhető a lista, ha szükséges.
            }

            // Lista bejárása foreach segítségével. A lista nem módosítható bejárás közben!
            Console.WriteLine("\nLista kiíratása foreach segítségével:");
            foreach (int item in otherList) // "item" egy alias, ami az aktuális elemre mutat. Bármilyen tetszőleges nevet adhatunk a változónak
            {
                Console.Write(item);
            }
            Console.WriteLine();

            exampleList.Add(0);                 // Elem szúrása a lista végére.
            exampleList.AddRange(otherList);    // Gyűjtemény szúrása a lista végére.
            exampleList.Remove(0);              // Elem kivétele érték alapján.
            exampleList.RemoveAt(0);            // Elem kivétele index alapján.

            #endregion

            #region 1.feladat

            /*
             * Készítsünk programot, amely ciklusok használatával felsorolja a francia kártya lapjait egy tömbbe . A
             * lehetséges színek: Kőr, Káró, Treff és Pikk. A lapoknak 13 féle magassága lehet: számok 2-től 10-ig, majd
             * Jumbó, Dáma, Király és Ász.
             */

            string[] suits = { "Kör", "Káró", "Treff", "Pikk" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász" };
            string[] deck = new string[52];
            int deckIdx = 0;
            for (int s = 0; s < suits.Length; s++)
            {
                for (int r = 0; r < ranks.Length; r++)
                {
                    deck[deckIdx++] = ranks[r] + " of " + suits[s];
                }
            }

            #endregion

            #region 2.feladat

            /*
             * Keverjük meg a korábban készített kártyapaklit a Fisher–Yates keveréssel. A módszer lényege, hogy a tömb
             * elemein végighaladva mindegyikhez kiválaszt egy véletlen helyen lévő elemet a korábban még nem vizsgáltak közül,
             * amelyeket utána megcserél. Az algoritmus pszeudokóddal az alábbi formában adható meg(1 - alapú indexelést
             * használva).            
             */

            Random rnd = new Random();
            for (int i = 0; i < deck.Length - 1; i++)
            {
                int j = rnd.Next(i, deck.Length);
                string temp = deck[i];              // A cseréhez segédváltozó használata szükséges.
                deck[i] = deck[j];
                deck[j] = temp;
            }

            #endregion

            #region 3.feladat

            /*
             * Kérjünk el a felhasználótól előre megadott darabszámú szót, amelyeket tároljunk el egy
             * tömbben. Ezután kérjünk el a felhasználótól egy további szót, és válaszoljuk meg az alábbiakat.
             *      • Benne van-e a gyűjteményben a megadott szó?
             *      • Ha benne van, hol található először?
             */

            Console.Write("Add meg hány szót fogsz megadni:\t");
            int wordCount = int.Parse(Console.ReadLine());
            string[] words = new string[wordCount];
            for (int i = 0; i < wordCount; i++)
            {
                Console.Write($"Adj meg egy szót a(z) {i + 1}/{wordCount}. helyre:\t");
                words[i] = Console.ReadLine();
            }

            Console.Write("Bekérés vége. Adj meg egy újabb szót:\t");
            string targetWord = Console.ReadLine();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == targetWord)
                {
                    Console.WriteLine($"Benne van a gyűjteményben a(z) {targetWord} szó, a(z) {i}. helyen.");
                    break;
                }
                if (i == words.Length - 1)
                {
                    Console.WriteLine($"A szó '{targetWord}' nem található a korábban megadott szavak közt.");
                }
            }

            #endregion

            #region 4.feladat

            /*
             * Módosítsuk az előző feladat megoldását úgy, hogy a felhasználótól bekért szavakat egy listában tároljuk el,
             * és a bekérést a STOP kulcsszó megadásakor fejezzük be. Ha szükséges, módosítsuk a két előbbi lekérdezést is.
             * Milyen hasonlóságokat és különbségeket tapasztalunk a tömbök és listák használatában?
             */

            List<string> wordList = new List<string>();

            while (true)
            {
                Console.Write($"(Leállítás: STOP) Adj meg egy szót a(z) {wordList.Count + 1}. helyre:\t");
                string givenWord = Console.ReadLine();
                if (givenWord.ToUpper() == "STOP")
                {
                    break;
                }
                wordList.Add(givenWord);
            }

            //// E tanterves megoldás (break nélkül):
            //string newWord;
            //do
            //{
            //    Console.Write($"(Leállítás: STOP) Adj meg egy szót a(z) {wordList.Count + 1}. helyre:\t");
            //    newWord = Console.ReadLine();
            //    if (newWord.ToUpper() != "STOP") {
            //        wordList.Add(newWord);
            //    }    
            //} while (newWord.ToUpper() != "STOP");

            Console.Write("Bekérés vége. Adj meg egy újabb szót:\t");
            targetWord = Console.ReadLine();

            for (int i = 0; i < wordList.Count; i++)
            {
                if (wordList[i] == targetWord) // Tömbhöz hasonló módon indexelhetünk, de a háttérben más a bejárás!
                {
                    Console.WriteLine($"Benne van a gyűjteményben a(z) {targetWord} szó, a(z) {i}. helyen.");
                    break;
                }
                if (i == wordList.Count - 1)
                {
                    Console.WriteLine($"A szó '{targetWord}' nem található a korábban megadott szavak közt.");
                }
            }

            #endregion

            #region 5.feladat

            /*
             * Felmérést végzünk barátaink programozói ismereteiről. Kérjük el az adott személy nevét (string), életkorát
             * (int) és hogy rendelkezik-e programozói tapasztalattal (bool). A neveket, életkorokat és tapasztalatokat tároljuk
             * három külön listában, amelyeket az kapcsol össze, hogy egy adott indexen egy konkrét személy adatait találjuk.
             * A bekérést egy üres név megadásáig folytassuk. Ezt követően határozzuk meg az alábbiakat.
             *      • Mi az átlagéletkor a teljes adathalmazban? (Használjuk a foreach utasítást a bejáráshoz.)
             *      • Mi az átlagéletkor a programozói tapasztalat nélküli személyek között?
             *      • Hány éves a legidősebb, programozó tapasztalattal rendelkező személy és mi a neve?
             */

            List<string> names = new List<string>();
            List<int> ages = new List<int>();
            List<bool> progExperiences = new List<bool>();

            string name;
            int age;
            bool progExp;
            do
            {
                Console.Write("Név:\t");
                name = Console.ReadLine();
                if (name != "")
                {
                    Console.Write("Életkor:\t");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("Programozói tapasztalat (true/false):\t");
                    progExp = bool.Parse(Console.ReadLine());

                    names.Add(name);
                    ages.Add(age);
                    progExperiences.Add(progExp);
                }
            } while (name != "");

            double meanAge = 0.0;
            foreach (int currAge in ages)
            {
                meanAge += currAge;
            }
            meanAge = meanAge / ages.Count;
            Console.WriteLine("Átlagéletkor a teljes adathalmazban:\t" + meanAge);

            double meanAgeNoProg = 0.0;
            int counterNoProg = 0;
            for (int i = 0; i < progExperiences.Count; i++)
            {
                if (progExperiences[i] == false) // !progExperiences[i] rövidebb szintaxissal.
                {
                    meanAgeNoProg += ages[i];
                    counterNoProg++;
                }
            }
            meanAgeNoProg = meanAgeNoProg / counterNoProg;
            Console.WriteLine("Átlagéletkor a programozói tapasztalat nélküli személyek között:\t" + meanAgeNoProg);

            int maxAge = int.MinValue;
            int maxIdx = -1;
            for (int i = 0; i < ages.Count; i++)
            {
                if (progExperiences[i] == true && maxAge < ages[i]) // == true elhhagyható rövidebb szintaxissal.
                {
                    maxAge = ages[i];
                    maxIdx = i;
                }
            }
            if (maxIdx != -1)
            {
                Console.WriteLine("Hány éves a legidősebb, programozó tapasztalattal rendelkező személy:\t" + maxAge);
                Console.WriteLine("Mi a neve:\t" + names[maxIdx]);
            }
            else
            {
                Console.WriteLine("Nincs programozó tapasztalattal rendelkező személy.");
            }

            #endregion

            #region 6.feladat

            /*
             * Hozzunk létre egy N x M-es kétdimenziós tömböt (1 < N;M < 10), amit töltsünk fel véletlenszerűen
             * 0 és 9 közötti értékekkel. Jelenítsük meg a képernyőn ennek a mátrixnak az elemeit. Állítsuk elő a mátrix
             * transzponáltját, vagyis tükrözzük azt a főátlójára.
             */

            int N = 8;
            int M = 3;
            int[,] matrix = new int[N, M];

            for (int i = 0; i < N; i++)     // N helyett matrix.GetLength(0)
            {
                for (int j = 0; j < M; j++) // M helyett matrix.GetLength(1)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }

            int[,] transposed = new int[M, N];  // M and N felcserélésre került.
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    transposed[j, i] = matrix[i, j];    // i és j felcserélésre került
                }
            }

            Console.WriteLine("Az eredeti matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("A transzponált matrix:");
            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    Console.Write(transposed[i, j] + "\t");
                }
                Console.WriteLine();
            }

            #endregion

            #region 7.feladat

            /*
             * Egy horgászverseny fogási adatait egy F táblázatban (kétdimenziós tömbben) tároljuk. F(i; j) azt jelenti,
             * hogy az i-edik horgász a j-edik halfajtából hány darabot fogott.
             *      • Generáljuk le véletlenszerűen a táblázat adatait.
             *      • Jelenítsük meg formázottan a fogási adatokat a képernyőn.
             *      • Adjuk meg, hogy a horgászok mennyit fogtak az egyes halfajtákból.
             *      • Melyik horgász fogta a legtöbb halat összesen?
             *      • Volt-e olyan horgász, aki egyetlen halat sem fogott?
             */

            Console.Write("Sorok száma:\t");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Oszlopok száma:\t");
            int column = int.Parse(Console.ReadLine());
            int[,] F = new int[row, column];

            // Generáljuk le véletlenszerűen a táblázat adatait.
            for (int i = 0; i < F.GetLength(0); i++)
            {
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    F[i, j] = rnd.Next(0, 101);
                }
            }

            // Jelenítsük meg formázottan a fogási adatokat a képernyőn.
            Console.WriteLine("A fogási adatok:");
            for (int i = 0; i < F.GetLength(0); i++)
            {
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    Console.Write(F[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Adjuk meg, hogy a horgászok mennyit fogtak az egyes halfajtákból.
            int[] NumberOfCatchesByFish = new int[F.GetLength(1)];
            for (int i = 0; i < F.GetLength(0); i++)
            {
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    NumberOfCatchesByFish[j] += F[i, j];
                }
            }

            int maxFishesCount = 0;
            int bestFisherManIdx = -1;
            for (int i = 0; i < F.GetLength(0); i++)
            {
                int currFishesCount = 0;
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    currFishesCount += F[i, j];
                }
                if (currFishesCount > maxFishesCount)
                {
                    maxFishesCount = currFishesCount;
                    bestFisherManIdx = i;
                }
            }
            Console.WriteLine($"Az {bestFisherManIdx}. horgász fogta a legtöbb halat összesen.");

            bool noCatchFisherman = false;
            for (int i = 0; i < F.GetLength(0); i++)
            {
                for (int j = 0; j < F.GetLength(1); j++)
                {
                    if (F[i, j] != 0)
                    {
                        break;
                    }
                    if (j == F.GetLength(1))
                    {
                        noCatchFisherman = true;
                    }
                }
                if (noCatchFisherman)
                {
                    break;
                }
            }
            Console.WriteLine("Volt - e olyan horgász, aki egyetlen halat sem fogott:\t" + noCatchFisherman);

            #endregion

            #region 8.feladat

            /*
             * Kérjünk el a felhasználótól egy N pozitív egész értéket, és adjuk hozzá egy listához első elemként. Vegyük
             * a lista utoljára hozzáadott elemét, legyen ez K. Ha K páros, adjuk hozzá a listához K felét, ha páratlan, akkor
             * 3K + 1-et. Addig ismételjük az előbbieket, amíg 1-et nem kapunk eredményül.
             * Kövessük nyomon a kiszámított érték és a lista állapotának változását hibakereső (debug) módban. Próbáljuk
             * meg hibakeresés közben módosítani az aktuálisan kiszámított értéket.
             */

            Console.Write("Adj meg egy pozitív egész számot:\t");
            int lastValue = int.Parse(Console.ReadLine());
            List<int> collatz = new List<int>();
            collatz.Add(lastValue);
            do
            {
                if (lastValue % 2 == 0)
                {
                    lastValue /= 2;
                }
                else
                {
                    lastValue = lastValue * 3 + 1;
                }
                collatz.Add(lastValue);
            } while (lastValue != 1);

            #endregion

            #region 9.feladat

            /*
             * Az alábbi algoritmussal szeretnénk az x tömb elemeit fordított sorrendben megkapni. Használjuk a hibakereső
             * üzemmódot a hibák felderítésére és javítására.
             */

            /*
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int i = 0; i < x.Length; i++)
            {
                int tmp = x[i];
                x[i] = x[x.Length - i - 1];
                x[x.Length - i] = tmp;
            }
            */

            #endregion

            #region 10.feladat

            /*
             * Töltsünk fel egy egydimenziós tömböt megadott számú véletlen értékkel, majd valósítsuk meg az alábbi
             * műveleteket, majd oldjuk meg a feladatot listával is.
             *      • Válogassuk ki a gyűjtemény minden második elemét egy új gyűjteménybe.
             *      • Fordítsuk meg a gyűjtemény elemeinek sorrendjét.
             *      • Rendezzük a lehető legkisebb négyzetes mátrixba a gyűjtemény elemeit (az esetlegesen üresen maradó
             *        értékek helyére nulla kerüljön).
             */

            Console.Write("Add meg a tömb méretét:\t");
            int arrayCount = int.Parse(Console.ReadLine());
            int[] array = new int[arrayCount];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 11);
            }
            List<int> everySecond = new List<int>();
            for (int i = 1; i < array.Length; i += 2)
            {
                everySecond.Add(array[i]);
            }
            for (int i = 0; i < array.Length; i++)
            {
                int tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }

            int[,] smallestMatrix;
            for (int i = 0; i < array.Length; i++)
            {
                if (i * i > array.Length)
                {
                    smallestMatrix = new int[i, i];
                    int counter = 0;
                    for (int j = 0; j < smallestMatrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < smallestMatrix.GetLength(1); k++)
                        {
                            if (counter < array.Length)
                            {
                                smallestMatrix[j, k] = array[counter++];
                            }
                        }
                    }
                    break;
                }
            }

            #endregion

            #region 11.feladat

            /*
             * Készítsünk algoritmust, amely egy NxM-es mátrix elemeit az óramutató járásának megfelelően K*90 fokkal
             * „elforgatja”, ahol K egész szám. Két példa található a gyakorlati jegyzetben a K = 1 esetre.
             */

            #endregion

            #region 12.feladat

            /*
             * Készítsünk egy egyszerű labirintus játékot. Töltsünk fel egy kétdimenziós tömböt véletlenszerűen true és
             * false értékekkel. Adjunk meg egy kezdő koordinátát (indexet), majd határozzuk meg, hogy onnan eljuthatunk-e
             * bármilyen úton a jobb alsó sarokba mindig csak szomszédos true mezőkre lépve. Egy adott elem szomszédai
             * alatt a tőle balra és jobbra, valamint felette és alatta lévő elemeket értjük. A feltételeknek eleget tevő út nem
             * minden esetben létezik. Ugyanígy előfordulhat, hogy több megfelelő útvonal is található a labirintusban.
             */

            #endregion

            Console.ReadKey();
        }
    }
}