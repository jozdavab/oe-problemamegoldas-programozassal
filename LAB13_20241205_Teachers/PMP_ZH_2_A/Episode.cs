namespace PMP_II_Starter
{
    /*
     * Elkészítettünk az ön számára egy Episode osztályt. Az osztály rendelkezik néhány jellemzővel
     * (Sorszám, évad, évadon belüli rész, cím, értékelés, premier, rendező). Továbbá elkészítettünk az ön
     * számára egy SeriesDatabase osztályt is. Ez az osztály 1 darab belső Episode tömböt tartalmaz, ide
     * kerülnek a gravity.csv fájlból az epizódok. A SeriesDatabase-ből egy példány van a Program osztályban.
     * Nincs szükség további adatbázisok példányosítására.
     */
    public class Episode
    {
        public int Ordinal { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime Premier { get; set; }
        public string Director { get; set; }
        /*
         * Készítsen az osztálynak egy olyan publikus tulajdonságot amely írható és olvasható, típusa
         * pedig EpisodeType!
         */
        public EpisodeType EpisodeType { get; set; }

        public Episode(string line)
        {

        }

        public Episode()
        {
            //ExamHelper osztályhoz. Ne töröld, ne módosítsd!
        }
    }
}