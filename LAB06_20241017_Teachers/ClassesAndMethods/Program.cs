using System.Globalization;
using System.Text;

namespace ClassesAndMethods
{
    public class Program
    {
        private static void Main(string[] args)
        {

            #region Methods

            int a = 3;
            int b = 2;
            int c;

            c = Add(a, b);          // Érték szerinti átadás, a paraméterekről másolat készül
            Console.WriteLine($"a:{a} b: {b} c:{c}");
            c = Add(ref a, ref b);  // Referencia szerinti átadás
            Console.WriteLine($"a:{a} b: {b} c:{c}");

            #endregion

            #region Classes

            // Létrehozok egy Triangle típusú, triangleRandom nevű változót, és a 0 paraméteres konstruktor segítségével példányosítom.
            Triangle triangleRandom = new Triangle();

            // Meghívom a háromszög példányon a showme metódust, és kiírom a visszakapott stringet a konzolra.
            Console.WriteLine(triangleRandom.ShowMe());

            // Létrehozok egy Triangle típusú, triangleUser nevű változót, és a 3 paraméteres konstruktor segítségével beállítom az összes oldalát.
            Triangle triangleUser = new Triangle(3, 4, 4);

            // Meghívom a háromszög példányon a showme metódust, és kiírom a visszakapott stringet a konzolra.
            Console.WriteLine(triangleUser.ShowMe());

            //Létrehozok egy 3 elemű, háromszög típusokat tartalmazó tömböt. Alapértelmezetten null értékeket kapnak a tömb elemei.
            Triangle[] triangles = new Triangle[3];

            //Bejárom a tömböt
            for (int i = 0; i < triangles.Length; i++)
            {
                //Minden egyes elemre példányosítok egy új háromszöget, és beleteszem a tömbbe.
                triangles[i] = new Triangle();

                //Minden egyes elemet kiíratok a konzolra.
                Console.WriteLine(triangles[i].ShowMe());

                //Ez nem lenne túl olvasható
                //Console.WriteLine(triangles[i]);
            }

            //Felülírom a tömböm első elemét a már korábban létrehozott háromszögemmel.
            triangles[0] = triangleUser;

            #endregion

            #region 1.feladat

            Book book = new Book("Az ötös számú vágóhíd", "Kurt Vonnegut", DateTime.Parse("1969.03.31"), 190);
            Console.WriteLine(book.AllData());

            #endregion

            #region 2.feladat

            Rectangle rec1 = new Rectangle(0, 0, ConsoleColor.Black);
            if (rec1.IsValid())
            {
                rec1.Draw(0, 0);
            }
            else
            {
                Console.WriteLine("r1 is invalid!");
            }
            Rectangle rec2 = new Rectangle(3, 4, ConsoleColor.Red);
            if (rec2.IsValid())
            {
                rec2.Draw(5, 5);
            }
            else
            {
                Console.WriteLine("r2 is invalid!");
            }

            #endregion

            #region 3.feladat

            int target = Console.WindowWidth / 2;
            Runner run1 = new Runner("David", 1, 5);
            Runner run2 = new Runner("Bolt", 2, 10);

            while (run1.GetDistance() < target && run2.GetDistance() < target)
            {
                Console.Clear();
                run1.RefreshDistance(1);
                run2.RefreshDistance(1);
                run1.Show();
                run2.Show();
                Thread.Sleep(1000);
            }

            #endregion

            #region 4.feladat

            string originalMsg = "Gravity Falls is awesome!";
            Cypher cypher = new Cypher(1);

            string encrypted = cypher.Encode(originalMsg);
            Console.WriteLine($"\nEncoded msg is: {encrypted}");

            string decrypted = cypher.Decode(encrypted);
            Console.WriteLine($"Decoded msg is: {decrypted}");

            #endregion

            #region 5.feladat

            StreamReader sr = new StreamReader("../../../NHANES_1999-2018.csv");
            sr.ReadLine();
            List<Person> people = new List<Person>();
            while (!sr.EndOfStream)
            {
                string[] lineData = sr.ReadLine().Split(',');
                people.Add
                (
                    new Person
                    (
                        int.Parse(lineData[0]),
                        lineData[1], lineData[2][0] - '0',
                        int.Parse(lineData[3].Split('.')[0]),
                        double.Parse(lineData[4], CultureInfo.InvariantCulture),
                        double.Parse(lineData[5], CultureInfo.InvariantCulture)
                    )
                );
            }
            sr.Close();

            double bmiMaleSum = 0, bmiFemaleSum = 0, obeseSum = 0;
            int bmiMaleCnt = 0, highSugarCnt = 0, obeseCnt = 0;
            Person maxPerson = people[0];
            foreach (Person p in people)
            {
                if (p.GetRIAGENDR() == 1)
                {
                    bmiMaleSum += p.GetBMXBMI();
                    bmiMaleCnt++;
                }
                else
                {
                    bmiFemaleSum += p.GetBMXBMI();
                }

                if (p.GetLBDGLUSI() > 5.6)
                {
                    highSugarCnt++;
                }

                if (p.GetBMXBMI() > maxPerson.GetBMXBMI())
                {
                    maxPerson = p;
                }

                if (p.GetBMXBMI() >= 30.0)
                {
                    obeseCnt++;
                    obeseSum += p.GetRIDAGEYR();
                }
            }

            Console.WriteLine("\n1. Egy adott felmérésben mennyi volt a nők és a férfiak átlagos testtömegindexe?");
            double avgMale = Math.Round(bmiMaleSum / bmiMaleCnt, 1);
            double avgFemale = Math.Round(bmiFemaleSum / (people.Count - bmiMaleCnt), 1);
            Console.WriteLine($"A férfi átlag BMI {avgMale}, a női átlag BMI {avgFemale}.");

            Console.WriteLine("\n2. Egy adott felmérésben az alanyok hány százalékának volt 5.6-nál magasabb a vércukorszintje?");
            double percentage = Math.Round(100.0 * highSugarCnt / people.Count, 1);
            Console.WriteLine($"Az alanyok {percentage}%-a rendelkezik 5.6-nál magasabb vércukorszinttel.");

            Console.WriteLine("\n3. Egy maximális BMI-vel rendelkező alanynak mennyi a vércukorszintje?");
            Console.WriteLine($"A maximális BMI ({maxPerson.GetBMXBMI()}), vércukorszintje:{maxPerson.GetLBDGLUSI()}");

            Console.WriteLine("\n4. A teljes adathalmazban mi a túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora?");
            Console.WriteLine($"A túlsúlyos személyek átlagos életkora {Math.Round(obeseSum / obeseCnt, 2)}");

            #endregion
        }

