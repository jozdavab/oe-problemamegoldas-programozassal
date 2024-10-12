namespace ZH
{
    // Projekten jobb klikk -> Set as Startup Project.
    public class Program
    {
        private static void Main(string[] args)
        {
            #region 1.feladat

            /*
             * A játékok lehetséges műfajait tartalmazó adatok a genre.txt fájlban találhatók. Töltse be a
             * fájlt, és nyerje ki a belőle a műfajok megnevezését, majd tárolja az adatokat valamilyen módon (pl.
             * tömb, lista, saját enum). 
             */

            string[] genreNames = File.ReadAllLines("../../../genre.txt")[0].Split(", ");

            #endregion

            #region 2.feladat

            /*
             * A játékok jellemzőit tartalmaztó adatok a games_dataset.csv fájlban találhatók. A fájl első
             * sorában az attribútumokat, a további sorokban egy-egy játék adatait találjuk. Az attribúrumok
             * jelentése a következő:
             *      • Title: a játék címe
             *      • Genre ID: a műfaj azonosítója (lásd az első feladatot)
             *      • Publisher: a játék kiadója
             *      • Release date: ettől a dátumtól érhető el a platformon a játék
             *      • Original release date: a játék megjelenésének dátuma
             * Töltse be a fájlt, dolgozza fel, és tárolja a benne található adatokat tetszőleges módon (pl. tömbök,
             * listák). A Genre ID attribútumnál szereplő egész értékeket cserélje le a megfelelő értékre a játék
             * műfajától függően. (5 pont)*/

            // Még nem tanultunk az osztályokról/struktúrákról, ezért külön listákban tároljuk el az adatokat.
            List<string> titles = new List<string>();
            List<string> genres = new List<string>();
            List<string> publishers = new List<string>();
            List<DateTime> releaseDates = new List<DateTime>();
            List<DateTime> originalReleaseDates = new List<DateTime>();

            StreamReader sr = new StreamReader("../../../games_dataset.csv");
            sr.ReadLine();  // A fejlécet nem akarjuk feldolgozni
            while (!sr.EndOfStream)
            {
                string[] lineData = sr.ReadLine().Split(';');
                titles.Add(lineData[0]);
                genres.Add(genreNames[int.Parse(lineData[1]) - 1]);
                publishers.Add(lineData[3]);
                releaseDates.Add(DateTime.Parse(lineData[4]));
                originalReleaseDates.Add(DateTime.Parse(lineData[5]));
            }

            sr.Close();

            #endregion

            #region 3.feladat

            /*
             * Adott kiadóhoz tartozó játékok száma. Kérje el a felhasználótól egy kiadó (Publisher) nevét,
             * majd jelenítse meg a kiadó által piacra dobott játékok darabszámát. 
             */

            Console.Write("Adja meg egy kiadó nevét:\t");
            string targetPublisherName = Console.ReadLine();

            int counter = 0;
            foreach (string publisherName in publishers)
            {
                if (publisherName.ToLower() == targetPublisherName.ToLower())
                {
                    counter++;
                }
            }
            Console.WriteLine("Kiadó által piacra dobott játékok száma: " + counter + "\n");

            #endregion

            #region 4.feladat

            /* 
             * A megjelenés napjától elérhető játékok. Készítsen lekérdezést, amely kiírja a képernyőre azokat
             * a játékokat (cím, műfaj és a megjelenés éve), amelyek a megjelenés évében (kinyerhető a Original
             * release date-ből) elérhetőek voltak a platformon is (Release date).
             */

            for (int i = 0; i < titles.Count; i++)
            {
                if (releaseDates[i].Year == originalReleaseDates[i].Year)
                {
                    Console.WriteLine($"{titles[i]}\t{genres[i]}\t{releaseDates[i].ToString("yyyy-MM-dd")}");
                }
            }

            #endregion

            #region 5.feladat

            /*
             * Játékok száma műfajonként. Készítsen lekérdezést, amely megadja az egyes műfajokhoz tartozó
             * játékok darabszámát.
             */

            int[] countByGenre = new int[genreNames.Length];

            for (int i = 0; i < genres.Count; i++)
            {
                for (int j = 0; j < genreNames.Length; j++)
                {
                    if (genres[i] == genreNames[j])
                    {
                        countByGenre[j]++;
                        break;
                    }
                }
            }

            Console.WriteLine("\nMűfajokhoz tartozó játékok darabszáma:");
            for (int i = 0; i < countByGenre.Length; i++)
            {
                Console.WriteLine($"{genreNames[i]} :{countByGenre[i]}");
            }

            #endregion
        }
    }
}