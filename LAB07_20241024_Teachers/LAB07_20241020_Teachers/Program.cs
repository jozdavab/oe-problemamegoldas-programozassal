using System.Text;

namespace LAB07_20241020_Teachers
{
    /*
     * Objektumtömbök. Felsorolt típus (enum). Tulajdonságok (Property). 
     * Metódusok túlterhelése(overloading), konstruktorok láncolása.
     */

    public class Program
    {
        private static void Main(string[] args)
        {
            #region 1.feladat

            /*
             * Készítsük el a Whac-A-Mole játék módosított változatát, ahol a vakond felbukkanása előtt kell megtippelnünk,
             * hol fog megjelenni. Hozzunk létre egy Mole osztályt, amely tárolja a vakond pozícióját (egész érték). 
             * A pozíció legyen lekérhető (de nem módosítható) egy publikus tulajdonságon keresztül. Hozzunk létre egy TurnUp
             * nevű metódust, amely meghíváskor egy M karaktert ír ki a képernyőre a vakond pozíciójának megfelelő helyre.
             * Készítsünk egy Hide nevű kétparaméteres metódust is, amely a vakond pozícióját véletlen értékre állítja úgy,
             * hogy az az első és második paraméterként megadott egészek közé essen. Készítsünk egy példányt, és hívjuk meg a
             * Hide metódusát. Kérjük el a felhasználótól egy tippet, rajzoljuk ki a vakondot, majd döntsünk róla, hogy a 
             * felhasználó eltalálta-e a pozícióját. A játék akkor ér véget, ha a felhasználó elkapta a vakondot.
             */

            Mole mole = new Mole();
            int hit;
            do
            {
                Console.Clear();
                mole.Hide(0, Console.WindowWidth);
                Console.Write($"Ütés helye (1-{Console.WindowWidth}): ");
                hit = int.Parse(Console.ReadLine()) - 1;

                mole.TurnUp();
                Console.SetCursorPosition(hit, 3);
                Console.WriteLine("X");

                Console.ReadKey();
            } while (mole.Position != hit);
            Console.WriteLine("Találat!");

            #endregion

            #region 2.feladat

            /*
             * Készítsünk földi kiszolgálást segítő alkalmazást egy repülőtér számára. Minden járatnál ismerjük a járat-
             * számot, a célállomást és a tervezett indulás időpontját, legyenek ezek a Flight osztály mezői. Tároljuk el még
             * a járat percekben megadott késését és aktuális státuszát is. A járatok státusza a Scheduled, Delayed vagy Canceled
             * lehet. Készítse el az ehhez tartozó felsorolt típust. A mezők értéke legyen lekérhető tulajdonságokon keresztül.
             * Az osztálynak legyen egy konstruktora, amely a fenti adatokat kéri a státusz kivételével. Legyen egy olyan konstruktora
             * is, amely csak a járatszámot, a célállomást és a tervezett indulás időpontját kéri, a késés ilyenkor nulla perc.
             * A Delay nevű publikus metódus a paraméterként megadott késést állítja be a járathoz. A Cancel nevű publikus
             * metódus törli a járatot a megfelelő státusz beállításával.
             * Készítsen egy privát UpdateStatus nevű metódust, amely a paraméterként megadott státuszt állítja be a járatnál.
             * Készítse el az UpdateStatus egy olyan túlterhelt változatát is, amely paraméter nélküli, és a késés időtartamának
             * megfelelően állítja be a járat státuszát (Scheduled vagy Delayed).
             * Az AllData nevű tulajdonság a járat adatait adja vissza egy formázott karakterláncban (lásd az alábbi példát)
             * a státusztától függően. Az EstimatedDeparture a tervezett indulási időpont és a késés ideje alapján kiszámítja
             * és visszaadja az indulás várható idejét DateTime típusként.
             * Hozza létre a GroundControl osztályt, amely tárolja az aktuális időpontot, valamint a kiszolgált járatok gyűjteményét.
             * Az AddFlight publikus metódussal egy járat példányt tudunk hozzávenni a gyűjteményhez. Az AverageDelay
             * privát metódus meghatározza a nem törölt járatok átlagos késési idejét. A DisplayFlightData publikus metódus
             * a járatok adatait listázza a képernyőre (használja a járatok AllData metódusát), majd kiírja az átlagos késést.
             * Hozzon létre egy GroundControl példányt, adjon hozzá néhány járatot, majd tesztelje a megírt metódusok működését
             */

            GroundControl BUD = new GroundControl();
            BUD.AddFlight(new Flight("6H728",  "Tel Aviv TLV",  DateTime.Parse("2024-10-21 19:45:00"), 10));
            BUD.AddFlight(new Flight("FR8247", "Rome CIA",      DateTime.Parse("2024-10-21 19:45:00")));
            BUD.AddFlight(new Flight("LX2259", "Zurizch",       DateTime.Parse("2024-10-21 14:10:00")));
            BUD.AddFlight(new Flight("FR5248", "Cagliari",      DateTime.Parse("2024-10-21 14:25:00")));
            BUD.AddFlight(new Flight("W62361", "Bari",          DateTime.Parse("2024-10-21 19:45:00")));

            Flight BlueBird = new Flight("BZ441", "Tel Aviv TLV", DateTime.Parse("2024-10-21 10:30:00"));
            BUD.AddFlight(BlueBird);
            BlueBird.Cancel();

            BUD.DisplayFlightData();

            #endregion

            #region 3.feladat

            /*
             * Hozzunk létre egy ExamResult osztályt, amely egy ZH dolgozat eredményét reprezentálja. Az osztály
             * rendelkezzen egy Neptun-kódot valamint egy 0-100 közötti pontszámot tároló mezővel. Készítsünk publikus
             * tulajdonságokat a két mezőhöz, amelyek csak formailag helyes értékek beállítását végzik el (tehát például nem
             * állíthatunk be vele 5 karakterből álló Neptun kódot, vagy negatív pontszámot).
             * Készítsünk konstruktort, amely a Neptun-kódot és a pontszámot kéri el, és elvégzi a mezők beállítását a tulaj-
             * donságokon keresztül. Hozzunk létre egy olyan konstruktort is, amely segítségével véletlenszerű Neptun-kóddal
             * és pontszámmal hozhatunk létre egy példányt.
             * Készítsünk egy Passed nevű tulajdonságot, amely true vagy false értékkel tér vissza attól függően, hogy a
             * dolgozat sikeres (legalább 50 pontos) volt-e.
             * Készítsünk egy Grade metódust is, amelynek paramétere egy ötelemű, egészekből álló tömb, az osztályzatok
             * ponthatárai (például {0, 50, 62, 74, 86 }). A metódus a pontszám alapján kalkulált érdemjegy megnevezését
             *  (pl. Jeles, Jó, stb.) adja vissza egy saját felsorolt típusként. Hozzuk létre a szükséges felsorolt típust is az
             * osztályzatok megnevezésével.
             * Kérjünk el a felhasználótól egy N egész értéket, majd hozzunk létre egy N elemű gyűjteményt ExamResult
             * típusú objektumok tárolására. Töltsük fel a gyűjteményt a felhasználó által megadott vagy véletlenszerűen
             * generált értékeket tartalmazó példányokkal. Soroljuk fel a sikeres dolgozatokhoz tartozó Neptun-kódokat. Írjuk
             * ki a pontszámok átlagát, illetve a legmagasabb pontszámhoz tartozó Neptun-kódot
             */

            Console.Write("Add meg a dolgozatok számát: ");
            ExamResult[] results = new ExamResult[int.Parse(Console.ReadLine())];
            Console.WriteLine("Automatikus feltöltés? (true false)");
            if (bool.Parse(Console.ReadLine()))
            {
                for (int i = 0; i < results.Length; i++)
                {
                    results[i] = new ExamResult();
                }
            }
            else
            {
                for (int i = 0; i < results.Length; i++)
                {
                    Console.Clear();
                    Console.Write($"{i + 1}. dolgozat neptun:");
                    string neptun = Console.ReadLine();
                    Console.Write($"{i + 1}. dolgozat pontszám:");
                    int score = int.Parse(Console.ReadLine());
                    results[i] = new ExamResult(neptun, score);
                }
            }

            Console.WriteLine("\nSikeres dolgozatokhoz tartozó neptunkódok:");
            double sum = 0;
            int maxi = 0;
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i].Passed)
                {
                    Console.Write(results[i].Neptun + " ");
                }
                if (results[i].Score > results[maxi].Score)
                {
                    maxi = i;
                }
                sum += results[i].Score;
            }

            if (results.Length > 0)
            {

                Console.WriteLine($"\nPontszámok átlaga:{sum / results.Length}");

                int[] grades = { 0, 50, 62, 72, 86 };
                Console.WriteLine($"\nLegjobb dolgozat " +
                    $"{results[maxi].Neptun}-hoz tartozik, " +
                    $"pontszáma {results[maxi].Score}, " +
                    $"érdemjegye:{results[maxi].Grade(grades)}");
            }
            else
            {
                Console.WriteLine("Nincsenek dolgozatok!");
            }


            #endregion
        }
    }

    #region 1.feladat

    public class Mole
    {
        static Random rnd = new Random();
        private int position;
        public int Position { get => position; }            // Lambdás csak olvasható property

        public void TurnUp()
        {
            Console.SetCursorPosition(Position, 3);
            Console.WriteLine("M");
        }

        public void Hide(int minValue, int maxValue)
        {
            position = rnd.Next(minValue, maxValue);
        }
    }


    #endregion

    #region 2.feladat

    public enum Status
    {
        Scheduled = 10, // Enumok értéke explicit állítható
        Delayed,        // 11, mivel egyel nagyobb az előtte lévőnél
        Canceled
    }

    public class Flight
    {
        private string flightNumber;
        private string destination;
        private Status state;
        private int delayTime;

        public string FlightNumber { get => flightNumber; }         // Lambdás csak olvasható property
        public string Destination { get { return destination; } }   // Csak olvasható property
        public DateTime Departure { get; private set; }             // Kívülről olvasható, belülről írható auto property
        public Status State { get => state; }
        public int DelayTime { get => delayTime; }

        public string Alldata // On the fly property
        {
            get
            {
                switch (State)
                {
                    case Status.Scheduled   : return $"Flight {FlightNumber} is on time. (STD {EstimatedDeparture.ToString("yyyy. MM. dd. HH:mm:ss")})";
                    case Status.Delayed     : return $"Flight {FlightNumber} is delayed by {DelayTime} minutes (ETD {EstimatedDeparture.ToString("yyyy. MM. dd. HH:mm:ss")})";
                    case Status.Canceled    : return $"Flight {FlightNumber} is canceled.";
                    default: return "";
                }
            }
        }
        public DateTime EstimatedDeparture { get { return Departure.AddMinutes(delayTime); } }


        public Flight(string flightNumber, string destination, DateTime departure, int delayTime)
        {
            this.flightNumber = flightNumber;
            this.destination = destination;
            Departure = departure;
            this.delayTime = delayTime;
            UpdateStatus();
        }

        public Flight(string flightNumber, string destination, DateTime departure) : this(flightNumber, destination, departure, 0)
        {
        }

        public void Delay(int delay)
        {
            delayTime += delay;
            UpdateStatus();
        }

        public void Cancel()
        {
            state = Status.Canceled;
        }

        private void UpdateStatus(Status state)
        {
            this.state = state;
        }
        private void UpdateStatus()
        {
            if (this.delayTime > 0)
            {
                this.state = Status.Delayed;
            }
            else
            {
                this.state = Status.Scheduled;
            }
        }
    }

    public class GroundControl
    {
        private DateTime currentTime;
        private readonly List<Flight> flights;

        public GroundControl()
        {
            flights = new List<Flight>();
        }

        public void AddFlight(Flight newFlight)
        {
            flights.Add(newFlight);
        }

        public void DisplayFlightData()
        {
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.Alldata);
            }
            Console.WriteLine($"Average delay is {AverageDelay()} minutes");
        }

        private double AverageDelay()
        {
            double sum = 0;
            int cnt = 0;
            foreach (var flight in flights)
            {
                if (flight.State != Status.Canceled)
                {
                    sum += flight.DelayTime;
                    cnt++;
                }
            }
            if (cnt > 0)
            {
                return sum / cnt;
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion

    #region 3.feladat

    public enum GradeType
    {
        Elégtelen,  // Ha az érték nincs explicit megadva, 0 az első elem értéke.
        Elégséges,
        Közepes,
        Jó,
        Jeles
    }

    public class ExamResult
    {
        static Random rnd = new Random();
        private string neptun;
        private int score;
        public string Neptun
        {
            get
            {
                return neptun;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 6 && char.IsLetter(value[0]))
                {
                    neptun = value;
                }
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score > -1 && score < 101)
                {
                    score = value;
                }
            }
        }

        public bool Passed { get => score > 49; }

        public ExamResult(string neptun, int score)
        {
            Neptun = neptun;        // A tulajdonságon keresztül módosítsuk neptun mező értékét, különben nincs validáció!
            Score = score;
        }

        public ExamResult()
        {
            Score = rnd.Next(101);
            StringBuilder sb = new StringBuilder();
            sb.Append((char)rnd.Next('A', 'Z' + 1));
            for (int i = 0; i < 5; i++)
            {
                if (rnd.Next(2) == 0)
                {
                    sb.Append((char)rnd.Next('A', 'Z' + 1));
                }
                else
                {
                    sb.Append(rnd.Next(10));
                }
            }
            Neptun = sb.ToString();
        }

        public GradeType Grade(int[] grades)
        {
            for (int i = grades.Length - 1; i >= 0; i--)
            {
                if (Score >= grades[i])
                {
                    return (GradeType)i;
                }
            }
            return GradeType.Elégtelen;
        }
    }
    #endregion
}