        #region Methods

        static int Add(int a, int b)            //Érték szerinti átadás
        {
            int c = a + b;
            a = 0;
            b = 0;
            return c;
        }

        // Azonos metódus szignatúra fordítási hibát okozna, mivel nem lenne eldönthető, melyikre hivatkozunk.
        /*static int ADD(int szam1, int szam2)  
        {
            return szam1 + szam2;
        }*/

        static int Add(ref int a, ref int b)    // Referencia szerinti átadás. Az eltérő paraméterek miatt a szignatúra eltér --> Metódus túlterhelés.
        {
            int c = a + b;
            a = 0;
            b = 0;
            return c;
        }

        /// <summary>
        /// 3DB /// al generálhatunk függvénydokumentációt
        /// </summary>
        public static void TestMethod()
        {
            Console.WriteLine("A void os metódusnak nincs visszatérési értéke");
            return; // A return kulcsszóval kiléphetünk a metódusból.
        }

        #endregion
    }

    #region Classes

    public class Triangle
    {
        //----------------------------------------FIELDS || MEZŐK

        // Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle amit az összes példány elér.
        // Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        // Readonly mivel létrehozás után nem akarjuk módosítani.
        private static readonly Random rnd = new Random();

        // Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle amit az összes példány elér.
        // Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        // Minden konstruktorban növeljük 1-el, így pontosan tudjuk, hány háromszög jött létre összesen.
        private static int TriangleCounter = 0;

        // Ha nem írok láthatóságot, akkor az alapértelmezett (private) láthatóságúak lesznek a mezőink.
        // Private mező csak az osztályon belül érhető el, kívülről nem olvasható, nem írható.
        // Mivel nincsen static kulcsszó, az adott példányhoz fognak tartozni, minden egyes háromszög példánynak lesz saját, önálló a, b, c mezője.
        double a, b, c;

        //----------------------------------------CTOR ||KONSTRUKTOROK

        // Nulla paraméteres konstruktor. A konstruktor meghívódik minden alkalommal, amikor egy új példányt hozunk létre az osztályból. Pl: new Triangle()
        // Ha egyetlen konstruktort sem deklarálunk, alapértelmezetten létrejön egy nulla paraméteres konstruktor, üres metódustörzzsel. 
        public Triangle()
        {
            //Mivel nem kaptunk paramétereket a,b,c hez, randomizált módon adunk nekik értéket..
            do
            {
                a = rnd.Next(1, 101);
                b = rnd.Next(1, 101);
                c = rnd.Next(1, 101);
            } while (!IsValid());
            TriangleCounter++;
        }

        // Egy paraméteres konstruktor, egyenlő oldalú háromszöget csinál
        public Triangle(double side)
        {
            a = side;
            b = side;
            c = side;
            TriangleCounter++;
        }

