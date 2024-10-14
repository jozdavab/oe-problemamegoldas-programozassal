using System.Text;

namespace ZH_B
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region 1.feladat

            /*
             * A kurzusok adatai a courses.csv fájlban találhatók. A fájl első sorában az attribútumokat, a
             * további sorokban egy-egy kurzus adatait találjuk. Az attribúrumok jelentése a következő:
             *      • Course: A kurzus neve
             *      • CourseDate: A kurzus indulásának dátuma
             *      • Capacity: A kurzuson legfeljebb hány hallgató vehet részt.
             *      • Students A kurzuson lévő hallgatók neptunkódja, vesszővel elválasztva
             *      • HasFinalExam: Vizsgás-e a tantárgy.
             *      • AverageGrade: A kurzuson lévő hallgatók jegyének átlaga. -1, ha még nincs adat a kurzusról.
             * Töltse be a fájlt, dolgozza fel, és tárolja a benne található adatokat tetszőleges módon (pl. tömbök,
             * listák). Ha egy kurzuson több hallgató van mint a kapacitás, írjon figyelmeztetést a konzolra.
             */

            List<string> courses = new List<string>();
            List<DateTime> courseDates = new List<DateTime>();
            List<int> capacities = new List<int>();
            List<string[]> students = new List<string[]>();
            List<bool> exams = new List<bool>();
            List<double> grades = new List<double>();

            StreamReader sr = new StreamReader("../../../courses.csv");
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string[] lineData = sr.ReadLine().Split(';');
                courses.Add(lineData[0]);
                courseDates.Add(DateTime.Parse(lineData[1]));
                int capacity = int.Parse(lineData[2]);
                capacities.Add(capacity);
                string[] studs = lineData[3].Split(",");
                students.Add(studs);
                exams.Add(bool.Parse(lineData[4]));
                grades.Add(double.Parse(lineData[5]));

                if (capacity < studs.Length)
                {
                    Console.WriteLine($"Hiábás adat, nem fér {studs.Length} ember {lineData[0]} kurzusba, mert a létszám maximum {capacity}");
                }
            }

            sr.Close();

            #endregion

            #region 2.feladat

            /*
             * Adott év vizsgás kurzusai. Kérjen el a felhasználótól egy évszámot. Készítsen lekérdezést, amely
             * listázza a képernyőre az adott évben indult vizsgás kurzusokat (Course, CourseDate, Capacity, AverageGrade). 
             */

            Console.Write("\nAdjon meg egy évszámot:\t");
            int year = int.Parse(Console.ReadLine());

            for (int i = 0; i < courseDates.Count; i++)
            {
                if (year == courseDates[i].Year && exams[i])
                {
                    Console.WriteLine($"{courses[i]}-{courseDates[i].ToString("yyyy-MM-dd")}-{capacities[i]}-{grades[i]}");
                }
            }

            #endregion

            #region 3.feladat

            /*
             * Adott hallgató kurzusai. Kérjen el a felhasználótól egy neptunkódot, majd jelenítse meg mely
             * kurzusokon vett részt az adott hallgató. Ha a felhasználó érvénytelen neptunkód formátumot ad meg, a
             * program kérje be újra azt, mindaddig amíg nem helyes (6 karakter hosszú, az első karakter betű)
             * formátumot ad meg a felhasználó. 
             */

            string targetNeptun;
            do
            {
                Console.Write("\nAdj meg egy neptun kódot:\t");
                targetNeptun = Console.ReadLine();
            } while (!(!string.IsNullOrEmpty(targetNeptun) && targetNeptun.Length == 6 && char.IsLetter(targetNeptun[0])));

            Console.WriteLine($"{targetNeptun} kurzusai:");
            for (int i = 0; i < courses.Count; i++)
            {
                for (int j = 0; j < students[i].Length; j++)
                {
                    if (students[i][j] == targetNeptun.ToUpper())
                    {
                        Console.WriteLine(courses[i]);
                        break;
                    }
                }
            }

            #endregion

            #region 4.feladat

            /*
             * Rosszul teljesítő kurzusok. Írja fájlba (bad_courses.csv), azon kurzusok összes adatát, melyeknek
             * az átlaga 3.0 alatti. Ha még nincs adat a kurzusról, hagyja ki a feldolgozásból. A kimeneti formátum
             * egyezzen meg a bemeneti formátummal.
             */

            StreamWriter sw = new StreamWriter("../../../bad_courses.csv");
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] < 3 && grades[i] != -1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(courses[i]).Append(";").Append(courseDates[i].ToString("yyyy-MM-dd")).Append(";").Append(capacities[i]).Append(";");
                    for (int j = 0; j < students[i].Length; j++)
                    {
                        sb.Append(students[i][j]);
                        if (j < students[i].Length - 1)
                        {
                            sb.Append(',');
                        }
                        else
                        {
                            sb.Append(";");
                        }
                    }
                    sb.Append(exams[i]).Append(';').Append(grades[i]).Append(";");
                    sw.WriteLine(sb.ToString());
                }
            }
            sw.Close();

            #endregion
        }
    }
}