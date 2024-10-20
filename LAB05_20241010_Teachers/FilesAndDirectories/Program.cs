using System.Globalization;

namespace FilesAndDirectories
{
    /*
     * Szövegfájlok feldolgozási lehetőségei (File, StreamReader + StringBuilder).
     * Karakterkódolás, az egyes sorok elkülönítése a beolvasási módtól függően.
     * Adatok fájlba írása (File, StreamWriter). CSV feldolgozás, beolvasás listába
     */

    public class Program
    {
        private static void Main(string[] args)
        {
            #region Fájlok

            string path = "tst.txt";                                                    // Alapértelmezetten a debug könyvtárba íródik.
            string pathRel = "../../../tst.txt";                                        // Projekt gyökérkönyvtára (debug felett 3-al).
            string pathDynamic = Path.Combine(Environment.CurrentDirectory, "tst.txt"); // Gyökérkönyvtár dinamikus elérése.

            StreamWriter streamWriter1 = new StreamWriter(path);                        // Fájlbaírás folyamként.
            streamWriter1.WriteLine("Egy sor a fájlban");                               // Egy sor kiírása tst.txt -be.
            streamWriter1.WriteLine("Egy újabb sor a fájlban");                         // Újabb sor kiírása tst.txt -be.
            streamWriter1.Close();                                                      // A műveletek elvégzése után az erőforrást fel kell szabadítani!

            using (StreamWriter streamWriter2 = new StreamWriter(pathRel))
            {
                streamWriter2.WriteLine("Egy sor a projekt gyökérkönyvtárában");
            }                                                                           // Automatikus erőforrás felszabadítás.

            StreamWriter streamWriter3 = new StreamWriter(pathDynamic, true);           // append flag igaz értéke miatt hozzáfűzés történik.
            streamWriter3.WriteLine("Hozzáfűztem a file-hoz felülírás helyett.");
            streamWriter3.Close();                                                      // A műveletek elvégzése után az erőforrást fel kell szabadítani!

            if (File.Exists(path))                                                      // Fájl létezésvizsgálat.
            {
                File.WriteAllText(path, "Felülírtam az eredeti fájlt");                 // Fájlbaírás egy lépésben.
            }
            else
            {
                File.Move(pathRel, path);                                               // Fájl áthelyezés.
                Console.WriteLine("Áthelyeztem egy fájlt a debug mappába.");
            }

            File.ReadAllLines(path);                                                    // Fájl olvasás egy lépésben.

            StreamReader streamReader1 = new StreamReader(path);                        // Fájl olvasás folyamként.
            while (!streamReader1.EndOfStream)                                          // Amíg nem értünk a folyam végére.
            {
                Console.Write("Beolvastam egy sort:");
                Console.WriteLine(streamReader1.ReadLine());                            // Egy sor beolvasása.
            }
            streamReader1.Close();                                                      // A műveletek elvégzése után az erőforrást fel kell szabadítani!
            #endregion

            #region Mappák

            string dir1 = "C:\\test\\MyFirstFolder";                                    // Escapelni kell a backslash-t, hiszen speciális karakter.
            string dir2 = @"C:\\test\\MySecondFolder";                                  // @-jel kikapcsolja a speciális karakterek értelmezését.

            Directory.CreateDirectory(dir1);                                            // Mappa létrehozása.
            Directory.CreateDirectory(dir2);

            Console.WriteLine("Directories in c:\\test");
            foreach (string dir in Directory.GetDirectories("C:\\test"))                // Mappák beolvasása
            {
                Console.Write(dir + " ");
            }
            Console.WriteLine();

            string path2 = @"C:\test";
            if (Directory.Exists(path2))                                                // Mappa létezésvizsgálat.
            {
                Directory.Delete(path2, true);                                          // Mappa törlés. Rekurzív flag miatt az almappák is törlődnek.
            }
            else
            {
                Directory.Move(pathRel, path2);                                         // Mappa áthelyezés.
            }

            #endregion

            #region 1.feladat

            /*
             * Írjunk programot, amely feldolgozza és megfelelő színekkel megjeleníti egy szöveges fájl tartalmát. A fájl
             * sorai az alábbi példához hasonló formátumúak, ahol az adott sor színe a # jel előtt, a sor szövege a jel után található.
             */

            string[] fileContent = File.ReadAllLines("../../../coloredText.txt");
            foreach (string readAllLine in fileContent)
            {
                string[] lineData = readAllLine.Split('#');
                Console.ForegroundColor = Enum.Parse<ConsoleColor>(lineData[0]);        // Enum parseolása szövegből és konzol betűszín állítás.
                Console.WriteLine(lineData[1]);
            }
            Console.ForegroundColor = ConsoleColor.White;                               // Konzolszínt alapértelmezettre visszaállítása.

            #endregion

            #region 2.feladat

            /*
             * Készítsünk lottóhúzást szimuláló és naplózó alkalmazást. Egy lottóhúzás során 90 számból pontosan ötöt
             * húznak ki véletlenszerűen (ismétlések nélkül). Készítsük el az adott heti húzást szimuláló algoritmust, majd
             * mentsük a nyerőszámokat a mai dátummal együtt egy szöveges fájlba, illetve jelenítsük meg a képernyőn is.
             * Kérdezzük meg a felhasználótól, szeretne-e egy újabb heti húzást szimulálni, és pozitív válasz esetén ismételjük meg a
             * fentieket, de a dátum egy héttel későbbi időpontot mutasson. A szimuláció a felhasználó negatív válaszakor érjen véget.
             */

            Random random = new Random();
            DateTime gameDate = DateTime.Now;                                           // Mai dátum és idő lekérdezése.
            bool shouldDrawAgain;
            do
            {
                List<int> winningNumbers = new List<int>();
                while (winningNumbers.Count < 5)
                {
                    int rndNum = random.Next(1, 91);
                    if (!winningNumbers.Contains(rndNum))
                    {
                        winningNumbers.Add(rndNum);
                    }
                }

                string output = gameDate.ToString("yyyy-MM-dd") + " nyerőszámai:";      // Nap-óra-perc nem releváns, ezért kiírásnál mellőzzük.
                foreach (int num in winningNumbers)
                {
                    output += " " + num;
                }
                Console.WriteLine(output);
                File.AppendAllText("../../../lottery.txt", output + "\n");

                Console.Write("Újabb heti húzás szimulálása (true/false): ");
                shouldDrawAgain = bool.Parse(Console.ReadLine());
                if (shouldDrawAgain)
                {
                    gameDate = gameDate.AddDays(7);                                     // Dátum módosítása egy héttel.
                }
            }
            while (shouldDrawAgain);

            #endregion

            #region 3.feladat

            /*
             * Készítsünk alkalmazást egy virtuális hangya útvonalának nyomon követésére. Egy szöveges fájl első sorában
             * a hangya kezdeti pozíciója (x és y), valamint iránya (0°, 90°, 180° vagy 360°) található szóközökkel elválasztva.
             * Az ezt követő sorokban a go, left vagy right utasítások valamelyikét követően egy egész számot találunk. A go k
             * utasítás a hangyát k lépéssel helyezi át a jelenlegi irányától függően egy új koordinátára, a left d és right d
             * utasítások pedig a hangya aktuális irányát módosítják d fokkal, az óramutató járásával egyező vagy fordított irányba.
             */

            #endregion

            #region 4.feladat

            /*
             * Készítsünk elemző programot az NHANES (National Health and Nutrition Examination Survey) adatbázisból
             * származó adatok feldolgozására, és különböző lekérdezések elkészítésére. Használjuk az NHANES_1999-2018.csv
             * fájlt, amely az 1999-től 2018-ig tartó időszakban végzett felmérések adatait tartalmazza vesszővel tagolt táblázatos
             * formában. A tábla attribútumai:
             *      • SEQN: az alany egyedi azonosítója (egész)
             *      • SURVEY: a felmérés időszaka (szöveg)
             *      • RIAGENDR: az alany neme (szám, 1=férfi, 2=nő)
             *      • RIDAGEYR: az alany életkora években (szám)
             *      • BMXBMI: az alany testtömegindexe (szám)
             *      • LBDGLUSI: az alany vércukorszintje (szám)
             * Töltsük be az adatokat egy-egy tömbbe, egy adott alany értékei minden tömbben ugyanarra az indexre kerüljenek.
             * Válaszoljuk meg az alábbi kérdéseket:
             *      1. Egy adott felmérésben mennyi volt a nők és a férfiak átlagos testtömegindexe?
             *      2. Egy adott felmérésben az alanyok hány százalékának volt 5.6-nál magasabb a vércukorszintje?
             *      3. Egy maximális BMI-vel rendelkező alanynak mennyi a vércukorszintje?
             *      4. A teljes adathalmazban mi a túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora?
             */

            StreamReader sr = new StreamReader("../../../NHANES_1999-2018.csv");
            int length = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                length++;
            }
            sr.Close();

