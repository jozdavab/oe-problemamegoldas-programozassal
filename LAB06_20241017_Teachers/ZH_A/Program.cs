namespace ZH_A
{
    public enum ExamType
    {
        első, második, javító
    }

    public class Program
    {
        private static void Main(string[] args)
        {
            #region 1.feladat

            /*
             * A dolgozatok eredményei a ZH.log fájlban találhatók. A fájl első sorában az attribútumokat, a további sorokban egy-egy játék adatait találjuk.
             * Az attribúrumok jelentése a következő:
             *      •	Subject: A tantárgy neve
             *      •	ExamType A dolgozat típusa (első, második, javító)
             *      •	MaximumScore: A dolgozat  maximum pontszáma
             *      •	ExamDate: A dolgozat  írásának dátuma
             *      •	Neptun: A dolgozat írójának neptunkódja
             *      •	Score: A dolgozatot író hallgató pontszáma
            Töltse be a fájlt, dolgozza fel, és tárolja a benne található adatokat tetszőleges módon (pl. tömbök, listák). 
            A Score attribútumnál szereplő pontszám értékeket cserélje le a százalékos értékre ]0-100[ a maximum pontszámtól függően.
            */

            List<string> subjects = new List<string>();
            List<ExamType> examTypes = new List<ExamType>();
            List<int> maximumScores = new List<int>();
            List<DateTime> examDates = new List<DateTime>();
            List<string> neptuns = new List<string>();
            List<int> percentages = new List<int>();

            StreamReader sr = new StreamReader("../../../ZH.log");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] lineData = sr.ReadLine().Split(',');
                subjects.Add(lineData[0]);
                examTypes.Add(Enum.Parse<ExamType>(lineData[1]));
                int maximumScore = int.Parse(lineData[2]);
                maximumScores.Add(maximumScore);
                examDates.Add(DateTime.Parse(lineData[3]));
                neptuns.Add(lineData[4]);
                percentages.Add(int.Parse(lineData[5]) * 100 / maximumScore);
            }

            sr.Close();

            #endregion

            #region 2.feladat

            /*
             * Adott típusú dolgozatok száma. Kérjen el a felhasználótól egy dolgozattípust (első || második || javító),
             * majd jelenítse meg az ilyen típusú dolgozatok darabszámát. Ha a felhasználó olyan típust ad meg amely 
             * nem létezik („pótló”), a program kérje be újból a dolgozat típusát, mindaddig, amíg nem helyes típust
             * ír be a felhasználó. (első || második || javító)
             */

            string targetTypeStr;
            do
            {
                Console.Clear();
                Console.Write("Adja meg a dolgozat típusát (első || második || javító):\t");
                targetTypeStr = Console.ReadLine();
            } while (targetTypeStr != "első" && targetTypeStr != "második" && targetTypeStr != "javító");

            ExamType targetType = Enum.Parse<ExamType>(targetTypeStr);
            int counter = 0;
            foreach (ExamType currType in examTypes)
            {
                if (currType == targetType)
                {
                    counter++;
                }
            }
            Console.WriteLine($"{counter} db {targetType} típusú dolgozat van.");

            #endregion

            #region 3.feladat

            /*
             * Sikeres idei dolgozatok. Készítsen lekérdezést, amely listázza a képernyőre azokat az idei dolgozatokat
             * (Subject, ExamType, Neptun, Percentage), amelyeken a hallgató elért legalább 50%-ot.
             */

            int currYear = DateTime.Now.Year;
            Console.WriteLine("\nIdei sikeres dolgozatok:");
            for (int i = 0; i < percentages.Count; i++)
            {
                if (percentages[i] > 49 && examDates[i].Year == currYear)
                {
                    Console.WriteLine($"{subjects[i]}-{examTypes[i]}-{neptuns[i]}-{percentages[i]}");
                }
            }

            #endregion

            #region 4.feladat

            /*
             * Dolgozatok átlaga típusonként. Készítsen lekérdezést, amely megadja az egyes dolgozattípusok átlageredményét
             */

            int cnt1 = 0, cnt2 = 0, cnt3 = 0;
            double sum1 = 0, sum2 = 0, sum3 = 0;
            for (int i = 0; i < examTypes.Count; i++)
            {
                if (examTypes[i] == ExamType.első)
                {
                    cnt1++;
                    sum1 += percentages[i];
                }
                else if (examTypes[i] == ExamType.második)
                {
                    cnt2++;
                    sum2 += percentages[i];
                }
                else
                {
                    cnt3++;
                    sum3 += percentages[i];
                }
            }

            Console.WriteLine("\nÁtlagok:");
            if (cnt1 != 0)
            {
                Console.WriteLine($"{ExamType.első} dolgozat átlaga: {sum1 / cnt1}");
            }
            else
            {
                Console.WriteLine($"Nem írt senki {ExamType.első} zárthelyi dolgozatot.");
            }
            if (cnt2 != 0)
            {
                Console.WriteLine($"{ExamType.második} dolgozat átlaga: {sum2 / cnt2}");
            }
            else
            {
                Console.WriteLine($"Nem írt senki {ExamType.második} zárthelyi dolgozatot.");
            }
            if (cnt3 != 0)
            {
                Console.WriteLine($"{ExamType.javító} dolgozat átlaga: {sum3 / cnt3}");
            }
            else
            {
                Console.WriteLine($"Nem írt senki {ExamType.javító} zárthelyi dolgozatot.");
            }
            #endregion
        }
    }
}