        // Két paraméteres konstruktor, egyenlő szárú háromszöget csinál
        public Triangle(double first, double second)
        {
            a = first;
            b = second;
            c = second;
            TriangleCounter++;
        }

        // Három paraméteres konstruktor, tetszőleges háromszöget csinál
        public Triangle(double a, double b, double c)
        {
            // Mivel a bejövő paraméter neve azonos az osztály mezőinek nevével, szükséges valahogy megkülönböztetni őket
            // A this. kulcsszóval az osztály adattagjára referálok
            // A this kulcsszó nélkül a legközelebb deklarált változóra referálok (a paraméterként bejövő a,b,c re)
            this.a = a;
            this.b = b;
            this.c = c;
            TriangleCounter++;
        }

        //----------------------------------------METHODS || METÓDUSOK

        // Ez a metódus egy bool értéket ad vissza, amely megmondja, hogy a háromszög érvényes-e.
        // Privát a láthatósága, mivel csak az osztályon belül szeretnénk használni
        private bool IsValid()
        {
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        // Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        // Visszaadja a háromszög kerületét.
        public double Disctrict()
        {
            return a + b + c;
        }

        // Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        // Visszaadja a háromszög területét.
        public double Area()
        {
            double s = Disctrict() / 2;

            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));      //Heron képlet
        }

        // Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk. Következő félévben majd tanulunk rá más megoldást.
        // Megjeleníti a háromszög legfontosabb adatait.
        public string ShowMe()
        {
            return $"A:{a} B:{b} C:{c} Disctrict: {Disctrict()} Area: {Area()}";
        }

