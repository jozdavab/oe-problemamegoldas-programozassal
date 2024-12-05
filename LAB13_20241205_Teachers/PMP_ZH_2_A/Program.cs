namespace PMP_II_Starter
{
    public class Program
    {
        /*
         * Tesztelje az összes elkészített publikus tulajdonságot és metódust a Main-ben!
         */
        private static void Main(string[] args)
        {
            SeriesDatabase database = new SeriesDatabase("..\\..\\..\\gravity.csv");
            Console.WriteLine("Átlagos értékelés: " + database.AverageRating);

            Console.WriteLine("Legrosszabb epizód: " + database.WorstEpisode().Title);

            Console.WriteLine("Évad adatok:");
            string[] seasonData = database.SeasonData();
            foreach (string season in seasonData)
            {
                Console.WriteLine(season);
            }

            Console.Write("\nFájlnév: ");
            string fileName = Console.ReadLine();
            bool outcome = database.Save(fileName, database.SeasonData());
            Console.WriteLine($"\nMentés {(outcome ? "sikeres" : "sikertelen")}!");

            Console.WriteLine("Rendezők adatai");
            Director[] directors = database.DirectorDetails();
            foreach (Director director in directors)
            {
                Console.Write(director.Name + " : ");
                foreach (Episode episode in director.Episodes)
                {
                    Console.Write(episode.Title + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Sorozat hossza: " + database.GravityDays() + " nap");
        }
    }
}