            int[] SEQN = new int[length];
            string[] SURVEY = new string[length];
            int[] RIAGENDR = new int[length];
            int[] RIDAGEYR = new int[length];
            double[] BMXBMI = new double[length];
            double[] LBDGLUSI = new double[length];

            sr = new StreamReader("../../../NHANES_1999-2018.csv");
            sr.ReadLine();                                                              // Fejlécadatokat tartalmazó sor mellőzése.
            int idx = 0;
            while (!sr.EndOfStream)
            {
                string[] lineData = sr.ReadLine().Split(',');
                SEQN[idx] = int.Parse(lineData[0]);
                SURVEY[idx] = lineData[1];
                RIAGENDR[idx] = lineData[2][0] - '0';
                RIDAGEYR[idx] = int.Parse(lineData[3].Split('.')[0]);
                BMXBMI[idx] = double.Parse(lineData[4], CultureInfo.InvariantCulture);
                LBDGLUSI[idx] = double.Parse(lineData[5], CultureInfo.InvariantCulture);
                idx++;
            }
            sr.Close();

            double bmiMaleSum = 0, bmiFemaleSum = 0, obeseSum = 0;
            int bmiMaleCnt = 0, highSugarCnt = 0, obeseCnt = 0;
            int maxi = 0;
            for (int i = 0; i < RIAGENDR.Length; ++i)
            {
                if (RIAGENDR[i] == 1)
                {
                    bmiMaleSum += BMXBMI[i];
                    bmiMaleCnt++;
                }
                else
                {
                    bmiFemaleSum += BMXBMI[i];
                }

                if (LBDGLUSI[i] > 5.6)
                {
                    highSugarCnt++;
                }

                if (BMXBMI[i] > BMXBMI[maxi])
                {
                    maxi = i;
                }

                if (BMXBMI[i] >= 30.0)
                {
                    obeseCnt++;
                    obeseSum += RIDAGEYR[i];
                }
            }
            Console.WriteLine("\n1. Egy adott felmérésben mennyi volt a nők és a férfiak átlagos testtömegindexe?");
            double avgMale = Math.Round(bmiMaleSum / bmiMaleCnt, 1);
            double avgFemale = Math.Round(bmiFemaleSum / (BMXBMI.Length - bmiMaleCnt), 1);
            Console.WriteLine($"A férfi átlag BMI {avgMale}, a női átlag BMI {avgFemale}.");

            Console.WriteLine("\n2. Egy adott felmérésben az alanyok hány százalékának volt 5.6-nál magasabb a vércukorszintje?");
            double percentage = Math.Round(100.0 * highSugarCnt / LBDGLUSI.Length, 1);
            Console.WriteLine($"Az alanyok {percentage}%-a rendelkezik 5.6-nál magasabb vércukorszinttel.");

            Console.WriteLine("\n3. Egy maximális BMI-vel rendelkező alanynak mennyi a vércukorszintje?");
            Console.WriteLine($"A(z) {maxi + 1}. ember rendelkezik maximális BMI-vel ({BMXBMI[maxi]}), vércukorszintje:{LBDGLUSI[maxi]}");

            Console.WriteLine("\n4. A teljes adathalmazban mi a túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora?");
            Console.WriteLine($"A túlsúlyos személyek átlagos életkora {Math.Round(obeseSum / obeseCnt, 2)}");

            #endregion

            Console.ReadKey();
        }
    }
}