        // Ez a metódus publikus, mivel szeretnénk, hogy az osztályon kívül is használhassuk.
        // Visszaadja az eddig előállított háromszöget számát
        // Statikus kulcsszó miatt az "osztályhoz tartozik", 1DB van belőle, és Triangle.GetTriangleCount() szintaxissal érhető el.
        // Mivel statikus metódus, nem tudja használni az osztály nem statikus mezőit, így nem fér hozzá az a, b, c értékekhez.
        public static int GetTriangleCount()
        {
            return TriangleCounter;
        }
    }

    #endregion

    #region 1.feladat

    /*
     * Készítsünk egy Book osztályt, amely eltárolja egy könyv szerzőjét, címét, a kiadás évét és a könyv oldalszámát.
     * Az adattagok értékét a konstruktoron keresztül lehessen beállítani. Hozzunk létre egy publikus AllData nevű
     * metódust, amely a könyv adatait egyetlen formázott karakterláncban adja vissza.
     */

    public class Book
    {
        private string author;
        private string title;
        private DateTime published;
        private int pageCnt;

        public Book(string author, string title, DateTime published, int pageCnt)
        {
            this.author = author;
            this.title = title;
            this.published = published;
            this.pageCnt = pageCnt;
        }

        public string AllData()
        {
            return $"Author: {author}, Title: {title}, Published: {published.ToString("yyyy-MM-dd")}, Pages: {pageCnt}.";
        }
    }

    #endregion

    #region 2.feladat

    /*
     * Készítsünk osztályt egy téglalap reprezentálására. A téglalapról tároljuk el, hogy hány egység széles, hány
     * egység magas, továbbá hogy milyen színű. Legyen lehetőség az adattagok beállítására a konstruktoron keresztül.
     * Az osztálynak legyen egy privát Area és egy publikus IsValid nevű metódusa. Az előbbi a példány területét hatá-
     * rozza meg, az utóbbi pedig egy logikai változóban visszaadja, hogy a példány szerkeszthető-e (nullánál nagyobb-e
     * a területe). Hozzunk létre egy kétparaméteres Draw nevű metódust is, amely nem rendelkezik visszatérési érték-
     * kel. A metódus az osztályban tárolt színnel és méretekkel kirajzolja a képernyőre a téglalapot, a bal felső sarkát
     * a metódus két paraméterének (x és y) megfelelően igazítva. A főprogramban hozzunk létre néhány téglalap
     * példányt, ellenőrizzük, hogy szerkeszthetőek-e, majd rajzoljuk ki, amelyek azok.
     */

    public class Rectangle
    {
        private double width;
        private double height;
        private ConsoleColor color;

        public Rectangle(double width, double height, ConsoleColor color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }

        private double Area()
        {
            return width * height;
        }

        public bool IsValid()
        {
            return Area() > 0;
        }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write("#");
                }
                Console.SetCursorPosition(x, y + i);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    #endregion

    #region 3.feladat

    /*
     * Futóverseny szimulációjához készítünk alkalmazást. Hozzunk létre egy Runner nevű osztályt, amely tárolja
     * a futó nevét, sorszámát, sebességét (m/s), és a startvonaltól számított aktuális távolságát. Az adattagoknak
     * a konstruktoron keresztül lehessen kezdőértéket adni, a távolság minden esetben a 0 keződértéket kapja. Az
     * osztály rendelkezzen egy RefreshDistance nevű metódussal, amely egy másodpercben megadott időtartamot
     * jelentő egész számot vár paraméterként, és a példány távolságát minden hívásnál a sebességéből és a kapott
     * időtartamból számított értékkel növeli meg. A Show metódus a futó sorszámának megfelelő sorba, a képernyő
     * bal szélétől a távolságának megfelelő oszlopba írja a futó nevének kezdőbetűjét. A GetDistance metódus a futó
     * aktuális távolságát adja vissza. A főprogramban hozzunk létre két futó példányt, majd léptessük és jelenítsük
     * meg őket annyi alkalommal a képernyőn, amíg egyikük távolsága elér egy előre megadott értéket.
     */

    public class Runner
    {
        private string name;
        private int number;
        private double speed;
        private int dst;

        public Runner(string name, int number, double speed)
        {
            this.name = name;
            this.number = number;
            this.speed = speed;
            dst = 0;
        }

        public void RefreshDistance(int seconds)
        {
            dst += (int)(speed * seconds);
        }

        public void Show()
        {
            Console.SetCursorPosition(dst, number);
            Console.Write(char.ToUpper(name[0]));
        }

        public int GetDistance()
        {
            return dst;
        }
    }

    #endregion

    #region 4.feladat

    /*
     * Készítsünk egy szöveges üzenet titkosítására és visszafejtésére alkalmas osztályt. Az üzenet titkosítása
     * történjen a korábban megismert Caesar-rejtjelezéssel. A példány tárolja el a kódoláshoz használt kulcsot (az
     * eltolás mértékét), amelyet példányosításkor lehessen megadni. Definiáljunk egy privát TransformMessage nevű
     * metódust, amelynek két paramétere van: egy karakterlánc (az üzenet) és egy egész érték (a kulcs). A metódus
     * visszatérési értéke a karakterek megfelelő eltolásával kapott üzenet. Definiáljunk továbbá egy Encode és egy
     * Decode nevű metódust is, amelyek egyetlen paramétere egy üzenet, és a példányban tárolt kulcsot felhasználva
     * meghívja a TransformMessage metódust, majd visszaadja az ez által kódolt vagy visszafejtett üzenetet.
     */

    public class Cypher
    {
        private int offset;

        public Cypher(int key)
        {
            offset = key;
        }

        private string TransformMessage(string msg, int key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < msg.Length; i++)
            {
                var c = (char)(msg[i] + key);
                sb.Append(c);
            }

            return sb.ToString();
        }

        public string Encode(string msg)
        {
            return TransformMessage(msg, offset);
        }

        public string Decode(string msg)
        {
            return TransformMessage(msg, -offset);
        }
    }

    #endregion

    #region 5.feladat

    /*
     * Készítsük el a korábban már megoldott NHANES adatbázisból származó adatok feldolgozására képes prog-
     * ramunkat objektumorientált megközelítésben is. Hozzunk létre egy osztályt egy személy adatainak tárolására. A
     * mezők inicializálása történjen a konstruktornak átadott paraméterek alapján. Írjunk tagfüggvényeket a szükséges
     * adatmezők érékének lekérdezésére. Dolgozzuk fel a bemeneti fájlt, majd a tábla soraiban lévő adatok alapján elő-
     * álló példányokat tároljuk egy tömbben vagy listában. Írjuk meg a korábbi lekérdezéseket a példányok metódusain
     * keresztüli adathozzáféréssel is
     */

    public class Person
    {
        private readonly int SEQN;
        private readonly string SURVEY;
        private readonly int RIAGENDR;
        private readonly int RIDAGEYR;
        private readonly double BMXBMI;
        private readonly double LBDGLUSI;

        public Person(int SEQN, string SURVEY, int RIAGENDR, int RIDAGEYR, double BMXBMI, double LBDGLUSI)
        {
            this.SEQN = SEQN;
            this.SURVEY = SURVEY;
            this.RIAGENDR = RIAGENDR;
            this.RIDAGEYR = RIDAGEYR;
            this.BMXBMI = BMXBMI;
            this.LBDGLUSI = LBDGLUSI;
        }

        public int GetSEQN()
        {
            return SEQN;
        }
        public string GetSURVEY()
        {
            return SURVEY;
        }
        public int GetRIAGENDR()
        {
            return RIAGENDR;
        }
        public int GetRIDAGEYR()
        {
            return RIDAGEYR;
        }
        public double GetBMXBMI()
        {
            return BMXBMI;
        }
        public double GetLBDGLUSI()
        {
            return LBDGLUSI;
        }
    }

    #endregion
}